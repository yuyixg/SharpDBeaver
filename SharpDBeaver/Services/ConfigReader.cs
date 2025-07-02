using System.Security.Cryptography;
using System.Text;
using SharpDBeaver.Interfaces;

namespace SharpDBeaver.Services;

public class ConfigReader : IConfigReader
{
    public string ReadConfig(string filePath, string keyHex, string ivHex)
    {
        byte[] encryptedBytes = File.ReadAllBytes(filePath);
        byte[] key = StringToByteArray(keyHex);
        byte[] iv = StringToByteArray(ivHex);

        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using MemoryStream memoryStream = new(encryptedBytes);
        using CryptoStream cryptoStream = new(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using StreamReader streamReader = new(cryptoStream, Encoding.UTF8);
        
        return streamReader.ReadToEnd();
    }

    private static byte[] StringToByteArray(string hex)
    {
        int numberChars = hex.Length;
        byte[] bytes = new byte[numberChars / 2];
        
        for (int i = 0; i < numberChars; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        
        return bytes;
    }
} 

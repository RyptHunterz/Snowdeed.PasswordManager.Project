using System.Security.Cryptography;
using System.Text;

namespace Snowdeed.PasswordManager.Core.Commons.Securities;

public static class AESecurity
{
    public static string ToCrypt(this string plainText, string key)
    {
        byte[] byteKey = Encoding.UTF8.GetBytes(key);

        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");

        if (byteKey == null || byteKey.Length <= 0)
            throw new ArgumentNullException("Key");

        byte[] encrypted;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = byteKey;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(byteKey, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        return Convert.ToBase64String(encrypted);
    }

    public static string? ToDecrypt(this string cipherText, string key)
    {
        byte[] byteKey = Encoding.UTF8.GetBytes(key);

        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException(nameof(cipherText));

        if (byteKey == null || byteKey.Length <= 0)
            throw new ArgumentNullException(nameof(key));

        string? plaintext = null;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = byteKey;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }
}
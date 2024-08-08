using System.Security.Cryptography;
using System.Text;

namespace Snowdeed.PasswordManager.Application.Commons.Securities;

public static class AESecurity
{
    public static string ToCrypt(this string plainText, string key, string iv)
    {
        byte[] byteKey = Encoding.UTF8.GetBytes(key);
        byte[] byteIV = Encoding.UTF8.GetBytes(iv);

        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");

        if (byteKey == null || byteKey.Length <= 0)
            throw new ArgumentNullException("Key");

        if (byteIV == null || byteIV.Length <= 0)
            throw new ArgumentNullException(nameof(iv));

        byte[] encrypted;

        using (var aesAlg = Aes.Create())
        {        
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(byteKey, byteIV);

            using (MemoryStream msEncrypt = new())
            {
                using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        return Convert.ToBase64String(encrypted);
    }

    public static string? ToDecrypt(this string cipherText, string key, string iv)
    {
        byte[] byteKey = Encoding.UTF8.GetBytes(key);
        byte[] byteIV = Encoding.UTF8.GetBytes(iv);

        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException(nameof(cipherText));

        if (byteKey == null || byteKey.Length <= 0)
            throw new ArgumentNullException(nameof(key));

        if (byteIV == null || byteIV.Length <= 0)
            throw new ArgumentNullException(nameof(iv));

        string? plaintext = null;

        using (var aesAlg = Aes.Create())
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(byteKey, byteIV);

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
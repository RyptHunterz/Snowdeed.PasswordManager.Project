using System.Security.Cryptography;

namespace Snowdeed.PasswordManager.Tests;

public sealed class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100000;

    private readonly HashAlgorithmName algorithmName = HashAlgorithmName.SHA512;

    public (string hash, string salt) Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, algorithmName, HashSize);

        return (Convert.ToHexString(hash), Convert.ToHexString(salt));
    }

    public string Hash(string password, string salt)
    {
        byte[] saltByte = Convert.FromHexString(salt);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, saltByte, Iterations, algorithmName, HashSize);

        return Convert.ToHexString(hash);
    }
}

namespace MySales.Core.Contracts;

public interface IOauthCore
{
    string Encrypt(string clearText);
    string Decrypt(string cipherText);
}

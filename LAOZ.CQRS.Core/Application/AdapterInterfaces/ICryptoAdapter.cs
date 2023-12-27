namespace LAOZ.CQRS.Core.Application.AdapterInterfaces
{
    public interface ICryptoAdapter
    {
        string Encrypt(string plaintext);
        string Decrypt(string ciphertext);

        byte[] Encrypt(byte[] data);
        byte[] Decrypt(byte[] data);

        void EncryptFile(string inputFilePath, string outputFilePath);
        void DecryptFile(string inputFilePath, string outputFilePath);
    }

}

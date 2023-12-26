using LAOZ.CQRS.Core.Application.AdapterInterfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace LAOZ.CQRS.Infrastructure.Adapters
{
    public class BlobStorageAdapter : IFileAdapter
    {
        private readonly CloudBlobClient blobClient;

        public BlobStorageAdapter(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            CloudStorageAccount storageAccount;
            if (CloudStorageAccount.TryParse(connectionString, out storageAccount))
            {
                blobClient = storageAccount.CreateCloudBlobClient();
            }
            else
            {
                throw new ArgumentException("Invalid storage account connection string");
            }
        }

        public bool FileExists(string filePath)
        {
            throw new NotImplementedException();
        }

        public bool ReadFile(string filePath)
        {
            var blob = GetBlobReference(filePath);
            var stream = new MemoryStream();

            try
            {
                blob.DownloadToStreamAsync(stream);
                return stream.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateFile(string filePath)
        {
            var blob = GetBlobReference(filePath);
            var stream = new MemoryStream();

            try
            {
                blob.UploadFromStreamAsync(stream);
                return stream.Length == 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Not Implemented
        public bool DeleteFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public bool DirectoryExists(string directoryPath)
        {
            // Blob Storage doesn't have a concept of directories, 
            // so consider implementing some logic based on your naming conventions.
            throw new NotImplementedException();
        }

        public bool CreateDirectory(string directoryPath)
        {
            // Blob Storage doesn't have a concept of directories, 
            // so consider implementing some logic based on your naming conventions.
            throw new NotImplementedException();
        }

        public string[] ListFiles(string directoryPath)
        {
            // Blob Storage doesn't have a concept of directories,
            // so consider implementing some logic based on your naming conventions.
            throw new NotImplementedException();
        }

        public bool DeleteDirectory(string directoryPath)
        {
            // Blob Storage doesn't have a concept of directories,
            // so consider implementing some logic based on your naming conventions.
            throw new NotImplementedException();
        }
        #endregion

        private CloudBlockBlob GetBlobReference(string filePath)
        {
            var container = blobClient.GetContainerReference("your-container-name"); // Replace with your container name
            return container.GetBlockBlobReference(filePath);
        }

        public async Task<bool> DeleteFileAsync(string filePath)
        {
            var blob = GetBlobReference(filePath);
            return await blob.DeleteIfExistsAsync();
        }

        public async Task<bool> FileExistsAsync(string filePath)
        {
            var blob = GetBlobReference(filePath);
            return await blob.ExistsAsync();
        }
    }

}

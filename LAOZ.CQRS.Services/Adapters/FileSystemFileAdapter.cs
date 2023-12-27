using LAOZ.CQRS.Core.Application.AdapterInterfaces;

namespace LAOZ.CQRS.Infrastructure.Adapters
{
    public class FileSystemFileAdapter : IFileAdapter
    {
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public bool ReadFile(string filePath)
        {
            try
            {
                FileStream fileStream = File.OpenRead(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateFile(string filePath)
        {
            try
            {
                FileStream fileStream = File.Create(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        public bool CreateDirectory(string directoryPath)
        {
            try
            {
                Directory.CreateDirectory(directoryPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string[] ListFiles(string directoryPath)
        {
            return Directory.GetFiles(directoryPath);
        }

        public bool DeleteDirectory(string directoryPath)
        {
            try
            {
                Directory.Delete(directoryPath, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Not Implemented
        public Task<bool> DeleteFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FileExistsAsync(string filePath)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}

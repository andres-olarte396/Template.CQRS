using LAOZ.CQRS.Core.Application.AdapterInterfaces;
using Renci.SshNet;

namespace LAOZ.CQRS.Infrastructure.Adapters
{
    public class SftpFileAdapter : IFileAdapter
    {
        private readonly string host;
        private readonly string username;
        private readonly string password;

        public SftpFileAdapter(string host, string username, string password)
        {
            this.host = host;
            this.username = username;
            this.password = password;
        }

        public bool FileExists(string filePath)
        {
            using (var sftp = CreateSftpClient())
            {
                return sftp.Exists(filePath);
            }
        }

        public bool ReadFile(string filePath)
        {
            var sftp = CreateSftpClient();
            var stream = new MemoryStream();

            try
            {
                sftp.DownloadFile(filePath, stream);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sftp.Disconnect();
            }

        }

        public bool CreateFile(string filePath)
        {
            var sftp = CreateSftpClient();
            var stream = new MemoryStream();

            try
            {
                sftp.UploadFile(stream, filePath);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sftp.Disconnect();
            }
        }

        public bool DeleteFile(string filePath)
        {
            using (var sftp = CreateSftpClient())
            {
                try
                {
                    sftp.DeleteFile(filePath);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool DirectoryExists(string directoryPath)
        {
            using (var sftp = CreateSftpClient())
            {
                return sftp.Exists(directoryPath);
            }
        }

        public bool CreateDirectory(string directoryPath)
        {
            using (var sftp = CreateSftpClient())
            {
                try
                {
                    sftp.CreateDirectory(directoryPath);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string[] ListFiles(string directoryPath)
        {
            using (var sftp = CreateSftpClient())
            {
                var files = sftp.ListDirectory(directoryPath);
                return files.Where(f => !f.IsDirectory).Select(f => f.FullName).ToArray();
            }
        }

        public bool DeleteDirectory(string directoryPath)
        {
            using (var sftp = CreateSftpClient())
            {
                try
                {
                    sftp.DeleteDirectory(directoryPath);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private SftpClient CreateSftpClient()
        {
            var connectionInfo = new ConnectionInfo(host, username, new PasswordAuthenticationMethod(username, password));
            var sftp = new SftpClient(connectionInfo);
            sftp.Connect();
            return sftp;
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

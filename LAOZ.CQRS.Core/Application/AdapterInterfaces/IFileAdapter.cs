namespace LAOZ.CQRS.Core.Application.AdapterInterfaces
{
    public interface IFileAdapter
    {
        bool FileExists(string filePath);
        IStream ReadFile(string filePath);
        IStream CreateFile(string filePath);
        bool DeleteFile(string filePath);
        bool DirectoryExists(string directoryPath);
        bool CreateDirectory(string directoryPath);
        string[] ListFiles(string directoryPath);
        bool DeleteDirectory(string directoryPath);
    }
    public interface IStream
    {
        void Write(byte[] buffer, int offset, int count);
        int Read(byte[] buffer, int offset, int count);
        void Close();
    }
}

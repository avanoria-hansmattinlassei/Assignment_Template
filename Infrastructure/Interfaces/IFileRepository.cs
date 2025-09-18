namespace Infrastructure.Interfaces
{
    public interface IFileRepository
    {
        bool FileExists(string path);
        string GetFileContent(string path);
        bool SaveFileContent(string path, string content);
    }
}
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class FileRepository : IFileRepository
{
    public bool FileExists(string path)
    {
        if (File.Exists(path))
            return true;

        return false;
    }

    public string GetFileContent(string path)
    {
        return File.ReadAllText(path);
    }


    public bool SaveFileContent(string path, string content)
    {
        try
        {
            var directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllText(path, content);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

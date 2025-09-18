using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IFileService
{
    FileResult SaveContentToFile(string path, string content);
    FileResult GetContentFromFile(string path);
}

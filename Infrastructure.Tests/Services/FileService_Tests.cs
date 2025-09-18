using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Moq;

namespace Infrastructure.Tests.Services;

public class FileService_Tests
{
    private Mock<IFileRepository> _fileRepositoryMock;
    private IFileService _fileService;

    public FileService_Tests()
    {
        _fileRepositoryMock = new Mock<IFileRepository>();
        _fileService = new FileService(_fileRepositoryMock.Object);
    }

    [Fact]
    public void GetContentFromFile_ShouldReturnTrueAndStringContent_WhenFileExists()
    {
        _fileRepositoryMock.Setup(fr => fr.FileExists(It.IsAny<string>())).Returns(true);
        _fileRepositoryMock.Setup(fr => fr.GetFileContent(It.IsAny<string>())).Returns("this is content");


        var result = _fileService.GetContentFromFile("");

        Assert.True(result.Succeeded);
        Assert.Equal("this is content", result.Content);
    }

    [Fact]
    public void GetContentFromFile_ShouldReturnFalseAndErrorMessage_WhenFileNotExists()
    {
        _fileRepositoryMock.Setup(fr => fr.FileExists(It.IsAny<string>())).Returns(false);

        var result = _fileService.GetContentFromFile("");

        Assert.True(result.Succeeded);
        Assert.Equal("File Not Found", result.Error);
    }

    [Fact]
    public void SaveContentToFile_ShouldReturnTrue_WhenContentIsSaved()
    {
        _fileRepositoryMock.Setup(fr => fr.SaveFileContent(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        var result = _fileService.SaveContentToFile("", "");

        Assert.True(result.Succeeded);
    }

    [Fact]
    public void SaveContentToFile_ShouldReturnFalse_WhenContentUnableToSave()
    {
        _fileRepositoryMock.Setup(fr => fr.SaveFileContent(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(false);

        var result = _fileService.SaveContentToFile("", "");

        Assert.False(result.Succeeded);
    }

}

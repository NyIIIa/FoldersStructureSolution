using System.Text.Json;
using FoldersStructure_Client.Application.Common.Interfaces.Services;
using FoldersStructure_Client.Domain;
using FoldersStructure_Client.Domain.Entities;

namespace FoldersStructure_Client.Infrastructure.Services;

public class FolderStructureService : IFileOperation
{
    private readonly string _uploadedFilesCatalog;
    
    public FolderStructureService(IWebHostEnvironment webHostEnvironment)
    {
        _uploadedFilesCatalog = @$"{webHostEnvironment.WebRootPath}\UploadedFiles\";
    }
    
    public async Task ImportFileAsync(FileModel fileModel)
    {
        if (fileModel.File.Length > 0)
        {
            string fileName = $"{Path.GetFileName(fileModel.FileName)}.txt";
            
            string filePath = Path.Combine(_uploadedFilesCatalog, fileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await fileModel.File.CopyToAsync(stream);
            }
        }
        else
        {
            throw new Exception("File lenght is empty");   
        }
    }

    public FileInfo[] GetUploadedFiles()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(_uploadedFilesCatalog);
        return directoryInfo.GetFiles("*.txt");
    }

    public async Task<string> ConvertStructureToFileAsync(IEnumerable<Folder> folders, string source)
    {
        var jsonFolders = JsonSerializer.Serialize<IEnumerable<Folder>>(folders);
        
        string filePath = Path.Combine(_uploadedFilesCatalog, source);

        await using var fileStream = File.Create(filePath);
        await using var sw = new StreamWriter(fileStream);
        await sw.WriteLineAsync(jsonFolders);
        
        
        return filePath;
    }


    public async Task<IEnumerable<Folder>> GetFileContentAsync(string fileName)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(_uploadedFilesCatalog);
        var files = directoryInfo.GetFiles(fileName);
        var searchedFile = files[0];
        if (searchedFile != null)
        {
            using (var fileStream = searchedFile.OpenRead())
            {
                var exportedFolders = await JsonSerializer
                    .DeserializeAsync<IEnumerable<Folder>>(fileStream);
                
                return exportedFolders ?? throw new Exception("There isn't any content in specified file");
            }
        }

        throw new Exception("File with the specified name doesn't exist in the -UploadedFiles directory-");
    }

    public void DeleteUploadedFile(string fileName)
    {
        File.Delete($"{_uploadedFilesCatalog}{fileName}");
    }
}
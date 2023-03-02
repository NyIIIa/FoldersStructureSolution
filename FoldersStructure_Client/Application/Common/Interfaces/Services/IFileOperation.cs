using FoldersStructure_Client.Domain;
using FoldersStructure_Client.Domain.Entities;

namespace FoldersStructure_Client.Application.Common.Interfaces.Services;

public interface IFileOperation
{
    Task ImportFileAsync(FileModel fileModel);
    FileInfo[] GetUploadedFiles();
    /// <summary>
    /// Convert structure into JSON and write to a file.
    /// </summary>
    /// <param name="folders">The uploaded structure from database</param>
    /// <param name="source">The source = file name, where stores a structure of folders</param>
    /// <returns>File path</returns>
    Task<string> ConvertStructureToFileAsync(IEnumerable<Folder> folders, string source);
    Task<IEnumerable<Folder>> GetFileContentAsync(string fileName);
    void DeleteUploadedFile(string fileName);
}
using FoldersStructure_Client.Domain;

namespace FoldersStructure_Client.Application.Common.Interfaces.Persistence;

public interface IFolderRepository
{
    Task<FolderNode> GetFolderRootAsync(string source = "BaseScheme");
    Task<FolderNode> GetFolderByNameAsync(string folderName, string source = "BaseScheme");
}
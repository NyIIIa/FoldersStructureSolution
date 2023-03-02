using FoldersStructure_Client.Domain.Entities;

namespace FoldersStructure_Client.Application.Common.Interfaces.Persistence;

public interface ICustomFolderRepository : IFolderRepository
{
    /// <summary>
    /// Upload exported folders from a file to database
    /// </summary>
    /// <param name="folders">Exported folders from a file</param>
    /// <param name="source">The source = file name, where stores a structure of folders</param>
    /// <returns></returns>
    Task UploadFoldersAsync(IEnumerable<Folder> folders, string source);

    IEnumerable<string> GetAllUploadedStructures();
    /// <summary>
    /// Get and remove uploaded structure from database.
    /// </summary>
    /// <param name="source">The source = file name, where stores a structure of folders</param>
    /// <returns></returns>
    Task<IEnumerable<Folder>> GetUploadedStructureBySourceAsync(string source);
}
using FoldersStructure_Client.Application.Common.Interfaces.Persistence;
using FoldersStructure_Client.Data;
using FoldersStructure_Client.Domain;
using Microsoft.EntityFrameworkCore;

namespace FoldersStructure_Client.Infrastructure.Persistence;

public class BaseFolderRepository : IBaseFolderRepository
{
    private readonly FoldersStructureDbContext _foldStructDbContext;

    public BaseFolderRepository(FoldersStructureDbContext foldStructDbContext)
    {
        _foldStructDbContext = foldStructDbContext;
    }
    
    
    public async Task<FolderNode> GetFolderRootAsync(string source = "BaseScheme")
    {
        var folderRoot = await _foldStructDbContext.Folders.
            FirstOrDefaultAsync(f => string.IsNullOrEmpty(f.ParentFolderName));
        
        if (folderRoot != null)
        {
            var subfolders = await _foldStructDbContext.Folders
                .Where(f => f.ParentFolderName == folderRoot.Name & f.Source == source)
                .Select(f => new SubfolderNode()
                {
                    Name = f.Name ?? "No-name subfolder name"
                }).ToListAsync();

            return new FolderNode()
            {
                Name = folderRoot.Name ?? "No-name folder name",
                Subfolders = subfolders
            };
        }

        throw new Exception("Folder root doesn't exist");
    }

    public async Task<FolderNode> GetFolderByNameAsync(string folderName, string source = "BaseScheme")
    {
        var subfolders = await _foldStructDbContext.Folders
            .Where(f => f.ParentFolderName == folderName & f.Source == source)
            .Select(f => new SubfolderNode()
            {
                Name = f.Name ?? "No-name subfolder name"
            }).ToListAsync();

        return new FolderNode()
        {
            Name = folderName,
            Subfolders = subfolders
        };
    }
}
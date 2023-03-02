using FoldersStructure_Client.Application.Common.Interfaces.Persistence;
using FoldersStructure_Client.Data;
using FoldersStructure_Client.Domain;
using FoldersStructure_Client.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoldersStructure_Client.Infrastructure.Persistence;

public class CustomFolderRepository : ICustomFolderRepository
{
    private readonly FoldersStructureDbContext _foldersStructureDbContext;

    public CustomFolderRepository(FoldersStructureDbContext foldersStructureDbContext)
    {
        _foldersStructureDbContext = foldersStructureDbContext;
    }

    public async Task<FolderNode> GetFolderRootAsync(string source = "BaseScheme")
    {
        var folderRoot = await _foldersStructureDbContext.Folders
            .FirstOrDefaultAsync(f => f.Source == source & string.IsNullOrEmpty(f.ParentFolderName));

        if (folderRoot != null)
        {
            var subfolders = await _foldersStructureDbContext.Folders
                .Where(f => f.ParentFolderName == folderRoot.Name
                            & f.Source == folderRoot.Source)
                .Select(f => new SubfolderNode()
                {
                    Name = f.Name ?? "No-name subfolder name",
                    Source = f.Source
                }).ToListAsync();

            return new FolderNode()
            {
                Name = folderRoot.Name,
                Subfolders = subfolders
            };
        }

        throw new Exception("The specified source or a source's folder root doesn't exist!");
    }

    public async Task<FolderNode> GetFolderByNameAsync(string folderName, string source = "BaseScheme")
    {
        var subfolders = await _foldersStructureDbContext.Folders
            .Where(f => folderName == f.ParentFolderName & f.Source == source)
            .Select(f => new SubfolderNode()
            {
                Name = f.Name,
                Source = source
            }).ToListAsync();

        return new FolderNode()
        {
            Name = folderName,
            Subfolders = subfolders
        };
    }

    public async Task UploadFoldersAsync(IEnumerable<Folder> folders, string source)
    {
        //check if folder root with specified source already exist
        var isRootSourceExist = await _foldersStructureDbContext.Folders
            .AnyAsync(f => f.Source == source & string.IsNullOrEmpty(f.ParentFolderName));

        if (!isRootSourceExist)
        {
            var foldersWithSource = folders.Select(f => new Folder()
            {
                Name = f.Name,
                ParentFolderName = f.ParentFolderName,
                Source = source
            });   
            
            await _foldersStructureDbContext.AddRangeAsync(foldersWithSource);
            await _foldersStructureDbContext.SaveChangesAsync();
        }
        else
        {
            throw new Exception("The folder root with such source already exist!");
        }
    }

    public IEnumerable<string> GetAllUploadedStructures()
    {
        return _foldersStructureDbContext.Folders
            .Where(f => f.Source != "BaseScheme" & f.ParentFolderName == String.Empty)
            .Select(f => f.Source)
            .AsEnumerable();
    }

    public async Task<IEnumerable<Folder>> GetUploadedStructureBySourceAsync(string source)
    {
        var uploadedStructure = await _foldersStructureDbContext.Folders
            .Where(f => f.Source == source)
            .ToListAsync();
        
        _foldersStructureDbContext.Folders.RemoveRange(uploadedStructure);
        await _foldersStructureDbContext.SaveChangesAsync();
        
        return uploadedStructure ?? throw new Exception($"The structure with source -{source}- doesn't exist ");
    }
}
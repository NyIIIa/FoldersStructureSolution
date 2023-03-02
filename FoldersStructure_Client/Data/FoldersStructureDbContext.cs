using FoldersStructure_Client.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoldersStructure_Client.Data;

public class FoldersStructureDbContext : DbContext
{
    public DbSet<Folder>? Folders { get; set; }

    public FoldersStructureDbContext(DbContextOptions<FoldersStructureDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        var folderRoot = new Folder()
        {
            Id = 1,
            Name = "Creating Digital Images",
            ParentFolderName = String.Empty,
            Source = "BaseScheme"
        };

        #region Folders of "Creating Digital Images"

        var resources = new Folder()
        {
            Id = 2,
            Name = "Resources",
            ParentFolderName = "Creating Digital Images",
            Source = "BaseScheme"
        };
        
        var evidence = new Folder()
        {
            Id = 3,
            Name = "Evidence",
            ParentFolderName = "Creating Digital Images",
            Source = "BaseScheme"
        };
        
        var graphicProducts = new Folder()
        {
            Id = 4,
            Name = "Graphic Products",
            ParentFolderName = "Creating Digital Images",
            Source = "BaseScheme"
        };

        #endregion

        #region Folders of "Resources"

        var primarySources = new Folder()
        {
            Id = 5,
            Name = "Primary Sources",
            ParentFolderName = "Resources",
            Source = "BaseScheme"
        };
        
        var secondarySources = new Folder()
        {
            Id = 6,
            Name = "Secondary Sources",
            ParentFolderName = "Resources",
            Source = "BaseScheme"
        };

        #endregion

        #region Folders of "Graphic Products"

        var process = new Folder()
        {
            Id = 7,
            Name = "Process",
            ParentFolderName = "Graphic Products",
            Source = "BaseScheme"
        };
        
        var finalProduct = new Folder()
        {
            Id = 8,
            Name = "Final Product",
            ParentFolderName = "Graphic Products",
            Source = "BaseScheme"
        };

        #endregion

        modelBuilder.Entity<Folder>().HasData(new List<Folder>()
        {
            folderRoot,
            resources,
            evidence,
            graphicProducts,
            primarySources,
            secondarySources,
            process,
            finalProduct
        });
        
    }
}
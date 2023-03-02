using FoldersStructure_Client.Application.Common.Interfaces.Persistence;
using FoldersStructure_Client.Application.Common.Interfaces.Services;
using FoldersStructure_Client.Data;
using FoldersStructure_Client.Infrastructure.Persistence;
using FoldersStructure_Client.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace FoldersStructure_Client.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, 
                                        ConfigurationManager configurationManager)
    {
        //Add DbContext
        serviceCollection.AddDbContext<FoldersStructureDbContext>(options =>
        {
            options.UseSqlite(configurationManager.GetConnectionString("DefaultConnection"));
        });
        
        //Add services
        serviceCollection.AddScoped<IBaseFolderRepository, BaseFolderRepository>();
        serviceCollection.AddScoped<ICustomFolderRepository, CustomFolderRepository>();
        serviceCollection.AddScoped<IFileOperation, FolderStructureService>();
    }
}
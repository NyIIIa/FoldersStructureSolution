using System.Net;
using FoldersStructure_Client.Application.Common.Interfaces.Persistence;
using FoldersStructure_Client.Application.Common.Interfaces.Services;
using FoldersStructure_Client.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FoldersStructure_Client.Controllers;

public class HomeController : Controller
{
    private readonly IFileOperation _fileOperation;
    private readonly ICustomFolderRepository _customFolderRepository;

    public HomeController(IFileOperation fileOperation, ICustomFolderRepository customFolderRepository)
    {
        _fileOperation = fileOperation;
        _customFolderRepository = customFolderRepository;
    }

    public IActionResult Index()
    {
        try
        {
            var uploadedStructures = _customFolderRepository.GetAllUploadedStructures();
            var uploadedFiles = _fileOperation.GetUploadedFiles();

            var homeModel = new HomeModel()
            {
                UploadedStructures = uploadedStructures,
                UploadedFiles = uploadedFiles
            };
            return View(homeModel);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("Import-File")]
    public async Task<IActionResult> ImportFileAsync(FileModel fileModel)
    {
        try
        {
            await _fileOperation.ImportFileAsync(fileModel);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("ImportFileToDatabase")]
    public async Task<IActionResult> ImportFileToDatabaseAsync(string fileName)
    {
        try
        {
            var exportedFoldersFromFile = await _fileOperation.GetFileContentAsync(fileName);

            await _customFolderRepository.UploadFoldersAsync(exportedFoldersFromFile, fileName);

            _fileOperation.DeleteUploadedFile(fileName);

            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    public async Task<IActionResult> DownloadStructureAsync(string source)
    {
        
        var uploadedStructureFromDb = await _customFolderRepository.GetUploadedStructureBySourceAsync(source);
        
        var filePath = await _fileOperation.ConvertStructureToFileAsync(uploadedStructureFromDb, source);
        return File(System.IO.File.OpenRead(filePath), "application/txt", source);
    }
}
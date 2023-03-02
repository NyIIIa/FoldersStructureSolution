using FoldersStructure_Client.Application.Common.Interfaces.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FoldersStructure_Client.Controllers;

public class BaseStructureController : Controller
{
    private readonly IBaseFolderRepository _baseFolderRepository;

    public BaseStructureController(IBaseFolderRepository baseFolderRepository)
    {
        _baseFolderRepository = baseFolderRepository;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var folderRoot = await _baseFolderRepository.GetFolderRootAsync();
            return View(folderRoot);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    public async Task<IActionResult> FindFolderNode(string folderName)
    {
        try
        {
            var folderNode = await _baseFolderRepository.GetFolderByNameAsync(folderName);

            return View(folderNode);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
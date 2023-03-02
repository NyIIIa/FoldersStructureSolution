using FoldersStructure_Client.Application.Common.Interfaces.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FoldersStructure_Client.Controllers;

public class CustomStructureController : Controller
{
    private readonly ICustomFolderRepository _customFolderRepository;

    public CustomStructureController(ICustomFolderRepository customFolderRepository)
    {
        _customFolderRepository = customFolderRepository;
    }

    public async Task<IActionResult> Index(string source)
    {
        try
        {
            var folderRoot = await _customFolderRepository.GetFolderRootAsync(source);

            return View(folderRoot);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    public async Task<IActionResult> FindFolderNode(string folderName, string source)
    {
        try
        {
            var folderNode = await _customFolderRepository.GetFolderByNameAsync(folderName, source);

            return View(folderNode);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
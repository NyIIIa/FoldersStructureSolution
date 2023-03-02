namespace FoldersStructure_Client.Domain.Entities;

public class Folder
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ParentFolderName { get; set; }
    public string? Source { get; set; }
}
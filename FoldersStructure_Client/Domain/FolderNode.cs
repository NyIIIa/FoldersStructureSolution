namespace FoldersStructure_Client.Domain;

public class FolderNode
{
    public string Name { get; set; } = String.Empty; // Root
    public IEnumerable<SubfolderNode> Subfolders { get; set; } = new List<SubfolderNode>();
}
namespace FoldersStructure_Client.Domain;

public class HomeModel
{
    public IEnumerable<string>? UploadedStructures { get; set; }
    public FileInfo[]? UploadedFiles { get; set; }
}
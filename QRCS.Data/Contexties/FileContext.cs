using QRCS.Core.FileContexties;
using QRCS.Core.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace QRCS.Data.Contexties;

public class FileContext : IFileContext<Scan>
{
    public IList<Scan> Entities { get; private set; }

    private readonly IFileConfig _fileConfig;

    public FileContext(IFileConfig fileConfig)
    {
        _fileConfig = fileConfig;
        Entities = Load() ?? new List<Scan>();
    }

    public Task SaveAsync()
    {
        var data = JsonSerializer.Serialize(Entities);
        return File.WriteAllTextAsync(_fileConfig.Filepath, data);
    }

    IList<Scan>? Load()
    {
        if (!File.Exists(_fileConfig.Filepath))
            return null;

        var data = File.ReadAllText(_fileConfig.Filepath);
        return JsonSerializer.Deserialize<List<Scan>>(data);
    }
}



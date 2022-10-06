using QRCS.Core.FileContexties;

namespace QRCS.Data.Contexties;

public class FileConfig : IFileConfig
{
    public string Filepath { get; }

	public FileConfig(string path)
	{
		Filepath = Path.Combine(path, "history");
	}
}



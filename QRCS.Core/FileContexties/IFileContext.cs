namespace QRCS.Core.FileContexties;
public interface IFileContext<T>
{
    IList<T> Entities { get; }
    Task SaveAsync();
}

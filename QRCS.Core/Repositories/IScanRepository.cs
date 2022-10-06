using QRCS.Core.Models;

namespace QRCS.Core.Repositories;
public interface IScanRepository
{
    IEnumerable<Scan> GetAll();
    void Create(Scan scan);
    void Delete(Scan scan);
    Task SaveChangesAsync();
}

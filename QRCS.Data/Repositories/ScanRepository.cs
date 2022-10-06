using QRCS.Core.FileContexties;
using QRCS.Core.Models;
using QRCS.Core.Repositories;

namespace QRCS.Data.Repositories;

public class ScanRepository : IScanRepository
{

    private readonly IFileContext<Scan> _context;

    public ScanRepository(IFileContext<Scan> context)
    {
        _context = context;
    }

    public void Create(Scan scan)
    {
        _context.Entities.Add(scan);
    }

    public void Delete(Scan scan)
    {
        _context.Entities.Remove(scan);
    }

    public IEnumerable<Scan> GetAll()
    {
        return _context.Entities;
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveAsync();
    }
}



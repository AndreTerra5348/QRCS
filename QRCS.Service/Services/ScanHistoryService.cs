using QRCS.Core.Models;
using QRCS.Core.Repositories;
using QRCS.Core.Services;

namespace QRCS.Service.Services;
public class ScanHistoryService : IScanHistoryService
{
    private readonly IScanRepository _repository;

    public ScanHistoryService(IScanRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(Scan scan)
    {
        _repository.Create(scan);
        await _repository.SaveChangesAsync();
    }

    public IEnumerable<Scan> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task RemoveAsync(Scan scan)
    {
        _repository.Delete(scan);
        await _repository.SaveChangesAsync();
    }
}

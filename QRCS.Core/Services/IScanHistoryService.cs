using QRCS.Core.Models;

namespace QRCS.Core.Services;

public interface IScanHistoryService
{
    Task AddAsync(Scan scan);
    Task RemoveAsync(Scan scan);
    IEnumerable<Scan> GetAll();

}



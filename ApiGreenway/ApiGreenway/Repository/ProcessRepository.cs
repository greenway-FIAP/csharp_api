using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class ProcessRepository : IProcessRepository
{
    public Task<Process> AddProcess(Process process)
    {
        throw new NotImplementedException();
    }

    public void DeleteProcess(int ProcessId)
    {
        throw new NotImplementedException();
    }

    public Task<Process> GetProcessById(int ProcessId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Process>> GetProcesses()
    {
        throw new NotImplementedException();
    }

    public Task<Process> UpdateProcess(Process process)
    {
        throw new NotImplementedException();
    }
}

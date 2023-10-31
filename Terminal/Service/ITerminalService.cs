using Terminal.Models;

namespace Terminal.Service
{
    public interface ITerminalService
    {
        Task AddProcedure(TerminalProceduresVM proceduresVM);
        List<TerminalProcedures> GetAllProcedure();
    }
}

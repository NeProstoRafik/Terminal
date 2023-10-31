using Microsoft.EntityFrameworkCore;
using Terminal.DAL;
using Terminal.Models;

namespace Terminal.Service
{

    public class TerminalService : ITerminalService
    {
        private readonly AppDbContext _context;
        public TerminalService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddProcedure(TerminalProceduresVM proceduresVM)
        {
            var procedure = new TerminalProcedures
            {
                NameTerminal = proceduresVM.IdTerminal,
                DateCreated = DateTime.Now,
                Command = proceduresVM.Command,
                Parameter1 = proceduresVM.parameter_default_value1 == null ? 0 : int.Parse(proceduresVM.parameter_default_value1),
                Parameter2 = proceduresVM.parameter_default_value2 == null ? 0 : int.Parse(proceduresVM.parameter_default_value2),
                Parameter3 = proceduresVM.parameter_default_value3 == null ? 0 : int.Parse(proceduresVM.parameter_default_value3),
                Status = WC.StatusInProgress
            };

            await _context.TerminalProcedures.AddAsync(procedure);
            await _context.SaveChangesAsync();
        }
        public List<TerminalProcedures> GetAllProcedure()
        {
            return _context.TerminalProcedures.AsNoTracking().OrderByDescending(p => p.DateCreated).Take(5).ToList();
        }
    }
}

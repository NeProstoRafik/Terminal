using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Terminal.Handlers;
using Terminal.Models;
using Terminal.Service;

namespace Terminal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GetRequestAllCommandHandler _getAllCommand;
        private readonly ITerminalService _terminalService;
        private readonly RequestForTerminalHandler _requestForTerminal;
        public HomeController(ILogger<HomeController> logger, GetRequestAllCommandHandler getAllCommand, ITerminalService terminalService, RequestForTerminalHandler requestForTerminal)
        {
            _logger = logger;
            _getAllCommand = getAllCommand;
            _terminalService = terminalService;
            _requestForTerminal = requestForTerminal;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Values = await _getAllCommand.GetAllCommandsAsync();
            var listProceduresVM = new List<TerminalProcedures>();
            listProceduresVM = _terminalService.GetAllProcedure();

            return View(listProceduresVM);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string selectedValue, TerminalProceduresVM proceduresVM)
        {
            var listProceduresVM = new List<TerminalProcedures>();

            if ((selectedValue == null && proceduresVM.IdTerminal == 0) || (proceduresVM.Command == null && proceduresVM.IdTerminal != 0))
            {
                return RedirectToAction("Index");
            }
            if (proceduresVM.IdTerminal != 0)
            {
                await _terminalService.AddProcedure(proceduresVM);

                listProceduresVM = _terminalService.GetAllProcedure();
                await _requestForTerminal.PostCommand(proceduresVM.IdTerminal, proceduresVM.Id);
                return RedirectToAction("Index", listProceduresVM);
            }
            var listCommand = await _getAllCommand.GetAllCommandsAsync();
            var command = listCommand.FirstOrDefault(x => x.name.Contains(selectedValue));

            ViewBag.Values = command;
            var commandVM = new AllCommandVM
            {
                Id = int.Parse(command.Id),
                parameter_default_value1 = command.parameter_default_value1 == null ? 0 : int.Parse(command.parameter_default_value1),
                parameter_default_value2 = command.parameter_default_value2 == null ? 0 : int.Parse(command.parameter_default_value2),
                parameter_default_value3 = command.parameter_default_value3 == null ? 0 : int.Parse(command.parameter_default_value3),
                name = command.name,
                parameter_name1 = command.parameter_name1,
                parameter_name2 = command.parameter_name2,
                parameter_name3 = command.parameter_name3,

            };
            return PartialView("_Index", commandVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
namespace Terminal.Models
{
    public class TerminalProceduresVM
    {
        public int IdTerminal { get; set; }
        public int Id { get; set; }
        public string Command { get; set; }    
        public string? parameter_name1 { get; set; }
        public string? parameter_name2 { get; set; }
        public string? parameter_name3 { get; set; }
        public string? parameter_default_value1 { get; set; }
        public string? parameter_default_value2 { get; set; }
        public string? parameter_default_value3 { get; set; }

    }
}

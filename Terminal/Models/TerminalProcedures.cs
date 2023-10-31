namespace Terminal.Models
{
    public class TerminalProcedures
    {
        public int Id { get; set; }
        public int NameTerminal { get; set; }
        public DateTime DateCreated{ get; set; }
        public string Command { get; set; }
        public int Parameter1 { get; set; }
        public int Parameter2 { get; set; }
        public int Parameter3 { get; set; }
        public string Status { get; set; }
    }
}

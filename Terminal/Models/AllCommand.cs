namespace Terminal.Models
{
    public class AllCommand
    {      
        public string Id { get; set; }
        public string name { get; set; }
        public string? parameter_name1 { get; set; }
        public string? parameter_name2 { get; set; }
        public string? parameter_name3 { get; set; }
        public string? parameter_default_value1 { get; set; }
        public string? parameter_default_value2 { get; set; }
        public string? parameter_default_value3 { get; set; }

    }
    public class Root
    {   
        public List<AllCommand> items { get; set; }
   
    }
}

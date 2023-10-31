namespace Terminal.Models
{
    public class AllCommandVM
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string? parameter_name1 { get; set; }
        public string? parameter_name2 { get; set; }
        public string? parameter_name3 { get; set; }
        public int parameter_default_value1 { get; set; }
        public int parameter_default_value2 { get; set; }
        public int parameter_default_value3 { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{
    public class Audit
    {
        [Key]
        public int id { get; set; }
        public DateTime date { get; set; }
        public string? table_name { get; set; }
        public string? message { get; set; }
        public string? operation { get; set; }
        public string user_log { get; set; }

    }
}

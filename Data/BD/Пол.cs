using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{
    public class Пол
    {
        [Key]
        public int ID_пола { get; set; }
        [MaxLength(7)]
        public string пол { get; set; }

        public List<Личные_данные> Личные_Данные { get; set; }
    }
}

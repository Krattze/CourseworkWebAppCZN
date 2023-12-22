using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{
    public class Организации
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_организации { get; set; }

        [Required]
        [MaxLength(40)]
        public string Наименование { get; set; }

        [Required]
        [MaxLength(200)]
        public string Адрес { get; set; }

        [Required]
        [MaxLength(11)]
        public string Телефон { get; set; }


        public List<Вакансии>? Вакансии { get; set; }
    }
}

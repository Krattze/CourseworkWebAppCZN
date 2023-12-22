using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{
    public class Образование
    {
        [Key]
        public int Id_образования { get; set; }

        [StringLength(26)]
        public string? Образования { get; set; }

        // Navigation property for relationships
        public ICollection<Сведения_об_образовании>? Сведения_об_образовании { get; set; }

        public ICollection<Вакансии>? Вакансии { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppCZN.Data.BD;

public class График_работы
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID_формы_занятости { get; set; }

    [StringLength(20)]
    public string? Форма_занятости { get; set; }

    // Navigation property for relationships
    public List<Резюме>? Резюме { get; set; }

    public List<Вакансии>? Вакансии { get; set; }
}
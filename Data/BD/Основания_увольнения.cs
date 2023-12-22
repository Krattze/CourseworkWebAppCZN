using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Основания_увольнения
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID_основания_увольнения { get; set; }

    [StringLength(150)]
    public string Основание { get; set; }

    // Navigation property for relationships
    public List<Сведения_о_последнем_месте_работы> Сведения_о_последнем_месте_работы { get; set; }
}

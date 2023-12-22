using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Опыт_работы
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID_опыта_работы { get; set; }

    [Required]
    [StringLength(40)]
    public string Организация { get; set; }

    [Required]
    [StringLength(30)]
    public string Должность { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Дата_начала_работы { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Дата_окончания { get; set; }

    [Required]
    [StringLength(200)]
    public string Обязанности { get; set; }

	[ForeignKey("ID_резюме")]
	public Резюме? Резюме { get; set; }
	public int ID_резюме { get; set; }

    public bool? Флаг_удаления { get; set; }

    // Navigation property for relationships
    
 
}

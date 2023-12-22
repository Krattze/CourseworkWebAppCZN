using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppCZN.Data.BD;

public class Сведения_о_последнем_месте_работы
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID_сведения { get; set; }

    [Required]
    [StringLength(10)]
    public string Номер_приказа_об_увольнении { get; set; }

    [Required]
    [StringLength(40)]
    public string Наименование_организации { get; set; }

    [Required]
    public DateTime Дата_начала_работы { get; set; }

    public DateTime? Дата_увольнения { get; set; }

	[ForeignKey("ID_основания_увольнения")]
	public Основания_увольнения? Основание_увольнения { get; set; }

	public int ID_основания_увольнения { get; set; }

	[ForeignKey("ID_заявления")]
	public Заявление? Заявление { get; set; }
	public int? ID_заявления { get; set; }
}


    // Navigation properties for relationships
   
  
   
   

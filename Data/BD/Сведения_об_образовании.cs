using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{
    public class Сведения_об_образовании
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_сведения_об_образовании { get; set; }

        [Required]
        [StringLength(100)]
        public string? Учебное_заведение { get; set; }

        [Required]
        public int Год_окончания { get; set; }

        [StringLength(50)]
        public string? Специальность { get; set; }

        [Required]
        public int? Серия_диплома { get; set; }

        [Required]
        public int? Номер_диплома { get; set; }

        [Required]
		[DataType(DataType.Date)]
		public DateTime Дата_выдачи_диплома { get; set; }

		[ForeignKey("ID_резюме")]
		public Резюме? Резюме { get; set; }
		public int? ID_резюме { get; set; }

		[ForeignKey("ID_образования")]
		public Образование? Образование { get; set; }
		public int ID_образования { get; set; }

        // Navigation property for relationships
       

    }
}

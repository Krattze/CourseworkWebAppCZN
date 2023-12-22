using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{
    public class Посещения
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_посещения { get; set; }

        [Required]
		[Column(TypeName = "date")]
		public DateTime Дата_записи { get; set; }

		[Column(TypeName = "time(0)")]
		public TimeSpan? Время_записи { get; set; }

		[Column(TypeName = "date")]
		public DateTime? Дата_явки { get; set; }

		[ForeignKey("ID_личных_данных")]
		public Личные_данные? Личные_данные { get; set; }
		public int ID_личных_данных { get; set; }

        [MaxLength(30)]
        public string? Результат_посещения { get; set; }

  



    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{
    public class Заявление
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_заявления { get; set; }

        [Required]
        public DateTime Дата_подачи { get; set; }

        public bool? Признание_безработным { get; set; }

        public bool? Результат_подачи { get; set; }

        [StringLength(300)]
        public string? Комментарий { get; set; }

		[ForeignKey("ID_личных_данных")]
		public Личные_данные? Личные_данные { get; set; }
		public int? ID_личных_данных { get; set; }


        public List<Сведения_о_последнем_месте_работы> Сведения_о_последнем_месте_работы;

        public List<Личные_дела> Личные_дела;
    }
}

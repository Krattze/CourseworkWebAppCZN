using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{
    public class Личные_дела
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_личного_дела { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Дата_постановки_на_учет { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Дата_регистрации_безработного { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Дата_снятия_с_учета { get; set; }

		[ForeignKey("ID_заявления")]
		public Заявление? Заявление { get; set; }
		public int ID_заявления { get; set; }

		[ForeignKey("ID_личных_данных")]
		public Личные_данные? Личные_данные { get; set; }
		public int? ID_личных_данных { get; set; }

  
        public List<Предложенные_вакансии>? Предложенные_вакансии { get; set; }
    }
}

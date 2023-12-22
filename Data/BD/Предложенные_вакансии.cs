using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebAppCZN.Data.BD
{

	public class Предложенные_вакансии
    {
        [Key]
		public int ID_предложения { get; set; }

		[ForeignKey("ID_вакансии")]
		public Вакансии? Вакансии { get; set; }
		public int ID_вакансии { get; set; }

		[ForeignKey("ID_личного_дела")]
		public Личные_дела? Личные_дела { get; set; }

        public int ID_личного_дела { get; set; }

        [Required]
        public DateTime Дата_предложения { get; set; }

        [Required]
        [MaxLength(30)]
        public string? Результат_предложения { get; set; }

        public DateTime? Дата_выдачи_направления { get; set; }

        [MaxLength(30)]
        public string? Результат_собеседования { get; set; }

		[ForeignKey("ID_резюме")]
		public Резюме? Резюме { get; set; }
		public int ID_резюме { get; set; }

      

    }
}

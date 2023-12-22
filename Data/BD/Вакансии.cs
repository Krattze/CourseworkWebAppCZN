using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{
    public class Вакансии
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_вакансии { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [MaxLength(40)]
        public string Профессия { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int Зарплата { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [MaxLength(30)]
        public string Адрес_трудоустройства { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [MaxLength(200)]
        public string Должностные_обязанности { get; set; }

        [ForeignKey("ID_образования")]
        public Образование? Образование { get; set; }
        public int ID_образования { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int Стаж { get; set; }

		[ForeignKey("ID_формы_занятости")]
		public График_работы? График_Работы { get; set; }
		public int ID_формы_занятости { get; set; }

		[ForeignKey("ID_тип_занятости")]
		public Тип_занятости? Тип_Занятости { get; set; }
		public int ID_тип_занятости { get; set; }

		[ForeignKey("ID_организации")]
		public Организации? Организации { get; set; }
		public int ID_организации { get; set; }

        public bool? Флаг_удаления { get; set; }
      
        public List<Предложенные_вакансии>? Предложенные_вакансии { get; set; }
    }
}

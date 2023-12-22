using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{
   
        public class Личные_данные
        {
            [Key]
            public int ID_личных_данных { get; set; }

        [Required (ErrorMessage = "Поле обязательно для заполнения")]
            public string? Фамилия { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string? Имя { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string? Отчество { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Date)]
            public DateTime? Дата_рождения { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int? Серия_паспорта { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int? Номер_паспорта { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Date)]
            public DateTime? Дата_выдачи_паспорта { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string? Кем_выдан_паспорт { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string? Адрес_регистрации { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string? Телефон { get; set; }

            [ForeignKey("ID_пола")]
            public Пол? Пол { get; set; }
            public int? ID_пола { get; set; }

            [ForeignKey("ID_пользователя")]
            public string? ID_пользователя { get; set; }

            public List<Посещения>? Посещения { get; set; }

            public List<Резюме>? Резюме { get; set; }

            public List<Заявление>? Заявление { get; set; }

            public List<Личные_дела>? Личные_дела { get; set; }


    }
    
}

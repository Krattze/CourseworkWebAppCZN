using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppCZN.Data.BD;

public class Резюме
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID_резюме { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [StringLength(40)]
    public string? Желаемая_должность { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [StringLength(40)]
    public string? Профессия { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [StringLength(30)]
    public string? Сфера_деятельности { get; set; }

    public int? Зарплата { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [DataType(DataType.Date)]
	public DateTime? Дата_готовности_к_работе { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [StringLength(200)]
    public string? Адрес_места_жительства { get; set; }

	[ForeignKey("ID_формы_занятости")]
	public График_работы? График_Работы { get; set; }
	public int? ID_формы_занятости { get; set; }

	[ForeignKey("ID_тип_занятости")]
	public Тип_занятости? Тип_Занятости { get; set; }
	public int? ID_тип_занятости { get; set; }

	[ForeignKey("ID_заявления")]
	public Заявление? Заявление { get; set; }
	public int? ID_заявления { get; set; }

    public bool? Флаг_удаления { get; set; }


	[ForeignKey("ID_личных_данных")]
	public Личные_данные? Личные_данные { get; set; }
	public int? ID_Личных_данных { get; set; }


    public List<Сведения_об_образовании>? Сведения_об_Образовании { get; set; }

    public List<Предложенные_вакансии>? Предложенные_Вакансии { get; set; }


    public List<Опыт_работы>? Опыт_работы { get; set; }

}
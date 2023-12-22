using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{

        public class Тип_занятости
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID_тип_занятости { get; set; }

            [StringLength(30)]
            public string Тип_Занятости { get; set; }

            // Navigation property for relationships
            public List<Резюме> Резюме { get; set; }


            public List<Вакансии> Вакансии { get; set; }

      


    }
    } 

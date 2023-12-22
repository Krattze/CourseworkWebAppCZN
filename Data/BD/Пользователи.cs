using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppCZN.Data.BD
{
    public class Пользователи
    {
        [Key]
     
        public string ID_пользователя { get; set; }

        public int? Роль { get; set; }
    }
}

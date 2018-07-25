using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dz4zad1.Models
{
    public class ModelAuthor
    {
        [Required(ErrorMessage = "Заполните поле имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните поле дата рождения")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "Не коректная дата")]
        public string DateOfBirth { get; set; }
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "Не коректная дата")]
        public string DateOfDeath { get; set; }
    }
}
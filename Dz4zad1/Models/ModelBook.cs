using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dz4zad1.Models
{
    public class ModelBook
    {
        [Required(ErrorMessage = "Заполните поле имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните поле дата")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "Некоректная дата")]
        public string PublishDate { get; set; }
        [Required(ErrorMessage = "Заполните поле страницы")]
        [RegularExpression(@"\-?\d+(\d{0,})?", ErrorMessage = "Некоректный ввод страниц")]
        public string PageCount { get; set; }
        [Required(ErrorMessage = "Заполните поле ISBN")]
        public string ISBN { get; set; }
        public string RadioCeck { get; set; }
        public IList<string> SelectedCeck { get; set; }= new List<string>();

    }
}
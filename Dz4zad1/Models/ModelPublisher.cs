using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dz4zad1.Models
{
    public class ModelPublisher
    {
        [Required(ErrorMessage = "Заполните поле Имя")]
        public string Name { get; set; }
    }
}
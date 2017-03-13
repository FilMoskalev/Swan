using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    public class Vacancies
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string Position { get; set; }
    }
}

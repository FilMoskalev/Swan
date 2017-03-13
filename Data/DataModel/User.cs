using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}

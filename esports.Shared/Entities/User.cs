using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esports.Shared.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Display(Name = "Usuario")]

        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]

        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string Role { get; set; } = null!;
        public virtual Player? Player { get; set; }
    }
}

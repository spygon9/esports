using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esports.Shared.Entities
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Display(Name = "Tipo")]
        public string Type { get; set; } = null!;

        public Team Team { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esports.Shared.Entities
{
    public class Match
    {
        public int Id { get; set; }
        [Required]
        public int TournamentId { get; set; }
        [Required]
        public int Team1Id { get; set; }
        [Required]
        public int Team2Id { get; set; }
        [Required]
        [Display(Name ="Inicio de partida")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Finalización de partida")]
        public DateTime EndTime { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Display(Name = "Puntuación")]
        public string Score { get; set; } = null!;
        public Tournament Tournament { get; set; } = null!;
        public Team Team1 { get; set; } = null!;
        public Team Team2 { get; set; } = null!;
    }
}

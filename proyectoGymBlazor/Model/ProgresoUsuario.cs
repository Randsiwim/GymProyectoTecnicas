using System;
using System.ComponentModel.DataAnnotations;

namespace proyectoGymBlazor.Model
{
    public class ProgresoUsuario
    {
        public int ProgresoId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje de grasa corporal debe estar entre 0 y 100.")]
        public string Metrica { get; set; }

        
        public decimal Valor { get; set; }
    }

  
 
        public class ProgresoUsuarioViewModel
        {
            public int ProgresoId { get; set; }
            public int UsuarioId { get; set; }
            public string UsuarioNombre { get; set; }
            public DateTime Fecha { get; set; }
            public string Metrica { get; set; }
            public decimal Valor { get; set; }
        }
    }


using System.ComponentModel.DataAnnotations;

namespace Administracion_Consorcio_PW3.Models.Entidades
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime FechaRegistracion { get; set; }
        public DateTime FechaUltLogin { get; set; }
    }
}
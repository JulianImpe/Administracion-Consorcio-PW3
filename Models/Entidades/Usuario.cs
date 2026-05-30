using System.ComponentModel.DataAnnotations;

namespace Administracion_Consorcio_PW3.Models.Entidades
{
    public class Usuario
    {
        [Key] // Define que esta propiedad es la clave primaria de la tabla
        public int IdUsuario { get; set; }

        [Required] // Indica que el campo es obligatorio en la BD y en los formularios
        [EmailAddress] // Valida que el texto ingresado tenga un formato de correo electrónico válido
        [StringLength(100)] // Define un límite máximo de 100 caracteres para el almacenamiento
        public string Email { get; set; }

        [Required] // Indica que el campo es obligatorio
        [StringLength(100)] // Define un límite máximo de 100 caracteres
        public string Password { get; set; }

        public DateTime FechaRegistracion { get; set; }
        public DateTime FechaUltLogin { get; set; }
    }
}
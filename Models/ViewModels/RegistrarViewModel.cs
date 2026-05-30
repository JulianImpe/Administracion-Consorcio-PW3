using System.ComponentModel.DataAnnotations;
using Administracion_Consorcio_PW3.Validaciones; // Importamos el namespace de la validación personalizada

namespace Administracion_Consorcio_PW3.Models.ViewModels
{
    public class RegistrarViewModel
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [StringLength(100, ErrorMessage = "El email no puede superar los 100 caracteres")] // Valida longitud máxima
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [PasswordValidacion] // Aplicamos nuestra validación personalizada
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe confirmar su contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")] // Valida que sea igual a la propiedad Password
        public string ConfirmarPassword { get; set; }
    }
}
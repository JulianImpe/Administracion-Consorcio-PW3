using System.ComponentModel.DataAnnotations;

namespace Administracion_Consorcio_PW3.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El email es obligatorio")] // Indica que el campo no puede estar vacío
        [EmailAddress(ErrorMessage = "Debe ingresar un formato de email válido")] // Valida sintaxis de correo
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")] // Campo obligatorio para login
        [DataType(DataType.Password)] // Indica al navegador que oculte los caracteres
        public string Password { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Administracion_Consorcio_PW3.Validaciones
{
    // Heredamos de ValidationAttribute para crear nuestra propia lógica de validación
    public class PasswordValidacionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;

            // Si el campo es nulo o vacío, dejamos que [Required] se encargue
            if (string.IsNullOrEmpty(password))
            {
                return ValidationResult.Success;
            }

            // Definimos las condiciones individuales
            bool tieneMinChars = password.Length >= 8;
            bool tieneMayuscula = Regex.IsMatch(password, @"[A-Z]");
            bool tieneNumero = Regex.IsMatch(password, @"[0-9]");
            bool tieneEspecial = Regex.IsMatch(password, @"[!@#$%^&*]");

            // Si cumple todo, la validación es exitosa
            if (tieneMinChars && tieneMayuscula && tieneNumero && tieneEspecial)
            {
                return ValidationResult.Success;
            }

            // Construimos un mensaje descriptivo basado en lo que falta
            var errores = new List<string>();
            if (!tieneMinChars) errores.Add("mínimo 8 caracteres");
            if (!tieneMayuscula) errores.Add("al menos una mayúscula");
            if (!tieneNumero) errores.Add("al menos un número");
            if (!tieneEspecial) errores.Add("un carácter especial (!@#$%^&*)");

            return new ValidationResult("La contraseña requiere: " + string.Join(", ", errores));
        }
    }
}
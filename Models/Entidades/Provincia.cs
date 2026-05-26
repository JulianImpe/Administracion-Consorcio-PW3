using System.ComponentModel.DataAnnotations;

namespace Administracion_Consorcio_PW3.Models.Entidades
{
    public class Provincia
    {
        [Key]
        public int IdProvincia { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
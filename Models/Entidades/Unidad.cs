using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administracion_Consorcio_PW3.Models.Entidades
{
    public class Unidad
    {
        [Key]
        public int IdUnidad { get; set; }

        [Required]
        public int IdConsorcio { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string NombrePropietario { get; set; }

        [Required]
        public string ApellidoPropietario { get; set; }

        [Required]
        [EmailAddress]
        public string EmailPropietario { get; set; }

        public int Superficie { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int IdUsuarioCreador { get; set; }

        // Relaciones
        [ForeignKey("IdConsorcio")]
        public virtual Consorcio Consorcio { get; set; }

        [ForeignKey("IdUsuarioCreador")]
        public virtual Usuario UsuarioCreador { get; set; }
    }
}
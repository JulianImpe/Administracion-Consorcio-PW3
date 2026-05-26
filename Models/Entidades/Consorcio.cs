using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administracion_Consorcio_PW3.Models.Entidades
{
    public class Consorcio
    {
        [Key]
        public int IdConsorcio { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int IdProvincia { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        public string Calle { get; set; }

        [Required]
        public string Altura { get; set; }

        [Required]
        public int DiaVencimientoExpensas { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int IdUsuarioCreador { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }

        // Relaciones
        [ForeignKey("IdProvincia")]
        public virtual Provincia Provincia { get; set; }

        [ForeignKey("IdUsuarioCreador")]
        public virtual Usuario UsuarioCreador { get; set; }

        public virtual ICollection<Unidad> Unidades { get; set; }
        public virtual ICollection<Gasto> Gastos { get; set; }
    }
}
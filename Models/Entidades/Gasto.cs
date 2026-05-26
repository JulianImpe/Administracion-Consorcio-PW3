using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administracion_Consorcio_PW3.Models.Entidades
{
    public class Gasto
    {
        [Key]
        public int IdGasto { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string? Descripcion { get; set; }

        [Required]
        public int IdConsorcio { get; set; }

        [Required]
        public int IdTipoGasto { get; set; }

        [Required]
        public DateTime FechaGasto { get; set; }

        [Required]
        public int AnioExpensa { get; set; }

        [Required]
        public int MesExpensa { get; set; }

        [Required]
        public string ArchivoComprobante { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int IdUsuarioCreador { get; set; }

        // Relaciones
        [ForeignKey("IdConsorcio")]
        public virtual Consorcio Consorcio { get; set; }

        [ForeignKey("IdTipoGasto")]
        public virtual TipoGasto TipoGasto { get; set; }

        [ForeignKey("IdUsuarioCreador")]
        public virtual Usuario UsuarioCreador { get; set; }
    }
}
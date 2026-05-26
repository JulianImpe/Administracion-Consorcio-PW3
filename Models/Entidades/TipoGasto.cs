using System.ComponentModel.DataAnnotations;

namespace Administracion_Consorcio_PW3.Models.Entidades
{
    public class TipoGasto
    {
        [Key]
        public int IdTipoGasto { get; set; }

        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Gasto> Gastos { get; set; }
    }
}
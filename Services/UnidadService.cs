using Administracion_Consorcio_PW3.Models;
using Administracion_Consorcio_PW3.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Administracion_Consorcio_PW3.Services
{
    public interface IUnidadService
    {
        public List<Unidad> ObtenerUnidades();
        public void CrearUnidad(Unidad unidad);
        public void EditarUnidad(int IdUnidad, Unidad u);
        public void EliminarUnidad(int IdUnidad);
    }

    public class UnidadService : IUnidadService
    {
        public readonly ConsorcioDbContext dbContext;

        public UnidadService(ConsorcioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CrearUnidad(Unidad unidad)
        {
            dbContext.Add(unidad);
            dbContext.SaveChanges();
        }

        public void EditarUnidad(int IdUnidad,Unidad u)
        {
            Unidad unidad = dbContext.Unidades.Find(IdUnidad);
            if (unidad != null)
            {
                unidad.Nombre = u.Nombre;
                unidad.NombrePropietario = u.NombrePropietario;
                unidad.ApellidoPropietario = u.ApellidoPropietario;
                unidad.EmailPropietario = u.EmailPropietario;
                unidad.Superficie = u.Superficie;
            }
            dbContext.SaveChanges();
        }

        public void EliminarUnidad(int IdUnidad)
        {
            Unidad unidad = dbContext.Unidades.Find(IdUnidad);
            if (unidad != null)
            {
                dbContext.Unidades.Remove(unidad);
                dbContext.SaveChanges();
            }
            else 
            {
                return;
            }
        }

        public List<Unidad> ObtenerUnidades()
        {
           return dbContext.Unidades.Include(u => u.Consorcio).ToList();
        }
    }
}

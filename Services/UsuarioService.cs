using Administracion_Consorcio_PW3.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Administracion_Consorcio_PW3.Models;

public interface IUsuarioService
{
    public Usuario Login(string email, string password);
    public bool Registrar(string email, string password);
}
public class UsuarioService : IUsuarioService
{
    public readonly ConsorcioDbContext dbContext;

    public UsuarioService(ConsorcioDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Usuario Login(string email, string password)
    {
        var usuario = dbContext.Usuarios.FirstOrDefault(u => u.Email == email && u.Password == password);


        if (usuario != null)
        {
            usuario.FechaUltLogin = DateTime.Now;
            dbContext.SaveChanges();
        }

        return usuario;
    }

    public bool Registrar(string email, string password)
    {
        var usuario = dbContext.Usuarios.FirstOrDefault(u => u.Email == email);

        if (usuario != null)
        {
            return false;
        }

        usuario = new Usuario
        {
            Email = email,
            Password = password,
            FechaRegistracion = DateTime.Now
        };

        dbContext.Usuarios.Add(usuario);
        dbContext.SaveChanges();
        return true;
    }
}
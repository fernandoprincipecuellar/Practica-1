using Practica_1.Models;

namespace Practica_1.Services;

public class InMemoryCampanaService : ICampanaService
{
    private readonly List<Campana> _campanas = new()
    {
        new Campana
        {
            Id = 1,
            Nombre = "Black Friday",
            Categoria = "Retail",
            Estado = "Activa",
            FechaInicio = new DateTime(2026, 11, 20),
            FechaFin = new DateTime(2026, 11, 30),
            DescuentoPct = 0.30m,
            Canal = "Digital",
            Descripcion = "Descuento especial para compras en línea durante Black Friday."
        },
        new Campana
        {
            Id = 2,
            Nombre = "Navidad 2026",
            Categoria = "Temporada",
            Estado = "Planificada",
            FechaInicio = new DateTime(2026, 12, 1),
            FechaFin = new DateTime(2026, 12, 25),
            DescuentoPct = 0.25m,
            Canal = "Tienda",
            Descripcion = "Promoción navideña disponible en todas las tiendas físicas."
        },
        new Campana
        {
            Id = 3,
            Nombre = "Campaña de Verano",
            Categoria = "Estacional",
            Estado = "Activa",
            FechaInicio = new DateTime(2026, 6, 15),
            FechaFin = new DateTime(2026, 7, 15),
            DescuentoPct = 0.20m,
            Canal = "Email",
            Descripcion = "Oferta de verano para clientes registrados por correo electrónico."
        },
        new Campana
        {
            Id = 4,
            Nombre = "Cyber Monday",
            Categoria = "E-commerce",
            Estado = "Finalizada",
            FechaInicio = new DateTime(2026, 11, 27),
            FechaFin = new DateTime(2026, 11, 27),
            DescuentoPct = 0.40m,
            Canal = "Online",
            Descripcion = "Oferta flash exclusiva para compras digitales."
        },
        new Campana
        {
            Id = 5,
            Nombre = "Aniversario de Marca",
            Categoria = "Fidelización",
            Estado = "En curso",
            FechaInicio = new DateTime(2026, 4, 1),
            FechaFin = new DateTime(2026, 4, 10),
            DescuentoPct = 0.15m,
            Canal = "Redes Sociales",
            Descripcion = "Descuentos especiales por el aniversario de la marca."
        }
    };

    public IReadOnlyList<Campana> ObtenerTodas() => _campanas;

    public Campana? ObtenerPorId(int id) => _campanas.FirstOrDefault(c => c.Id == id);
}

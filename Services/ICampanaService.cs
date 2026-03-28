using Practica_1.Models;

namespace Practica_1.Services;

public interface ICampanaService
{
    IReadOnlyList<Campana> ObtenerTodas();
    Campana? ObtenerPorId(int id);
}

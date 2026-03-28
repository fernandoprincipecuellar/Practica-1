using Microsoft.AspNetCore.Mvc;
using Practica_1.Models;
using Practica_1.Services;

namespace Practica_1.Controllers;

public class CampanasController : Controller
{
    private readonly ICampanaService _campanaService;

    public CampanasController(ICampanaService campanaService)
    {
        _campanaService = campanaService;
    }

    public IActionResult Index(string? categoria, string? estado)
    {
        var campanas = _campanaService.ObtenerTodas();

        if (!string.IsNullOrWhiteSpace(categoria))
        {
            campanas = campanas.Where(c => string.Equals(c.Categoria, categoria, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrWhiteSpace(estado))
        {
            campanas = campanas.Where(c => string.Equals(c.Estado, estado, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        return View(campanas);
    }

    public IActionResult Resumen()
    {
        var campanas = _campanaService.ObtenerTodas();
        var today = DateTime.Today;

        ViewBag.TotalCampanas = campanas.Count;
        ViewBag.CampanasVigentes = campanas.Count(c => c.FechaInicio <= today && c.FechaFin >= today);
        ViewBag.CampanasProximas = campanas.Count(c => c.FechaInicio > today);
        ViewBag.PromedioDescuento = campanas.Any() ? campanas.Average(c => c.DescuentoPct) : 0m;
        ViewBag.CantidadPorCanal = campanas
            .GroupBy(c => c.Canal)
            .ToDictionary(g => g.Key, g => g.Count());

        return View();
    }

    public IActionResult Detalle(int id)
    {
        var campana = _campanaService.ObtenerPorId(id);
        if (campana == null)
        {
            return NotFound();
        }

        return View(campana);
    }
}

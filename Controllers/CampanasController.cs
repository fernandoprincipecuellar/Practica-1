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

    public IActionResult Index()
    {
        var campanas = _campanaService.ObtenerTodas();
        return View(campanas);
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

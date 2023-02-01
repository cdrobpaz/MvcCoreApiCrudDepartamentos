using Microsoft.AspNetCore.Mvc;
using MvcCoreApiCrudDepartamentos.Models;
using MvcCoreApiCrudDepartamentos.Services;

namespace MvcCoreApiCrudDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        private ServiceDepartamentos service;
        public DepartamentosController(ServiceDepartamentos service)
        {
            this.service = service;
        }
        public async Task<IActionResult> DepartamentosLocalidad()
        {
            List<Departamento> depts = await service.GetDepartamentosAsync();
            List<string> locs = await service.GetLocalidadesAsync();
            ViewData["LOCALIDADES"] = locs;
            return View(depts);
        }
        [HttpPost]
        public async Task<IActionResult> DepartamentosLocalidad(string localidad)
        {
            List<Departamento> depts = await service.FindLocalidadAsync(localidad);
            List<string> locs = await service.GetLocalidadesAsync();
            ViewData["LOCALIDADES"] = locs;
            return View(depts);
        }
        public async Task<IActionResult> Details(int id)
        {
            Departamento dept = await service.FindDepartamentoAsync(id);
            return View(dept);
        }

    }
}

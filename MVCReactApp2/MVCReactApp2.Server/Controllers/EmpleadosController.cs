using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCReactApp2.Server.Models;

namespace MVCReactApp2.Server.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ReactMvcContext _context;

        public EmpleadosController(ReactMvcContext dbcontext)
        {
            _context = dbcontext;
        }


        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> lista()
        {
            List<Empleado> lista = await _context.Empleados.OrderByDescending(c => c.IdEmpleado).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> guardar([FromBody] Empleado request)
        {
            await _context.Empleados.AddRangeAsync(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> editar([FromBody] Empleado request)
        {
            _context.Empleados.Update(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> eliminar(int id)
        {
            Empleado empleado = _context.Empleados.Find(id)!;
            if (empleado == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No encontrado");
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        //// GET: Empleados
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Empleados.ToListAsync());
        //}

        //// GET: Empleados/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var empleado = await _context.Empleados
        //        .FirstOrDefaultAsync(m => m.IdEmpleado == id);
        //    if (empleado == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(empleado);
        //}

        //// GET: Empleados/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Empleados/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("IdEmpleado,Nombre,Correo,Direccion,Telefono")] Empleado empleado)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(empleado);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(empleado);
        //}

        //// GET: Empleados/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var empleado = await _context.Empleados.FindAsync(id);
        //    if (empleado == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(empleado);
        //}

        //// POST: Empleados/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,Nombre,Correo,Direccion,Telefono")] Empleado empleado)
        //{
        //    if (id != empleado.IdEmpleado)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(empleado);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EmpleadoExists(empleado.IdEmpleado))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(empleado);
        //}

        //// GET: Empleados/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var empleado = await _context.Empleados
        //        .FirstOrDefaultAsync(m => m.IdEmpleado == id);
        //    if (empleado == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(empleado);
        //}

        //// POST: Empleados/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var empleado = await _context.Empleados.FindAsync(id);
        //    if (empleado != null)
        //    {
        //        _context.Empleados.Remove(empleado);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EmpleadoExists(int id)
        //{
        //    return _context.Empleados.Any(e => e.IdEmpleado == id);
        //}
    }
}

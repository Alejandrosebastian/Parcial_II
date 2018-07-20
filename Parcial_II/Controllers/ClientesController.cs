using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial_II.Data;
using Parcial_II.Models;
using Microsoft.AspNetCore.Identity;

namespace Parcial_II.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ClienteModel claseclientemodel;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
            claseclientemodel = new ClienteModel(context);
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public List<object[]> Controladorlistaindexcliente()
        {
            return claseclientemodel.ModeloListaCliente();
        }
        public List<IdentityError> ControladorGuardarCliente
           (
           int Cedula, string Primernombre, string Segundonombre,
           string Primerapellido, string Segundoapellido, int Telefono,
           string Correo, string Tipo_prefe_inmueble, int Importe_maximo, DateTime Fecha_registro
           )
        {
            return claseclientemodel.ClaseGuardarCliente
                (Cedula, Primernombre, Segundonombre, Primerapellido, Segundoapellido, Telefono, Correo, Tipo_prefe_inmueble, Importe_maximo, Fecha_registro);
        }


    }
}

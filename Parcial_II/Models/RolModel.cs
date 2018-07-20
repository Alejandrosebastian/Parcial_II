using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial_II.Data;
using Microsoft.AspNetCore.Identity;

namespace Parcial_II.Models
{
    public class RolModel
    {
        private ApplicationDbContext _contexto;

        public RolModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<IdentityError> ClaseGuardarRol(string Nombre)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var objetorol = new Rol
            {
                Nombre = Nombre
            };
            try
            {
                _contexto.Rol.Add(objetorol);
                _contexto.SaveChanges();
                dato = new IdentityError
                {
                    Code = "Save",
                    Description = "Save"
                };
            }
            catch (Exception ex)
            {
                dato = new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                };
            }
            Lista.Add(dato);
            return Lista;
        }
        public List<object[]> ModeloListaRol()
        {
            List<object[]> Listarol = new List<object[]>();
            var resultado = _contexto.Rol.ToList();
            var html = "";
            var rol = (from c in _contexto.Rol
                         select new
                         {
                             c.Nombre,
                             c.RolId
                         }).OrderBy(c => c.Nombre).ToList();
            foreach (var item in rol)
            {
                html += "<tr class='info'>" +
                    "<td>" + item.Nombre + "<td>" +
                    "<td>" + item.RolId + "<td>" +
                    "<td>" + "<a class='btn btn-succes' data->data-toggle='modal' data-target='#Ingresorol' onclick='Cargaprie(" + item.RolId + ")'>Editar</a>" +
                    "</td></tr>";
            }
            object[] dato = { html };
            Listarol.Add(dato);
            return Listarol;
        }
    }
}

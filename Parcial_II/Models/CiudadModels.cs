using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial_II.Models;
using Parcial_II.Data;
using Microsoft.AspNetCore.Identity;
namespace Parcial_II.Models
{
    public class CiudadModels
    {
        private ApplicationDbContext _contexto;
        
        public CiudadModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<IdentityError> ClaseGuardarCiudad(string Nombre)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var objetociudad = new Ciudad
            {
                Nombre = Nombre
            };
            try
            {
                _contexto.Ciudad.Add(objetociudad);
                _contexto.SaveChanges();
                dato = new IdentityError
                {
                    Code = "Save",
                    Description = "Save"
                };
            }
            catch(Exception ex)
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
        public List<object[]> ModeloListaCiudad()
        {
            List<object[]> Listaciudad = new List<object[]>();
            var resultado = _contexto.Ciudad.ToList();
            var html = "";
            var ciuda = (from c in _contexto.Ciudad
                         select new
                         {
                             c.Nombre,
                             c.CiudadId
                         }).OrderBy(c => c.Nombre).ToList();
            foreach(var item in ciuda)
            {
                html +="<tr class='info'>"+
                    "<td>" + item.Nombre + "<td>" +
                    "<td>" + item.CiudadId + "<td>" +
                    "<td>" + "<a class='btn btn-succes' data->data-toggle='modal' data-target='#Ingresociudad' onclick='Cargaprie(" + item.CiudadId + ")'>Editar</a>" +
                    "</td></tr>";
            }
            object[] dato = { html };
            Listaciudad.Add(dato);
            return Listaciudad;
        }
        
    }
}

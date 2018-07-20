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

        public List<IdentityError> ClaseGuardarRol(String Nombre)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var objetorol = new Rol
            {
                Nombre = Nombre,
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

        public List<object[]> ModeloListarol()
        {

            List<object[]> Listarol = new List<object[]>();
            var resultado = _contexto.Rol.ToList();
            var html = "";
            var rol = (from p in _contexto.Rol
                            select new
                            {
                                p.Nombre,
                                p.RolId
                            }).OrderBy(p => p.Nombre).ToList();
            foreach (var item in rol)
            {
                html += "<tr class='info'>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoRol' onclick='Cargarol (" + item.RolId + ")'>Editar</a>" +
                    //  "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionTiporol' onclick='CargaParaImpresionTiporol();'>Imprimir</a>" +

                    "</td></tr>";
            }
            object[] dato = { html };
            Listarol.Add(dato);
            return Listarol;


        }

        public List<IdentityError> Modaleditarrol(String Nombre, int RolId)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();
            var rol = new Rol
            {
                Nombre = Nombre,
                RolId = RolId
            };
            try
            {
                _contexto.Rol.Update(rol);
                _contexto.SaveChanges();
                regresa = new IdentityError
                {
                    Code = "save",
                    Description = "save"
                };
            }
            catch (Exception ex)
            {
                regresa = new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                };
            }
            ListaEditar.Add(regresa);
            return ListaEditar;
        }

    }
}


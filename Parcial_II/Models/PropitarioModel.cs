using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial_II.Models;
using Parcial_II.Data;

namespace Parcial_II.Models
{
    public class PropitarioModel
    {
        private ApplicationDbContext _contexto;

        public PropitarioModel (ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<IdentityError> ClaseGuardarPropietario(String Nombre1, String Nombre2, String Apellido1, String Apellido2, String Direccion, String Correo, int Telefono)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var objetopropietario = new Propietario
            {
                Nombre1 = Nombre1,
                Nombre2 = Nombre2,
                Apellido1 = Apellido1,
                Apellido2 = Apellido2,
                Direccion = Direccion,
                Correo = Correo,
                Telefono = Telefono
              
            };
            try
            {
                _contexto.Propietario.Add(objetopropietario);
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

        public List<object[]> ModeloListapropietario()
        {

            List<object[]> Listapro = new List<object[]>();
            var resultado = _contexto.Propietario.ToList();
            var html = "";
            var Propieta = (from p in _contexto.Propietario
                            select new
                            {
                                p.Nombre1,
                                p.Nombre2,
                                p.Apellido1,
                                p.Apellido2,
                                p.Direccion,
                                p.Correo,
                                p.Telefono,
                                p.PropietarioId
                            }).OrderBy(p => p.Nombre1).ToList();
            foreach (var item in Propieta)
            {
                html += "<tr class='info'>" +
                    "<td>" + item.Nombre1 + "</td>" +
                    "<td>" + item.Nombre2 + "</td>" +
                    "<td>" + item.Apellido1 + "</td>" +
                    "<td>" + item.Apellido2 + "</td>" +
                    "<td>" + item.Direccion + "</td>" +
                    "<td>" + item.Correo + "</td>" +
                    "<td>" + item.Telefono + "</td>" +
                    "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoPropietario' onclick='Cargapropie(" + item.PropietarioId + ")'>Editar</a>" +
                    //  "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionTipoinmu' onclick='CargaParaImpresionTipoinmu();'>Imprimir</a>" +

                    "</td></tr>";
            }
            object[] dato = { html };
            Listapro.Add(dato);
            return Listapro;


        }

        public List<IdentityError> Modaleditarpro(String Nombre1, String Nombre2, String Apellido1, String Apellido2, String Direccion, String Correo, int Telefono, int PropietarioId)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();
            var propie = new Propietario
            {
                Nombre1 = Nombre1,
                Nombre2 = Nombre2,
                Apellido1 = Apellido1,
                Apellido2 = Apellido2,
                Telefono = Telefono,
                Correo = Correo,
                Direccion = Direccion,
                PropietarioId = PropietarioId
            };
            try
            {
                _contexto.Propietario.Update(propie);
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

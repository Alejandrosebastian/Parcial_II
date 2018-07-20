using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial_II.Data;
using Microsoft.AspNetCore.Identity;

namespace Parcial_II.Models
{
    public class ClienteModel
    {
        private ApplicationDbContext _contexto;
        public ClienteModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<IdentityError> ClaseGuardarCliente(
            int Cedula, string Primernombre, string Segundonombre,
            string Primerapellido, string Segundoapellido, int Telefono,
            string Correo, string Tipo_prefe_inmueble, int Importe_maximo, DateTime Fecha_registro
            )
        {
            List<IdentityError> ListaResultado = new List<IdentityError>();
            IdentityError error = new IdentityError();
            var objetocliente = new Cliente
            {
                Cedula = Cedula,
                Primernombre = Primernombre,
                Segundonombre = Segundonombre,
                Primerapellido = Primerapellido,
                Segundoapellido = Segundoapellido,
                Telefono = Telefono,
                Correo = Correo,
                Tipo_prefe_inmueble = Tipo_prefe_inmueble,
                Importe_maximo = Importe_maximo,
                Fecha_registro = Fecha_registro
            };
            try
            {
                _contexto.Cliente.Add(objetocliente);
                _contexto.SaveChanges();
                error = new IdentityError
                {
                    Code = "Save",
                    Description = "Save"
                };

            }
            catch (Exception ex)
            {
                error = new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                };
            }
            ListaResultado.Add(error);
            return ListaResultado;
        }
        public List<object[]> ModeloListaCliente()
        {

            List<object[]> Listacli = new List<object[]>();
            var resultado = _contexto.Cliente.ToList();
            var html = "";
            var cliente = (from c in _contexto.Cliente
                           select new
                           {
                               c.Cedula,
                               c.Primernombre,
                               c.Segundonombre,
                               c.Primerapellido,
                               c.Segundoapellido,
                               c.Telefono,
                               c.Correo,
                               c.Tipo_prefe_inmueble,
                               c.Importe_maximo,
                               c.Fecha_registro,
                               c.ClienteId
                           }).OrderBy(c => c.Cedula).ToList();
            foreach (var item in cliente)
            {
                html += "<tr class='info'>" +
                    "<td>" + item.Cedula + "</td>" +
                     "<td>" + item.Primernombre + "</td>" +
                      "<td>" + item.Segundonombre + "</td>" +
                       "<td>" + item.Primerapellido + "</td>" +
                        "<td>" + item.Segundoapellido + "</td>" +
                         "<td>" + item.Telefono + "</td>" +
                          "<td>" + item.Correo + "</td>" +
                           "<td>" + item.Tipo_prefe_inmueble + "</td>" +
                            "<td>" + item.Importe_maximo + "</td>" +
                             "<td>" + item.Fecha_registro + "</td>" +
                    "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoClienteS' onclick='CargaCliente(" + item.ClienteId + ")'>Editar</a>" +
                    "</td></tr>";
            }
            object[] dato = { html };
            Listacli.Add(dato);
            return Listacli;


        }
    }
}

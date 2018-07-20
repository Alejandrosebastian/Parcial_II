using Microsoft.AspNetCore.Identity;
using Parcial_II.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial_II.Models
{
    public class EmpleadoModel
    {
        private ApplicationDbContext _contexto;
        public EmpleadoModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<IdentityError> ModeloGrabaEmpleado(string primernombre, string segundonombre, string primerapellido, string segundoapellido, string direccion,
        string salario,
        string correo,
         DateTime fecha_nacimiento,
          int edad,
          int UsuarioId,
          int Categoria_LaboralId)
        {

            List<IdentityError> listaempleado = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var objetoempleado = new Empleado
            {
                PrimerNombre = primernombre,
                SegundoNombre = segundonombre,
                PrimerApellido = primerapellido,
                SegundoApellido = segundoapellido,
                Direccion = direccion,
                Salario = salario,
                Correo = correo,
                Fecha_nacimiento = fecha_nacimiento,
                Edad = edad,
                UsuarioId=UsuarioId, 
               CategoriaLaboralId=Categoria_LaboralId,

            };
            try
            {

                _contexto.Empleado.Add(objetoempleado);
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
            listaempleado.Add(dato);
            return listaempleado;
        }


        public List<object[]> ModeloListaempleado()
        {

            List<object[]> Listemple = new List<object[]>();
            var resultado = _contexto.Empleado.ToList();
            var html = "";
            var Emple = (from p in _contexto.Empleado
                            select new
                            {
                                p.PrimerNombre,
                                p.SegundoNombre,
                                p.PrimerApellido,
                                p.SegundoApellido,
                                p.Direccion,
                                p.Salario,
                                p.Correo,
                                p.Fecha_nacimiento,
                                p.Edad,
                                p.UsuarioId,
                                p.CategoriaLaboralId, 
                                p.EmpleadoId
                  
                            }).OrderBy(p => p.PrimerNombre).ToList();
            foreach (var item in Emple)
            {
                html += "<tr class='info'>" +
                    "<td>" + item.PrimerNombre + "</td>" +
                    "<td>" + item.SegundoNombre + "</td>" +
                    "<td>" + item.PrimerApellido + "</td>" +
                    "<td>" + item.SegundoApellido + "</td>" +
                    "<td>" + item.Direccion + "</td>" +
                    "<td>" + item.Salario + "</td>" +
                    "<td>" + item.Correo + "</td>" +
                    "<td>" + item.Fecha_nacimiento+ "</td>" +
                    "<td>" + item.Edad + "</td>" +
                    "<td>" + item.UsuarioId + "</td>" +
                    "<td>" + item.CategoriaLaboralId + "</td>" +
                    "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoPropietario' onclick='Cargaemple(" + item.EmpleadoId + ")'>Editar</a>" +
                    //  "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionTipoinmu' onclick='CargaParaImpresionTipoinmu();'>Imprimir</a>" +

                    "</td></tr>";
            }
            object[] dato = { html };
            Listemple.Add(dato);
            return Listemple;


        }

        public List<IdentityError> Modaleditaremple(string primernombre, string segundonombre, string primerapellido, string segundoapellido, string direccion,
        string salario,
        string correo,
         DateTime fecha_nacimiento,
          int edad,
          int UsuarioId,
          int Categoria_LaboralId, int EmpleadoId)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();
            var emple = new Empleado
            {
               PrimerNombre = primernombre,
                SegundoNombre = segundonombre,
                PrimerApellido = primerapellido,
                SegundoApellido = segundoapellido,
                Direccion = direccion, 
                Salario=salario,
                Correo =correo , 
                Fecha_nacimiento=fecha_nacimiento, 
                Edad=edad, 
                UsuarioId=UsuarioId, 
                CategoriaLaboralId=Categoria_LaboralId, 
                EmpleadoId=EmpleadoId
             
            };
            try
            {
                _contexto.Empleado.Update(emple);
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
    




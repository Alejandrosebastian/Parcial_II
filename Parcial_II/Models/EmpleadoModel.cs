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
    }
}



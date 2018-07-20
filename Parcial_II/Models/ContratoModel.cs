using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial_II.Models;
using Parcial_II.Data;
using Microsoft.AspNetCore.Identity;

namespace Parcial_II.Models
{
    public class ContratoModel
    {
        private ApplicationDbContext _contexto;
        public ContratoModel (ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<IdentityError> ClaseGuardarContrato(int deposito, string duracion, 
            DateTime fecha_ini, DateTime fecha_vence, int tipopagoId, int sucursalId, int clienteId)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var objetocontrato = new Contrato
            {
                deposito = deposito,
                Duracion=duracion,
                fecha_ini=fecha_ini,
                fecha_vence=fecha_vence,
                TipopagosId=tipopagoId,
                SucursalId=sucursalId,
                ClienteId=clienteId
            };
            try
            {
                _contexto.Contrato.Add(objetocontrato);
                _contexto.SaveChanges();
                dato = new IdentityError
                {
                    Code="save",
                    Description="save"
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
       // public List<object[]> ModeloListaContrato()
        //{
          //  List<object[]> ListaContrato = new List<object[]>();
            //var resultado = _contexto.Contrato.ToList();
            //var html = "";
            //var Contra
        //}
        
        
    }
}

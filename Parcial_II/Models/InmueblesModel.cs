using Microsoft.AspNetCore.Identity;
using Parcial_II.Data;
using Parcial_II.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial_II.Models
{
    public class InmueblesModel
    {
        private ApplicationDbContext _contexto;

        public InmueblesModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<IdentityError> ModeloGrabaInmueble(String Direccion, String Nhabitcion, int cos, int Tipo, int Propio, int Parro, Boolean Activo)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var Objetosexo = new Inmuebles
            {
                direccion = Direccion,
                N_habitaciones = Nhabitcion,
                Costo = cos,
                Tipos_inmuid = Tipo,
                PropietarioId = Propio,
                ParroquiaId = Parro,
                activo = Activo
            };
            try
            {
                _contexto.Inmuebles.Add(Objetosexo);
                _contexto.SaveChanges();
                dato = new IdentityError
                {
                    Code = "save",
                    Description = "save"
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
        public List<object[]> ModeloListaInmueble()
        {
            //    int count = 0, cant, numRegistros = 0, inicio = 0;
            //    int registro_por_pagina = 2, can_paginas,pagina;
            //    string dataFilter = "", paginador = "";
            //    IEnumerable<Sexo> query;
            //    List<Sexo> sexo = null;
            //    switch (orden)
            //    {
            //        case "az":
            //            sexo = _contexto.Sexos.OrderBy(s => s.Detalle).ToList();
            //            break;
            //        case "za":
            //            sexo = _contexto.Sexos.OrderByDescending(s => s.Detalle).ToList();
            //            break;
            //    }
            //    numRegistros = sexo.Count;
            //    inicio = (numeropagina - 1) * registro_por_pagina;
            //    can_paginas = (numRegistros / registro_por_pagina);
            //    if(valor == "null")
            //    {
            //        query = sexo.Skip(inicio).Take(registro_por_pagina);
            //    }
            //    else
            //    {
            //        query = sexo.Where(s => s.Detalle.StartsWith(valor)).Take(registro_por_pagina);
            //        //cadena =cliente.where(c=> c.nombre.StarWith(valor)
            //        // || c.Apellido.starwith(valor) || c.Direccion.starwith(valor)).skip(inicio).take(registro);
            //    }
            //    cant = query.Count();
            List<object[]> ListaSexos = new List<object[]>();
            var resultado = _contexto.Inmuebles.ToList();
            //    //var resultado = from s in _contexto.Sexos select s;
            //    //var resultado = from s in _contexto.Sexos select new { s.Detalle, s.SexoId };
            var html = "";
            var inmuebles = (from i in _contexto.Inmuebles
                             join pro in _contexto.Propietario on i.PropietarioId equals pro.PropietarioId
                             join par in _contexto.Parroquia on i.ParroquiaId equals par.ParroquiaId

                             select new
                             {
                                 i.InmueblesId,
                                 i.direccion,
                                 i.N_habitaciones,
                                 i.Costo,
                                 i.activo,
                                 par.Nombre,
                                 pro.Nombre1,
                                 i.Tipos_inmuid
                             }).OrderBy(i => i.direccion).ToList();
            foreach (var item in inmuebles)
            {
                html += "<tr class='info'>" +
                    "<td>" + item.direccion + "</td>" +
                    "<td>" + item.N_habitaciones + "</td>" +
                    "<td>" + item.Costo + "</td>" +
                    "<td>" + item.activo + "</td>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.Nombre1 + "</td>" +
                    "<td>" + item.Tipos_inmuid + "</td>" +

                    "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoInmueble' onclick='CargaInmueble(" + item.InmueblesId + ")'>Editar</a>" +
                    "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionInmueble' onclick='CargaParaImpresionInmueble();'>Imprimir</a>" +
                    //            "<a class='btn btn-danger' onclick='eliminaSexo(" + item.SexoId + ")'>Eliminar</a>" +

                    "</td></tr>";
            }
            //    if (valor == "null")
            //    {
            //        if (numeropagina > 1)
            //        {
            //            pagina = numeropagina + 1;
            //            paginador += "<a class='btn btn-default onclick = 'ListaSexos(" + 1 + "," + '"' + orden + '"' + ")'><<<</a>" + '< a class="btn btn-default" onclick="ListaSexo(' + pagina + ",'',orden"')"><</a>';
            //        }
            //    }
            object[] dato = { html };
            ListaSexos.Add(dato);
            return ListaSexos;
        }
        //public List<object[]> Claselistamedicamento(

        //    )
        //{
        //    string resultado = "";
        //    List<object[]> listaresultado = new List<object[]>();
        //    var Tipoinmu = (from m in _contexto.Tipos_inmu
        //                        //join tm in _conju.TipoMedicamento on m.TipoMedicamentoID equals tm.TipoMedicamentoID
        //                        select new
        //                        {
        //                            m.Tipos_inmuId,
        //                            m.nombre
        //                        }).OrderBy(m => m.nombre).ToList();
        //    foreach (var item in Tipoinmu)
        //    {
        //        resultado += "<tr>" +
        //            "<td>" + item.nombre + "</td>" +
        //            "<td>" +
        //            "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoTipoinmu' onclick='CargaTipoinmu(" + item.Tipos_inmuId + ")'>Editar</a>" +
        //            "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionTipoinmu' onclick='CargaParaImpresionTipoinmu();'>Imprimir</a>"  +
        //            "<a class= 'btn btn-alert'> Eliminar </td>" +
        //            "</td>"
        //            + "</tr>";
        //    }
        //    object[] datos = { resultado };
        //    listaresultado.Add(datos);
        //    return listaresultado;
        //}

        public List<IdentityError> ModeloEditarInmueble(string direccion, string nhabitacion, int inmuebleid, int parra, int pro, int tipoinmuId, int costo, Boolean Activo)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();
            var Inmuebles = new Inmuebles
            {
                InmueblesId = inmuebleid,
                direccion = direccion,
                N_habitaciones = nhabitacion,
                Costo = costo,
                PropietarioId = pro,
                ParroquiaId = parra,
                activo = Activo,
                Tipos_inmuid = tipoinmuId
            };
            try
            {
                _contexto.Inmuebles.Update(Inmuebles);
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

        //public List<IdentityError> ModeloEliminarTipoinmu(int tipo_inmuId)
        //{
        //    List<IdentityError> ListaEliminar = new List<IdentityError>();
        //    IdentityError dato = new IdentityError();
        //    var inmu = new Tipos_inmu { Tipos_inmuId = tipo_inmuId };
        //    try
        //    {
        //        _contexto.Tipos_inmu.Remove(tipo_inmd);
        //        _contexto.SaveChanges();
        //        dato = new IdentityError
        //        {
        //            Code = "Save",
        //            Description = "Save"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        dato = new IdentityError
        //        {
        //            Code = ex.Message,
        //            Description = ex.Message
        //        };
        //    }
        //    ListaEliminar.Add(dato);
        //    return ListaEliminar;
        //}
        public List<object[]> ModeloImpresionInmueble()
        {
            List<object[]> lista = new List<object[]>();
            string dato = "";
            var respuesta = _contexto.Inmuebles.OrderBy(i => i.direccion).ToList();
            foreach (var item in respuesta)
            {
                dato += "<tr class='info'><td>" + item.InmueblesId + "</td> <td>" + item.direccion + "</td></tr>" + "</td> <td>" + item.N_habitaciones + "</td></tr>" + "</td> <td>" + item.Costo + "</td></tr>" + "</td> <td>" + item.activo + "</td></tr>" + "</td> <td>" + item.ParroquiaId + "</td></tr>" + "</td> <td>" + item.PropietarioId + "</td></tr>" + "</td> <td>" + item.Tipos_inmuid + "</td></tr>";
            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }
    }

}

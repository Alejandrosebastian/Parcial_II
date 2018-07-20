// Write your JavaScript code.

$().ready(() => {
    sitelistaindexpro();

    ListaTipo_inmu();

   // ListaInmueble();
    ListaCliente();
});

var sitelistaindexpro = () => {
    var accion = 'Propietarios/Controladorlistaindexpro';
    var clspropie = new ClasePropietario('', '', '', '', '', '', '', accion);
    clspropie.listaindex();
}

var guardaCliente = () => {
    var cedula = document.getElementById('Cedula').value;
    var primernombre = document.getElementById('Primernombre').value;
    var segundonombre = document.getElementById('Segundonombre').value;
    var primerapellido = document.getElementById('Primerapellido').value;
    var segundoapellido = document.getElementById('Segundoapellido').value;
    var telefono = document.getElementById('Telefono').value;
    var correo = document.getElementById('Correo').value;
    var tipo_profe = document.getElementById('Tipo_prefe_inmueble').value;
    var importe_maximo = document.getElementById('Importe_maximo').value;
    var fecha_reg = document.getElementById('Fecha_registro').value;
    var ClienteId = document.getElementById('ClienteId').value;
    if (ClienteId === '') {
        ClienteId == '0';
        var accion = 'Clientes/ControladorGuardarCliente';
    } else {
        var accion = 'Clientes/ControladorEditarCliente';
    }
    var graba = new Claseclientejs(cedula, primernombre, segundonombre, primerapellido, segundoapellido, telefono, correo, tipo_profe, importe_maximo, fecha_reg, ClienteId, accion)
    graba.claseGuardarCliente(ClienteId);
}

var guardarpropietario = () => {
    var Nombre1 = document.getElementById('Nombre1').value;
    var Nombre2 = document.getElementById('Nombre2').value;
    var Apellido1 = document.getElementById('Apellido1').value;
    var Apellido2 = document.getElementById('Apellido2').value;
    var Direccion = document.getElementById('Direccion').value;
    var Correo = document.getElementById('Correo').value;
    var Telefono = document.getElementById('Telefono').value;
    var PropietarioId = document.getElementById('PropietarioId').value;
    if (PropietarioId === '') {
        PropietarioId = '0';
        var accion = 'Propietarios/ControladorGuardaPropietario';
    } else {

        var accion = 'Propietarios/ControladorEditapropi';
    }
    var graba = new ClasePropietario(Nombre1, Nombre2, Apellido1, Apellido2, Direccion, Correo, Telefono, accion);
    graba.guardarpropietario(PropietarioId);

}

var guardaCiudad = () => {
    var Nombre = document.getElementById('Nombre').value;
    var CiudadId = document.getElementById('CiudadId').value;
    if (CiudadId == '') {
        CiudadId = '0';
        var accion = 'Ciudads/ControladorGuardaCiudad';
    } else {
        var accion = '';
    }
    var graba = new ClaseCiudad(Nombre, accion);
    graba.guardaciudad(CiudadId);
}

var Cargapropie = (PropietarioId) => {
    var accion = 'Propietarios/ControladorUnpropi';
    var clspropieta = new ClasePropietario('','','','','','','',accion)
    clspropieta.Cargarpropi(PropietarioId);
}

var CargaCliente = (ClienteId) => {
    var accion = 'Propietarios/ControladorUnpropi';
    var clsclien = new Claseclientejs('', '', '', '', '', '', '','','','','', accion);
    clsclien.CargarCliente(ClienteId);
}
var ListaTipo_inmu = () => {
    var accion = 'Tipos_inmu/ControladorListaTipo_inmu';
    var tipoinmu = new ClaseTipoinmu('', accion);
    tipoinmu.ListadeTipoinmu();
}

var CargaTipoinmu = (tipoinmuId) => {
    var accion = 'Tipos_inmu/ControladorUnTipoinmu';
    var untipoinmu = new ClaseTipoinmu('', accion);
    untipoinmu.CargarTipoinmu(tipoinmuId);
}
//var eliminaSexo = (id) => {
//    var accion = 'Sexos/ControladorEliminarSexo';
//    var eliminasexo = new ClaseSexo('', accion);
//    var res = confirm('Desea eliminar el registro');
//    if (res == true) {
//        eliminasexo.EliminarSexo(id);
//        alert('registro eliminado');
//    } else { alert('usted canselo la elimnacion del registro'); }
//}
var CargaParaImpresionTipoinmu = () => {
    var accion = 'Tipos_inmu/ContronladorImprimirTipoinmu';
    var carga = new ClaseTipoinmu('', accion);
    carga.ImprimirTipoinmu();

}
var ImpresionTipoinmu = () => {
    var contenido = document.getElementById('areaImprimir').innerHTML;
    var contenidooriginial = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
}




var grabaInmueble = () => {
    var direccion = document.getElementById('direccion').value;
    var nhabitacion = document.getElementById('nhabitacion').value;
    var costo = document.getElementById('costo').value;
    var activo = document.getElementById('activo').value;
    var parroquia = document.getElementById('parro').value;
    var propietario = document.getElementById('pro').value;
    var inmuId = document.getElementById('tipo').value;
    var inmueble = document.getElementById('id').value;

    if (inmueble == '') {
        inmueble == 0;
        var accion = 'Inmuebles/ControladorGuardaInmueble';
    }
    else {
        var accion = 'Inmuebles/ControladorEditaInmueble';
    }
    var graba = new ClaseInmueble(direccion, nhabitacion, costo, activo, parroquia, propietario, inmuId, accion);
    graba.GuardarInmueble(inmueble);
}

var ListaInmueble = () => {
    var accion = 'Inmuebles/ControladorListaInmueble';
    var inmu = new ClaseInmuble('', accion);
    inmu.ListadeInmueble();
}

var ListaCliente = () => {
    var accion = 'Clientes/Controladorlistaindexcliente';
    var cliente = new Claseclientejs('', '', '', '', '', '', '', '', '', '','', accion);
    cliente.listarcliente();
}

var CargaInmueble = (inmuebleId) => {
    var accion = 'Inmuebles/ControladorUnInmuble';
    var untipoinmu = new ClaseInmueble('', accion);
    untipoinmu.CargarInmueble(inmuebleId);
}
//var eliminaSexo = (id) => {
//    var accion = 'Sexos/ControladorEliminarSexo';
//    var eliminasexo = new ClaseSexo('', accion);
//    var res = confirm('Desea eliminar el registro');
//    if (res == true) {
//        eliminasexo.EliminarSexo(id);
//        alert('registro eliminado');
//    } else { alert('usted canselo la elimnacion del registro'); }
//}
var CargaParaImpresionInmueble = () => {
    var accion = 'Inmuebles/ContronladorImprimirInmueble';
    var carga = new ClaseInmueble('', accion);
    carga.ImprimirInmuebe();

}
var ImpresionInmueble = () => {
    var contenido = document.getElementById('areaImprimir').innerHTML;
    var contenidooriginial = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
}

//var eliminaSexo = (id) => {
//    var accion = 'Sexos/ControladorEliminarSexo';
//    var eliminasexo = new ClaseSexo('', accion);
//    var res = confirm('Desea eliminar el registro');
//    if (res == true) {
//        eliminasexo.EliminarSexo(id);
//        alert('registro eliminado');
//    } else { alert('usted canselo la elimnacion del registro'); }
//}

var grabaEmpleado = () => {
    var PrimerNombre = document.getElementById('PrimerNombre').value;
    var SegundoNombre = document.getElementById('SegundoNombre').value;
    var PrimerApellido = document.getElementById('PrimerApellido').value;
    var SegundoApellido = document.getElementById('SegundoApellido').value;
    var Direccion = document.getElementById('Direccion').value;
    var Salario = document.getElementById('Salario').value;
    var Correo = document.getElementById('Correo').value;
    var Fecha_nacimiento = document.getElementById('Fecha_nacimiento').value;
    var Edad = document.getElementById('Edad').value;
    var UsuarioId = document.getElementById('UsuarioId').value;
    var CategoriaLaboralId = document.getElementById('CategoriaLaboralId').value;
    var EmpleadoId = document.getElementById('EmpleadoId').value;
    if (EmpleadoId === '') {
        EmpleadoId = '0';
        var accion = 'Empleado/ControladorGuardaEmpleado';
    } else {

        var accion = '';
    }
    var graba = new claseEmpleado(primernombre, segundonombre, primerapellido, segundoapellido, direccion, salario, correo, fecha_nacimiento, edad, UsuarioId, CategoriaLaboralId);
    graba.GuardarEmpleado(EmpleadoId);
}

    var guardaRol = () => {
        var Nombre = document.getElementById('Nombre').value;
        var RolId = document.getElementById('RolId').value;
        if (RolId == '')
        {
            RolId = '0';
            var accion = 'Rols/ControladorGuardaRol';
        } else
        {
            var accion = '';
        }
        var graba = new ClaseRol(Nombre, accion);
        graba.guardarol(CiudadId);
    }

// Write your JavaScript code.

$().ready(() => {
    sitelistaindexpro();

    ListaTipo_inmu();

    //ListaInmueble();

});





var sitelistaindexpro = () => {
    var accion = 'Propietarios/Controladorlistaindexpro';
    var clspropie = new ClasePropietario('', '', '', '', '', '', '', accion);
    clspropie.listaindex();
}


var grabaPropietario = () => {
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

var Cargapropie = (PropietarioId) => {
    var accion = 'Propietarios/ControladorUnpropi';
    var clspropieta = new ClasePropietario('', '', '', '', '', '', '', accion);
    clspropieta.Cargarpropi(PropietarioId);
}

var ListaTipo_inmu = () => {
    var accion = 'Tipos_inmu/ControladorListaTipoinmu';
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
var CargaParaImpresionInmueble = () => {
    var accion = 'Inmuebles/ContronladorImprimirInmueble';
    var carga = new ClaseInmueble('', accion);
    carga.ImprimirInmuebe();
}
// Write your JavaScript code.
$().ready(() => {
    //sitelistaindexpro();

    ListaTipo_inmu();

    // ListaInmueble();


    ListaInmueble();

});
var ListaTipo_inmu = () => {
    var accion = 'Tipos_inmus/ControladorListaTipoinmu';
    var tipoinmu = new ClaseTipoinmu('', accion);
    tipoinmu.ListadeTipoinmu();
}
var CargaTipoinmu = (tipoinmuId) => {
    var accion = 'Tipos_inmus/ControladorUnTipoinmu';
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
    var accion = 'Tipos_inmus/ContronladorImprimirTipoinmu';
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

var ListaInmueble = () => {
    var accion = 'Inmuebles/ControladorListaInmueble';
    var inmu = new ClaseInmueble('', accion);
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
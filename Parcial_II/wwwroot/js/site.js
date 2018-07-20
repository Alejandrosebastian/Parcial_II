// Write your JavaScript code.






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
    clspropieta.Cargapropi(PropietarioId);
}

class ClasePropietario {

    constructor(Nombre1, Nombre2, Apellido1, Apellido2, Direccion, Correo, Telefono, accion) {
        this.Nombre1 = Nombre1;
        this.Nombre2 = Nombre2;
        this.Apellido1 = Apellido1;
        this.Apellido2 = Apellido2;
        this.Direccion = Direccion;
        this.Correo = Correo;
        this.Telefono = Telefono;
        this.accion = accion;
    }

    guardarpropietario(id) {
        var nombre1 = this.Nombre1;
        var nombre2 = this.Nombre2;
        var apellido1 = this.Apellido1;
        var apellido2 = this.Apellido2;
        var direccion = this.Direccion;
        var telefono = this.Telefono;
        var correo = this.Correo;
        var accion = this.accion;
        if (id == '0') {
            $.ajax(
                {
                    type: "POST",
                    url: accion,
                    data: {
                        nombre1,
                        nombre2,
                        apellido1,
                        apellido2,
                        direccion,
                        telefono,
                        correo},
                    success: (respuesta) => {
                        if (respuesta[0].code == 'save') {
                            $('#IngresoPropietario').modal('hide');
                            this.limpiarcajaspro();
                        }
                    }
                });
        }
        else {
            // codigo actualizar
            $.ajax(
                {
                    type: "POST",
                    url: accion,
                    data: {
                        nombre1,
                        nombre2,
                        apellido1,
                        apellido2,
                        direccion,
                        telefono,
                        correo,
                        id
                    },
                    success: (respuesta) => {
                        if (respuesta[0].code == 'save') {
                            this.limpiarcajas();
                        }
                    }
                });
        }


    }

    listaindex() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $("#Listapropietario").html(val[0]);
                });
            }
        });
    }

    Cargarpropi(PropietarioId) {
        var accion = this.accion;

        $.ajax({
            type: "POST",
            url: accion,
            data: {PropietarioId},
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById('Nombre1').value = respuesta[0].Nombre1;
                document.getElementById('Nombre2').value = respuesta[0].Nombre2;
                document.getElementById('Apellido1').value = respuesta[0].Apellido1;
                document.getElementById('Apellido2').value = respuesta[0].Apellido2;
                document.getElementById('Direccion').value = respuesta[0].Direccion;
                document.getElementById('Correo').value = respuesta[0].Correo;
                document.getElementById('Telefono').value = respuesta[0].Telefono;
                document.getElementById('PropietarioId').value = respuesta[0].PropietarioId;
            }
        });
    }

    limpiarcajaspro() {
        document.getElementById('Nombre1').value = '';
        document.getElementById('Nombre2').value = '';
        document.getElementById('Apellido1').value = '';
        document.getElementById('Apellido2').value = '';
        document.getElementById('Direccion').value = '';
        document.getElementById('Correo').value = '';
        document.getElementById('Telefono').value = '';
        document.getElementById('PropietarioId').value = '';
        $('#IngresoPropietario').modal('hide');
        listaindex();
    }

}
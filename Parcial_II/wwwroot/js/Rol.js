class ClaseRol {

    constructor(Nombre, accion)
    {
        this.Nombre = Nombre;
        this.accion = accion;
    }

    guardarrol(id) {
        var nombre = this.Nombre;
        var accion = this.accion;
        if (id == '0') {
            $.ajax(
                {
                    type: "POST",
                    url: accion,
                    data: {
                        nombre,
                    },
                    success: (respuesta) => {
                        if (respuesta[0].code == 'save') {
                            this.limpiarcajasrol();
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
                        nombre,
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
                    $("#ListaRol").html(val[0]);
                });
            }
        });
    }

    Cargarrol(RolId) {
        var accion = this.accion;

        $.ajax({
            type: "POST",
            url: accion,
            data: { RolId },
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById('Nombre').value = respuesta[0].Nombre;
                document.getElementById('RolId').value = respuesta[0].RolId;
            }
        });
    }

    limpiarcajasrol() {
        document.getElementById('Nombre').value = '';
        document.getElementById('RolId').value = '';
        $('#IngresoRol').modal('hide');
        listaindex();
    }

}
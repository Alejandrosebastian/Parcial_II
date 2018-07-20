class ClaseRol {
    constructor(Nombre, accion) {
        this.Nombre = Nombre;
        this.accion = accion;
    }

    guardaciudad(id) {
        var Nombre = this.Nombre;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: {
                    Nombre
                },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }
        else {
            $.ajax({
                type: "POST",
                url: accion,
                data{
                    Nombre,
                    id
                },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }



                }
            })
        }
    }
    listaindex() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion ,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, va) => {
                    $('#ListaRol').html(val[0]);
                });
            }

        });
    }

    limpiarcajas() {
        document.getElementById('Nombre').value = '';
        document.getElementById('RolId').value = '';
        $('#Ingresorol').modal('hide');
        listaindex();
    }

}
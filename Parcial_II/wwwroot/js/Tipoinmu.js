class ClaseTipoinmu {
    constructor(nombre, accion) {
        this.nombre = nombre;
        this.accion = accion;
    }
    GuardarTipoinmu(id) {
        var nombre = this.nombre;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { nombre },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        } else {
            $.ajax({
                type: "POST",
                url: accion,
                data: { id, nombre },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }

    ListadeTipoinmu() {

        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaTipoinmu').html(val[0]);
                });
            }
        });
    }
    CargarTipoinmu(Tipos_inmuId) {
        var accion = this.accion;

        $.post(
            accion,
            { Tipos_inmuId },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('nombre').value = respuesta[0].nombre;
                document.getElementById('tipoinmuId').value = respuesta[0].Tipos_inmuId;

            }
        );


    }
    //EliminarTipoinmu(id) {
    //    var accion = this.accion;
    //    $.ajax({
    //        type: "POST",
    //        url: accion,
    //        data: { id },
    //        success: (respuesta) => {
    //            if (respuesta[0].code == 'Save') {
    //                this.limpiarcajas();
    //            }
    //        }
    //    });
    //}
    ImprimirTipoinmu() {
        var accion = this.accion;
        $.post(accion, {},
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#CuerpoImpresionTipoinmu').html(respuesta[0]);
                });
            }
        );
    }

    limpiarcajas() {
        document.getElementById('nombre').value = '';
        document.getElementById('tipoinmuId').value = '';
        //$('#sexo').value = '';
        $('#IngresoTipoinmu').modal('hide');
        ListaTipo_inmu();
    }
}
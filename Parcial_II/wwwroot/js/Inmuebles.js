class ClaseInmueble {
    constructor(direccion, N_habitaciones, costo, activo, propietarioid, parroquiaid, Tipos_inmuId, accion) {
        this.direccion = direccion;
        this.N_habitaciones = N_habitaciones;
        this.costo = costo;
        this.activo = activo;
        this.propietarioid = propietarioid;
        this.parroquiaid = parroquiaid;
        this.Tipos_inmuId = Tipos_inmuId;
        this.accion = accion;
    }
    GuardarInmueble(id) {
        var direccion = this.direccion;
        var nhabitacion = this.N_habitaciones;
        var costo = this.costo;
        var activo = this.activo;
        var pro = this.propietarioid;
        var parro = this.parroquiaid;
        var tipo = this.Tipos_inmuId;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { direccion, nhabitacion, costo, activo, pro, parro, tipo },
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
                data: { id, direccion, nhabitacion, costo, activo, pro, parro, tipo },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }

    ListadeInmueble() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaInmuebl').html(val[0]);
                });
            }
        });
    }
    CargarInmueble(inmuebleId) {
        var accion = this.accion;

        $.post(
            accion,
            { inmuebleId },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('direccion').value = respuesta[0].direccion;
                document.getElementById('nhabitacion').value = respuesta[0].N_habitaciones;
                document.getElementById('costo').value = respuesta[0].Costo;
                document.getElementById('activo').value = respuesta[0].Activo;
                document.getElementById('pro').value = respuesta[0].PropioId;
                document.getElementById('parro').value = respuesta[0].ParroquiaId;
                document.getElementById('tipo').value = respuesta[0].Tipos_inmuId;
                document.getElementById('id').value = respuesta[0].InmuebleId;
                //localStorage.setItem("sexoId", JSON.respuesta[0].sexoId);

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
    ImprimirInmueble() {
        var accion = this.accion;
        $.post(accion, {},
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#CuerpoImpresionInmueble').html(respuesta[0]);
                });
            }
        );
    }

    limpiarcajas() {
        document.getElementById('direccion').value = '';
        document.getElementById('nhabitacion').value = '';
        document.getElementById('costo').value = '';
        document.getElementById('activo').value = '';
        document.getElementById('pro').value = '';
        document.getElementById('parro').value = '';
        document.getElementById('tipo').value = '';
        document.getElementById('id').value = '';
        //$('#sexo').value = '';
        $('#IngresoInmueble').modal('hide');
        ListaInmueble();
    }
}
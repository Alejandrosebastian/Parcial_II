class Claseclientejs {
    constructor(Cedula, Primernombre, Segundonombre, Primerapellido, Segundoapellido,
        Telefono, Correo, Tipo_prefe_inmueble, Importe_maximo, Fecha_registro, ClienteId, accion) {
        this.Cedula = Cedula;
        this.Primernombre = Primernombre;
        this.Segundonombre = Segundonombre;
        this.Primerapellido = Primerapellido;
        this.Segundoapellido = Segundoapellido;
        this.Telefono = Telefono;
        this.Correo = Correo;
        this.Tipo_prefe_inmueble = Tipo_prefe_inmueble;
        this.Importe_maximo = Importe_maximo;
        this.Fecha_registro = Fecha_registro;
        this.ClienteId = ClienteId;
        this.accion = accion;
    }
    claseGuardarCliente(id) {
        var cedula = this.Cedula;
        var primernombre = this.Primernombre;
        var segundonombre = this.Segundonombre;
        var primerapellido = this.Primerapellido;
        var segundoapellido = this.Segundoapellido;
        var telefono = this.Telefono;
        var correo = this.Correo;
        var tipo_prefe_inmueble = this.Tipo_prefe_inmueble;
        var importe_maximo = this.Importe_maximo;
        var fecha_registro = this.Fecha_registro;
        var ClienteId = this.ClienteId;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: {
                    cedula,
                    primernombre,
                    segundonombre,
                    primerapellido,
                    segundoapellido,
                    telefono,
                    correo,
                    tipo_prefe_inmueble,
                    importe_maximo,
                    fecha_registro,
                    ClienteId
                },
                success: (respuesta) => {

                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }

                }
            });

        }
        else {
            $.ajax(
                {
                    type: "POST",
                    url: accion,
                    data: {
                        cedula,
                        primernombre,
                        segundonombre,
                        primerapellido,
                        segundoapellido,
                        telefono,
                        correo,
                        tipo_prefe_inmueble,
                        importe_maximo,
                        fecha_registro,
                        ClienteId,
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
                    $("#ListaClientes").html(val[0]);
                });
            }
        });
    }

    CargarCliente(PropietarioId) {
        var accion = this.accion;

        $.ajax({
            type: "POST",
            url: accion,
            data: { PropietarioId },
            success: (respuesta) => {
                console.log(respuesta);
                document.getElementById('Cedula').value = respuesta[0].Cedula;
                document.getElementById('Primernombre').value = respuesta[0].Primernombre;
                document.getElementById('Segundonombre').value = respuesta[0].Segundonombre;
                document.getElementById('Primerapellido').value = respuesta[0].Primerapellido;
                document.getElementById('Segundoapellido').value = respuesta[0].Segundoapellido;
                document.getElementById('Telefono').value = respuesta[0].Telefono;
                document.getElementById('Correo').value = respuesta[0].Correo;
                document.getElementById('Tipo_prefe_inmueble').value = respuesta[0].Tipo_prefe_inmueble;
                document.getElementById('Importe_maximo').value = respuesta[0].Importe_maximo;
                document.getElementById('Fecha_registro').value = respuesta[0].Fecha_registro;
            
            }
        });
    }

    limpiarcajaspro() {
        document.getElementById('Cedula').value ='';
        document.getElementById('Primernombre').value = '';
        document.getElementById('Segundonombre').value = '';
        document.getElementById('Primerapellido').value = '';
        document.getElementById('Segundoapellido').value = '';
        document.getElementById('Telefono').value = '';
        document.getElementById('Correo').value = '';
        document.getElementById('Tipo_prefe_inmueble').value = '';
        document.getElementById('Importe_maximo').value = '';
        document.getElementById('Fecha_registro').value = '';
        document.getElementById('ClienteId').value = '';
        $('#IngresoClientes').modal('hide');
        listaindex();
    }
}
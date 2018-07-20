



class ClaseCiudad {
    constructor(Nombre, accion) {
        this.Nombre = Nombre;
        this.accion = accion;
    }

    guardaciudad(id) {
        var Nombre = this.Nombre;
        var Ciudad = this.CiudadId;
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
                data: { 
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
    CargaCiudad(CiudadId) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { CiudadId },
            success: (respuesta) => {
                console.getElementById('Nombre').value = respuesta[0].Nombre;
            }

        });
    }
    listaindex() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion ,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaCiudad').html(val[0]);
                });
            }

        });
    }

    limpiarcajas(){
            document.getElementById('Nombre').value = '';
             document.getElementById('CiudadId').value='';
            $('#Ingresociudad').modal('hide');
            listaindex();
    }
    
}
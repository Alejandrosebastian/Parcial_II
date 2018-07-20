class claseEmpleado { 
    constructor(primernombre, segundonombre, primerapellido, segundoapellido, direccion, salario, correo, fecha_nacimiento, edad, UsuarioId, CategoriaLaboralId, accion) {
        this.primernombre = primernombre;
        this.segundonombre = segundonombre;
        this.primerapellido = primerapellido;
        this.segundoapellido = segundoapellido;
        this.direccion = direccion;
        this.salario = salario;
        this.correo = correo;
        this.fecha_nacimiento = fecha_nacimiento;
        this.edad = edad;
        this.accion = accion;
    }  
    GuardarEmpleado(id) {
        var primernombre = this.primernombre;
        var segundonombre = this.segundonombre;
        var primerapellido = this.primerapellido;
        var segundoapellido = this.segundoapellido;
        var direccion = this.direccion;
        var salario = this.salario;
        var correo = this.correo;
        var fecha_nacimiento = this.fecha_nacimiento;
        var edad = this.edad;
        var usuarioid = this.UsuarioId;
        var CategorialaboralId = this.CategoriaLaboralId;
        var accion = this.accion;
        var resultado = '';
        if (id === '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { primernombre, segundonombre, primerapellido, segundoapellido, direccion, salario, correo, fecha_nacimiento, edad, UsuarioId, CategoriaLaboralId },
                success: (respuesta) => {
                    if (respuesta[0].code == "save") {
                        this.limpiarcajas();
                    }
                }
            });
        }
        else {
            $.ajax({
                type: "POST",
                url: accion,
                data: { id, primernombre, segundonombre, primerapellido, segundoapellido, direccion, salario, correo, fecha_nacimiento, edad },
                success: (respuesta) => {
                    if (respuesta[0].code == "save") {
                        this.limpiarcajas();
                    }
                }

            });
        }
    }
    ListadeEmpleado() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListadeEmpleado').html(val[0]);
                });
            }
        });
    }
    CargarEmpleados(EmpleadoId) {
        var accion = this.accion;

        $.post(
            accion,
            { EmpleadoId },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('empleID').value = respuesta[0].EmpleadoId;
                document.getElementById('primernombre').value = respuesta[0].primernombre;
                document.getElementById('segundonombre').value = respuesta[0].segundonombre;
                document.getElementById('primerapellido').value = respuesta[0].primerapellido;
                document.getElementById('segundoapellido').value = respuesta[0].segundoapellido;
                document.getElementById('direccion').value = respuesta[0].direccion;
                document.getElementById('salario').value = respuesta[0].salario;
                document.getElementById('correo').value = respuesta[0].correo;
                document.getElementById('fecha_naci').value = respuesta[0].fecha_nacimiento;
                document.getElementById('edad').value = respuesta[0].edad;
                document.getElementById('UsuarioId').value = respuesta[0].UsuarioId;
                document.getElementById('CategoriaLaboralId ').value = respuesta[0].CategoriaLaboralId;


            }
        );


    }
    ImprimirEmpleados() {
        var accion = this.accion;
        $.post(accion, {},
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#CuerpoImpresionEmpleado').html(respuesta[0]);
                });
            }
        );
    }

    limpiarcajas() {

        document.getElementById('empleID').value = '';
        document.getElementById('primernombre').value = '';
        document.getElementById('segundonombre').value = '';
        document.getElementById('primerapellido').value = '';
        document.getElementById('segundoapellido').value = '';
        document.getElementById('direccion').value = '';
        document.getElementById('salario').value = '';
        document.getElementById('correo').value = '';
        document.getElementById('fecha_naci').value = '';
        document.getElementById('edad').value = '';
        document.getElementById('UsuarioId').value = '';
        document.getElementById('CategoriaLaboralId').value = '';


        $('#IngresoEmpleado').modal('hide');
        ListadeEmpleado();

    }

}


class ClaseContrato {
    constructor(deposito, Duracion, fecha_ini, fecha_vence, TipopagosId, SucursalId, ClienteId, accion) {
        this.deposito = deposito;
        this.Duracion = Duracion;
        this.fecha_ini = fecha_ini;
        this.fecha_vence = fecha_vence;
        this.TipopagosId = TipopagosId;
        this.SucursalId = SucursalId;
        this.ClienteId = ClienteId;
        this.accion = accion;
    }
    guardarContrato(id) {
        var deposito = this.deposito;
        var Duracion = this.Duracion;
        var fecha_ini = this.fecha_ini;
        var fecha_vence = this.fecha_vence;
        var TipopagosId = this.TipopagosId;
        var SucursalId = this.SucursalId;
        var ClienteId = this.ClienteId;
        var accion = this.accion;
        if (id == '0') {
            $.ajax(
                {
                    type: "POST",
                    url: accion,
                    data: {
                        deposito,
                        Duracion,
                        fecha_ini,
                        fecha_vence,
                        TipopagosId,
                        SucursalId,
                        ClienteId
                    },
                    success: (respuesta) => {
                        if (respuesta[0].code == 'save') {
                            this.limpiarcajascont();
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
                        deposito,
                        Duracion,
                        fecha_ini,
                        fecha_vence,
                        TipopagosId,
                        SucursalId,
                        ClienteId,
                        id
                    },
                    success: (respuesta) => {
                        if (respuesta[0].code == 'save') {
                            this.limpiarcajascont();
                        }
                    }
                });
        }
    }
}
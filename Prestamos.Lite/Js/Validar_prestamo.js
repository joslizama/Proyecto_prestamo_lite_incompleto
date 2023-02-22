$(document).ready(function () {
$("#Validar_prestamos").validate({

    rules: {

        tmoneda: {

            required:true,
            number: true,
            min: 1


        },
        tpago: {

            required: true,
            number: true,
            min:1

        },
        monto: {

            required: true,
            number: true

        },
        cuotas: {

            required: true,
            number: true,
            min:1


        },
        fechainicio: {

            required: true,
            date:true
        },
        fechafin: {

            required: true,
            date: true

        },
        interes: {

            required: true,
            number:true

        },
        mcuotassininteres: {

            required: true,
            number: true


        },
        mcuotasconinteres: {

            required: true,
            number:true
        },
        total: {

            required: true,
            number:true

        },
        rcliente: {

            required: true
        },
        clausulas: {

            required: true
        }


    },
    messages: {


        tmoneda: {

            required: "Campo obligatorio",
            number: "Debe ser una moneda valida",
            min: "El campo no debe ser null"


        },
        tpago: {

            required: "Campo obligatorio",
            number: "Debe ser un pago valido",
            min: "El campo no debe ser null"

        },
        monto: {

            required: "Campo obligatorio",
            number: "Campo numerico",

        },
        cuotas: {

            required: "Campo obligatorio",
            number: "Campo numerico",
            min: "Minimo una cuota"


        },
        fechainicio: {

            required: "Campo obligatorio",
            date: "Debe ser una fecha valida"
        },
        fechafin: {

            required: "Campo obligatorio",
            date: "Debe ser una fecha valida"

        },
        interes: {

            required: "Campo obligatorio",
            number: "Campo numerico"

        },
        mcuotassininteres: {

            required: "Campo obligatorio",
            number: "Campo numerico"


        },
        mcuotasconinteres: {

            required: "Campo obligatorio",
            number: "Campo numerico"
        },
        total: {

            required: "Campo obligatorio",
            number: "Campo numerico"

        },
        rcliente: {

            required: "Campo obligatorio"
        },
        clausulas: {

            required: "Campo obligatorio"
        }




    }








});
});
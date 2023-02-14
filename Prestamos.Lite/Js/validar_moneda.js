$(document).ready(function () {
$("#validar_monedas").validate({


    rules: {

        nombre: {

            required: true

        },
        abreviatura: {

            required: true


        }

    },
    messages: {


        nombre: {

            required: "Campo obligatorio"

        },
        abreviatura: {

            required: "Campo obligatorio"


        }



    }





});

});
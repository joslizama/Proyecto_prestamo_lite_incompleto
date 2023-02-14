$(document).ready(function () {
$("#Validar_login").validate({

    rules: {

        rut: {

            required: true

        },
        contraseña: {

            required: true

        }

    },
    messages: {

        rut: {

            required: "Campo obligatorio"

        },
        contraseña: {

            required: "Campo obligatorio"

        }


    }





});
});
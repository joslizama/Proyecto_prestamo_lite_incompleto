$(document).ready(function () {
$("#validar_usuarios").validate({

    rules: {

        rut: {

            required: true

        },
        fecha: {

            required: true,
            date: true


        },
        nombre: {

            required: true


        },
        apellido: {

            required: true

        },
        direccion: {

            required: true


        },
        comuna: {

            required: true
        },
        correo: {

            required: true,
            email: true


        },
        ciudad: {

            required: true

        },
        telefono: {

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
        fecha: {

            required: "Campo obligatorio",
            date: "Debe ser fecha valida"


        },
        nombre: {

            required: "Campo obligatorio"


        },
        apellido: {

            required: "Campo obligatorio"

        },
        direccion: {

            required: "Campo obligatorio"


        },
        comuna: {

            required: "Campo obligatorio"
        },
        correo: {

            required: "Campo obligatorio",
            email: "Debe ser correo electronico"


        },
        ciudad: {

            required: "Campo obligatorio"

        },
        telefono: {

            required: "Campo obligatorio"
        },
        contraseña: {

            required: "Campo obligatorio"



        }



    }






});
});
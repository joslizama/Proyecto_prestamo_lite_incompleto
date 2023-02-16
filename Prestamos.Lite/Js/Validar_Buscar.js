$(document).ready(function () {
    $("#Buscar_clientes").validate({

        rules: {

            tipo: {

                required: true,
                number: true,
                min:1


            }


        },
        messages: {

            tipo: {

                required: "Campo obligatorio",
                number: "Tipo de usuario debe ser valido",
                min: "Tipo de usuario debe ser valido"


            }

        }






    });
});

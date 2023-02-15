$(document).ready(function () {
$("#validar_pagos").validate({

    rules: {

        nombre_tpago: {


            required: true
        },

        valor: {

            required: true

        },
        descripcion: {

            required: true


        }

        



    },
    messages: {


        nombre_tpago: {


            required: "Campo obligatorio"
        },

        valor: {

            required: "Campo obligatorio"

        },
        descripcion: {

            required: "Campo obligatorio"


        }


    }







});
});
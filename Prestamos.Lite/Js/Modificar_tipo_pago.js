$(document).ready(function () {
$("#Modificar").click(function () {

    var nombre_tpago = $("#nombre_tpago").val();
    var valor = $("#valor").val();
    var descripcion = $("#descripcion").val(); 


    if (nombre_tpago == null || nombre_tpago == "" || valor == null || valor == "" || descripcion == null || descripcion == "") {
        return false;
    } else {


        $.ajax({

            type: "POST",
            url: "/Admin/Mtpagoc",
            data: {

                nombre_tpago: nombre_tpago,
                descripcion: descripcion,
                valor: valor

            },
            datatype: "Json",

            success: function (data)
            {
                alert("Modificando");

                window.location.href = "/Admin/Ltpago";
            }




        });




    }



});
});
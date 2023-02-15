$(document).ready(function () {
$("#Nuevo").click(function () {

    var nombre_tpago = $("#nombre_tpago").val();
    var valor = $("#valor").val();
    var descripcion = $("#descripcion").val(); 


    if (nombre_tpago == null || nombre_tpago == "" || valor == null || valor == "" || descripcion == null || descripcion == "") {
        return false;
    } else {



        $.ajax({

            type: "POST",
            url: "/Admin/Ntipopagoc",
            data: {

                nombre_tpago: nombre_tpago,
                descripcion: descripcion,
                valor: valor
            },
            datatype: "Json",
            success: function (data)
            {
                alert("Agregando");
            }



        });


    }






});
});
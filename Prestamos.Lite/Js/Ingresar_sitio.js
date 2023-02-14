$(document).ready(function () {
$("#Ingresar").click(function () {

    var rut = $("#rut").val();
    var contraseña = $("#contraseña").val();

    if (rut == null || rut == "" || contraseña == null || contraseña == "") {
        return false;


    } else {


        $.ajax({

            type: "POST",
            url: "/Home/Logc",
            data: {

                rut: rut,
                contraseña: contraseña

            },
            datatype: "Json",
            success: function (data)
            {
                alert("Ingresando");
            }



        });



    }





});
});
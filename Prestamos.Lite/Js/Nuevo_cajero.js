$(document).ready(function () {
$("#Nuevo").click(function () {


    var rut = $("#rut").val();
    var fecha = $("#fecha").val();
    var nombre = $("#nombre").val();
    var apellido = $("#apellido").val();
    var direccion = $("#direccion").val();
    var comuna = $("#comuna").val();
    var ciudad = $("#ciudad").val();
    var correo = $("#correo").val();
    var telefono = $("#telefono").val();
    var contraseña = $("#contraseña").val(); 


    if (rut == null || rut == "" || fecha == null || fecha == "" || nombre == null || nombre == "" || apellido == null || apellido == "" ||
        direccion == null || direccion == "" || comuna == null || comuna == "" || ciudad == null || ciudad == "" || correo == null || correo == ""||
    telefono == null || telefono == "" || contraseña == null || contraseña == ""){
        return false;
    }else {


        $.ajax({

            type: "POST",
            url: "/Admin/Ncajeroc",
            data: {

                rut: rut,
                fecha: fecha,
                nombre: nombre,
                apellido: apellido,
                direccion: direccion,
                comuna: comuna,
                ciudad: ciudad,
                correo: correo,
                telefono: telefono,
                contraseña: contraseña

            },
            datatype: "Json",
            success: function (data)
            {
                alert("Agregando"); 

                window.location.href = "/Admin/Lclientes";

            }



        })




    }





});
});
$(document).ready(function () {
$("#Modificar").click(function () {


    var nombre = $("#nombre").val();
    var abreviatura = $("#abreviatura").val(); 


    if (nombre == null || nombre == "" || abreviatura == null || abreviatura == "") {
        return false;
    } else {


        $.ajax({

            type: "POST",
            url: "/Admin/Mtmonedac",
            data: {

                nombre: nombre,
                abreviatura: abreviatura
            },
            datatype: "Json",
            success: function (data)
            {
                alert("Modificando");

                window.location.href = "/Admin/Ltmonedas";
            }




        });




    }


});
});
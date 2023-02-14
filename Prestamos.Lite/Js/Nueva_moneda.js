$(document).ready(function () {
$("#Nuevo").click(function () {

    var nombre = $("#nombre").val();
    var abreviatura = $("#abreviatura").val();


    if (nombre == null || nombre == "" || abreviatura == null || abreviatura == "")
    {
        return false;
    } else{

        $.ajax({

            type: "POST",
            url: "/Admin/Ntmonedasc",
            data: {

                nombre: nombre,
                abreviatura: abreviatura

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
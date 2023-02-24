function llenar()
{


        var m = document.getElementById("monto").value;
        var c = document.getElementById("cuotas").value;

        var f = m / c;

        document.getElementById("mcuotassininteres").value = f;



}

function llenar2()
{
    var m = document.getElementById("monto").value;
    var c = document.getElementById("cuotas").value;

    var f = m / c;

    //Hacer la operacion matematica 

    var f2 = f * 0.19; 
    var f3 = f + f2; 
    document.getElementById("mcuotasconinteres").value = f3;


}

function llenar3()
{
    var m = document.getElementById("monto").value;
    var i = document.getElementById("interes").value;

    var f = parseFloat(m * i); 

    var f2 = parseFloat(m + f);


    document.getElementById("total").value = f2;

    
}





$(document).ready(function () {


    $("#Nuevo").click(function () {



    var tmoneda = $("#tmoneda").val();
    var tpago = $("#tpago").val();
    var monto = $("#monto").val();
    var cuotas = $("#cuotas").val();
    var fechainicio = $("#fechainicio").val();
    var fechafin = $("#fechafin").val();
    var interes = $("#interes").val();
    var mcuotassininteres = $("#mcuotassininteres").val();
    var mcuotasconinteres = $("#mcuotasconinteres").val();
    var total = $("#total").val();
    var rcliente = $("#rcliente").val();
    var clausulas = $("#clausulas").val(); 


        if (tmoneda == null || tmoneda == "" || tpago == null || tpago == "" || monto == null || monto == "" || cuotas == null || cuotas == "" ||
            fechainicio == null || fechainicio == "" || fechafin == null || fechafin == "" || interes == null || interes == "" || mcuotassininteres == null || mcuotassininteres == "" ||
            mcuotasconinteres == null || mcuotasconinteres == "" || total == null || total == "" || rcliente == null || rcliente == "" || clausulas == null || clausulas == "") {
            return false;
        } else {


            $.ajax({

                type: "POST",
                url: "/Admin/Nprestamosc",
                data: {

                    tmoneda: tmoneda,
                    tpago: tpago,
                    monto: monto,
                    cuotas: cuotas,
                    fechainicio: fechainicio,
                    fechafin: fechafin,
                    interes: interes,
                    mcuotassininteres: mcuotassininteres,
                    mcuotasconinteres: mcuotasconinteres,
                    total: total,
                    rcliente: rcliente,
                    clausulas: clausulas
                },
                datatype: "Json",
                success: function (data)
                {
                    alert("Agregando");
                    window.location.href = "/Admin/Lprestamos";
                }





            });





        }











});
});

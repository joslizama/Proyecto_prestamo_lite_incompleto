$(document).ready(function () {


    var tmoneda = $("#tmoneda").val();
    var tpago = $("#tpago").val();
    var fechainicio = $("#fechainicio").val();
    var fechafin = $("#fechafin").val();
    var interes = $("#interes").val();
    var mcuotassininteres = $("#mcuotassininteres").val();
    var mcuotasconinteres = $("#mcuotasconinteres").val();
    var total = $("#total").val();
    var rcliente = $("#rcliente").val();
    var clausulas = $("#clausulas").val();


    function llenar()
    {

    }







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
                }





            });





        }











});
});

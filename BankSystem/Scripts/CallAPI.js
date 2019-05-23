//este api es para llenar los dropdown
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "http://localhost:51790/api/Account",
        data: "{}",  
        success: function (data) {
            var s = '<option value="-1">Please Select a Account</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].AccountNumber + '">' + data[i].Client.Name +' '+ '('+data[i].AccountNumber +' - '+'RD$'+data[i].Balance.toFixed(2) +')'+ '</option>';
            }
            $("#inputFromAccount").html(s);
            $("#inputToAccount").html(s);
        }
    });
   
    $("#inputToAccount").change(function () {
        var fromAccount = $("#inputFromAccount").val();
        var toAccount = $("#inputToAccount").val();
        if (fromAccount == toAccount) {
            alert("No se puede hacer transacción entre cuentas iguales");
            $("#inputToAccount").val('');
        }
    });
    $("#inputFromAccount").change(function () {

        var fromAccount = $("#inputFromAccount").val();
        var toAccount = $("#inputToAccount").val();
        if (fromAccount == toAccount) {
            alert("No se puede hacer transacción entre cuentas iguales");
            $("#inputToAccount").val('');
        }
    });
});

//este metodo fue creado para guardar la transaccion
function process() {

    var amount = $("#inputAmount").val();
    var fromAccount = $("#inputFromAccount").val();
    var toAccount = $("#inputToAccount").val();
        var transaction = {
            'fromAccountNumber': fromAccount,
            'toAccountNumber': toAccount,
            'amount': amount
    };

        $.ajax({
            url: "http://localhost:51790/api/Transaction",
            type: "POST",
            data: JSON.stringify(transaction),
            contentType: "application/json",
            success: function (data) {
                alert("Transacción realizada con éxito");
                $("#inputFromAccount").val('');
                $("#inputToAccount").val('');
                $("#inputAmount").val('');
            },
            error: function (data) {
                alert(data.responseJSON.Message)

            }
    });
  
    
}
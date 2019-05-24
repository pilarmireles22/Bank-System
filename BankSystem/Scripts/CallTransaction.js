$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/api/Account",
        success: function (data) {
            var a;
            for (var i = 0; i < data.length; i++) {
                a += '<tr>< th scope = "row" ></th ><td>' + data[i].AccountID + '</td><td>' + data[i].Bank.Name + '</td><td>' + data[i].Client.Name + '</td><td>' + data[i].AccountNumber + '</td><td>' + 'RD$' + data[i].Balance.toFixed(2) + '</td></tr>';
            }
            $("#ViewBalance").html(a);
        }
    });
});

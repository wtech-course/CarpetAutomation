$(document).ready(function () {
    debugger;
    $.ajax({
        url: "https://localhost:44384/api/login/create",
        type: 'GET',
        contentType: "application/json;charset-utf-8",
        dataType: "json",
        success: function (res) {
            console.log("data2", res);
            $.each(res.result, function (i, item) {
                var rows = "<tr>" +
                    "<td id='name'>" + item.name + "</td>" +
                    "<td id='address'>" + item.address + "</td>" +
                    "</tr>";
                $('#Table').append(rows);
            });
        }
    });
});

let today;
let tomorrow;
let origin;
let destination;

$(document).ready(function () {
    today = new Date();
    tomorrow = new Date(today);
    tomorrow.setDate(tomorrow.getDate() + 1);
    today = today.toJSON();
    tomorrow = tomorrow.toJSON();

    $("#date").attr("min", today.slice(0, 10));

    $("#date").val(today.slice(0, 10));
    let selectedValue = $("#origin").val();
    let selectedValue2 = $("#destination").val();

    if (selectedValue == "1" || selectedValue2 == "1") {
        $(":submit").attr("disabled", true);
    }
  
});

function getToday() {
    $("#date").val(today.slice(0, 10));
}
function getTomorrow() {
    $("#date").val(tomorrow.slice(0, 10));
}

$('#origin').on('change', function () {
    $(":submit").attr("disabled", false);
    origin = this.value;
    if (origin == destination) {
        alert("Aynı şehir seçilemez!");
        $("#origin").val("1");
    }
});

$('#destination').on('change', function () {
    $(":submit").attr("disabled", false);
    destination = this.value;
    if (destination == origin) {
        alert("Aynı şehir seçilemez!");
        $("#destination").val("1");
    }
    
});





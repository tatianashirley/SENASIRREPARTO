function ChangeCalendarView(sender, args) {
    sender._switchMode("years", true);
}
function setDate(sender, args) {
    var d = new Date(); //Hoy
    d.setYear(d.getFullYear() - 19); //19 años atras
    $find("myDate").set_selectedDate(d);
}
function efecto(id) {
    $('#' + id).show();
}
function disableEnterKey(e) {
    var key;
    if (window.event) {
        key = window.event.keyCode; //IE
    } else {
        key = e.which; //firefox 
    }
    if (key == 13) {
        return false;
    } else {
        return true;
    }
}

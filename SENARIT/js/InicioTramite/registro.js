//habilita cambio de años en el calendario
function ChangeCalendarView(sender, args) {
    sender._switchMode("years", true);
}
function setDate(sender, args) {
    var d = new Date(); //Hoy
    d.setYear(d.getFullYear() - 19); //19 años atras 
    $find("myDate").set_selectedDate(d);
}
function setDateEmp1(sender, args) {
    var d = new Date(); //Hoy
    d.setYear(d.getFullYear() - 19); //19 años atras 
    $find("myDateEmpDesde").set_selectedDate(d);
}
function setDateEmp2(sender, args) {
    var d = new Date(); //Hoy
    d.setYear(d.getFullYear() - 19); //19 años atras 
    $find("myDateEmpHasta").set_selectedDate(d);
}
function PrintPanel(id) {
    var panel = document.getElementById(id);
    var printWindow = window.open('', '', 'height=400,width=800');
    printWindow.document.write('<html><head><title>Preview</title>');
    printWindow.document.write('</head><body >');
    printWindow.document.write(panel.innerHTML);
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    setTimeout(function () {
        printWindow.print();
    }, 500);
    return false;
}
function efecto(id) {
    $('#'+id).show();
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
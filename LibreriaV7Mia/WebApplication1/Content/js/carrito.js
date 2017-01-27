(function () {
    $("#cart").on("click", function () {
        $(".shopping-cart").fadeToggle("fast");
    });

})();
var total = function (precio) {
    var cosa=document.getElementById("total").innerHTML;
    cosa=cosa.replace("Total:","");
    cosa=cosa.replace("€","");
    var totalCarrito = parseFloat(cosa) + parseFloat(precio);
    document.getElementById("total").innerHTML = "Total:" + extraerDecimales(totalCarrito,2) + "€";
}
anadirCarrito = function (titulo, codigo, precio) {
    var nodo = document.createElement("li");
    nodo.innerHTML = codigo + ": " + titulo.replace(/_/gi, " ") + " " + precio + "€";
    nodo.setAttribute("value", codigo);
    nodo.setAttribute("name", "libro");
    document.getElementById("elementos").appendChild(nodo);
    document.getElementById("carrito").innerHTML = parseInt(document.getElementById("carrito").innerHTML) + 1;
    document.getElementById("cesta").innerHTML = parseInt(document.getElementById("cesta").innerHTML) + 1;
    var mycookie = getCookie("CODIGO");
    if (mycookie==null) {
        document.cookie = "CODIGO=" + codigo + ";path=/Inicio";
    } else {
        document.cookie ="CODIGO="+ mycookie + "_" + codigo + ";path=/Inicio";
    }
    //if (document.cookie.startsWith("_")) {
    //    document.cookie = document.cookie.substring(1,document.cookie.length);
    //}
    total(precio);
}

function extraerDecimales(numero,decimales) {
    if (!decimales) decimales = 2;
    var d = Math.pow(10, decimales);
    return ((numero * d) / d).toFixed(decimales);
}

function getCookie(name) {
    var cname = name + "=";
    var dc = document.cookie;
    if (dc.length > 0) {
        begin = dc.indexOf(cname);
        if (begin != -1) {
            begin += cname.length;
            end = dc.indexOf(";", begin);
            if (end == -1) end = dc.length;
            return unescape(dc.substring(begin, end));
        }
    }
    return null;
}


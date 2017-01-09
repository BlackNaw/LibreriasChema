(function () {

    $("#cart").on("click", function () {
        $(".shopping-cart").fadeToggle("fast");
    });

})();
var total = function (precio) {
    var cosa=document.getElementById("total").innerHTML;
    cosa=cosa.replace("Total:","");
    cosa=cosa.replace("€","");
    var totalCarrito =parseFloat(cosa)+ parseFloat(precio);
    document.getElementById("total").innerHTML = "Total:"+totalCarrito+"€";
}
anadirCarrito = function (titulo, codigo, precio) {
    var nodo = document.createElement("li");
    nodo.innerHTML = codigo + ": " + titulo.replace(/_/gi, " ") + " " + precio + "€";
    nodo.setAttribute("value", codigo);
    nodo.setAttribute("name", "libro");
    document.getElementById("elementos").appendChild(nodo);
    document.getElementById("carrito").innerHTML = parseInt(document.getElementById("carrito").innerHTML) + 1;
    document.getElementById("cesta").innerHTML = parseInt(document.getElementById("cesta").innerHTML) + 1;
    if (document.cookie=="") {
        document.cookie="CODIGO="+codigo;
    } else {
        document.cookie=document.cookie+"_"+codigo;
    }
   total(precio);
}



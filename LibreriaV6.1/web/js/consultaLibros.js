/**
 * Created by Juangra on 26/11/2016.
 */

obtnerLibro = function (codigo, titulo, autor, tema, pagina, f1, f2, f3, estado, precio) {

    //Usar /_/gi es lo mismo que replaceAll("_")
    document.getElementById("codigo").value=codigo.replace(/_/gi," ");
    document.getElementById("titulo").value=titulo.replace(/_/gi," ");
    document.getElementById("autor").value = autor.replace(/_/gi," ");
    document.getElementById("tema").value = tema.replace(/_/gi," ");
    document.getElementById("paginas").value = pagina;
    document.getElementById("precio").value = precio +" €";
    if(f1!="N/A"){
        document.getElementById("formatoUno").checked=true;
    }else{
        document.getElementById("formatoUno").checked=false;
    }
    if(f2!="N/A"){
        document.getElementById("formatoDos").checked=true;
    }else{
        document.getElementById("formatoDos").checked=false;
    }
    if(f3!="N/A"){
        document.getElementById("formatoTres").checked=true;
    }else{
        document.getElementById("formatoTres").checked=false;
    }
    if(estado=="novedad") {
        document.getElementById("reedicion").checked = false;
        document.getElementById("novedad").checked = true;
    }else {
        document.getElementById("novedad").checked = false;
        document.getElementById("reedicion").checked = true;
    }

}

desactivarCampos=function (condition) {

    document.getElementById("titulo").disable=condition;
    document.getElementById("autor").disable=condition;
    document.getElementById("tema").disable=condition;
    document.getElementById("paginas").disable=condition;
    document.getElementById("formatoUno").disable=condition;
    document.getElementById("formatoDos").disable=condition;
    document.getElementById("formatoTres").disable=condition;
    document.getElementById("reedicion").disable=condition;
    document.getElementById("novedad").disable=condition;

}



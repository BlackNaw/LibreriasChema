
<%--
  Created by IntelliJ IDEA.
  User: Juangra
  Date: 26/11/2016
  Time: 1:29
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<jsp:useBean id="dao" class="Negocio.ControlAccesoDAO" scope="page"/>
<jsp:useBean id="TLibro" class="Negocio.TLibro" scope="page"/>
<c:set var="temas" value="${dao.obtenerTemas()}"/>
<c:set var = "libros" value="${dao.obtener(TLibro.getClass())}"/>
<html>
    <head>
        <meta charset="UTF-8">
        <title>La esquina del Zorro</title>
        <%--Para poder mostrar el icono en la pestaña del navegador--%>
        <link rel="shortcut icon" href="Imagenes/favicon.ico">
        <link rel="icon" type="image/gif" href="Imagenes/animated_favicon1.gif" >
        <link rel="stylesheet" href="css/styleFooter.css">
        <link rel="stylesheet" href="css/styleHeader.css">
        <link rel="stylesheet" href="css/styleBaja.css">
    </head>
    <body>
        <%@ include file="header.jsp"%>
        <div id="notebooks" ng-app="notebooks" ng-controller="NotebookListCtrl">
            <ul id="notebook_ul">
                <c:forEach var="TLibro" items="${libros}">
                    <li ng-repeat="notebook in notebooks | filter:query | orderBy: orderList" class="campo" id="campo" onclick=obtnerLibro("${(TLibro.codLibro).replaceAll(" ","_")}","${(TLibro.titulo).replaceAll(" ","_")}","${(TLibro.autor).replaceAll(" ","_")}","${(TLibro.tema).replaceAll(" ","_")}","${TLibro.paginas}","${TLibro.formatouno}","${TLibro.formatodos}","${TLibro.formatotres}","${TLibro.estado}","${TLibro.precio}")>
                        ${TLibro.toString()}<br/>
                            </c:forEach>
            </ul>
            <span>Total de libros: ${libros.size()}</span>
        </div>
        <div id="form-main">
            <div id="form-divi">
                <form class="form" id="form1" action="ServletLibros" method="post">
                    <input hidden name="codigo"  id="codigo"/>
                    <p class="name" title="Título">
                        <input name="titulo" type="text" maxlength="30" required = ""  class="feedback-input" placeholder="Título" id="titulo"/>
                    </p>
                    <p class="paswd" title="Autor">
                        <input name="autor" type="text" maxlength="30" minlength="5" required = "" class="feedback-input"  placeholder="Autor" id="autor"/>
                    </p>
                    <p class="nombre" title="Tema">
                        <select name="tema" class="feedback-input" id="tema">
                            <c:forEach var="temas" items="${temas}">
                                <option value="${temas}">${temas.toString()}</option>
                            </c:forEach>
                        </select>
                    </p>
                    <p class="cif">
                        <input name="paginas" type="text" maxlength="5" minlength="1" required = "" class="feedback-input"  placeholder="Páginas" id="paginas"/>
                    </p>
                    <p class="cif">
                        <input name="precio" type="text"  required = "" class="feedback-input"  placeholder="Precio" id="precio"/>
                        <%--maxlength="5" minlength="1" pattern="[0-9]{9}"--%>
                    </p>
                    <fieldset>
                        <legend>Formato:</legend>
                        <input type="checkbox" name="formatoUno" value="cantone" id="formatoUno"/>Cantoné <br>
                        <input type="checkbox" name="formatoDos" value="rustica" id="formatoDos"/>Rústica<br>
                        <input type="checkbox" name="formatoTres" value="tapadura" id="formatoTres"/>Tapa Dura<br>
                    </fieldset>

                    <fieldset>
                        <legend>Estado: </legend>
                        <input type="radio" name="estado" value="novedad"  id="novedad" />Novedad<br />
                        <input type="radio" name="estado" value="reedicion" id="reedicion" />Reedición<br />
                    </fieldset>
                    <br>
                    <div class="submit">
                        <input name = "boton" type="submit" value="Modificar"  class="boton" id="button-blue"/>
                        <div class="ease"></div>
                    </div>
                </form>
            </div>
        </div>
        <script src="js/consultaLibros.js"></script>
        <%@ include file="footer.jsp"%>
    </body>
</html>

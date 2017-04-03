<%@ page import="Persistencia.AccesoDAO" %>
<%@ page import="java.util.ArrayList" %><%--
  Created by IntelliJ IDEA.
  User: Juangra
  Date: 20/10/2016
  Time: 13:44
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<%@ include file="header.jsp"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<jsp:useBean id="dao" class="Negocio.ControlAccesoDAO" scope="page"/>
<c:set var="temas" value="${dao.obtenerTemas()}"/>
<html>
    <head>
        <meta charset="UTF-8">
        <title>La esquina del Zorro</title>
        <%--Para poder mostrar el icono en la pestaña del navegador--%>
        <link rel="shortcut icon" href="Imagenes/favicon.ico">
        <link rel="icon" type="image/gif" href="Imagenes/animated_favicon1.gif" >
        <link rel="stylesheet" href="css/styleAlta.css">
        <link rel="stylesheet" href="css/styleFooter.css">
        <link rel="stylesheet" href="css/styleHeader.css">
    </head>

    <body>
        <div id="form-main">
            <div id="form-div">
                <form class="form" id="form1" action="ServletLibros" method="post">
                    <p class="name" title="Título">
                        <input name="titulo" type="text" maxlength="30" required = ""  class="feedback-input" placeholder="Título" id="titulo" />
                    </p>
                    <p class="paswd" title="Autor">
                        <input name="autor" type="text" maxlength="30" minlength="5" required = "" class="feedback-input"  placeholder="Autor" id="autor" />
                    </p>
                    <p class="nombre" title="Tema">
                        <select name="tema" class="feedback-input" id="tema">
                            <c:forEach var="temas" items="${temas}">
                                <option value="${temas}">${temas.toString()}</option>
                            </c:forEach>
                        </select>
                    </p>
                    <p class="cif">
                        <input name="paginas" type="text"  required = "" class="feedback-input"  placeholder="Páginas" id="paginas"/>
                        <%--maxlength="5" minlength="1" pattern="[0-9]{9}"--%>
                    </p>
                    <p class="cif">
                        <input name="precio" type="text"  required = "" class="feedback-input"  placeholder="Precio" id="precio"/>
                        <%--maxlength="5" minlength="1" pattern="[0-9]{9}"--%>
                    </p>
                    <fieldset>
                        <legend>Formato:</legend>
                            <input type="checkbox" name="formatoUno" value="cantone"/>Cartoné <br>
                            <input type="checkbox" name="formatoDos" value="rustica"/>Rústica<br>
                            <input type="checkbox" name="formatoTres" value="tapadura"/>Tapa Dura<br>
                    </fieldset>
                    <fieldset>
                        <legend>Estado: </legend>
                        <input type="radio"  name="estado" value="novedad" checked/>Novedad<br />
                        <input type="radio"  name="estado" value="reedicion" />Reedición<br />
                    </fieldset>
                    <%--<form action="subir.php" method="POST" enctype="multipart/form-data">--%>
                        <%--<label for="imagen">Imagen:</label>--%>
                        <%--<input type="file" name="imagen" id="imagen" />--%>
                        <%--<input type="submit" name="subir" value="Subir"/>--%>
                    <%--</form>--%>
                    <br>
                    <div class="submit">
                        <input name ="boton" type="submit" value="Registrar"  class="boton" id="button-blue"/>
                        <div class="ease"></div>
                    </div>
                    <br>
                    <div class="submit">
                        <input type="reset" value="Borrar Campos" class="boton" id="button-reset">
                        <div class="ease"></div>
                    </div>
                </form>
            </div>
        </div>
    </body>
    <%@ include file="footer.jsp"%>
</html>

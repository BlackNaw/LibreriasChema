<%@ page import="Persistencia.AccesoBD" %>
<%@ page import="java.sql.SQLException" %>
<%@ page import="javax.naming.NamingException" %><%--
  Created by IntelliJ IDEA.
  User: Juangra
  Date: 21/11/2016
  Time: 9:07
  To change this template use File | Settings | File Templates.
--%>

<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>


<html>
    <head>
        <link rel="stylesheet" href="css/styleFooter.css">
        <link rel="stylesheet" href="css/styleHeader.css">
        <link rel="stylesheet" href="css/styleIndex.css">
        <%--Para poder mostrar el icono en la pestaña del navegador--%>
        <link rel="shortcut icon" href="Imagenes/favicon.ico">
        <link rel="icon" type="image/gif" href="Imagenes/animated_favicon1.gif" >
        <title>La Esquina del Zorro</title>
    </head>
    <body>
        <%@ include file="header.jsp"%>
        <h1>La Esquina del Zorro</h1>
        <div class="container">
            <div id="carousel">
                <figure><img src="Imagenes/fotos/libreria1.jpg" alt=""></figure>
                <figure><img src="Imagenes/fotos/libreria2.jpg" alt=""></figure>
                <figure><img src="Imagenes/fotos/libreria3.jpg" alt=""></figure>
                <figure><img src="Imagenes/fotos/libreria4.jpg" alt=""></figure>
                <figure><img src="Imagenes/fotos/libreria5.jpg" alt=""></figure>
                <figure><img src="Imagenes/fotos/libreria6.jpg" alt=""></figure>
                <figure><img src="Imagenes/fotos/libreria7.jpg" alt=""></figure>
                <figure><img src="Imagenes/fotos/libreria8.jpg" alt=""></figure>
                <figure><img src="Imagenes/fotos/libreria9.jpg" alt=""></figure>
            </div>
        </div>
        <%@ include file="footer.jsp"%>
    </body>
</html>

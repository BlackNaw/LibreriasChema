<%@ page import="Negocio.TUsuario" %>
<c:set var="usuario" value="${sessionScope.usuario}" property="Negocio.TUsuario"/>


<head>
    <meta charset="UTF-8">
    <title>Index</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, minimum-scale=1">
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/styleMenu.css">
    <link rel="stylesheet" href="css/styleCarrito.css">
    <link rel="stylesheet" href="css/styleCarrito2.css">
</head>

<header class="header">
    <div class="header-inner wrapper">
        <a href="index.jsp">
            <img src="/Imagenes/scripture-website-banner.jpg" id="cabecera">
        </a>
        <nav class="clearfix">
            <ul class="clearfix">
                <li><a href="/">Inicio</a></li>
                <c:choose>
                    <c:when test="${usuario!=null}">
                        <li><a href="/Perfil.jsp">Mi Perfil</a></li>
                    </c:when>
                    <c:when test="${usuario==null}">
                        <li><a href="login.html">Inicar Sesi&oacuten</a></li>
                    </c:when>
                </c:choose>
                <c:if test="${usuario!=null&&usuario.rol=='admin'}">
                    <li><a href="accesoAdmin.jsp">Administrador</a></li>
                </c:if>
                <c:if test="${usuario!=null}">
                    <li><a href="/ServletLogin" methods="get">Desconectar</a></li>
                </c:if>

                <ul class="navbar-right">
                    <li><a href="#" id="cart"><i class="fa fa-shopping-cart"></i> Cesta <span class="badge" id="cesta">0</span></a>
                    </li>
                    <li><a href="contacto.jsp">Contacto</a></li>
                </ul> <!--end navbar-right -->
                <!--<li><span><i class="shopping-cart"></i></span></li>-->
            </ul>
            <a href="#" id="pull">Menu</a>
        </nav>
    </div>
    <script src="js/consultaLibros.js"></script>
    <!-- /.header-inner wrapper -->
</header>
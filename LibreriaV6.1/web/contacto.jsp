<!DOCTYPE html>
<html >
    <head>
        <%--<meta charset="UTF-8">--%>
        <title>La Esquina del Zorro</title>
        <link rel='stylesheet prefetch' href='https://fonts.googleapis.com/css?family=Lato:400,700,300'>
        <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css'>
        <link rel="stylesheet" href="css/styleContacto.css">
        <!--Para poder mostrar el icono en la pestaña del navegador-->
        <link rel="shortcut icon" href="Imagenes/favicon.ico">
        <link rel="icon" type="image/gif" href="Imagenes/animated_favicon1.gif" >
        <link rel="stylesheet" href="css/styleFooter.css">
        <link rel="stylesheet" href="css/styleHeader.css">
        <link rel="stylesheet" href="css/styleBaja.css">
    </head>
    <body>
    <nav role="custom-dropdown">
        <ul>

            <li><a href="index.jsp">Volver</a></li>
        </ul>
    </nav>

    <script src="js/contacto.js"></script>
        <%--<div class="flex">--%>
            <div class="card">
                <div class="photo"></div>
                <div class="banner"></div>
                <ul>
                    <li><b>Libreria</b></li>
                    <li>La Esquina del Zorro</li>

                </ul>
                <button class="contact" id="main-button">Mostrar Datos</button>
                <div class="social-media-banner">
                    <a href="https://twitter.com/esquinadelzorro"><i class="fa fa-twitter"></i></a>
                    <a href="https://www.facebook.com/laesquinadelzorro/"><i class="fa fa-facebook"></i></a>
                    <a href="https://www.instagram.com/"><i class="fa fa-instagram"></i></a>
                    <a href=""><i class="fa fa-linkedin"></i></a>
                </div>
                <form class="email-form">
                    <input id="name" type="text" placeholder="C/ Arroyo del Olivar, 34 Puente de Vallecas" disabled>
                    <input id="email" type="email" placeholder="contacto@librerialaesquinadelzorro.com" disabled>
                    <input id="comment" type="tel" placeholder="91 833 14 57" disabled>
                    <!--<button class="contact">send</button>-->
                </form>
            </div>
            <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d8171.2124325147715!2d-3.6631588390724503!3d40.392754582852376!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xfc86b549d4c2181f!2sLibrer%C3%ADa+La+esquina+del+Zorro!5e0!3m2!1ses!2ses!4v1480123165125" class="mapa" allowfullscreen></iframe>
        <%--</div>--%>

        <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src="js/contacto.js"></script>
        <%--<%@ include file="footer.jsp"%>--%>
    </body>
</html>

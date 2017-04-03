<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ page import="Negocio.TUsuario" %>
<jsp:useBean id="dao" class="Negocio.ControlAccesoDAO" scope="page"/>
<jsp:useBean id="librito" class="Negocio.TLibro" scope="page"/>
<c:set var="temas" value="${dao.obtenerTemas()}"/>
<c:set var="libros" value="${dao.obtener(librito.getClass())}"/>


<script>
    document.cookie = "CODIGO=" + '=;expires=Thu, 01 Jan 1970 00:00:01 GMT;'
</script>
<!DOCTYPE html>
<html>

<%@ include file="headerIndex.jsp" %>

<title>Index</title>
<!-- /.header -->
<div class="container">
    <div class="shopping-cart" style="display: none">
        <i class="fa fa-shopping-cart cart-icon" id="numero">
            Libros elegidos:
        </i>

        <span class="badge" id="carrito">0</span>
        <%--Aquí se añaden los libros al carrito--%>
        <form action="/ServletCompra" method="post">
            <ul class="shopping-cart-items" id="elementos">

            </ul>



        <div class="shopping-cart-items"  id="total">Total:0€</div>
        <button style="border: black 1px solid" type="submit" class="button">Compra</button>
        </form>
        <a style="border: black 1px solid" onclick="location.href='/'" class="button">Vaciar Cesta</a>

    </div> <!--end shopping-cart -->
</div> <!--end container -->
<html ng-app="flyingCartApp">
<main class="main" role="main">
    <div class="main-inner wrapper">
        <ul class="product-list ul-reset">
            <%--Se añaden los libros a la pagina--%>
            <c:forEach var="TLibro" items="${libros}">
            <li class="product-item ib">
                <section class="product-item-inner">
                    <div class="product-item-image">
                        <img src="Imagenes/libroDefecto.png"
                             alt="item"/>
                    </div>
                    <!-- /.product-item-image -->
                    <h1 style="text-align: center" class="product-item-title">
                        Titulo: ${TLibro.titulo}
                    </h1>
                    <!-- /.product-item-title -->
                    <div class="product-item-rrp-price-saving">
                        <div style="text-align: center" class="product-item-rrp">
                            Autor: ${TLibro.autor}
                        </div>
                        <!-- /.product-item-rrp -->
                        <div style="text-align: center" class="product-item-price">
                            Tema: ${TLibro.tema}
                        </div>
                        <!-- /.product-item-price -->
                        <div style="text-align: center" class="product-item-saving">
                            Estado: ${TLibro.estado}
                        </div>
                        <div style="text-align: center" class="product-item-saving">
                            Precio: ${TLibro.precio} €
                        </div>
                        <!-- /.product-item-saving -->
                    </div>
                    <!-- /.product-item-rrp-price-saving -->
                    <div style="text-align: center" class="product-item-lower">
                        <div style="text-align: center">
                                <c:if test="${!(TLibro.formatouno).equals('N/A')}">
                                    Formato:${TLibro.formatouno}<br>
                                </c:if>
                                <c:if test="${!(TLibro.formatodos).equals('N/A')}">
                                    Formato:${TLibro.formatodos}<br>
                                </c:if>
                                <c:if test="${!(TLibro.formatotres).equals('N/A')}">
                                    Formato:${TLibro.formatotres}<br>
                                </c:if>
                            Paginas:${TLibro.paginas}
                        </div>
                        <!-- /.product-item-short-description -->
                        <button class="product-item-add-to-cart" onclick=anadirCarrito("${(TLibro.titulo).replaceAll(" ","_")}","${TLibro.codLibro}","${TLibro.precio}")> Añadir al carrito</button>
                        <!--<input type="submit" value="Add to Cart" class="product-item-add-to-cart">-->

                    </div>
                    <!-- /.product-item-lower -->
                </section>
                <!-- /.product-item-inner -->
            </li>
            </c:forEach>
        </ul>
        <!-- /.product-list ul-reset -->
    </div>
    <!-- /.main-inner wrapper -->
</main>
<!-- /.main -->
</html>

<script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
<script src='http://ajax.googleapis.com/ajax/libs/angularjs/1.3.2/angular.min.js'></script>
<script src="js/index.js"></script>
<script src="js/addtocart.js"></script>
<script src="js/carrito.js"></script>

</body>
</html>

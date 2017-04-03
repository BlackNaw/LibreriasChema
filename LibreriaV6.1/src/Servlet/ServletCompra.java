package Servlet;

import Comun.Errores;
import Comun.Mensajes;
import Persistencia.UtilFichero;
import Negocio.*;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.ObjectInput;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

/**
 * Created by JAVI on 20/12/2016.
 */
@WebServlet("/ServletCompra")
public class ServletCompra extends HttpServlet {

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        TUsuario usuario = (TUsuario) request.getSession().getAttribute("usuario");
        Cookie[] cookies = request.getCookies();
        String[] codigos = null;

        if (usuario == null) {
            response.sendRedirect("index.jsp");
        } else {

            for (Cookie cookie : cookies) {
                if (cookie.getName().equals("CODIGO")) {
                    codigos = cookie.getValue().split("_");
                }
            }
            try {
                crearFactura(buscarLibros(codigos), usuario);
                response.sendRedirect("Perfil.jsp");
            } catch (Exception e) {
                Mensajes.mostrarmensaje(Errores.controlError(e), "index.jsp", response);
            }

        }
    }

    private ArrayList<TLibro> buscarLibros(String[] codigos) throws Exception {
        ArrayList<TLibro> listLibro = new ArrayList<>();
        ControlAccesoDAO controlDao = new ControlAccesoDAO();
        for (String cod : codigos) {
            listLibro.add((TLibro) controlDao.buscar(TLibro.class, "codLibro", cod).get(0));
        }
        return listLibro;
    }

    private void crearFactura(ArrayList<TLibro> listLibro, TUsuario usuario) throws Exception {
        ControlAccesoDAO controlDao = new ControlAccesoDAO();
        ArrayList<Object> facturaCompleta = new ArrayList<>();
        TFactura factura = new TFactura(usuario.getNick());
        //Ordenamos el array de libros
        Collections.sort(listLibro, new Comparator<TLibro>() {
            @Override
            public int compare(TLibro o1, TLibro o2) {
                return o1.getCodLibro().compareTo(o2.getCodLibro());
            }
        });
        facturaCompleta.add(factura);
        int contador = 1;
        for (int i = 0; i < listLibro.size() - 1; i++) {
            if (listLibro.get(i).getCodLibro().equals(listLibro.get(i + 1).getCodLibro())) {
                contador++;
            } else {
                facturaCompleta.add(new TLineaFactura(factura.getCodFactura(), listLibro.get(i).getTitulo(), String.valueOf(contador), String.valueOf(Double.valueOf(listLibro.get(i).getPrecio()) * contador)));
                contador = 1;
            }
        }
        facturaCompleta.add(new TLineaFactura(factura.getCodFactura(), listLibro.get(listLibro.size() - 1).getTitulo(), String.valueOf(contador), String.valueOf(Double.valueOf(listLibro.get(listLibro.size() - 1).getPrecio()) * contador)));
        controlDao.insertar(facturaCompleta);
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}

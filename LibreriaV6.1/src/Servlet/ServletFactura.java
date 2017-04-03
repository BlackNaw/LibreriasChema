package Servlet;

import Comun.Errores;
import Comun.Mensajes;
import Persistencia.UtilFichero;
import Negocio.ControlAccesoDAO;
import Negocio.TFactura;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * Created by JAVI on 26/12/2016.
 */
@WebServlet("/ServletFactura")
public class ServletFactura extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
       String codFactura=request.getParameter("codFactura");
        try {
            ControlAccesoDAO dao=new ControlAccesoDAO();
           TFactura factura= (TFactura) dao.buscar(TFactura.class,codFactura);
           factura.setBorrado("1");
           dao.modificar(factura.getCodFactura(),factura);
        } catch (Exception e) {
            Mensajes.mostrarmensaje(Errores.controlError(e), "Perfil.jsp", response);
        }
        response.sendRedirect("Perfil.jsp");


    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}

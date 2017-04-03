package Servlet;

import Comun.Errores;
import Comun.Mensajes;
import Persistencia.UtilFichero;
import Negocio.ControlAccesoDAO;
import Negocio.TLibro;

import javax.naming.NamingException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 * Created by Juangra on 28/11/2016.
 */
@WebServlet("/ServletLibros")
public class ServletLibros extends HttpServlet {


    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
//        doPost(request,response);
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setCharacterEncoding("UTF-8");
        // Capturamos la palabra clave servlet que viene dentro del request.
        String accion = request.getParameter("boton");
        // Dependiendo de la accion, desivamos a un método u otro
        switch (accion) {
            case "Registrar":
                altaLibro(request, response);
                break;
            case "Modificar":
                modificarLibros(request, response);
                break;
            case "Baja":
                borrarLibro(request, response);
                break;
        }
    }

    private void borrarLibro(HttpServletRequest request, HttpServletResponse response) throws IOException {
        ControlAccesoDAO controlDao = null;
        TLibro TLibro = null;
        String mensaje = null;
        try {
            controlDao = new ControlAccesoDAO();
            TLibro = obtenerLibro(request);
            if (controlDao.buscar(Negocio.TLibro.class, TLibro.getCodLibro()) == null) {
                mensaje = Mensajes.obtenerMensaje(Mensajes.ERRORB);
                //MostrarErrores.mostrarError(Mensajes.obtenerMensaje(Mensajes.ERRORB));
            } else {
                controlDao.borrar(TLibro);
                mensaje = "TLibro borrado con éxito";
            }
            Mensajes.mostrarmensaje(mensaje, String.valueOf("BajaLibro.jsp"), response);

        } catch (Exception e) {
            Mensajes.mostrarmensaje(Errores.controlError(e), String.valueOf("BajaLibro.jsp"), response);
        }
    }



    private void modificarLibros(HttpServletRequest request, HttpServletResponse response) throws IOException {
        ControlAccesoDAO controlDao = null;
        TLibro TLibro = null;
        try {
            controlDao = new ControlAccesoDAO();
            TLibro = obtenerLibro(request);
            controlDao.modificar(TLibro.getCodLibro(), TLibro);
            request.getRequestDispatcher("ModificarLibro.jsp").forward(request, response);
        } catch (Exception e) {
            Mensajes.mostrarmensaje(Errores.controlError(e), "ModificarLibro.jsp", response);
        }


    }

    private void altaLibro(HttpServletRequest request, HttpServletResponse response) throws IOException {
        ControlAccesoDAO controlDao = null;
        TLibro TLibro = null;
        String mensaje = null;
        try {
            controlDao = new ControlAccesoDAO();
            TLibro = obtenerLibro(request);
            if (controlDao.buscar(Negocio.TLibro.class, TLibro.getCodLibro()) == null) {
                ArrayList aux=new ArrayList();
                aux.add(TLibro);
                controlDao.insertar(aux);
                mensaje = "Libro guardado con éxito";
            } else {
                mensaje = Mensajes.obtenerMensaje(Mensajes.EXISTE);
            }
            Mensajes.mostrarmensaje(mensaje, "AltaLibros.jsp", response);
        } catch (Exception e) {
            Mensajes.mostrarmensaje(Errores.controlError(e), "AltaLibros.jsp", response);
        }

    }

    private TLibro obtenerLibro(HttpServletRequest request) throws IOException, ClassNotFoundException, SQLException, NamingException {
        String codigo = request.getParameter("codigo");
        String titulo = request.getParameter("titulo");
        String autor = request.getParameter("autor");
        String tema = request.getParameter("tema");
        String paginas = request.getParameter("paginas");
        String formatoUno = request.getParameter("formatoUno") == null ? "N/A" : request.getParameter("formatoUno");
        String formatoDos = request.getParameter("formatoDos") == null ? "N/A" : request.getParameter("formatoDos");
        String formatoTres = request.getParameter("formatoTres") == null ? "N/A" : request.getParameter("formatoTres");
        String estado = request.getParameter("estado");
        String precio = request.getParameter("precio").replace(" €","");
        precio=precio.replace(",",".");

        if (codigo == null) {
            return new TLibro(titulo, autor, tema, paginas, precio, formatoUno, formatoDos, formatoTres, estado);
        } else {
            return new TLibro(codigo, titulo, autor, tema, paginas, precio, formatoUno, formatoDos, formatoTres, estado);
        }
    }
}

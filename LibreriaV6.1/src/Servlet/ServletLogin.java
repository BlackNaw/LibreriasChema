package Servlet;

import Comun.Errores;
import Comun.Mensajes;
import Persistencia.UtilFichero;
import Negocio.ControlAccesoDAO;
import Negocio.TUsuario;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.ArrayList;

/**
 * Created by JAVI on 19/12/2016.
 */
@WebServlet("/ServletLogin")
public class ServletLogin extends HttpServlet {

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        String accion = request.getParameter("boton");
        // Dependiendo de la accion, desivamos a un método u otro
        switch (accion) {
            case "iniciar":
                login(request, response);
                break;
            case "registrar":
                registrar(request, response);
                break;

        }
    }


    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.getSession().setAttribute("usuario",null);
        response.sendRedirect("index.jsp");
    }


    private void registrar(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String nombre = request.getParameter("usernamer");
        String password = request.getParameter("passwordr");
        String rol = request.getParameter("rol");
        ControlAccesoDAO controlDao = null;
        ArrayList<Object> usuarios=new ArrayList<>();
        try {
            controlDao = new ControlAccesoDAO();
            TUsuario usuario;
            try {
                usuario = (TUsuario) controlDao.buscar(TUsuario.class, "nick", nombre).get(0);
            } catch (Exception e) {
                usuarios.add( new TUsuario(nombre, password,rol));
                controlDao.insertar(usuarios);
                request.getSession().setAttribute("usuario", usuarios.get(0));
                response.sendRedirect("accesoAdmin.jsp");
            }
        } catch (Exception e) {
            Mensajes.mostrarmensaje(Errores.controlError(e), "login.html", response);
        }
        Mensajes.mostrarmensaje("El usuario ya existe", "login.html", response);
    }


    private void login(HttpServletRequest request, HttpServletResponse response) throws IOException {

        String nombre = request.getParameter("username");
        String password = request.getParameter("password");
        ControlAccesoDAO controlDao = null;
        try {
            controlDao = new ControlAccesoDAO();
            TUsuario usuario = (TUsuario) controlDao.buscar(TUsuario.class, "nick", nombre).get(0);
            if (usuario.getNick().equals(nombre) && usuario.getPass().equals(password)) {
                request.getSession().setAttribute("usuario", usuario);
                response.sendRedirect("accesoAdmin.jsp");

            } else {
                Mensajes.mostrarmensaje("Contraseña errónea", "login.html", response);
            }
        } catch (Exception e) {
            Mensajes.mostrarmensaje("El usuario no existe", "login.html", response);
        }
    }
}




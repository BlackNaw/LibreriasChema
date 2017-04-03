package Filtros;

import Negocio.TUsuario;

import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;

/**
 * Created by Mary on 06/12/2015.
 */
@WebFilter(filterName = "Filtro",urlPatterns = {"/accesoAdmin.jsp", "/AltaLibros.jsp", "/BajaLibro.jsp", "/ConsultaLibros.jsp", "/ModificarLibro.jsp","/Perfil.jsp","/detalle.jsp"})
public class Filtro implements Filter {
    public void destroy() {
    }

    public void doFilter(ServletRequest req, ServletResponse resp, FilterChain chain) throws ServletException, IOException {
        TUsuario usuario = (TUsuario) ((HttpServletRequest) req).getSession().getAttribute("usuario");

        if (usuario!=null&&usuario.getRol().equals("admin")) {
            chain.doFilter(req, resp);
        } else if((((HttpServletRequest) req).getRequestURI().equals("/Perfil.jsp")||((HttpServletRequest) req).getRequestURI().equals("/detalle.jsp"))&&usuario!=null){
            chain.doFilter(req, resp);
        }else{
            req.getRequestDispatcher("index.jsp").forward(req, resp);
        }
    }

    public void init(FilterConfig config) throws ServletException {
    }
}

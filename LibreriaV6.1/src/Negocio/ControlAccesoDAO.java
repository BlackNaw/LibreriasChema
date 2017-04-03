package Negocio;

import Persistencia.AccesoDAO;

import javax.naming.NamingException;
import java.io.IOException;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 * Created by Juangra on 07/11/2016.
 */
public class ControlAccesoDAO {

    AccesoDAO acceso = new AccesoDAO();

    public ControlAccesoDAO() throws ClassNotFoundException, SQLException, NamingException, IOException {
    }


    public boolean insertar(ArrayList list) throws Exception {
        assert list != null;
        return acceso.insertar(list);
    }

    public boolean borrar(Object object) throws Exception {
        assert object != null;
        return acceso.borrar(object);

    }

    public Object buscar(Class clase, String nombre) throws Exception {
        assert clase != null || nombre != null;
        return acceso.buscar(clase, nombre);

    }

    public ArrayList<Object> buscar(Class clase, String campo, String busqueda) throws Exception {
        assert clase != null || campo != null || busqueda != null;
        return acceso.buscar(clase, campo, busqueda);

    }

    public ArrayList<Object> obtener(Class clase) throws Exception {
        assert clase != null;
        return acceso.obtener(clase);
    }

    public boolean modificar(String nombreAntiguo, Object object) throws Exception {
        assert object != null || nombreAntiguo != null;
        return acceso.modificar(nombreAntiguo, object);
    }

    public ArrayList<String> obtenerTemas() throws Exception {
        return acceso.obtenerTemas();
    }
}

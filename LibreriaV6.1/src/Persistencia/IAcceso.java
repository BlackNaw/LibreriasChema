package Persistencia;

import javax.naming.NamingException;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 * Created by Juangra on 07/11/2016.
 */
public interface IAcceso <obj> {

    boolean insertar(ArrayList<obj> list) throws Exception;
    boolean borrar(Object object) throws Exception;
    Object buscar(Class clase, String nombre) throws Exception;
    ArrayList<obj> obtener(Class clase) throws Exception;
    boolean modificar(String nombre,obj obj) throws Exception;


}

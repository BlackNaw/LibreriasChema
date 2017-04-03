package Persistencia;

import javax.naming.NamingException;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.sql.SQLException;
import java.util.ArrayList;

import java.util.Map;

/**
 * Created by Juangra on 07/11/2016.
 */
public class AccesoDAO implements IAcceso {


    public AccesoDAO() throws SQLException, ClassNotFoundException, IOException, NamingException {
        super();
    }

    /**
     * Inserta en la BBDD un objeto que pasamos por parametro
     * Guarda mas rápidamente los libros que otros objetos (hace reflexión)
     *
     * @param list arraylist de objetos a insertar
     * @return verdadero si se ha insertado correctamente
     * @throws Exception
     **/
    @Override
    public boolean insertar(ArrayList list) throws Exception {
        assert list != null;
        AccesoBD accesoBD = new AccesoBD();
        String sql;
        try {
            accesoBD.startTransaction();
            for (Object obj : list) {
                if ((sql = existeSentencia("INSERT" + obj.getClass().getSimpleName())) == null) {
                    accesoBD.insertarBD(guardarSQL("INSERT" + obj.getClass().getSimpleName(), UtilSQL.sqlInsertar(obj)), obj, "");
                } else {
                    accesoBD.insertarBD(sql, obj, "");
                }
            }
            accesoBD.commit();
            return true;

        } catch (Exception e) {
            accesoBD.rollBack();
            throw e;
        } finally {
            accesoBD.close();
        }
    }


    /**
     * Borra de la BBDD un objeto que pasamos por parametro
     * Funciona más rapidamente con Libros que otros objetos(hace reflexión)
     *
     * @param object objeto a borrar de la BBDD
     * @return verdadero si se ha insertado correctamente
     * @throws SQLException
     * @throws IllegalAccessException
     * @throws InvocationTargetException
     * @throws NoSuchMethodException
     */
    @Override
    public boolean borrar(Object object) throws Exception {
        assert object != null;
        AccesoBD accesoBD = new AccesoBD();
        try {
            accesoBD.startTransaction();
            String sql;
            if ((sql = existeSentencia("DELETE" + object.getClass().getSimpleName())) == null) {
                if (accesoBD.borrarBD(guardarSQL("DELETE" + object.getClass().getSimpleName(), UtilSQL.sqlBorrar(object)), object)) {
                    accesoBD.commit();
                    return true;
                }
            } else {
                if (accesoBD.borrarBD(sql, object)) {
                    accesoBD.commit();
                    return true;
                }
            }
        } catch (Exception e) {
            accesoBD.rollBack();
            throw e;
        } finally {
            accesoBD.close();
        }
        accesoBD.rollBack();
        return false;
    }

    /**
     * Busca y retorna un objeto de la BBDD
     *
     * @param clase  Del objeto a buscar
     * @param nombre Del objeto a buscar
     * @return Devuelve el objeto si se encuentra, si no, devuelve null
     * @throws Exception
     */
    @Override
    public Object buscar(Class clase, String nombre) throws Exception {
        assert clase != null;
        assert nombre != null;
        ArrayList<Object> objeto = null;
        try (AccesoBD accesoBD = new AccesoBD()) {
            String sql;
            if ((sql = existeSentencia("SELECTONE" + clase.getSimpleName())) == null) {
                if ((objeto = accesoBD.ejecutarConsultaBD((guardarSQL("SELECTONE" + clase.getSimpleName(), UtilSQL.sqlBuscar(clase))), clase, nombre)).size() == 0) {
                    return null;
                }
            } else {
                if ((objeto = accesoBD.ejecutarConsultaBD(sql, clase, nombre)).size() == 0) {
                    return null;
                }
            }

        }
        return objeto.get(0);
    }

    public ArrayList<Object> buscar(Class clase, String campo, String busqueda) throws Exception {
        String sql = "SELECT * FROM " + clase.getSimpleName().toLowerCase() + " WHERE " + campo + " = \"" + busqueda + "\"";
        try (AccesoBD accesoBD = new AccesoBD()) {
            return accesoBD.ejecutarConsultaBD(sql, clase, "");
        }
    }


    /**
     * Devuelve todos los elementos que hay en una tabla especifica de la BBDD
     *
     * @param clase Clase de la tabla a buscar
     * @return devuelve un ArrayList<Object> con todos los objetos
     * @throws Exception
     */
    @Override
    public ArrayList<Object> obtener(Class clase) throws Exception {
        assert clase != null;
        try (AccesoBD accesoBD = new AccesoBD()) {
            String sql;
            if ((sql = existeSentencia("SELECTALL" + clase.getSimpleName())) == null) {
                return (accesoBD.ejecutarConsultaBD(guardarSQL("SELECTALL" + clase.getSimpleName(), UtilSQL.sqlObtener(clase)), clase, ""));
            } else {
                return accesoBD.ejecutarConsultaBD(sql, clase, "");
            }
        }
    }

    /**
     * Modifica un objeto concreto de a BBDD
     *
     * @param nombreAntiguo valor de la clave principal del objeto a modificar
     * @param object        nuevo objeto con los cambios realizados
     * @return True si se ha modificado correctamente, si no, false.
     * @throws Exception
     */
    @Override
    public boolean modificar(String nombreAntiguo, Object object) throws Exception {
        assert object != null;
        assert nombreAntiguo != null;
        AccesoBD accesoBD = new AccesoBD();
        try {
            accesoBD.startTransaction();
            String sql;
            if ((sql = existeSentencia("UPDATE" + object.getClass().getSimpleName())) == null) {
                if (accesoBD.insertarBD(guardarSQL("UPDATE" + object.getClass().getSimpleName(), UtilSQL.sqlModificar(object)), object, nombreAntiguo)) {
                    accesoBD.commit();
                    return true;
                }
            } else {
                if (accesoBD.insertarBD(sql, object, nombreAntiguo)) {
                    accesoBD.commit();
                    return true;
                }
            }
            accesoBD.rollBack();
        } catch (Exception e) {
            accesoBD.rollBack();
            throw e;
        } finally {
            accesoBD.close();
        }
        accesoBD.rollBack();
        return false;
    }

    public ArrayList<String> obtenerTemas() throws Exception {
        try (AccesoBD accesoBD = new AccesoBD()) {
            return accesoBD.obtenerTemas();
        }
    }

    private String guardarSQL(String orden, String sql) {
        UtilFichero.getSENTENCIAS().put(orden, sql);
        return sql;
    }

    private String existeSentencia(String orden) {
        for (Map.Entry<String, String> entry : UtilFichero.getSENTENCIAS().entrySet()) {
            if (entry.getKey().equals(orden)) {
                return entry.getValue();
            }
        }
        return null;
    }


}

package Persistencia;



import javax.naming.NamingException;
import java.io.IOException;
import java.lang.reflect.Field;
import java.lang.reflect.InvocationTargetException;
import java.sql.SQLException;
import java.util.Map;
import java.util.TreeMap;

/**
 * Created by JAVI on 07/11/2016.
 */
public class UtilSQL {

    private static StringBuilder sql = new StringBuilder();


    public final static String sqlInsertar(Object object) throws InvocationTargetException, IllegalAccessException {
        sql.setLength(0);
        sql.append("INSERT INTO " + object.getClass().getSimpleName().toLowerCase() + " ( ");
        rellenarSql(obtenerHashMapMetodos(object));
        return sql.toString();
    }


    public final static String sqlBuscar(Class clase) throws NoSuchMethodException, IllegalAccessException, InvocationTargetException {
        sql.setLength(0);
        sql.append("SELECT * FROM " + clase.getSimpleName().toLowerCase() + " WHERE "+obtenerClave(clase)+" = ? ");
        return sql.toString();
    }

    public final static String sqlBorrar(Object object) throws NoSuchMethodException, IllegalAccessException, InvocationTargetException {
        sql.setLength(0);
        sql.append("DELETE FROM " + object.getClass().getSimpleName().toLowerCase() + " WHERE "+obtenerClave(object.getClass()) +" = ? ");
        return sql.toString();
    }

    public final static String sqlModificar(Object object) throws InvocationTargetException, IllegalAccessException, NoSuchMethodException {
        sql.setLength(0);
        sql.append("UPDATE " + object.getClass().getSimpleName().toLowerCase() + " SET ");
        for (Map.Entry<String, String> entry : obtenerHashMapMetodos(object).entrySet()) {
            sql.append(entry.getKey() + " =  ? , ");
        }
        sql.replace(0, sql.length(), sql.substring(0, sql.length() - 2));
        sql.append(" WHERE " + obtenerClave(object.getClass()) + " = ? ");
        return sql.toString();
    }

    public final static String sqlObtener(Class clase) {
        sql.setLength(0);
        sql.append("SELECT * FROM " + clase.getSimpleName().toLowerCase());
        return sql.toString();
    }

    private static void rellenarSql(Map<String, String> get) throws InvocationTargetException, IllegalAccessException {
        StringBuilder string = new StringBuilder(" ) VALUES ( ");
        for (Map.Entry<String, String> entry : get.entrySet()) {
            sql.append(entry.getKey() + ", ");
            string.append("? , ");
        }
        sql.replace(0, sql.length(), sql.substring(0, sql.length() - 2));
        sql.append(string.substring(0, string.length() - 2) + " ) ");
    }


    private static String obtenerClave(Class clase){
        for (Field campo : clase.getDeclaredFields()) {
           if(campo.getName().startsWith("cod")){
               return campo.getName();
           }
        }
        return null;
    }

    private static Map<String, String> obtenerHashMapMetodos(Object objeto) {
        Map<String, String> mapM = new TreeMap<String, String>();
        for (Field campo : objeto.getClass().getDeclaredFields()) {
            mapM.put(campo.getName(), "?");
        }
        return mapM;
    }

    public static String generarCodigo(Class clase) throws ClassNotFoundException, SQLException, NamingException, IOException {
        String codigo= new AccesoBD().obtenerCodigo(clase);
        if(codigo==null){
            return "cod001";
        }
        int indice=Integer.valueOf(codigo.substring(3))+1;
        return "cod"+(indice>=10?"0"+indice:indice>=100?indice:"00"+indice);
    }

}





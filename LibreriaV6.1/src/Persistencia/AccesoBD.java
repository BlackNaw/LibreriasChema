package Persistencia;


import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import javax.sql.DataSource;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.sql.*;
import java.util.*;

public class AccesoBD implements AutoCloseable{

    private static Connection miConexion = null;
    private static UtilFichero util = new UtilFichero();

    public AccesoBD() throws SQLException, ClassNotFoundException, IOException,NamingException {
        util.rellenarHashMapSentencias();
        Context initCtx = new InitialContext();
        Context envCtx = (Context) initCtx.lookup("java:comp/env");
        DataSource datasource = (DataSource) envCtx.lookup("jdbc/PoolDB");
        miConexion = datasource.getConnection();
    }

    public boolean insertarBD(String sql, Object object, String antiguo) throws SQLException, InvocationTargetException, IllegalAccessException, NoSuchMethodException {
        assert sql != null;
        assert object != null;
        assert antiguo != null;
        try (PreparedStatement pmsql = miConexion.prepareStatement(sql)) {
            Map<String, Method> map = obtenerHashMapMetodos(object, "get");
            int index = 1;
            for (Map.Entry<String, Method> entry : map.entrySet()) {
                pmsql.setString(index++, String.valueOf(entry.getValue().invoke(object, null)));
            }
            if (sql.contains("UPDATE")) {
                pmsql.setString(index, antiguo);
            }
            return pmsql.executeUpdate() > 0;
        }
    }

    public boolean borrarBD(String sql, Object object) throws SQLException, NoSuchMethodException, IllegalAccessException, InvocationTargetException {
        assert sql != null;
        assert object != null;
        try (PreparedStatement pmsql = miConexion.prepareStatement(sql)) {
            pmsql.setString(1, obtenerValorClavePrimaria(object));
            return pmsql.executeUpdate() > 0;
        }
    }



    public ArrayList<Object> ejecutarConsultaBD(String sql, Class clase, String nombre) throws SQLException, ClassNotFoundException,
            IllegalAccessException, InstantiationException, InvocationTargetException {
        assert sql != null;
        assert clase != null;
        assert nombre != null;
        ArrayList<Object> objetos = null;
        Object objeto;
        Map<String, Method> mapM;
        ResultSet rs = null;
        try (PreparedStatement pmsql = miConexion.prepareStatement(sql)) {
            if (!nombre.equals("")) {
                pmsql.setString(1, nombre);
            }
            rs = pmsql.executeQuery();
            if (rs != null) {
                objetos = new ArrayList<Object>();
                while (rs.next()) {
                    objeto = Class.forName(clase.getName()).newInstance();
                    mapM = obtenerHashMapMetodos(objeto, "set");

                    for (Map.Entry<String, Method> entry : mapM.entrySet()) {
                        entry.getValue().invoke(objeto, rs.getObject(entry.getKey()));
                    }
                    objetos.add(objeto);
                }
            }
        }
        return objetos;
    }



    private String obtenerValorClavePrimaria(Object object) throws InvocationTargetException, IllegalAccessException {
        assert object != null;
        for (Method method : object.getClass().getDeclaredMethods()) {
            if(method.getName().contains("getCod")){
                return method.invoke(object,null).toString();
            }
        }
        return null;
    }
    /**
     * Obtiene todos los métodos y los almacena en un hashMap
     *
     * @param objeto del que se quieren obtener los métodos
     * @return HashMap con los métodos del objeto
     */
    protected static Map<String, Method> obtenerHashMapMetodos(Object objeto, String parametro) {
        assert objeto != null;
        assert parametro != null;
        Map<String, Method> mapM = new HashMap<String, Method>();
        Method[] metodos = objeto.getClass().getDeclaredMethods();
        for (Method method : metodos) {
            if (method.getName().startsWith(parametro)) {
                String nombre = method.getName().substring(3).toLowerCase();
                mapM.put(nombre, method);
            }
        }
        Map<String, Method> treeMap = new TreeMap<>(mapM);
        return treeMap;
    }


    public ArrayList<String> obtenerTemas() throws SQLException {
        ArrayList<String> temas=new ArrayList<>();
        ResultSet rs;
        String sql="SELECT * FROM tema";
        try (PreparedStatement pmsql = miConexion.prepareStatement(sql)){
            rs=pmsql.executeQuery();
            while (rs.next()){
                temas.add(rs.getString(1));
            }
        }
        return temas;
    }

    public String obtenerCodigo(Class clase) throws SQLException {
        String sql = "SELECT MAX(cod" + clase.getSimpleName().substring(1) + ") FROM " + clase.getSimpleName().toLowerCase();
        ResultSet rs;
        try (PreparedStatement pmsql = miConexion.prepareStatement(sql)) {
           rs=pmsql.executeQuery();
           rs.first();
           return rs.getString(1);
        }
    }

    public void startTransaction() throws SQLException {
        miConexion.setAutoCommit(false);

    }

    public void rollBack() throws SQLException {
        miConexion.rollback();
        miConexion.setAutoCommit(true);

    }

    public void commit() throws SQLException {
        miConexion.commit();
        miConexion.setAutoCommit(true);

    }

    @Override
    public void close() throws Exception {
        if(!miConexion.getAutoCommit())
            miConexion.rollback();
        util.escribirHasMapSentenciasFichero();
        miConexion.close();
    }
}


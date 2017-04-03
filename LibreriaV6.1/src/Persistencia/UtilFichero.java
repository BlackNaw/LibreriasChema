package Persistencia;

import Comun.Errores;
import Persistencia.AccesoBD;

import javax.naming.NamingException;
import javax.servlet.http.HttpServletResponse;
import java.io.*;
import java.sql.SQLException;
import java.util.HashMap;

/**
 * Created by Juangra on 09/11/2016.
 */
public class UtilFichero {


    private static HashMap<String, String> SENTENCIAS;

    public static HashMap<String ,String> getSENTENCIAS(){
            return SENTENCIAS;
    }

    private static File archivo = new File("sqlCarrito.txt");

    public static void rellenarHashMapSentencias() throws IOException, ClassNotFoundException {
        if(comprobarArchivo()&&archivo.length()>0) {
            try (FileInputStream flujoR = new FileInputStream(archivo)) {
                SENTENCIAS = (HashMap<String, String>) new ObjectInputStream(flujoR).readObject();

            }
        }else {
            SENTENCIAS = new HashMap<String, String>();
        }
    }

    public static void escribirHasMapSentenciasFichero() throws IOException {
        if(comprobarArchivo()) {
            try (FileOutputStream flujoW = new FileOutputStream(archivo)) {
                new ObjectOutputStream(flujoW).writeObject(SENTENCIAS);
            }
        }
    }

    private static boolean comprobarArchivo() throws IOException {
        if (!archivo.exists()){
            if (!archivo.createNewFile()){
                Errores.controlError(new Errores(Errores.ERROR_FICHERO));
                return false;
            }
        }
        return true;
    }





}

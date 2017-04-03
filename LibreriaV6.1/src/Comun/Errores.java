package Comun;

import javax.swing.*;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.sql.SQLException;
import java.sql.SQLSyntaxErrorException;

public class Errores extends Exception{
	/**
	 * Creamos en contructor del padre para poder crear nuestros propios errores
	 * @param message es el tipo de error que vamos a crear propios
	 */
	public Errores(String message) {
		super(message);
	}

	public static final String ERRORCLAVE = "Clave";
	public static final String ERROR_FICHERO = "fichero";

	public static String controlError(Exception e){
        assert e != null;
		if (e.getClass().equals(IOException.class)) {
			return "Error en al tratarel fichero";
		}else if (e.getClass().equals(FileNotFoundException.class)) {
			return "ERROR: Archivo no encontrado";
		}else if(e.getClass().equals(SQLException.class)){
			return "ERROR: Base de datos";
		}else if(e.getClass().equals(ClassNotFoundException.class)){
			return "ERROR: Clase no encontrada";
		}else if(e.getClass().equals(InstantiationException.class)){
			return "ERROR: No se pudo instanciar";
		}else if(e.getClass().equals(IllegalAccessException.class)){
			return "ERROR: No se pudo hacer una instancia reflexiva";
		}else if(e.getClass().equals(IllegalArgumentException.class)){
			return "ERROR: Metodo inválido";
		}else if(e.getClass().equals(InvocationTargetException.class)){
			return "ERROR: No se pudo comprobar el constructor";
		}else if(e.getMessage().equals(ERRORCLAVE)){
			return "ERROR: No existe la clave principal";
		}else if(e.getMessage().equals(ERROR_FICHERO)){
			return "ERROR: Nose ha creado el fichero";
		}else if(e.getClass().equals(SQLSyntaxErrorException.class)) {
			return "ERROR: Base de datos";
		}
		return "ERROR desconocido";
	}

}

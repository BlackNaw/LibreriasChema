package Comun;

import javax.servlet.http.HttpServletResponse;
import javax.swing.*;
import java.io.IOException;
import java.io.PrintWriter;

public class Mensajes {
	
	public static final int RELLENAR=0;
	public static final int EXISTE=1;
	public static final int EXITO=2;
	public static final int BORRADO=3;
	public static final int ERRORB=4;
	public static final int MODIFICARE=5;
	public static final int MODIFICAR=6;
	
	private static final  String[] MENSAJES = { "Error, debes rellenar todos los campos",
			"Error, el libro ya existe", 
			"Guardado con exito",
			"TLibro borrado con éxito",
			"Error: no se ha podido borrar el libro", 
			"Error no se ha podido modificar el libro",
			"Exito al modificar"};
	public static String obtenerMensaje(int mensaje){
		assert mensaje > 0;
		return MENSAJES[mensaje];
	}


	public static void mostrarmensaje(String mensaje, String pagina, HttpServletResponse response) throws IOException {
		//Mostramos el mensaje de error
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		out.print("<link rel = stylesheet href=css/mensaje.css>");
		out.print("<div id = openModal class = modalDialog>");
		out.print("<div>");
		out.print("<a href= " + pagina + " title = Close class = 'close'>X</a>");
		out.print("<h2> Mensaje </h2>");
		out.print("<p>" + mensaje + "</p>");
		out.print("</div>");
		out.print("</div>");
	}

}

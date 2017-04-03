package Negocio;


import Persistencia.UtilSQL;

import javax.naming.NamingException;
import java.io.IOException;
import java.sql.SQLException;

public class TLibro {

	private String codLibro;
	private String autor;
	private String titulo;
	private String tema;
	private String paginas;
	private String precio;
	private String formatouno;
	private String formatodos;
	private String formatotres;
	private String estado;


	public TLibro() {
	}

	public TLibro(String titulo, String autor, String tema, String paginas, String precio, String f1, String f2, String f3, String estado) throws ClassNotFoundException, SQLException, IOException, NamingException {
		super();
		this.codLibro= UtilSQL.generarCodigo(this.getClass());
		this.titulo = titulo;
		this.autor = autor;
		this.tema = tema;
		this.paginas = paginas;
		this.precio = precio;
		this.formatouno = f1;
		this.formatodos = f2;
		this.formatotres = f3;
		this.estado = estado;
	}

	public TLibro(String codLibro, String titulo, String autor, String tema, String paginas, String precio, String f1, String f2, String f3, String estado) {
		super();
		this.codLibro=codLibro;
		this.titulo = titulo;
		this.autor = autor;
		this.tema = tema;
		this.paginas = paginas;
        this.precio = precio;
		this.formatouno = f1;
		this.formatodos = f2;
		this.formatotres = f3;
		this.estado = estado;
	}



	public String getAutor() {
		return autor;
	}

	public void setAutor(String autor) {
		this.autor = autor;
	}

	public String getTitulo() {
		return titulo;
	}

	public void setTitulo(String titulo) {
		this.titulo = titulo;
	}

	public String getTema() {
		return tema;
	}

	public void setTema(String tema) {
		this.tema = tema;
	}

	public String getPaginas() {
		return paginas;
	}

	public void setPaginas(String paginas) {
		this.paginas = paginas;
	}

    public String getPrecio() {
        return precio;
    }

    public void setPrecio(String precio) {
        this.precio = precio;
    }

    public String getFormatouno() {
		return formatouno;
	}

	public void setFormatouno(String formatouno) {
		this.formatouno = formatouno;
	}

	public String getFormatodos() {
		return formatodos;
	}

	public void setFormatodos(String formatodos) {
		this.formatodos = formatodos;
	}

	public String getFormatotres() {
		return formatotres;
	}

	public void setFormatotres(String formatotres) {
		this.formatotres = formatotres;
	}

	public String getEstado() {
		return estado;
	}

	public void setEstado( String estado) {
		this.estado= estado;
	}

	public String getCodLibro() {
		return codLibro;
	}

	public void setCodLibro(String codLibro) {
		this.codLibro = codLibro;
	}

	@Override
	public String toString() {
		return titulo;
	}

}

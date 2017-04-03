package Negocio;

import Persistencia.UtilFichero;
import Persistencia.UtilSQL;

import javax.naming.NamingException;
import java.io.IOException;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.Calendar;

/**
 * Created by JAVI on 19/12/2016.
 */
public class TFactura {

    private String codFactura;
    private String usuario;
    private String fechaFactura;
    private String borrado;

    public TFactura() {
    }

    public TFactura(String codFactura, String usuario, String fechaFactura, String borrado) {
        this.codFactura = codFactura;
        this.usuario = usuario;
        this.fechaFactura = fechaFactura;
        this.borrado = borrado;
    }

    public TFactura(String usuario) throws ClassNotFoundException, SQLException, IOException, NamingException {
        Calendar calendario=Calendar.getInstance();
        SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        this.codFactura= UtilSQL.generarCodigo(this.getClass());
        this.usuario = usuario;
        this.fechaFactura=formato.format(calendario.getTimeInMillis());
        this.borrado="0";
    }


    public String getCodFactura() {
        return codFactura;
    }

    public void setCodFactura(String codFactura) {
        this.codFactura = codFactura;
    }

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public String getFechaFactura() {
        return fechaFactura;
    }

    public void setFechaFactura(String fechaFactura) {
        this.fechaFactura = fechaFactura;
    }

    public String getBorrado() {
        return borrado;
    }

    public void setBorrado(String borrado) {
        this.borrado = borrado;
    }

    @Override
    public String toString() {
        return codFactura + " " + usuario + " " + fechaFactura + " " + borrado;
    }
}



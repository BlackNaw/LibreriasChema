package Negocio;

import Persistencia.UtilFichero;
import Persistencia.UtilSQL;

import javax.naming.NamingException;
import java.io.IOException;
import java.sql.SQLException;

/**
 * Created by Juangra on 09/11/2016.
 */
public class TUsuario {

    private String codUsuario;
    private String nick;
    private String pass;
    private String rol;

    public TUsuario() {
    }

    public TUsuario(String codUsuario, String nick, String pass,String rol) {
        this.codUsuario = codUsuario;
        this.nick = nick;
        this.pass = pass;
        this.rol=rol;
    }

    public TUsuario(String nick, String pass,String rol) throws ClassNotFoundException, SQLException, IOException, NamingException {
        this.codUsuario= UtilSQL.generarCodigo(this.getClass());
        this.nick = nick;
        this.pass = pass;
        this.rol=rol;
    }

    public String getRol() {
        return rol;
    }

    public void setRol(String rol) {
        this.rol = rol;
    }

    public String getCodUsuario() {
        return codUsuario;
    }

    public void setCodUsuario(String codUsuario) {
        this.codUsuario = codUsuario;
    }

    public String getNick() {
        return nick;
    }

    public void setNick(String nick) {
        this.nick = nick;
    }

    public String getPass() {
        return pass;
    }

    public void setPass(String pass) {
        this.pass = pass;
    }

    @Override
    public String toString() {
        return codUsuario+" "+nick+" "+pass+" "+rol;
    }
}

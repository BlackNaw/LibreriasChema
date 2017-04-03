package Test;

import Negocio.TLibro;
import Negocio.TUsuario;
import Persistencia.UtilSQL;
import org.junit.Test;



/**
 * Created by Juangra on 08/11/2016.
 */
public class UtilSQLTest {
    TLibro TLibro = new TLibro("Hola","yo","novela","152","fUno","fDos","fTres","nuevo");
    TUsuario TUsuario = new TUsuario();


    @Test
    public void sqlInsertar() throws Exception {
        System.out.println(UtilSQL.sqlInsertar(TLibro));
        System.out.println(UtilSQL.sqlInsertar(TUsuario));
    }

    @Test
    public void sqlBuscar() throws Exception {
        //        System.out.println(UtilSQL.sqlBuscar(TLibro.class,"Nuevo"));
//        System.out.println(UtilSQL.sqlBuscar(TUsuario.class,"CACA"));
    }

    @Test
    public void sqlBorrar() throws Exception {
       // System.out.println(UtilSQL.sqlBorrar(TLibro.class,TLibro.getTitulo()));
    }

    @Test
    public void sqlModificar() throws Exception {
//        System.out.println(UtilSQL.sqlModificar("Cosa",new TLibro()));
//        System.out.println(UtilSQL.sqlModificar("YO",TUsuario));
    }

    @Test
    public void sqlObtener() throws Exception {
        System.out.println(UtilSQL.sqlObtener(TLibro.class));
    }

}
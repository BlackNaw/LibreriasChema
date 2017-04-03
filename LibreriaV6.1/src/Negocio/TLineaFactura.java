package Negocio;

/**
 * Created by JAVI on 19/12/2016.
 */
public class TLineaFactura {

    private String codFactura;
    private String libro;
    private String cantidad;
    private String total;


    public TLineaFactura() {
    }

    public TLineaFactura(String codFactura, String libro, String cantidad, String total) {
        this.codFactura = codFactura;
        this.libro = libro;
        this.cantidad = cantidad;
        this.total = total;
    }

    public String getCodFactura() {
        return codFactura;
    }

    public void setCodFactura(String codFactura) {
        this.codFactura = codFactura;
    }

    public String getLibro() {
        return libro;
    }

    public void setLibro(String libro) {
        this.libro = libro;
    }

    public String getCantidad() {
        return cantidad;
    }

    public void setCantidad(String cantidad) {
        this.cantidad = cantidad;
    }

    public String getTotal() {
        return total;
    }

    public void setTotal(String total) {
        this.total = total;
    }

    @Override
    public String toString() {
        return codFactura + " " + libro + " " + cantidad + " " + total;
    }

    @Override
    public boolean equals(Object obj) {
        return ((TLineaFactura)obj).libro.equals(this.libro);
    }
}

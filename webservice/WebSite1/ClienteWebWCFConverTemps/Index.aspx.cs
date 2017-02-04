using RefServWCFConverTemps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    private ServWebWCFConverTempsClient cliente = null;
    private double nGrados;
    protected void Page_Load(object sender, EventArgs e)
    {
        etError.Text = "";
        cliente = new ServWebWCFConverTempsClient();
    }

    protected void btConvertir_Click(object sender, EventArgs e)
    {
        etError.Text = "";

        // Obtener el valor escrito en la caja de texto
        try
        {
            nGrados = Convert.ToDouble(ctGrados.Text);
            // Realizar la conversión invocando al método correspondiente
            if (rdButton.SelectedValue.Equals("0"))
            {
                ctGrados.Text =
                  Convert.ToString(cliente.ConvCentAFahr(nGrados));
            }
            if (rdButton.SelectedValue.Equals("1"))
            {
                ctGrados.Text =
                  Convert.ToString(cliente.ConvFahrACent(nGrados));
            }
        }
        catch (Exception exc)
        {
            etError.Text = exc.Message;
        }

    }

    protected void btnDetalles_Click(object sender, EventArgs e)
    {
        etError.Text = "";
        try
        {
            nGrados = Convert.ToDouble(ctGrados.Text);
            Detalles detalle = new Detalles();
            detalle.Grados = nGrados;
            detalle.SonCentigrados = rdButton.SelectedValue.Equals("0");
            ctGrados.Text = cliente.ResultadoDetallado(detalle).Literal;
        }
        catch (Exception exc)
        {
            etError.Text = exc.Message;
        }
    }
    //public void ConvCentAFahrAsync(double gCent)
    //{
    //    this.ConvCentAFahrAsync(gCent, null);
    //}
    //public void ConvFahrACentAsync(double gFahr)
    //{
    //    this.ConvFahrACentAsync(gFahr, null);
    //}
}
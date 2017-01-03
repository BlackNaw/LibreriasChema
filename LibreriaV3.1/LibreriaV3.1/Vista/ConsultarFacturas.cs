using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaV3._1.Negocio;
using LibreriaV3._1;
using LibreriaV3._1.Comun;

namespace LibreriaV3._1.Vista
{
    public partial class ConsultarFacturas : Form
    {
        ControlAccesoDAO<object> control = new ControlAccesoDAO<object>();
        List<object> listLineasFactura;

        public ConsultarFacturas()
        {
            InitializeComponent();
            LlenarCombo();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("¿Estás seguro de borrar?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    control.BorradoVirtual(cmbFactura.SelectedItem);
                }
                LlenarCombo();
                LimpiarPantalla();
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void cmbFactura_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                LimpiarPantalla();
                TFactura factura = (TFactura)cmbFactura.SelectedItem;
                lblCliente.Text = factura.Cliente;
                lblFecha.Text = factura.FechaFactura;
                listLineasFactura = control.Buscar(new TLineaFactura().GetType(), "CodFactura", factura.CodFactura);
                RefrescarLineas();
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void LlenarCombo()
        {
            try
            {
                cmbFactura.Items.Clear();
                foreach (TFactura factura in control.Obtener(new TFactura().GetType()))
                {
                    if (factura.Borrado.Equals("0"))
                        cmbFactura.Items.Add(factura);
                }
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void RefrescarLineas()
        {
            try
            {
                decimal contador = 0;
                dataGridView1.Rows.Clear();
                foreach (TLineaFactura linea in listLineasFactura)
                {
                    dataGridView1.Rows.Add(
                        new object[]
                        {
                        linea.Libro,
                        linea.Cantidad,
                        Convert.ToString(decimal.Parse(linea.Total)/int.Parse(linea.Cantidad)),
                        linea.Total
                        });
                    contador += decimal.Parse(linea.Total);
                }
                lblTotal.Text = contador + " €";
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void LimpiarPantalla()
        {
            dataGridView1.Rows.Clear();
            lblCliente.Text = "";
            lblFecha.Text = "";
        }

    }
}

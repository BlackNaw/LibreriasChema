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
using LibreriaV3._1.Modelo;
using LibreriaV3._1.Comun;

namespace LibreriaV3._1.Vista
{
    public partial class InsertarFacturas : Form
    {
      
        private ControlAccesoDAO<object> control = new ControlAccesoDAO<object>();
        private List<TLineaFactura> listLineasFacturas=new List<TLineaFactura>();
        public InsertarFacturas()
        {
            InitializeComponent();
            LlenarCombos();
            lblCodFactura.Text = Util.GenerarCodigo(new TFactura().GetType());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            cmbClientes.Enabled = false;
            TLibro libro=(TLibro)cmbLibros.SelectedItem;
            TLineaFactura lineaFactura = new TLineaFactura(lblCodFactura.Text, libro.Titulo, Convert.ToString(txtCantidad.Value), Convert.ToString(Convert.ToDecimal(libro.Precio) * txtCantidad.Value));
            if (!listLineasFacturas.Contains(lineaFactura)) {
                listLineasFacturas.Add(lineaFactura);
                dataGridView1.Rows.Add(
                new object[]
                {
                        lineaFactura.Libro,
                        lineaFactura.Cantidad,
                        libro.Precio,
                        lineaFactura.Total,
                });

            }
            else
            {   
                lineaFactura.Cantidad = Convert.ToString(int.Parse(listLineasFacturas[listLineasFacturas.IndexOf(lineaFactura)].Cantidad) + txtCantidad.Value);
                listLineasFacturas[listLineasFacturas.IndexOf(lineaFactura)].Cantidad=lineaFactura.Cantidad;
                lineaFactura.Total = Convert.ToString(int.Parse(lineaFactura.Cantidad) * decimal.Parse(libro.Precio));
                listLineasFacturas[listLineasFacturas.IndexOf(lineaFactura)].Total = lineaFactura.Total;
                dataGridView1["Cantidad", listLineasFacturas.IndexOf(lineaFactura)].Value = lineaFactura.Cantidad;
                dataGridView1["Subtotal", listLineasFacturas.IndexOf(lineaFactura)].Value = lineaFactura.Total;
            }

            decimal total = 0;
            foreach (TLineaFactura item in listLineasFacturas)
            {
                total += decimal.Parse(item.Total);
            }

            lblTotal.Text = Convert.ToString(total);

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            TFactura factura = new TFactura(lblCodFactura.Text, ((TCliente)cmbClientes.SelectedItem).Nombre +" "+((TCliente)cmbClientes.SelectedItem).Apellidos, txtFecha.Text);
            if (listLineasFacturas.Count == 0)
            {
                MessageBox.Show("Añade elementos a la factura");
            }else
            {
                control.Insertar(factura);
                foreach (TLineaFactura item in listLineasFacturas)
                {
                    control.Insertar(item);
                }
            }
            cmbClientes.Enabled = true;
            RefrescarLineas();
        }

        private void RefrescarLineas()
        {
            dataGridView1.Rows.Clear();
            cmbClientes.SelectedIndex = 0;
            cmbLibros.SelectedIndex = 0;
            txtCantidad.Value = 1;
            txtFecha.Value = DateTime.Today;
            listLineasFacturas.Clear();
            lblCodFactura.Text = Util.GenerarCodigo(new TFactura().GetType());
        }

        private void LlenarCombos()
        {
            foreach (TCliente cliente in control.Obtener(new TCliente().GetType()))
            {
                if (cliente.Borrado.Equals("0"))
                {
                    cmbClientes.Items.Add(cliente);
                }
            }

            foreach (TLibro libro in control.Obtener(new TLibro().GetType()))
            {
                if (libro.Borrado.Equals("0")){
                    cmbLibros.Items.Add(libro);
                }
            }

            cmbClientes.SelectedIndex = 0;
            cmbLibros.SelectedIndex = 0;
        }

        public void LimpiarPantalla()
        {
       
            dataGridView1.Rows.Clear();
            cmbClientes.SelectedIndex = 0;
            cmbLibros.SelectedIndex = 0;
            txtCantidad.Value = 1;
            txtFecha.Value = DateTime.Today;
        }

   

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void InsertarFacturas_Load(object sender, EventArgs e)
        {
           
        }
    }
}

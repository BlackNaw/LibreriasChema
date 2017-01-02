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

namespace LibreriaV3._1.Vista
{
    public partial class BorrarFacturas : Form
    {
        //ControlAccesoDAO<Cliente> clienteAccesoDao;
        ControlAccesoDAO<Libro> libroAccesoDao;
        //ControlAccesoDAO<Factura> facturaAccesoDao;
        //Factura factura;
        //private List<LineaFactura> lineasFactura;

        public BorrarFacturas()
        {
            InitializeComponent();
            InicializarVariables();
            LlenarCombo();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            //if (facturaAccesoDao.BorradoVirtual(factura.CodFactura))
                MessageBox.Show("Factura Eliminada.");
            LimpiarPantalla();
            LlenarCombo();
        }

        private void cmbFactura_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LimpiarPantalla();
            //factura = facturaAccesoDao.Buscar(cmbFactura.SelectedItem.ToString());
            //lblCliente.Text = clienteAccesoDao.Buscar(factura.Dni).ToString();
            //lblFecha.Text = factura.Fecha.ToString().Substring(0, 10);
            //lineasFactura = new ControlAccesoDAO<LineaFactura>().Obtener(cmbFactura.SelectedItem.ToString());
            //factura.LineasFactura = lineasFactura;
            RefrescarLineas();
        }

        private void LlenarCombo()
        {
            cmbFactura.Items.Clear();
            //List<Factura> facturas = facturaAccesoDao.Obtener();

            //foreach (var factura in facturas)
            //{
            //    cmbFactura.Items.Add(factura.CodFactura);
            //}

            //cmbFactura.SelectedIndex = 0;
        }

        private void RefrescarLineas()
        {
            float contador = 0;
            dataGridView1.Rows.Clear();
            //foreach (LineaFactura linea in factura.LineasFactura)
            //{
                //dataGridView1.Rows.Add(
                //    new object[]
                //    {
                //        linea.Titulo,
                //        linea.Cantidad,
                //        linea.Precio,
                //        linea.Cantidad*linea.Precio
                //    });
                //contador += linea.Cantidad * linea.Precio;
            //}
            lblTotal.Text = contador + " €";
        }

        public void LimpiarPantalla()
        {
            dataGridView1.Rows.Clear();
            InicializarVariables();
            lblCliente.Text = "";
            lblFecha.Text = "";
        }

        public void InicializarVariables()
        {
            //clienteAccesoDao = new ControlAccesoDAO<Cliente>();
            libroAccesoDao = new ControlAccesoDAO<Libro>();
            //facturaAccesoDao = new ControlAccesoDAO<Factura>();
            //factura = new Factura();
            //lineasFactura = new List<LineaFactura>();
        }
    }
}

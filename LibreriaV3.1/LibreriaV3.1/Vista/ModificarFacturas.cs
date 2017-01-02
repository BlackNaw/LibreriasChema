using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibreriaV3._1.Negocio;

namespace LibreriaV3._1.Vista
{
    public partial class ModificarFacturas : Form
    {
        //ControlAccesoDAO<Cliente> clienteAccesoDao;
        ControlAccesoDAO<Libro> libroAccesoDao;
        //ControlAccesoDAO<Factura> facturaAccesoDao;
        //Factura factura;
        //private List<LineaFactura> lineasFactura;

        public ModificarFacturas()
        {
            InitializeComponent();
            InicializarVariables();
            LlenarCombo();
        }

        private void cmbFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LimpiarPantalla();
            //factura = facturaAccesoDao.Buscar(cmbFactura.SelectedItem.ToString());
            //cmbCliente.Text = clienteAccesoDao.Buscar(factura.Dni).ToString();
            //txtFecha.Text = factura.Fecha.ToString().Substring(0, 10);
            //lineasFactura = new ControlAccesoDAO<LineaFactura>().Obtener(cmbFactura.SelectedItem.ToString());
            //factura.LineasFactura = lineasFactura;
            //RefrescarLineas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //if (facturaAccesoDao.Modificar(factura.CodFactura,factura))
            //    MessageBox.Show("Factura Modificada.");
            LimpiarPantalla();
            LlenarCombo();
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                cmbLibros.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtCantidad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void LlenarCombo()
        {
            cmbFactura.Items.Clear();
            cmbCliente.Items.Clear();
            cmbLibros.Items.Clear();
            //List<Factura> facturas = facturaAccesoDao.Obtener();
            //List<Cliente> clientes = clienteAccesoDao.Obtener();
            //List<Libro> libros = libroAccesoDao.Obtener();

            //foreach (var factura in facturas)
            //{
            //    cmbFactura.Items.Add(factura.CodFactura);
            //}

            //foreach (var libro in libros)
            //{
            //    cmbLibros.Items.Add(libro);
            //}

            //foreach (var cliente in clientes)
            //{
            //    cmbCliente.Items.Add(cliente);
            //}

            //cmbFactura.SelectedIndex = 0;
            //cmbCliente.SelectedIndex = 0;
            //cmbLibros.SelectedIndex = 0;
        }

        private void RefrescarLineas()
        {
            float contador = 0;
            dataGridView1.Rows.Clear();
            //foreach (LineaFactura linea in factura.LineasFactura)
            //{
            //    if (linea.Estado != 3)
            //    {
            //        dataGridView1.Rows.Add(
            //            new object[]
            //            {
            //                linea.Titulo,
            //                linea.Cantidad,
            //                linea.Precio,
            //                linea.Cantidad*linea.Precio
            //            });
            //        contador += linea.Cantidad*linea.Precio;
            //    }
            //}
            lblTotal.Text = contador + " €";
        }

        public void LimpiarPantalla()
        {
            dataGridView1.Rows.Clear();
            InicializarVariables();
        }

        public void InicializarVariables()
        {
            //clienteAccesoDao = new ControlAccesoDAO<Cliente>();
            //libroAccesoDao = new ControlAccesoDAO<Libro>();
            //facturaAccesoDao = new ControlAccesoDAO<Factura>();
            //factura = new Factura();
            //lineasFactura = new List<LineaFactura>();
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            Libro libroActual = (Libro)cmbLibros.SelectedItem;
            if (libroActual != null)
            {
                int cantidad = (int)txtCantidad.Value;
                bool encontrado = false;
                //foreach (LineaFactura linea in factura.LineasFactura)
                //{
                //    if (linea.Titulo.Equals(libroActual.Titulo))
                //    {
                //        linea.Cantidad += cantidad;
                //        encontrado = true;
                //        break;
                //    }
                //}
                //if (!encontrado)
                //{
                //    factura.LineasFactura.Add(new LineaFactura()
                //    {
                //        CodFactura = cmbFactura.SelectedItem.ToString(),
                //        Titulo = libroActual.Titulo,
                //        Cantidad = cantidad,
                //        Precio = libroActual.Precio,
                //        Estado = 1
                //    });
                //}
                //RefrescarLineas();
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            Libro libroActual = (Libro)cmbLibros.SelectedItem;
            //if (libroActual != null)
            //{
            //    if (dataGridView1.CurrentRow.Cells[0].Value.ToString() != libroActual.Titulo)
            //        factura.LineasFactura.RemoveAll(linea => linea.Titulo.Equals(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

            //    int cantidad = (int)txtCantidad.Value;
            //    bool encontrado = false;
            //    foreach (LineaFactura linea in factura.LineasFactura)
            //    {
            //        if (linea.Titulo.Equals(libroActual.Titulo))
            //        {
            //                linea.Cantidad = cantidad;
            //            encontrado = true;
            //            break;
            //        }
            //    }
            //    if (!encontrado)
            //    {
            //        factura.LineasFactura.Add(new LineaFactura()
            //        {
            //            Titulo = libroActual.Titulo,
            //            Cantidad = cantidad,
            //            Precio = libroActual.Precio,
            //            Estado = 1
            //        });
            //    }
            //    RefrescarLineas();
            //}
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Libro libroActual = (Libro)cmbLibros.SelectedItem;
            if (libroActual != null)
            {
                int cantidad = (int)txtCantidad.Value;
                //foreach (LineaFactura linea in factura.LineasFactura)
                //{
                //    if (linea.Titulo.Equals(libroActual.Titulo))
                //    {
                //        linea.Cantidad += cantidad;
                //        linea.Estado = 3;
                //        break;
                //    }
                //}
                RefrescarLineas();
            }
        }
    }
}

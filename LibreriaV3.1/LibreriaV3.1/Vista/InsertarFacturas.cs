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
    public partial class InsertarFacturas : Form
    {
        //ControlAccesoDAO<Cliente> clienteAccesoDao;
        ControlAccesoDAO<Libro> libroAccesoDao;
        //ControlAccesoDAO<Factura> facturaAccesoDao;
        //Factura factura;
        //private List<LineaFactura> lineasFactura;
        public InsertarFacturas()
        {
            InitializeComponent();
            InicializarVariables();
            LlenarCombos();
        }

        private void btnOk_Click(object sender, EventArgs e)
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
                if (!encontrado)
                {
                    //factura.LineasFactura.Add(new LineaFactura()
                    //{
                    //    Titulo = libroActual.Titulo,
                    //    Cantidad = cantidad,
                    //    Precio = libroActual.Precio,
                    //});
                }
                RefrescarLineas();
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string codigo = lblCodFactura.Text;
            //Cliente cliente = (Cliente)cmbClientes.SelectedItem;
            //factura.CodFactura = codigo;
            //factura.Dni = cliente.Dni;
            //factura.Fecha = txtFecha.Value;
            //foreach (var linea in factura.LineasFactura)
            //{
            //    linea.CodFactura = codigo;
            //}
            //facturaAccesoDao.Insertar(factura);
            MessageBox.Show("Factura añadida con éxito");
            //lineasFactura.Clear();
            LimpiarPantalla();
        }

        private void RefrescarLineas()
        {
            float contador = 0;
            dataGridView1.Rows.Clear();
            //foreach (LineaFactura linea in factura.LineasFactura)
            //{
            //    dataGridView1.Rows.Add(
            //        new object[]
            //        {
            //            linea.Titulo,
            //            linea.Cantidad,
            //            linea.Precio,
            //            linea.Cantidad*linea.Precio
            //        });
            //    contador += linea.Cantidad*linea.Precio;
            //}
            lblTotal.Text = contador + " €";
        }

        private void LlenarCombos()
        {
            //List<Cliente> clientes = clienteAccesoDao.Obtener();
            //List<Libro> libros = libroAccesoDao.Obtener();

            //foreach (var cliente in clientes)
            //{
            //    cmbClientes.Items.Add(cliente);
            //}

            //foreach (var libro in libros)
            //{
            //    cmbLibros.Items.Add(libro);
            //}

            //cmbClientes.SelectedIndex = 0;
            //cmbLibros.SelectedIndex = 0;
        }

        public void LimpiarPantalla()
        {
            dataGridView1.Rows.Clear();
            InicializarVariables();
            cmbClientes.SelectedIndex = 0;
            cmbLibros.SelectedIndex = 0;
            txtCantidad.Value = 1;
            txtFecha.Value = DateTime.Today;
        }

        public void InicializarVariables()
        {
            //clienteAccesoDao = new ControlAccesoDAO<Cliente>();
            //libroAccesoDao = new ControlAccesoDAO<Libro>();
            //facturaAccesoDao = new ControlAccesoDAO<Factura>();
            //factura = new Factura();
            //lineasFactura = new List<LineaFactura>();
            //lblCodFactura.Text = facturaAccesoDao.ObtenerSiguienteId(factura);
        }
    }
}

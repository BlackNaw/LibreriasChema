using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaV3._1.Persistencia;
using LibreriaV3._1.Negocio;
using LibreriaV3._1.Modelo;

namespace LibreriaV3._1
{
    public partial class Libro : Form
    {
        private ControlAccesoDAO<TLibro> control = new ControlAccesoDAO<TLibro>();
        private TLibro libro;
        public Libro()
        {
            InitializeComponent();
            ObtenerTemas();
            ObtenerTodosLibros();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMensaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConexionJDBC.CerrarConexion();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConexionJDBC.CerrarConexion();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            VaciarPantalla();
        }


        private void btnAlta_Click(object sender, EventArgs e)
        {
            txtMensaje.Text = "";
            if ((libro = RecogerDatosPantalla()) == null)
            {
                txtMensaje.Text="Rellenar todos los campos";
            }
            else
            {
                if (control.Buscar(libro.GetType(), libro.CodLibro) != null)
                {
                    txtMensaje.Text = "El libro ya existe";
                }
                else
                {
                    control.Insertar(libro);
                    VaciarPantalla();
                    txtMensaje.Text = "Libro añadido con exito";
                    ObtenerTodosLibros();
                }
            }


        }

        private TLibro RecogerDatosPantalla()
        {
            TLibro libro = null;
            string titulo, autor, paginas, precio, formatoUno, formatoDos, formatoTres, estado, tema;
            titulo = txtTitulo.Text;
            autor = txtAutor.Text;
            paginas = txtPaginas.Text;
            precio = txtPrecio.Text.Replace(",",".");
            formatoUno = chkCartone.Checked ? chkCartone.Text : "N/A" ;
            formatoDos = chkRustica.Checked ? chkRustica.Text : "N/A";
            formatoTres = chkTapaDura.Checked ? chkTapaDura.Text : "N/A";
            tema = cbxTemas.SelectedItem.ToString();
            if (rbNovedad.Checked)
            {
                estado = "novedad";
            }
            else
            {
                estado = "reedicion";
            }

            if (titulo.Count() != 0 && paginas.Count() != 0 && titulo.Count() != 0 && precio.Count() != 0)
            {
                libro = new TLibro(autor, titulo, tema, paginas, precio, formatoUno, formatoDos, formatoTres, estado);
            }
            return libro;
        }

        private void ObtenerTodosLibros()
        {
            List<object> libros = new List<object>();
            foreach (TLibro item in control.Obtener(new TLibro().GetType()))
            {
                if (item.Borrado.Equals("0")){
                    libros.Add(item);
                }
            } 
            lstLibros.DataSource = libros;

        }
        private void ObtenerTemas()
        {
            foreach (var item in control.ObtenerTemas())
            {
                cbxTemas.Items.Add(item);
            }
            cbxTemas.SelectedIndex = 0;
        }

        private void VaciarPantalla()
        {
            txtAutor.Text = "";
            txtMensaje.Text = "";
            txtPaginas.Text = "";
            txtPrecio.Text = "";
            txtTitulo.Text = "";
            cbxTemas.SelectedIndex = 0;
            rbNovedad.Checked = true;
            rbReedicion.Checked = false;
            chkCartone.Checked = false;
            chkRustica.Checked = false;
            chkTapaDura.Checked = false;
        }

   
    }
}

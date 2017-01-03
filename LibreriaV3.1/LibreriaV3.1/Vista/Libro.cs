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
using LibreriaV3._1.Comun;

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
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            VaciarPantalla();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                txtMensaje.Text = "";
                if ((libro = RecogerDatosPantalla()) == null)
                {
                    MessageBox.Show("Rellenar todos los campos");
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
                        ObtenerTodosLibros();
                        txtMensaje.Text = "Libro añadido con exito";
                    }
                }
                lstLibros.ClearSelected();
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private TLibro RecogerDatosPantalla()
        {
            try
            {
                TLibro libro = null;
                string titulo, autor, paginas, precio, formatoUno, formatoDos, formatoTres, estado, tema;
                titulo = txtTitulo.Text;
                autor = txtAutor.Text;
                paginas = txtPaginas.Text;
                precio = txtPrecio.Text.Replace(".", ",");
                precio = precio.Replace("€", "");
                precio = precio.Trim();
                formatoUno = chkCartone.Checked ? chkCartone.Text : "N/A";
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
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
        }

        private void ObtenerTodosLibros()
        {
            try
            {
                List<object> libros = new List<object>();
                foreach (TLibro item in control.Obtener(new TLibro().GetType()))
                {
                    if (item.Borrado.Equals("0"))
                    {
                        libros.Add(item);
                    }
                }
                lstLibros.DataSource = libros;
                lstLibros.ClearSelected();
                VaciarPantalla();
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void ObtenerTemas()
        {
            try
            {
                foreach (var item in control.ObtenerTemas())
                {
                    cbxTemas.Items.Add(item);
                }
                cbxTemas.SelectedIndex = 0;
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLibros.SelectedItem != null)
            {
                RellenarCampos((TLibro)lstLibros.SelectedItem);
            }
        }

        private void RellenarCampos(TLibro sender)
        {
            try
            {
                txtAutor.Text = sender.Autor;
                txtPaginas.Text = sender.Paginas;
                txtPrecio.Text = sender.Precio + " €";
                txtTitulo.Text = sender.Titulo;
                cbxTemas.Text = sender.Tema;
                if (sender.Estado.Equals("reedicion"))
                {
                    rbReedicion.Checked = true;
                    rbNovedad.Checked = false;
                }
                else
                {
                    rbNovedad.Checked = true;
                    rbReedicion.Checked = false;
                }

                chkCartone.Checked = sender.Formatouno.Equals("Cartoné") ? true : false;
                chkRustica.Checked = sender.Formatodos.Equals("Rústica") ? true : false;
                chkTapaDura.Checked = sender.Formatotres.Equals("Tapa dura") ? true : false;
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try{
                if (lstLibros.SelectedItem != null)
                {
                    MsgBoxUtil.HackMessageBox("Borrado Virtual", "Borrar");
                    var result = MessageBox.Show("¿Cómo deseas borrar?", "¡Atención!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                    //Borrado virtual
                    if (result == DialogResult.Yes)
                    {
                        if (control.BorradoVirtual(lstLibros.SelectedItem))
                        {
                            txtMensaje.Text = "Borrado virtual satisfactorio";
                            ObtenerTodosLibros();
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        if (control.Borrar(lstLibros.SelectedItem))
                        {
                            txtMensaje.Text = "Libro borrado satisfactoriamente";
                            ObtenerTodosLibros();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un libro");
                }
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtPaginas_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.') && (e.KeyChar != ','))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
                if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                {
                    e.Handled = true;
                }
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                TLibro libro = RecogerDatosPantalla();
                if (libro != null)
                {
                    libro.CodLibro = ((TLibro)lstLibros.SelectedItem).CodLibro;
                    if (control.Modificar(libro.CodLibro, libro))
                    {
                        ObtenerTodosLibros();
                        txtMensaje.Text = "Libro modificado";
                    }
                }
                else
                {
                    MessageBox.Show("Compruebe los campos");
                }
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }


        }
    }
}

using LibreriaV3._1.Comun;
using LibreriaV3._1.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaV3._1.Vista
{
    public partial class Clientes : Form
    {

        private ControlAccesoDAO<TCliente> control = new ControlAccesoDAO<TCliente>();
        private TCliente cliente;

        public Clientes()
        {
            InitializeComponent();
            ObtenerTodosClientes();
        }

        private void lstLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstClientes.SelectedItem != null)
                {
                    RellenarCampos((TCliente)lstClientes.SelectedItem);
                }
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void RellenarCampos(TCliente cliente)
        {
            try
            {
                txtNombre.Text = cliente.Nombre;
                txtApellidos.Text = cliente.Apellidos;
                txtDireccion.Text = cliente.Direccion;
                txtEmail.Text = cliente.Email;
                txtDNI.Text = cliente.DNI;
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                txtMensaje.Text = "";
                if ((cliente = RecogerDatosPantalla()) == null)
                {
                    MessageBox.Show("Rellenar todos los campos");
                }
                else
                {
                    if (control.Buscar(cliente.GetType(), cliente.CodCliente) != null)
                    {
                        txtMensaje.Text = "El cliente ya existe";
                    }
                    else
                    {
                        control.Insertar(cliente);
                        ObtenerTodosClientes();
                        txtMensaje.Text = "Cliente añadido con exito";
                    }
                }
                lstClientes.ClearSelected();
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            VaciarPantalla();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstClientes.SelectedItem != null)
                {
                    MsgBoxUtil.HackMessageBox("Borrado Virtual", "Borrar");
                    var result = MessageBox.Show("¿Cómo deseas borrar?", "¡Atención!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                    //Borrado virtual
                    if (result == DialogResult.Yes)
                    {
                        if (control.BorradoVirtual(lstClientes.SelectedItem))
                        {
                            txtMensaje.Text = "Borrado virtual satisfactorio";
                            ObtenerTodosClientes();
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        if (control.Borrar(lstClientes.SelectedItem))
                        {
                            txtMensaje.Text = "Cliente borrado satisfactoriamente";
                            ObtenerTodosClientes();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un cliente");
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
                TCliente cliente = RecogerDatosPantalla();
                if (cliente != null)
                {
                    cliente.CodCliente = ((TCliente)lstClientes.SelectedItem).CodCliente;
                    if (control.Modificar(cliente.CodCliente, cliente))
                    {
                        ObtenerTodosClientes();
                        txtMensaje.Text = "Cliente modificado";
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ObtenerTodosClientes()
        {
            try
            {
                List<object> clientes = new List<object>();
                foreach (TCliente item in control.Obtener(new TCliente().GetType()))
                {
                    if (item.Borrado.Equals("0"))
                    {
                        clientes.Add(item);
                    }
                }
                lstClientes.DataSource = clientes;
                lstClientes.ClearSelected();
                VaciarPantalla();
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void VaciarPantalla()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            txtMensaje.Text = "";

        }

        private TCliente RecogerDatosPantalla()
        {
            try
            {
                TCliente libro = null;
                string nombre, apellidos, dni, direccion, email;
                nombre = txtNombre.Text;
                apellidos = txtApellidos.Text;
                dni = txtDNI.Text;
                direccion = txtDireccion.Text;
                email = txtEmail.Text;

                if (nombre.Count() != 0 && apellidos.Count() != 0 && dni.Count() != 0 && direccion.Count() != 0 && email.Count() != 0)
                {
                    libro = new TCliente(nombre, apellidos, dni, direccion, email);
                }
            return libro;
            }
            catch (Errores error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
        }
    }
}

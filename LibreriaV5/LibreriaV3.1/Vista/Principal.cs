using LibreriaV3._1.Comun;
using LibreriaV3._1.Persistencia;
using System;
using System.Windows.Forms;

namespace LibreriaV3._1.Vista
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        
        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Libro().ShowDialog(this);
        }

        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InsertarFacturas().ShowDialog(this);
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ConsultarFacturas().ShowDialog(this);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Clientes().ShowDialog(this);
            
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Util.EscribirDictionarySentenciasFichero();
            ConexionJDBC.CerrarConexion();
        }
    }
}

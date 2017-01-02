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
            this.IsMdiContainer = true;
            Libro formularioLibros = new Libro();
            formularioLibros.MdiParent = this;
            formularioLibros.Show();
        }

        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            InsertarFacturas formularioFacturas = new InsertarFacturas();
            formularioFacturas.MdiParent = this;
            formularioFacturas.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ModificarFacturas formularioFacturas = new ModificarFacturas();
            formularioFacturas.MdiParent = this;
            formularioFacturas.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BorrarFacturas formularioFacturas = new BorrarFacturas();
            formularioFacturas.MdiParent = this;
            formularioFacturas.Show();
        }
    }
}

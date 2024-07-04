using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;

namespace CapaPedentacion
{
    public partial class Form1 : Form

    {
        CN_Citas objetoCN = new CN_Citas();

        private string idCitas;

        private bool Modif=false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarCitas();
        }
        private void MostrarCitas()
        {
            CN_Citas objeto = new CN_Citas();
            dataGridView1.DataSource = objeto.MostrarCit();
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Modif == false)
            {
                try
                {
                    objetoCN.InsertarCit(txtNombre.Text, txtFecha.Text, txtHora.Text, txtDuracion.Text);
                    MessageBox.Show("Se Inserto Correctamente");
                    MostrarCitas();
                }
                catch (Exception)
                {
                    MessageBox.Show("error");
                }
            }
            if (Modif == true) 
            {
                try
                {
                    objetoCN.ModificarCitas(txtNombre.Text, txtFecha.Text, txtHora.Text, txtDuracion.Text,idCitas);
                    MessageBox.Show("Se edito Correctamente" );
                    MostrarCitas();
                    LimpiarEntrada();
                    Modif = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al Editar" + ex);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Modif = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                txtHora.Text = dataGridView1.CurrentRow.Cells["Hora"].Value.ToString();
                txtDuracion.Text = dataGridView1.CurrentRow.Cells["Duracion"].Value.ToString();
                idCitas = dataGridView1.CurrentRow.Cells["id"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una Fila Porfavor");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idCitas = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                objetoCN.EliminarCitas(idCitas);
                MessageBox.Show("se elimino correctamente");
                MostrarCitas();
            }
            else
            {
                MessageBox.Show("Falla al Eliminar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEntrada();
            txtNombre.Enabled = false;
        }
         private void LimpiarEntrada()
        {
            txtNombre.Clear();
            txtFecha.Clear();
            txtHora.Clear();
            txtDuracion.Clear();
            txtNombre.Focus();
        }
    }
}

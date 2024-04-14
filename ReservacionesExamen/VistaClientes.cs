using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservacionesExamen
{
    public partial class VistaClientes : Form
    {
        private NClientes nVariable;
        public VistaClientes()
        {
            InitializeComponent();
            nVariable = new NClientes();
        }

        private void VistaClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            var grupo = nVariable.obtener().Select(c => new { c.ClienteId, c.Nombres, c.Apellidos, c.FechaIngreso, c.Estado });
            DGVDatos.DataSource = grupo.ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var id = txtID.Text.ToString();

            var Nombres = txtNombres.Text.ToString();
            var Apellidos = txtApellidos.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Agregar = true;
            }

            if (string.IsNullOrEmpty(Nombres) || string.IsNullOrWhiteSpace(Nombres))
            {
                errorProvider1.SetError(txtNombres, "Debe de ingresar los Nombres");
                return;
            }
            if (string.IsNullOrEmpty(Apellidos) || string.IsNullOrWhiteSpace(Apellidos))
            {
                errorProvider1.SetError(txtApellidos, "Debe de ingresa los Apellidos");
                return;
            }

            if (Agregar)
            {
                nVariable.Agregar(new Datos.BaseDatos.Modelos.Clientes()
                {
                    Nombres = txtNombres.Text.ToString(),
                    Apellidos = txtApellidos.Text.ToString(),
                    FechaIngreso = DateTime.Now,
                    Estado = chkEstado.Checked,
                });
            }
            else
            {
                nVariable.Editar(new Datos.BaseDatos.Modelos.Clientes()
                {
                    ClienteId = int.Parse(id),
                    Nombres = Nombres,
                    Apellidos = Apellidos,
                    FechaIngreso = dtpFechaIngreso.Value,
                    Estado = chkEstado.Checked,
                });

            }
            CargarDatos();
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            txtID.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            dtpFechaIngreso.Value = DateTime.Now;
            chkEstado.Checked = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var id = txtID.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return;
            }
            nVariable.EliminarRegistro(int.Parse(id));
            CargarDatos();
            LimpiarDatos();
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            DGVDatos.DataSource = nVariable.RegistrosActivos();
        }

        private void rbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            DGVDatos.DataSource = nVariable.RegistrosInactivos();
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool estado = Convert.ToBoolean(DGVDatos.CurrentRow.Cells["Estado"].Value);

            txtID.Text = DGVDatos.CurrentRow.Cells["ClienteId"].Value.ToString();
            txtNombres.Text = DGVDatos.CurrentRow.Cells["Nombres"].Value.ToString();
            txtApellidos.Text = DGVDatos.CurrentRow.Cells["Apellidos"].Value.ToString();
            dtpFechaIngreso.Text = DGVDatos.CurrentRow.Cells["FechaIngreso"].Value.ToString();
            chkEstado.Checked = estado;
        }
    }
}

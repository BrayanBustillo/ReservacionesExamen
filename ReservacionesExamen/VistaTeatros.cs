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
    public partial class VistaTeatros : Form
    {
        private NTeatros nVariable;
        public VistaTeatros()
        {
            InitializeComponent();
            nVariable = new NTeatros();
        }

        private void VistaTeatros_Load(object sender, EventArgs e)
        {
            CargarDatos();

            DGVDatos.Columns["Nombre"].Width = 150;
        }
        private void CargarDatos()
        {
            var grupo = nVariable.obtener().Select(c => new { c.TeatroId, c.Nombre, c.Capacidad, c.Estado });
            DGVDatos.DataSource = grupo.ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var id = txtID.Text.ToString();

            var Nombres = txtNombre.Text.ToString();
            var Capacidad = txtCapacidad.Text.ToString();

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Agregar = true;
            }

            if (string.IsNullOrEmpty(Nombres) || string.IsNullOrWhiteSpace(Nombres))
            {
                errorProvider1.SetError(txtNombre, "Debe de ingresar el Nombre");
                return;
            }
            if (string.IsNullOrEmpty(Capacidad) || string.IsNullOrWhiteSpace(Capacidad))
            {
                errorProvider1.SetError(txtCapacidad, "Debe de ingresa la Capacidad");
                return;
            }

            if (Agregar)
            {
                nVariable.Agregar(new Datos.BaseDatos.Modelos.Teatros()
                {
                    Nombre = txtNombre.Text.ToString(),
                    Capacidad = int.Parse(txtCapacidad.Text),
                    Estado = chkEstado.Checked,
                });
            }
            else
            {
                nVariable.Editar(new Datos.BaseDatos.Modelos.Teatros()
                {
                    TeatroId = int.Parse(id),
                    Nombre = Nombres,
                    Capacidad = int.Parse(Capacidad),
                    Estado = chkEstado.Checked,
                });

            }
            CargarDatos();
            LimpiarDatos();
        }
        private void LimpiarDatos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtCapacidad.Clear();
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

            txtID.Text = DGVDatos.CurrentRow.Cells["TeatroId"].Value.ToString();
            txtNombre.Text = DGVDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            txtCapacidad.Text = DGVDatos.CurrentRow.Cells["Capacidad"].Value.ToString();
            chkEstado.Checked = estado;
        }
    }
}

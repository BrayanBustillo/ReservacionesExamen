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
    public partial class VistaReservas : Form
    {
        private NReservas nReservas;
        private NTeatros nTeatros;
        private NClientes nClientes;
        public VistaReservas()
        {
            InitializeComponent();
            nReservas = new NReservas();
            nTeatros = new NTeatros();
            nClientes = new NClientes();
        }

        private void VistaReservas_Load(object sender, EventArgs e)
        {
            CargarCombobox();
            CargarDatos();
            ColumnasDGV();
        }

        private void CargarDatos()
        {
            var grupo = nReservas.obtener().Select(c => new { c.ReservaId, c.TeatroId, Nombre = c.teatro.Nombre, c.ClienteId, InformacionCliente = c.cliente.Nombres + " " + c.cliente.Apellidos, c.FechaReserva });
            DGVDatos.DataSource = grupo.ToList();
        }

        private void CargarCombobox()
        {
            //Teatros
            cmbTeatros.DataSource = nTeatros.RegistrosActivos()
                                          .Select(c => new { c.TeatroId, Nombre = $"{c.Nombre}" })
                                          .ToList();

            cmbTeatros.ValueMember = "TeatroId";
            cmbTeatros.DisplayMember = "Nombre";

            //Clientes
            cmbClientes.DataSource = nClientes.RegistrosActivos()
                                          .Select(c => new { c.ClienteId, Nombre = $"{c.ClienteId} - {c.Nombres} {c.Apellidos}" })
                                          .ToList();

            cmbClientes.ValueMember = "ClienteId";
            cmbClientes.DisplayMember = "Nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var Agregar = false;
            var id = txtID.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Agregar = true;
            }

            if (Agregar)
            {
                nReservas.Agregar(new Datos.BaseDatos.Modelos.Reserva()
                {
                    TeatroId = int.Parse(cmbTeatros.SelectedValue.ToString()),
                    ClienteId = int.Parse(cmbClientes.SelectedValue.ToString()),
                    FechaReserva = dtpFechaReserva.Value,
                });
            }
            else
            {
                nReservas.Editar(new Datos.BaseDatos.Modelos.Reserva()
                {
                    ReservaId = int.Parse(id),
                    TeatroId = int.Parse(cmbTeatros.SelectedValue.ToString()),
                    ClienteId = int.Parse(cmbClientes.SelectedValue.ToString()),
                    FechaReserva = dtpFechaReserva.Value,
                });
            }

            CargarDatos();
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            txtID.Clear();

            dtpFechaReserva.Value = DateTime.Now;

            Random random = new Random();

            int index1 = random.Next(0, cmbTeatros.Items.Count);
            int index2 = random.Next(0, cmbClientes.Items.Count);

            cmbTeatros.SelectedIndex = index1;
            cmbClientes.SelectedIndex = index2;
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = DGVDatos.CurrentRow.Cells["ReservaId"].Value.ToString();
            cmbTeatros.Text = DGVDatos.CurrentRow.Cells["TeatroId"].Value.ToString();
            cmbClientes.Text = DGVDatos.CurrentRow.Cells["ClienteId"].Value.ToString();
            dtpFechaReserva.Text = DGVDatos.CurrentRow.Cells["FechaReserva"].Value.ToString();
        }

        public void ColumnasDGV()
        {
            DGVDatos.Columns["ReservaId"].Width = 45;
            DGVDatos.Columns["TeatroId"].Width = 60;
            DGVDatos.Columns["Nombre"].Width = 160;
            DGVDatos.Columns["ClienteId"].Width = 60;
            DGVDatos.Columns["InformacionCliente"].Width = 160;
            DGVDatos.Columns["FechaReserva"].Width = 100;
        }
    }
}

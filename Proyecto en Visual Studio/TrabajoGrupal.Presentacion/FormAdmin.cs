using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoGrupal.Negocio;

namespace TrabajoGrupal.Presentacion
{
    public partial class FormAdmin : Form
    {

        int FechaA;
        string hora;

        public int  ID;



        public FormAdmin()
        {
            InitializeComponent();
            Botones(true,false,true);
        }

        public void Botones(bool Gen,bool Lan,bool Bus)
        {
            btnGenerar.Enabled = Gen;
            btnLanzar.Enabled = Lan;
            txtFecha.Enabled = Bus;
        }


        public void AgregarColumnas()
        {
            dgvTrabajadores.Columns[0].HeaderText = "Código";
            dgvTrabajadores.Columns[0].Width = 75;

            dgvTrabajadores.Columns[1].HeaderText = "Nombre";
            dgvTrabajadores.Columns[1].Width = 100;

            dgvTrabajadores.Columns[2].HeaderText = "Apellido";
            dgvTrabajadores.Columns[2].Width = 100;

            dgvTrabajadores.Columns[3].HeaderText = "DNI";
            dgvTrabajadores.Columns[3].Width = 100;

            dgvTrabajadores.Columns[4].HeaderText = "Rol";
            dgvTrabajadores.Columns[4].Width = 120;

            dgvTrabajadores.Columns[5].Visible = false;
            dgvTrabajadores.RowHeadersVisible = false;
            
        }
        public void AgregarColumnas2()
        {
            dgvListar.Columns[0].HeaderText = "Código";
            dgvListar.Columns[0].Width = 75;

            dgvListar.Columns[1].HeaderText = "Nombre";
            dgvListar.Columns[1].Width = 100;

            dgvListar.Columns[2].HeaderText = "Apellido";
            dgvListar.Columns[2].Width = 100;

            dgvListar.Columns[3].HeaderText = "DNI";
            dgvListar.Columns[3].Width = 100;

            dgvListar.Columns[4].HeaderText = "Rol";
            dgvListar.Columns[4].Width = 120;

            dgvListar.Columns[5].Visible = false;
            dgvListar.RowHeadersVisible = false;

        }


        public void ObtenerHora()
        {
            DateTime fecha;
            fecha = DateTime.Now;
            hora = fecha.ToString("HH:mm");
        }

        public void FechaActual()
        {
            FechaA= ClsTablaAsistenciaNegocio.FechaActualC();
        }


        private void btnGenerar_Click(object sender, EventArgs e)
        {
            
            ObtenerHora();
            string Fecha = txtFecha.Text;

            string rspta=ClsTablaAsistenciaNegocio.Insertar(Fecha, hora);

            if (rspta.Equals("OK"))
            {
                this.MensajeCorrecto("Se realizo la inserccion correctamente");
                txtFecha.Clear();

                dgvTrabajadores.DataSource = ClsTrabajadorNegocio.Listar();
                AgregarColumnas();
                Botones(false, true, false);
            }
            else
            {
                this.MensajeError(rspta);
            }


            
        }

        private void btnLanzar_Click(object sender, EventArgs e)
        {
            FechaActual();

            for (int i = 0; i < dgvTrabajadores.Rows.Count; i++) { 
                ClsHojaNegocio.Insertar(FechaA, Convert.ToInt32(dgvTrabajadores.Rows[i].Cells[0].Value),"Falta","");
            }

            this.MensajeCorrecto("Se Asistencia se lanzo correctamente"+txtFecha.Text);

            Botones(true, false, true);
            dgvTrabajadores.Columns.Clear();

            MarcarAdmin();
        }



        public void MarcarAdmin()
        {
            ObtenerHora();
            int Id_Asistencia = ClsTablaAsistenciaNegocio.FechaActualC();

            string rspta = ClsHojaNegocio.Asistencia_ACT(Id_Asistencia, ID, hora);
            if (rspta == "OK")
            {
                this.MensajeCorrecto("Se registro su asistencia correctamente");
            }
            else
            {
                this.MensajeError(rspta);
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;

            dgvBuscar.DataSource=ClsTablaAsistenciaNegocio.Buscar_Fecha(busqueda);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form FrmjInicio = new FormInicio();
            FrmjInicio.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string rspta;

            rspta=ClsTrabajadorNegocio.Insertar(txtNombre.Text,txtApellidos.Text,txtDNI.Text,txtRol.Text,txtClave.Text);

            if (rspta.Equals("OK"))
            {
                this.MensajeCorrecto("Se Agrego correctamente al nuevo Trabajador");
                
                LimpiarAtributos();
                Listar();
            }
            else
            {
                this.MensajeError(rspta);
            }

        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema ABC", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeCorrecto(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema ABC", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LimpiarAtributos()
        {
            txtClave.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            txtRol.Clear();
            txtApellidos.Clear();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            Listar();
        }


        public void Listar()
        {
            
            dgvListar.DataSource=ClsTrabajadorNegocio.Listar();
            AgregarColumnas2();
        }
    }
}

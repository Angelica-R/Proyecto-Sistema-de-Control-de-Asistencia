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
    public partial class FormTrabajador : Form
    {

        public string nombre, apellido, dni, rol;
        public int ID;
        string hora;

        int Id_Asistencia;

        public FormTrabajador()
        {
            InitializeComponent();
        }

        private void FormTrabajador_Load(object sender, EventArgs e)
        {
            txtNombre.Text = nombre;
            txtApellidos.Text = apellido;
            txtDni.Text = dni;
            lblRol.Text = rol;
            FechaActual();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form FrmjInicio = new FormInicio();
            FrmjInicio.Show();
            this.Hide();
        }

        public void ObtenerHora()
        {
            DateTime fecha;
            fecha = DateTime.Now;
            hora = fecha.ToString("HH:mm");
        }

        public void FechaActual()
        {
            Id_Asistencia = ClsTablaAsistenciaNegocio.FechaActualC();


            DataTable tabla = new DataTable();
            tabla = ClsTablaAsistenciaNegocio.Buscar_EncontrarFecha(Id_Asistencia);
            label7.Text = Convert.ToString(tabla.Rows[0][1]);
        }


        private void btnMarcar_Click(object sender, EventArgs e)
        {
            ObtenerHora();
            
            string rspta= ClsHojaNegocio.Asistencia_ACT(Id_Asistencia, ID, hora);
            if (rspta == "OK")
            {
                this.MensajeCorrecto("Se registro su asistencia correctamente");
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


    }
}

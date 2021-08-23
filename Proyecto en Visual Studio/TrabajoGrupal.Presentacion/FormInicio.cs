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
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();


            string usuario, clave;
            usuario = txtDni.Text;
            clave = txtClave.Text;


            tabla= ClsTrabajadorNegocio.Loguin(usuario, clave);


            if (tabla.Rows.Count <= 0)
            {
                MessageBox.Show("El usuario no existe en la BD", "Acceso al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                if (Convert.ToString(tabla.Rows[0][4]) == "Administrador")
                {
                    FormAdmin datos = new FormAdmin();
                    datos.ID = Convert.ToInt32(tabla.Rows[0][0]);
                    datos.Show();
                    this.Hide();
                }
                else
                {

                    int Id_Asistencia = ClsTablaAsistenciaNegocio.FechaActualC();

                    string decision;
                    decision=ClsHojaNegocio.Verificar_Hoja(Id_Asistencia, Convert.ToInt32(tabla.Rows[0][0]));

                    

                    if (decision=="Asistio")
                    {
                        MessageBox.Show("Usted ya marco su Asistencia","Sistema ABC",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        FormTrabajador datos = new FormTrabajador();
                        datos.ID = Convert.ToInt32(tabla.Rows[0][0]);
                        datos.nombre = Convert.ToString(tabla.Rows[0][1]);
                        datos.apellido = Convert.ToString(tabla.Rows[0][2]);
                        datos.dni = Convert.ToString(tabla.Rows[0][3]);
                        datos.rol = Convert.ToString(tabla.Rows[0][4]);
                        datos.Show();
                        this.Hide();

                    }

                }
            }

            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

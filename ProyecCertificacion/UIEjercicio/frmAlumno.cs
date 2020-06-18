using BEUEjercicio;
using BEUEjercicio.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIEjercicio
{
    public partial class frmAlumno : Form
    {
        public frmAlumno()
        {
            InitializeComponent();
        }


        private void cargarListado()
        {
            this.lsAlumnos.DataSource = null;
            List<Alumno> alumnos = AlumnoBLL.List();
            lsAlumnos.DataSource = alumnos;
        }
        private void frmAlumno_Load(object sender, EventArgs e)
        {
            cargarListado();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno a = new Alumno();
                a.nombres = txtnombre.Text.Trim();
                a.apellidos = txtapellido.Text.Trim();
                a.cedula = txtcedula.Text.Trim();
                a.lugar_nacimiento = txtlugar.Text.Trim();
                a.sexo = rbmasculino.Checked ? "M" : "F";
                a.fecha_nacimiento = stpfecha.Value;
                AlumnoBLL.Create(a);
                cargarListado();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}

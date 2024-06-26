using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data; //Librerias para usar SQL
using System.Data.SqlClient;

namespace CRUD_EJEMPLO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //No hace nada
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //No hace nada
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //No hace nada
        }

        private void Form1_Load(object sender, EventArgs e) //Formulario
        {
            Conexion.Conectar(); //Conectar a base de datos
            MessageBox.Show("Conexion exitosa");

            dataGridView1.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            Conexion.Conectar(); //Llama a la clase conectar
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM alumnos"; //Mostrar tabla
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO alumnos (Codigo, nombre, apellidos, direccion) " +
                              "VALUES(@Codigo, " +
                                     "@Nombres, " +
                                     "@Apellidos, " +
                                     "@Direccion)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());

            cmd1.Parameters.AddWithValue("@Codigo", txtcodigo.Text);        //El texto de los Texbox Se recibe y envía a SQL
            cmd1.Parameters.AddWithValue("@Nombres", txtnombre.Text);       //El texto de los Texbox Se recibe y envía a SQL
            cmd1.Parameters.AddWithValue("@Apellidos", txtapellidos.Text);  //El texto de los Texbox Se recibe y envía a SQL
            cmd1.Parameters.AddWithValue("@Direccion", txtdireccion.Text);  //El texto de los Texbox Se recibe y envía a SQL

            cmd1.ExecuteNonQuery(); //Ejecuta los comandos en SQL

            MessageBox.Show("Los datos fueron agregados exitosamenre");//Envia mensaje
            dataGridView1.DataSource= llenar_grid(); //Muestra la tabla actual en la App
        }

        private void BtModificar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE alumnos SET Codigo=@Codigo, " +
                                                    "nombre=@Nombres, " +
                                                    "apellidos=@Apellidos, " +
                                                    "direccion=@Direccion " +
                                                    "WHERE Codigo = @Codigo";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@Codigo", txtcodigo.Text);        //El texto de los Texbox Se recibe y envía a SQL
            cmd2.Parameters.AddWithValue("@Nombres", txtnombre.Text);       //El texto de los Texbox Se recibe y envía a SQL
            cmd2.Parameters.AddWithValue("@Apellidos", txtapellidos.Text);  //El texto de los Texbox Se recibe y envía a SQL
            cmd2.Parameters.AddWithValue("@Direccion", txtdireccion.Text);  //El texto de los Texbox Se recibe y envía a SQL

            cmd2.ExecuteNonQuery(); //Ejecuta los comandos en SQL

            MessageBox.Show("Los datos fueron actualizados con exito"); //Envia mensaje
            dataGridView1.DataSource = llenar_grid(); //Muestra la tabla actual en la App
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();        //Selecciona los datos del data gridview
                txtnombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();        //y los muestra en los texbox 
                txtapellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();     //correspondientes.
                txtdireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch { }
        }

        private void BtEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM alumnos " +
                              "WHERE Codigo = @Codigo";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());

            cmd3.Parameters.AddWithValue("@Codigo", txtcodigo.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron eliminados con exito");

            dataGridView1.DataSource = llenar_grid();
        }

        private void BtNuevo_Click(object sender, EventArgs e)
        {
            txtcodigo.Clear();      //Limpiar texbox
            txtnombre.Clear();      //Limpiar texbox
            txtapellidos.Clear();   //Limpiar texbox
            txtdireccion.Clear();   //Limpiar texbox
        }
    }
}

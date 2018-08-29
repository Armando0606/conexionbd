using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sqlconexcion
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool nuevo;


        private void CargarDataGrid()
        {
            SqlConnection conexion;
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=Escuela;Trusted_Connection=True";
            conexion = new SqlConnection(connectionString);

            string query = "Select * from Alumnos";
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.Close();
        }

        //botones
        private void Activar()
        {
            button4.Enabled = false;
            textBox1.Enabled = false;
            button7.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;

            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        //Inactivar Botones
        private void Inactivar()
        {
            button4.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            button7.Enabled = false;
            button6.Enabled = false;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";

            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = true;

            button3.Enabled = false;
            button7.Enabled = false;
            button6.Enabled = false;
            button5.Enabled = false;

            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            CargarDataGrid();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Inactivar();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Focus();
            button7.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = false;
            button5.Enabled = false;
            dataGridView1.Enabled = true;


        }

        private void button3_Click(object sender, EventArgs e)
        {

            Inactivar();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection conexion;
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=Escuela;Trusted_Connection=True";
            conexion = new SqlConnection(connectionString);


            SqlCommand commando;

            string query = "INSERT INTO Alumnos (no_control, nombre, apaterno, amaterno)" + "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox3.Text + "')";
            try
            {
                conexion.Open();
                commando = new SqlCommand(query, conexion);
                commando.ExecuteNonQuery();
                MessageBox.Show("Registro guardado exitosamente....!");
                commando.Dispose();
                conexion.Close();

                CargarDataGrid();
                Inactivar();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }

        }


        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conexion;
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=Escuela;Trusted_Connection=True";
            conexion = new SqlConnection(connectionString);


            SqlCommand commando;

            string query = "DELETE FROM Alumnos WHERE no_control= " + textBox1.Text;
            //"' where no_control= " + txtNoControl.Text;

            try
            {
                conexion.Open();
                commando = new SqlCommand(query, conexion);
                commando.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado exitosamente....!");
                commando.Dispose();
                conexion.Close();

                CargarDataGrid();
                Inactivar();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string conexionString = "Server=localhost\\SQLEXPRESS;Database=Escuela;Trusted_Connection=True";
            SqlConnection conexion;

            conexion = new SqlConnection(conexionString);

            SqlCommand comando;

            SqlDataReader dataReader;

            string query = "SELECT * FROM Alumnos WHERE no_control=" + textBox1.Text;
            conexion.Open();
            comando = new SqlCommand(query, conexion);

            //string datos = "";

            try
            {
                dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    button2.Enabled = false;
                    button7.Enabled = true;
                    button3.Enabled = true;
                    button6.Enabled = true;
                    button4.Enabled = false;
                   button5.Enabled = true;

                    textBox1.Enabled = false;
                    textBox2.Enabled = true;
                    textBox4.Enabled = true;
                    textBox3.Enabled = true;

                    //txtNoControl.Focus();
                    textBox1.Text = dataReader[0].ToString();
                    textBox2.Text = dataReader[1].ToString();
                    textBox4.Text = dataReader[2].ToString();
                    textBox3.Text = dataReader[3].ToString();
                    nuevo = false;
                }
                else
                    MessageBox.Show("No se encontro registro !");

                //MessageBox.Show(datos);

                comando.Dispose();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conexion.Close();
            }
            //txtNoControl.Text = "";
        }


        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conexion;
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=ESCUELA;Trusted_Connection=True";
            conexion = new SqlConnection(connectionString);


            SqlCommand commando;

            string query = "UPDATE Alumnos set nombre ='" + textBox2.Text + "' , apaterno ='" + textBox4.Text + "', amaterno='" + textBox3.Text + "' where no_control= " + textBox1.Text;

            try
            {
                conexion.Open();
                commando = new SqlCommand(query, conexion);
                commando.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado exitosamente....!");
                commando.Dispose();
                conexion.Close();

                CargarDataGrid();
                Inactivar();
                nuevo = false;


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }

        }


        private void button22_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }




        private void btnSaveDg_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Necesita llenar los datos !");
            }
            else
            {
                dataGridView1.Rows[0].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[1].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[2].Cells[2].Value = textBox4.Text;
                dataGridView1.Rows[3].Cells[3].Value = textBox3.Text;

            }
        }


       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = (sender as DataGridView).CurrentRow;
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox4.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            Activar();
        }
    }

}

    





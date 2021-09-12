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

namespace Login_Demo_1
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection();
        SqlCommand command = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
            conexion.ConnectionString = @"Data Source=DESKTOP-NP38RB6\RUBIODB;Initial Catalog=LoginDemo;User ID=sa;Password=2133720100";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conexion.Open();
            command.Connection = conexion;
            command.CommandText = "select * from \"User\"";
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                if (txtUser.Text.Equals(dr["username"].ToString()) && txtPassword.Text.Equals(dr["password"].ToString()))
                {
                    MessageBox.Show("Logged In", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtUser.Text.Equals(dr["email"].ToString()) && txtPassword.Text.Equals(dr["password"].ToString())) {
                    MessageBox.Show("Logged In", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Either Username or password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            conexion.Close();
        }
    }
}

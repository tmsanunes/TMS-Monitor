using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace TMS_Monitor
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string data_source = @"Server=monitor.clu0feauwb6x.us-east-1.rds.amazonaws.com;username=root;password=Geopuc123;database=monitor";
            var con = new MySqlConnection(data_source);

            try
            {
                con.Open();
                string stm = "select nome,pswrd from usuarios where username = @name and pswrd = md5('@senha');";
                var cmd = new MySqlCommand(stm, con);

                cmd.Parameters.AddWithValue("@name", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                cmd.ExecuteReader();
                Tela_Principal_Form();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.Close();
        }

        private void Tela_Principal_Form()
        {
            this.Hide();
            Principal frm = new Principal();
            frm.ShowDialog();
            this.Close();
        }
    }
}

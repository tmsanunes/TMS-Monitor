using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace TMS_Monitor
{
    public partial class Principal : Form
    {
        private int _ticks;
        public Principal()
        {
            InitializeComponent();
            timer.Start();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            string data_source = @"Server=monitor.clu0feauwb6x.us-east-1.rds.amazonaws.com;username=root;password=Geopuc123;database=monitor";
            var con = new MySqlConnection(data_source);

            try
            {
                con.Open();
                Ramal9000();
                Ramal9001();
                Ramal9002();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        public void Ramal9000()
        {
            string data_source = @"Server=monitor.clu0feauwb6x.us-east-1.rds.amazonaws.com;username=root;password=Geopuc123;database=monitor";
            var con = new MySqlConnection(data_source);

            try
            {
                con.Open();
                string stm = "select count(*) from cdr " +
                            "where origem = '9000' and " +
                            "dataChamada between concat(curdate(), ' 00:00:00') and concat(curdate(), ' 23:59:00');";
                var cmd = new MySqlCommand(stm, con);
                MySqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    lblChamada1.Visible = true;
                    lblChamada1.Text = da.GetValue(0).ToString();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.Close();

            return;
        }

        public void Ramal9001()
        {
            string data_source = @"Server=monitor.clu0feauwb6x.us-east-1.rds.amazonaws.com;username=root;password=Geopuc123;database=monitor";
            var con = new MySqlConnection(data_source);

            try
            {
                con.Open();
                string stm = "select count(*) from cdr " +
                            "where origem = '9001' and " +
                            "dataChamada between concat(curdate(), ' 00:00:00') and concat(curdate(), ' 23:59:00');";
                var cmd = new MySqlCommand(stm, con);
                MySqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    lblChamada2.Visible = true;
                    lblChamada2.Text = da.GetValue(0).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            return;
        }

        public void Ramal9002()
        {
            string data_source = @"Server=monitor.clu0feauwb6x.us-east-1.rds.amazonaws.com;username=root;password=Geopuc123;database=monitor";
            var con = new MySqlConnection(data_source);

            try
            {
                con.Open();
                string stm = "select count(*) from cdr " +
                            "where origem = '9002' and " +
                            "dataChamada between concat(curdate(), ' 00:00:00') and concat(curdate(), ' 23:59:00');";
                var cmd = new MySqlCommand(stm, con);
                MySqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    lblChamada3.Visible = true;
                    lblChamada3.Text = da.GetValue(0).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            return;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer.Interval == 10000)
            {
                Ramal9000();
                Ramal9001();
                Ramal9002();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        OracleConnection oracleConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            string connectionString = "User ID=stud_popescum; Password=stud; Data Source=(DESCRIPTION=" +
            "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=37.120.249.41)(PORT=1521)))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcls)));";
            oracleConnection = new OracleConnection(connectionString);

            MessageBox.Show("Connection Established");

           
        }

        //call stored procedure
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                oracleConnection.Open();
            }
            catch(OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

            OracleCommand oracleCommand = new OracleCommand("INSERT_PROCEDURE",oracleConnection);
            oracleCommand.CommandType = CommandType.StoredProcedure;

            oracleCommand.Parameters.Add("v_id_image", OracleDbType.Int32);
            oracleCommand.Parameters.Add("v_description", OracleDbType.Varchar2,255);
            oracleCommand.Parameters.Add("file_name", OracleDbType.Varchar2);

            oracleCommand.Parameters[0].Value = Convert.ToInt32(tbId.Text);
            oracleCommand.Parameters[1].Value = tbDescription.Text;
            oracleCommand.Parameters[2].Value = tbFileName.Text;

            try
            {
                oracleCommand.ExecuteNonQuery();
            }
            catch(OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

            oracleConnection.Close();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                oracleConnection.Open();
            }
            catch(OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

            OracleCommand oracleCommand = new OracleCommand("SELECT_PROCEDURE", oracleConnection);
            oracleCommand.CommandType = CommandType.StoredProcedure;

            oracleCommand.Parameters.Add("v_id_image", OracleDbType.Int32);
            oracleCommand.Parameters.Add("flux", OracleDbType.Blob);

            oracleCommand.Parameters[0].Direction = ParameterDirection.Input;
            oracleCommand.Parameters[1].Direction = ParameterDirection.Output;

            oracleCommand.Parameters[0].Value = Convert.ToInt32(tbId.Text);

            try
            {
                oracleCommand.ExecuteScalar();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

            OracleBlob temp = (OracleBlob)oracleCommand.Parameters[1].Value;

            pictureBox1.Image = Image.FromStream((System.IO.Stream)temp);

            oracleConnection.Close();
        }
    }
}

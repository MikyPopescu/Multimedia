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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        OracleConnection oracleConnection;

        public Form1()
        {
            InitializeComponent();
        }

        //creare conexiune
        private void btnConnection_Click(object sender, EventArgs e)
        {
            string connectionString = "User ID=stud_popescum; Password=stud; Data Source=(DESCRIPTION=" +
            "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=37.120.249.41)(PORT=1521)))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcls)));";
            oracleConnection = new OracleConnection(connectionString);

           // MessageBox.Show("Conexiune Stabilita!");
        }

        //Faza1
        //procedura de inserare
        private void btnInserareCaine_Click(object sender, EventArgs e)
        {
            btnConnection_Click(sender, e);
            try
            {
                oracleConnection.Open();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

            OracleCommand oracleCommand = new OracleCommand("PROCEDURA_INSERARE", oracleConnection);
            oracleCommand.CommandType = CommandType.StoredProcedure;

            oracleCommand.Parameters.Add("v_id", OracleDbType.Int32);
            oracleCommand.Parameters.Add("v_rasa", OracleDbType.Varchar2, 255);
            oracleCommand.Parameters.Add("v_data_nastere", OracleDbType.Varchar2, 255);
            oracleCommand.Parameters.Add("nume_fisier", OracleDbType.Varchar2, 255);

            oracleCommand.Parameters[0].Value = Convert.ToInt32(tbIdCaine.Text);
            oracleCommand.Parameters[1].Value = tbRasaCaine.Text;
            oracleCommand.Parameters[2].Value = tbDataNastereCaine.Text;
            oracleCommand.Parameters[3].Value = tbFisier.Text;

            try
            {
                oracleCommand.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Eroare! - " + ex.Message);
            }

            oracleConnection.Close();
        }
        //procedura afisare
        private void btnAfisareCaine_Click(object sender, EventArgs e)
        {
            btnConnection_Click(sender, e);
            try
            {
                oracleConnection.Open();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

            OracleCommand oracleCommand = new OracleCommand("PROCEDURA_AFISARE", oracleConnection);
            oracleCommand.CommandType = CommandType.StoredProcedure;

            oracleCommand.Parameters.Add("v_id",OracleDbType.Int32);
            oracleCommand.Parameters.Add("flux", OracleDbType.Blob);

            oracleCommand.Parameters[0].Direction = ParameterDirection.Input;
            oracleCommand.Parameters[1].Direction = ParameterDirection.Output;

            oracleCommand.Parameters[0].Value = Convert.ToInt32(tbIdAfisareCaine.Text);

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
        //procedura export
        private void btnExportCaine_Click(object sender, EventArgs e)
        {
            btnConnection_Click(sender, e);
            try
            {
                oracleConnection.Open();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

            OracleCommand oracleCommand = new OracleCommand("PROCEDURA_EXPORT", oracleConnection);
            oracleCommand.CommandType = CommandType.StoredProcedure;

            oracleCommand.Parameters.Add("v_id", OracleDbType.Int32);
            oracleCommand.Parameters.Add("nume_fisier", OracleDbType.Varchar2, 255);

            oracleCommand.Parameters[0].Value = Convert.ToInt32(tbExportId.Text);
            oracleCommand.Parameters[1].Value = tbExportFisier.Text;

            try
            {
                oracleCommand.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Eroare! - " + ex.Message);
            }

            oracleConnection.Close();
        }
    }
}

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

            oracleCommand.Parameters[0].Value = Convert.ToInt32(tbIdAfisare.Text);

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

        private void btnGenerateSignature_Click(object sender, EventArgs e)
        {
            //btnConnection_Click(this, null);
            oracleConnection.Open();
            OracleCommand oracleCommand = new OracleCommand("generate_signature_procedure", oracleConnection);
            oracleCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                oracleCommand.ExecuteNonQuery();
            }
            catch(OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

            oracleConnection.Close();
            MessageBox.Show("Successfully generated signature!");
        }

        private void btnSemanticSearch_Click(object sender, EventArgs e)
        {
            try
            {
                oracleConnection.Open();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            OracleCommand cmd = new OracleCommand("regasire", oracleConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("nfis", OracleDbType.Varchar2);
            cmd.Parameters.Add("cculoare", OracleDbType.Decimal);
            cmd.Parameters.Add("ctextura", OracleDbType.Decimal);
            cmd.Parameters.Add("cforma", OracleDbType.Decimal);
            cmd.Parameters.Add("clocatie", OracleDbType.Decimal);
            cmd.Parameters.Add("idrez", OracleDbType.Int32);


            for (int i = 0; i < 5; i++)
            {
                cmd.Parameters[i].Direction = ParameterDirection.Input;
            }
               
            cmd.Parameters[5].Direction = ParameterDirection.Output;
            cmd.Parameters[0].Value = tbFile.Text;
            cmd.Parameters[1].Value = Convert.ToDecimal(tbColor.Text);
            cmd.Parameters[2].Value = Convert.ToDecimal(tbTexture.Text);
            cmd.Parameters[3].Value = Convert.ToDecimal(tbShape.Text);
            cmd.Parameters[4].Value = Convert.ToDecimal(tbLocation.Text);
            try
            {
                cmd.ExecuteScalar();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);

            }
            tbResultSemantic.Text = cmd.Parameters[5].Value.ToString();
            oracleConnection.Close();

        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            this.btnConnection_Click(sender, e);

            oracleConnection.Open();

            OracleCommand oracleCommand = new OracleCommand("show_video", oracleConnection);
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.Parameters.Add("flux", OracleDbType.Blob);
            oracleCommand.Parameters[0].Direction = ParameterDirection.Output;
            try
            {
                oracleCommand.ExecuteNonQuery();
            }
            catch(OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

            Byte[] blob = new Byte[((OracleBlob)oracleCommand.Parameters[0].Value).Length];
            FileStream fileStream = null;
           ((OracleBlob)oracleCommand.Parameters[0].Value).Read(blob,0,blob.Length);
            fileStream = new FileStream("d:\\film1.avi",FileMode.CreateNew,FileAccess.ReadWrite);
            fileStream.Write(blob, 0, blob.Length);
            fileStream.Close();
            oracleConnection.Close();
        }
    }
}

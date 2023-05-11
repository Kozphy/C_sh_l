using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Ch18_3_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public DataSet BindDatabase(string strSQL)
        { 
            string strDbCon;
            SqlDataAdapter objAdapter;
            DataSet objDataSet = new DataSet();
            strDbCon = "Data Source=(local);Initial Catelog=教務系統" + ";Integrated Security=SSPI";
            try
            {
                using (SqlConnection objCon = new SqlConnection(strDbCon))
                {
                    objCon.Open();
                    objAdapter = new SqlDataAdapter(strSQL, objCon);
                    objAdapter.Fill(objDataSet, "Temp");
                    return objDataSet;
                }
            }
            catch (Exception ex) { 
            }


        }

        private void toolStripSplitButton1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
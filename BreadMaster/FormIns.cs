using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMaster
{
    public partial class FormIns : Form
    {
        string connectionString = BreadMasterAppConstants.connectionString;
        string sCrLf = BreadMasterAppConstants.sCrLf;
        string strid = "";

        public FormIns()
        {
            InitializeComponent();
        }

        private void FormIns_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM vMaster WHERE id = :id";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        command.Parameters.Add(new OracleParameter("id", strid));
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                textBoxId.Text = reader["id"].ToString();
                            }
                            textBoxLog.Text = sCrLf + sql + textBoxLog.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;

                Console.WriteLine($"エラー: {ex.Message}");
            }
        }
        public void setId(string id)
        {
            strid = id;
        }
        public void setTextBoxId(string id)
        {
            textBoxId.Text = id;
        }
        public void setTextBoxFId(string id)
        {
            textBoxFId.Text = id;
        }
        public void setTextBoxSauceId(string id)
        {
                textBoxSauceId.Text = id;
        }
        public void setTextBoxSandwichId(string id)
        {
            textBoxSandwichId.Text = id;
        }
        public void setTextBoxBId(string id)
        {
            textBoxBId.Text = id;
        }
        public void setTextBoxRId(string id)
        {
            textBoxRId.Text = id;
        }

    }
}

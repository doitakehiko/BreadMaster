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

        public FormIns()
        {
            InitializeComponent();
        }

        private void FormIns_Load(object sender, EventArgs e)
        {
    
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
        public void setTextBoxFname( string fname )
        {
                textBoxFName.Text = fname;
        }
 
        public void setTextBoxSauceName(string sauceName)
        {
            textBoxSauceName.Text = sauceName;
        }
        public void setTextBoxSandwichName(string sandwichName)
        {
            textBoxSandwichName.Text = sandwichName;
        }
        public void setTextBoxRName(string rName)
        {
            textBoxRName.Text = rName;
        }
        public void setTextBoxBName(string bName)
        {
            textBoxBName.Text = bName;
        }
        public void setTextBoxCNameJp(string cNameJp)
        {
            textBoxCNameJp.Text = cNameJp;
        }
        public void setTextBoxCNameEn(string cNameEn)
        {
            textBoxCNameEn.Text = cNameEn;
        }
        public void setTextBoxCCode(string cCode)
        {
            textBoxCCode.Text = cCode;
        }
        public string getTextBoxId()
        {
            return textBoxId.Text;
        }
        public string getTextBoxFId()
        {
            return textBoxFId.Text;
        }
        public string getTextBoxSauceId()
        {
            return textBoxSauceId.Text;
        }
        public string getTextBoxSandwichId()
        {
            return textBoxSandwichId.Text;
        }
        public string getTextBoxBId()
        {
            return textBoxBId.Text;
        }
        public string getTextBoxRId()
        {
            return textBoxRId.Text;
        }
        public string getTextBoxFName()
        {
            return textBoxFName.Text;
        }
        public string getTextBoxSauceName()
        {
            return textBoxSauceName.Text;
        }
        public string getTextBoxSandwichName()
        {
            return textBoxSandwichName.Text;
        }
        public string getTextBoxRName()
        {
            return textBoxRName.Text;
        }
        public string getTextBoxBName()
        {
            return textBoxBName.Text;
        }
        public string getTextBoxCNameJp()
        {
            return textBoxCNameJp.Text;
        }
        public string getTextBoxCNameEn()
        {
            return textBoxCNameEn.Text;
        }
        public string getTextBoxCCode()
        {
            return textBoxCCode.Text;
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            string sqlIns = @"
                    INSERT INTO bread_master (
                        filling_id,
                        sauce_id,
                        sandwich_id,
                        region_id,
                        bread_name_id
                    ) VALUES (
                        :fid,
                        :sauceid,
                        :sandwichid,
                        :rid,
                        :bnid
                    )";
            string sql2 = "SELECT bread_seq.CURRVAL as id FROM dual";

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sqlIns, connection))
                    {
                        command.BindByName = true;

                        command.Parameters.Add("fid", OracleDbType.Int32).Value =
                            string.IsNullOrWhiteSpace(textBoxFId.Text) ? (object)DBNull.Value : int.Parse(textBoxFId.Text);
                        command.Parameters.Add("sauceid", OracleDbType.Int32).Value =
                            string.IsNullOrWhiteSpace(textBoxSauceId.Text) ? (object)DBNull.Value : int.Parse(textBoxSauceId.Text);
                        command.Parameters.Add("sandwichid", OracleDbType.Int32).Value = int.Parse(textBoxSandwichId.Text);
                        command.Parameters.Add("rid", OracleDbType.Int32).Value = int.Parse(textBoxRId.Text);
                        command.Parameters.Add("bnid", OracleDbType.Int32).Value = int.Parse(textBoxBId.Text);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            textBoxId.Text = BreadMasterAppConstants.getCurrentSequenceValue(connection, sql2).ToString();
                        }

                        textBoxLog.Text = sCrLf + $"{rowsAffected} 行が挿入されました。" + textBoxLog.Text;
                        MessageBox.Show($"{rowsAffected} 行が挿入されました。");
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
                Console.WriteLine($"エラー: {ex.Message}");
                this.DialogResult = DialogResult.None;
                return;

            }
        }
    }
}

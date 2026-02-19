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
    public partial class FormUpd : Form
    {
        string connectionString = BreadMasterAppConstants.connectionString;
        string sCrLf = BreadMasterAppConstants.sCrLf;
        string strid = "";
        public FormUpd()
        {
            InitializeComponent();
        }

        private void FormUpd_Load(object sender, EventArgs e)
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
        public void setTextBoxFId(string fId)
        {
            textBoxFId.Text = fId;
        }
        public void setTextBoxSauceId(string sauceId)
        {
            textBoxSauceId.Text = sauceId;
        }
        public void setTextBoxSandwichId(string sandwichId)
        {
            textBoxSandwichId.Text = sandwichId;
        }
        public void setTextBoxBId(string bId)
        {
            textBoxBId.Text = bId;
        }
        public void setTextBoxRId(string rId)
        {
            textBoxRId.Text = rId;
        }
        public void setTextBoxFName(string fName)
        {
            textBoxFName.Text = fName;
        }
        public void setTextBoxSauceName(string sauceName)
        {
            textBoxSauceName.Text = sauceName;
        }
        public void setTextBoxSandwichName(string sandwichName)
        {
            textBoxSandwichName.Text = sandwichName;
        }
        public void setTextBoxBName(string bName)
        {
            textBoxBName.Text = bName;
        }
        public void setTextBoxRName(string rName)
        {
            textBoxRName.Text = rName;
        }
        public void setTextBoxNameJp(string cName)
        {
            textBoxCNameJp.Text = cName;
        }
        public void setTextBoxNameEn(string eName)
        {
            textBoxCNameEn.Text = eName;
        }
        public void setTextBoxCCode(string code)
        {
            textBoxCCode.Text = code;
        }
        // C#
        private void buttonOK_Click(object sender, EventArgs e)
        {
            string sqlUpd = @"
                UPDATE bread_master
                SET filling_id = :fid,
                    sauce_id   = :sauceid,
                    sandwich_id= :sandwichid,
                    region_id  = :rid,
                    bread_name_id = :bnid
                WHERE id = :id";

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(sqlUpd, connection))
                    {
                        command.BindByName = true;

                        command.Parameters.Add("fid", OracleDbType.Int32).Value =
                            string.IsNullOrWhiteSpace(textBoxFId.Text) ? (object)DBNull.Value : int.Parse(textBoxFId.Text);
                        command.Parameters.Add("sauceid", OracleDbType.Int32).Value =
                            string.IsNullOrWhiteSpace(textBoxSauceId.Text) ? (object)DBNull.Value : int.Parse(textBoxSauceId.Text);
                        command.Parameters.Add("sandwichid", OracleDbType.Int32).Value = int.Parse(textBoxSandwichId.Text);
                        command.Parameters.Add("rid", OracleDbType.Int32).Value = int.Parse(textBoxRId.Text);
                        command.Parameters.Add("bnid", OracleDbType.Int32).Value = int.Parse(textBoxBId.Text);
                        command.Parameters.Add("id", OracleDbType.Int32).Value = int.Parse(textBoxId.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        textBoxLog.Text = sCrLf + $"{rowsAffected} 行が更新されました。" + textBoxLog.Text;
                        MessageBox.Show($"{rowsAffected} 行が更新されました。");
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
                Console.WriteLine($"エラー: {ex.Message}");
            }
        }

    }
}

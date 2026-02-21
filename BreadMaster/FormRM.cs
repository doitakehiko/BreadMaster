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
    public partial class FormRM : Form
    {
        string connectionString = BreadMasterAppConstants.connectionString;
        string sCrLf = BreadMasterAppConstants.sCrLf;
        public FormRM()
        {
            InitializeComponent();
        }

        private void FormRM_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            string sql = "SELECT * FROM vRegionMaster";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(sql, connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataGridViewにデータをバインド [2]
                        dataGridView1.DataSource = dataTable;
                        textBoxLog.Text = sCrLf + sql + textBoxLog.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;

                Console.WriteLine($"エラー: {ex.Message}");
            }
        }

        private void buttonCSelect_Click(object sender, EventArgs e)
        {
            FormC f = new FormC();
            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK)
            {
                textBoxCId.Text = f.getid();
                textBoxCNameJp.Text = f.getnamejp();
                textBoxCNameEn.Text = f.getnameen();

            }

            f.Dispose();
            FormRM_Load(sender, e);

        }
        public string getid()
        {
            return textBoxId.Text;
        }
        public string getname()
        {
            return textBoxRName.Text;
        }
        public string getcnamejp()
        {
            return textBoxCNameJp.Text;
        }
        public string getcnameen()
        {
            return textBoxCNameEn.Text;
        }
        public string getcid()
        {
            return textBoxCId.Text;
        }
        public void setid(string id)
        {
            textBoxId.Text = id;
        }


        private void buttonIns_Click(object sender, EventArgs e)
        {
            if (textBoxRName.Text == "")
            {
                MessageBox.Show("名前が入力されていません。");
                return;
            }
            if (textBoxCId.Text == "")
            {
                MessageBox.Show("国IDが入力されていません。");
                return;
            }
            string sqlIns = "INSERT INTO region_master ( region_name, country_id ) VALUES (:name, :id)";
            string sql2 = "SELECT region_master_seq.CURRVAL as id FROM dual";

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sqlIns, connection))
                    {
                        command.Parameters.Add(new OracleParameter("name", textBoxRName.Text));
                        command.Parameters.Add(new OracleParameter("id", int.Parse(textBoxCId.Text)));
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            textBoxId.Text = BreadMasterAppConstants.getCurrentSequenceValue(connection, sql2).ToString();
                        }

                        textBoxLog.Text = sCrLf + $"{rowsAffected} 行が挿入されました。" + textBoxLog.Text;
                        MessageBox.Show($"{rowsAffected} 行が挿入されました。");
                        FormRM_Load(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
                Console.WriteLine($"エラー: {ex.Message}");
            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                // 行インデックスと列インデックスを取得
                int rowIndex = hit.RowIndex;
                textBoxId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                textBoxRName.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                textBoxCNameJp.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                textBoxCNameEn.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                textBoxCId.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == "")
            {
                MessageBox.Show("IDが入力されていません。");
                return;
            }
            string sqlDel = "DELETE FROM region_master WHERE id = :id";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sqlDel, connection))
                    {
                        command.Parameters.Add(new OracleParameter("id", int.Parse(textBoxId.Text)));
                        int rowsAffected = command.ExecuteNonQuery();
                        textBoxLog.Text = sCrLf + $"{rowsAffected} 行が削除されました。" + textBoxLog.Text;
                        MessageBox.Show($"{rowsAffected} 行が削除されました。");
                        buttonReset_Click(sender, e);
                        FormRM_Load(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
                Console.WriteLine($"エラー: {ex.Message}");
            }

        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (textBoxRName.Text == "")
            {
                MessageBox.Show("地域名が入力されていません。");
                return;
            }
            if (textBoxCId.Text == "")
            {
                MessageBox.Show("国IDが入力されていません。");
                return;
            }

            else
            {
                string sqlUpd = "update region_master set region_name = :name, country_id = :code where id = :id";
                try
                {
                    using (OracleConnection connection = new OracleConnection(connectionString))
                    {
                        connection.Open();
                        Console.WriteLine("接続成功");
                        textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                        using (OracleCommand command = new OracleCommand(sqlUpd, connection))
                        {
                            command.Parameters.Add(new OracleParameter("name", textBoxRName.Text));
                            command.Parameters.Add(new OracleParameter("code", int.Parse(textBoxCId.Text)));
                            command.Parameters.Add(new OracleParameter("id", int.Parse(textBoxId.Text)));
                            int rowsAffected = command.ExecuteNonQuery();
                            textBoxLog.Text = sCrLf + $"{rowsAffected} 行が更新されました。" + textBoxLog.Text;
                            MessageBox.Show($"{rowsAffected} 行が更新されました。");
                            FormRM_Load(sender, e);
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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxId.Clear();
            textBoxRName.Clear();
            textBoxCNameJp.Clear();
            textBoxCNameEn.Clear();
            textBoxCId.Clear();
            FormRM_Load(sender, e);
        }
    }
}

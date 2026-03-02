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
    public partial class FormT : Form
    {
        string connectionString = BreadMasterAppConstants.connectionString;
        string sCrLf = BreadMasterAppConstants.sCrLf;
        public FormT()
        {
            InitializeComponent();

        }

        private void FormT_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            string sql = "SELECT * FROM type_master";
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

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == "")
            {
                MessageBox.Show("IDが入力されていません。");
                return;
            }
            string sqlDel = "DELETE FROM type_master WHERE id = :id";
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
                        MessageBox.Show($"{rowsAffected} 行が削除されました。");
                        buttonReset_Click(sender, e);
                        FormT_Load(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
                Console.WriteLine($"エラー: {ex.Message}");
            }
        }

        private void buttonIns_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("タイプ名が入力されていません。");
                return;
            }
            string sqlIns = "INSERT INTO type_master (type_name) VALUES (:name)";
            string sql2 = "SELECT type_master_seq.CURRVAL as id FROM dual";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sqlIns, connection))
                    {
                        command.Parameters.Add(new OracleParameter("name", textBoxName.Text));
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            textBoxId.Text = BreadMasterAppConstants.getCurrentSequenceValue(connection, sql2).ToString();
                        }
                        textBoxLog.Text = sCrLf + $"{rowsAffected} 行が挿入されました。" + textBoxLog.Text;
                        MessageBox.Show($"{rowsAffected} 行が挿入されました。");
                        FormT_Load(sender, e);
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
                if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count - 1) return;

                textBoxId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                textBoxName.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("タイプ名が入力されていません。");
                return;
            }
            if (textBoxName.Modified == false)
            {
                MessageBox.Show("タイプ名が変更されていません。");
                return;
            }
            else
            {
                string sqlUpd = "UPDATE type_master SET type_name = :name WHERE id = :id";
                try
                {
                    using (OracleConnection connection = new OracleConnection(connectionString))
                    {
                        connection.Open();
                        Console.WriteLine("接続成功");
                        textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                        using (OracleCommand command = new OracleCommand(sqlUpd, connection))
                        {
                            command.Parameters.Add(new OracleParameter("name", textBoxName.Text));
                            command.Parameters.Add(new OracleParameter("id", int.Parse(textBoxId.Text)));
                            int rowsAffected = command.ExecuteNonQuery();
                            textBoxLog.Text = sCrLf + $"{rowsAffected} 行が更新されました。" + textBoxLog.Text;
                            MessageBox.Show($"{rowsAffected} 行が更新されました。");
                            FormT_Load(sender, e);
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
            textBoxName.Clear();
            FormT_Load(sender, e);

        }
        public string getid()
        {
            return textBoxId.Text;
        }
        public string getname()
        {
            return textBoxName.Text;
        }
        public void setid(string id)
        {
            textBoxId.Text = id;
        }
        public void setname(string name)
        {
            textBoxName.Text = name;
        }
    }
}

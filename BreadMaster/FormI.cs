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
    public partial class FormI : Form
    {
        string connectionString = BreadMasterAppConstants.connectionString;
        string sCrLf = BreadMasterAppConstants.sCrLf;

        public FormI()
        {
            InitializeComponent();
        }

        private void FormI_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            dataGridViewAdd.ColumnCount = 2;
            dataGridViewAdd.Columns[0].Name = "ID";
            dataGridViewAdd.Columns[1].Name = "食材名";

            dataGridViewAdd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAdd.MultiSelect = false;
            dataGridViewAdd.ReadOnly = true;


            string sql = "SELECT * FROM ingredients_master";
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
        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxId.Clear();
            textBoxName.Clear();
            FormI_Load(sender, e);
        }

        private void buttonIns_Click(object sender, EventArgs e)
        {
            if (textBoxIName.Text == "")
            {
                MessageBox.Show("素材名が入力されていません。");
                return;
            }
            string sqlIns = "INSERT INTO ingredients_master (ingredients_name) VALUES (:name)";
            string sql2 = "SELECT ingredients_master_seq.CURRVAL as id FROM dual";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sqlIns, connection))
                    {
                        command.Parameters.Add(new OracleParameter("name", textBoxIName.Text));
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            textBoxId.Text = BreadMasterAppConstants.getCurrentSequenceValue(connection, sql2).ToString();
                        }
                        textBoxLog.Text = sCrLf + $"{rowsAffected} 行が挿入されました。" + textBoxLog.Text;
                        MessageBox.Show($"{rowsAffected} 行が挿入されました。");
                        FormI_Load(sender, e);
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
            if (textBoxName.Text == "")
            {
                MessageBox.Show("食材名が入力されていません。");
                return;
            }
            if (textBoxName.Modified == false)
            {
                MessageBox.Show("食材名が変更されていません。");
                return;
            }
            else
            {
                string sqlUpd = "UPDATE ingredients_master SET ingredients_name = :name WHERE id = :id";
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
                            FormI_Load(sender, e);
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

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == "")
            {
                MessageBox.Show("IDが入力されていません。");
                return;
            }
            string sqlDel = "DELETE FROM ingredients_master WHERE id = :id";
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
                        FormI_Load(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
                Console.WriteLine($"エラー: {ex.Message}");
            }

        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxId.Text == "" || textBoxName.Text == "")
            {
                MessageBox.Show("IDと食材名の両方を入力してください。");

                return;
            }
            if (textBoxName.Modified )
            {
                string sql = "SELECT id FROM ingredients_master WHERE ingredients_name = :name";

                try
                {
                    using (OracleConnection connection = new OracleConnection(connectionString))
                    {
                        connection.Open();
                        Console.WriteLine("接続成功");
                        if (BreadMasterAppConstants.getUniqMasterId(connection, sql, textBoxName.Text) == 0)
                        {
                            DialogResult result = MessageBox.Show("食材マスターに登録しますか？", "食材マスターにありませんでした", MessageBoxButtons.OKCancel);
                            if (result == DialogResult.OK)
                            {
                                buttonIns_Click(sender, e);
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
                    Console.WriteLine($"エラー: {ex.Message}");
                    return;
                }


            }
            if (dataGridViewAdd.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewAdd.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == textBoxId.Text)
                    {
                        MessageBox.Show("同じIDが既に追加されています。");
                        return;
                    }
                }
            }
            dataGridViewAdd.Rows.Add(textBoxId.Text, textBoxName.Text);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                // 行インデックスと列インデックスを取得
                int rowIndex = hit.RowIndex;
                textBoxId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                textBoxName.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            }
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

        private void buttonAddDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridViewAdd.SelectedRows)
            {
                // 新しい行（新規レコード用の行）は削除しない
                if (!r.IsNewRow)
                {
                    dataGridViewAdd.Rows.Remove(r);
                }
            }
        }
    }
}

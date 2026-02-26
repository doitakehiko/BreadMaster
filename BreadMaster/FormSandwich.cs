using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMaster
{
    public partial class FormSandwich : Form
    {
        string connectionString = BreadMasterAppConstants.connectionString;
        string sCrLf = BreadMasterAppConstants.sCrLf;

        public FormSandwich()
        {
            InitializeComponent();
        }

        private void FormSandwich_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            string sql = "SELECT * FROM vSandwich";
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
                        dataGridView1.DataSource = dataTable;


                        string idToSelect = textBoxId.Text; // 選択したいID
                        string idColumnName = "ID"; // IDが格納されている列名

                        // 1. 一旦、既存の選択を解除
                        dataGridView1.ClearSelection();

                        // 2. 指定したIDの行を探して選択
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            // セル値がNULLでないか確認し、一致する行を探す
                            if (row.Cells[idColumnName].Value != null &&
                                row.Cells[idColumnName].Value.ToString() == idToSelect)
                            {
                                row.Selected = true;
                                // 必要であれば、その行へスクロール
                                dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                                break; // 見つかったらループを抜ける
                            }
                        }


                        textBoxLog.Text = sCrLf + sql + textBoxLog.Text;
                    }

                    setI();
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;

                Console.WriteLine($"エラー: {ex.Message}");
            }
        }
        private void setI()
        {
            string sql2 = "SELECT * FROM vIngredients WHERE sid = :id";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand cmd2 = new OracleCommand(sql2, connection))
                    {
                        if (string.IsNullOrWhiteSpace(textBoxId.Text) == false)
                        {
                            cmd2.Parameters.Add("id", OracleDbType.Int32).Value = int.Parse(textBoxId.Text);
                            OracleDataAdapter adapter2 = new OracleDataAdapter(cmd2);
                            DataTable dataTable2 = new DataTable();
                            adapter2.Fill(dataTable2);
                            dataGridView2.DataSource = dataTable2;
                            textBoxLog.Text = sCrLf + sql2 + textBoxLog.Text;
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
                textBoxTypeId.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();    
                textBoxTName.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                setI();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == "")
            {
                MessageBox.Show("IDが入力されていません。");
                return;
            }
            string sqlDel = "DELETE FROM sandwich_master WHERE id = :id";
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
                        FormSandwich_Load(sender, e);
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
                MessageBox.Show("サンドイッチ名が入力されていません。");
                return;
            }
            string sqlIns = "INSERT INTO sandwich_master (sandwich_name, type_id) VALUES (:name, :id)";
            string sql2 = "SELECT sandwich_master_seq.CURRVAL as id FROM dual";
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
                        command.Parameters.Add("id", OracleDbType.Int32).Value =
                                string.IsNullOrWhiteSpace(textBoxTypeId.Text) ? (object)DBNull.Value : int.Parse(textBoxTypeId.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            textBoxId.Text = BreadMasterAppConstants.getCurrentSequenceValue(connection, sql2).ToString();
                        }

                        textBoxLog.Text = sCrLf + $"{rowsAffected} 行が挿入されました。" + textBoxLog.Text;
                        MessageBox.Show($"{rowsAffected} 行が挿入されました。");
                        FormSandwich_Load(sender, e);
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
                MessageBox.Show("サンドイッチ名が入力されていません。");
                return;
            }
            if (textBoxName.Modified == false  )
            {

            }

            if (textBoxName.Modified == false)
            {
                MessageBox.Show("サンドイッチ名が変更されていません。");
                return;
            }
            else
            {
                string sqlUpd = "UPDATE sandwich_master SET sandwich_name = :name WHERE id = :id";
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
                            FormSandwich_Load(sender, e);
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
            textBoxTName.Clear();
            textBoxTypeId.Clear();
            FormSandwich_Load(sender, e);
        }

        private void buttonType_Click(object sender, EventArgs e)
        {
            FormT f = new FormT();
            f.setname(textBoxTName.Text);
            f.setid(textBoxTypeId.Text);
            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK)
            {
                textBoxTName.Text = f.getname();
                textBoxTypeId.Text = f.getid();
            }
            f.Dispose();
        }

        private void buttonI_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == "")
            {
                MessageBox.Show("サンドイッチIDが入力されていません。");
                return;
            }
            FormI f = new FormI();
            f.setid(textBoxId.Text);
            f.setname(textBoxName.Text);
            f.ShowDialog(this);
            setI();
            f.Dispose();

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

        }

        public string getid()
        {
            return textBoxId.Text;
        }
        public string getname()
        {
            return textBoxName.Text;
        }
        public string getTname()
        {
            return textBoxTName.Text;
        }
        public string getTypeId()
        {
            return textBoxTypeId.Text;
        }
        public void setTname(string tname)
        {
            textBoxTName.Text = tname;
        }
        public void setTypeId(string typeId)
        {
            textBoxTypeId.Text = typeId;
        }
        public void setid(string id)
        {
            textBoxId.Text = id;
        }
        public void setname(string name)
        {
            textBoxName.Text = name;
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // 行が選択されている場合のみ処理
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(textBoxId.Text) == false)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    //textBoxId.Text = row.Cells["id"].Value?.ToString();
                    //textBoxName.Text = row.Cells["sandwich_name"].Value?.ToString();
                    textBoxTypeId.Text = row.Cells["typeid"].Value?.ToString();
                    textBoxTName.Text = row.Cells["type_name"].Value?.ToString();
                    setI();
                }
            }
        }

        private void buttonTUpd_Click(object sender, EventArgs e)
        {
            string sqlUpd = "UPDATE sandwich_master SET type_id = :typeid WHERE id = :id";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sqlUpd, connection))
                    {
                        command.Parameters.Add("typeid", OracleDbType.Int32).Value =
                            string.IsNullOrWhiteSpace(textBoxTypeId.Text) ? (object)DBNull.Value : int.Parse(textBoxTypeId.Text);
                        command.Parameters.Add(new OracleParameter("id", int.Parse(textBoxId.Text)));
                        int rowsAffected = command.ExecuteNonQuery();
                        textBoxLog.Text = sCrLf + $"{rowsAffected} 行が更新されました。" + textBoxLog.Text;
                        MessageBox.Show($"{rowsAffected} 行が更新されました。");
                        FormSandwich_Load(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
                Console.WriteLine($"エラー: {ex.Message}");
            }
        }

        private void buttonTypeClr_Click(object sender, EventArgs e)
        {
            textBoxTName.Clear();
            textBoxTypeId.Clear();
        }
    }
}

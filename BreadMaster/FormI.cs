using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMaster
{
    public partial class FormI : Form
    {
        string connectionString = BreadMasterAppConstants.connectionString;
        string sCrLf = BreadMasterAppConstants.sCrLf;
        private BindingSource bindingSource1 = new BindingSource();
        private Boolean UpdateFlag = false;
        private Boolean InsertFlag = false;
        public FormI()
        {
            InitializeComponent();
        }

        private void FormI_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;


            dataGridViewAdd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAdd.MultiSelect = false;
            dataGridViewAdd.ReadOnly = true;

            LoadData();
            setI();
        }
        private void LoadData()
        {
            try
            {
                string sql = "SELECT * FROM ingredients_master";
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    OracleDataAdapter adapter = new OracleDataAdapter(sql, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // BindingSourceの元データを最新にする
                    bindingSource1.DataSource = dataTable;
                    dataGridView1.DataSource = bindingSource1;
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
            bindingSource1.Filter = null;
            textBoxIName.Clear();
            textBoxSIId.Clear();
            textBoxIId.Clear();
            textBoxFilter.Clear();
            dataGridViewAdd.DataSource = null;
            dataGridViewAdd.Rows.Clear();
            InsertFlag = false;
            UpdateFlag = false;
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
                            textBoxIId.Text = BreadMasterAppConstants.getCurrentSequenceValue(connection, sql2).ToString();
                        }

                        textBoxLog.Text = sCrLf + $"{rowsAffected} 行が挿入されました。" + textBoxLog.Text;
                        MessageBox.Show($"{rowsAffected} 行が挿入されました。");
                        UpdateFlag = true;
                        LoadData();

                        selectGridUpdIns(textBoxIName.Text);

                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
                Console.WriteLine($"エラー: {ex.Message}");
            }


        }

        private void selectGridUpdIns(string selectText)
        {
            // 全件表示したい場合は Filter = "" または null にする
            if (string.IsNullOrEmpty(selectText))
            {
                bindingSource1.Filter = "";
            }
            else
            {
                // 念のためシングルクォートをエスケープ
                string safeText = selectText.Replace("'", "''");
                bindingSource1.Filter = $"ingredients_name LIKE '%{selectText}%'";
            }

            // デバッグ用：イミディエイトウィンドウ等で数を確認
            Console.WriteLine($"Filter: {bindingSource1.Filter}");
            Console.WriteLine($"Count: {bindingSource1.Count}");

            if (bindingSource1.Count > 0)
            {
                bindingSource1.Position = 0;
            }
        }

        private void setI()
        {

            string sql2 = "SELECT * FROM vIngredients WHERE sid = :id";
            try
            {
                using (OracleConnection connection2 = new OracleConnection(connectionString))
                {
                    connection2.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command2 = new OracleCommand(sql2, connection2))
                    {
                        command2.Parameters.Add(new OracleParameter("id", int.Parse(textBoxId.Text)));

                        using (OracleDataAdapter adapter2 = new OracleDataAdapter(command2))
                        {
                            DataTable datatTable2 = new DataTable();
                            adapter2.Fill(datatTable2);
                            dataGridViewAdd.DataSource = datatTable2;
                        }
                        textBoxLog.Text = sCrLf + sql2 + textBoxLog.Text;
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
            if (textBoxIName.Text == "")
            {
                MessageBox.Show("食材名が入力されていません。");
                return;
            }
            if (textBoxIName.Modified == false)
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
                            command.Parameters.Add(new OracleParameter("name", textBoxIName.Text));
                            command.Parameters.Add(new OracleParameter("id", int.Parse(textBoxIId.Text)));
                            int rowsAffected = command.ExecuteNonQuery();
                            textBoxLog.Text = sCrLf + $"{rowsAffected} 行が更新されました。" + textBoxLog.Text;

                            MessageBox.Show($"{rowsAffected} 行が更新されました。");
                            UpdateFlag = true;
                            LoadData();

                            selectGridUpdIns(textBoxIName.Text);
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
                        command.Parameters.Add(new OracleParameter("id", int.Parse(textBoxIId.Text)));
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} 行が削除されました。");
                        buttonReset_Click(sender, e);
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
            if(textBoxId.Text == "" && textBoxIId.Text == "")
            {
                MessageBox.Show("サンドイッチIDと食材IDの両方を入力してください。");

                return;
            }
            string sqlIns = "INSERT INTO sandwich_ingredients (sandwich_id, ingredients_id) VALUES (:sid, :iid)";
            string sql2 = "SELECT sandwich_ingredients_seq.CURRVAL as id FROM dual";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sqlIns, connection))
                    {
                        command.Parameters.Add(new OracleParameter("sid", int.Parse(textBoxId.Text)));
                        command.Parameters.Add(new OracleParameter("iid", int.Parse(textBoxIId.Text)));
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            textBoxIId.Text = BreadMasterAppConstants.getCurrentSequenceValue(connection, sql2).ToString();
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                int rowIndex = hit.RowIndex;
                if (rowIndex < 0 || rowIndex  >= dataGridView1.Rows.Count - 1) return;

                // 先に値をローカルに退避（TextChanged の副作用を防ぐ）
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                string id = row.Cells[0].Value?.ToString() ?? "";
                string name = row.Cells[1].Value?.ToString() ?? "";

                // まとめて UI を更新
                textBoxIId.Text = id;
                textBoxIName.Text = name;
                setI();

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
            if (textBoxSIId.Text == "")
            {
                MessageBox.Show("IDが入力されていません。");
                return;
            }
            string sqlDel = "DELETE FROM sandwich_ingredients WHERE id = :id";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sqlDel, connection))
                    {
                        command.Parameters.Add(new OracleParameter("id", int.Parse(textBoxSIId.Text)));
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

        private void textBoxIName_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchAndSelectFirstRow(string searchText)
        {
            // bindingSource1 は DataGridView.DataSource に設定されているものとします
            // 例: bindingSource1.DataSource = dt; (DataTable等)

            // 1. フィルタ処理 (検索)
            if (string.IsNullOrEmpty(searchText))
            {
                bindingSource1.RemoveFilter();
            }
            else
            {
                // Name列が検索文字列を含む場合をフィルタリング
                bindingSource1.Filter = $"ingredients_name LIKE '%{searchText}%'";
            }

            // 2. 検索結果が1件以上あるか確認
            if (bindingSource1.Count > 0)
            {
                // 3. 先頭（0番目）を選択する
                bindingSource1.Position = 0;

                // (任意) DataGridViewのフォーカスを確実にする場合
                dataGridView1.Focus();
            }
        }
        // C#
        private void buttonOK_Click(object sender, EventArgs e)
        { 
        
        }


        private void dataGridViewAdd_MouseClick_1(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridViewAdd.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                // 行インデックスと列インデックスを取得
                int rowIndex = hit.RowIndex;
                if (rowIndex < 0 || rowIndex >= dataGridViewAdd.Rows.Count - 1) return;
                textBoxSIId.Text = dataGridViewAdd.Rows[rowIndex].Cells[5].Value.ToString();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // 行が選択されている場合のみ処理
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //if (string.IsNullOrWhiteSpace(textBoxId.Text) == false)
                //{
                if (UpdateFlag == false && InsertFlag == false)
                {

                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    textBoxIId.Text = row.Cells["ID"].Value?.ToString();
                    textBoxIName.Text = row.Cells["ingredients_name"].Value?.ToString();
                }
                setI();
               //}
            }
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBoxFilter.Text;
            if (string.IsNullOrWhiteSpace(filterText))
            {
                bindingSource1.Filter = null;
            }
            else
            {
                SearchAndSelectFirstRow(filterText.Replace("'", "''"));
            }
        }
    }
}

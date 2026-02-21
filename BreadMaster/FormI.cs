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
                        bindingSource1.DataSource = dataTable;
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.DataSource = bindingSource1;
                        textBoxLog.Text = sCrLf + sql + textBoxLog.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;

                Console.WriteLine($"エラー: {ex.Message}");
            }
            setI();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            bindingSource1.Filter = null;
            //textBoxId.Clear();
            //textBoxName.Clear();
            textBoxIName.Clear();
            textBoxSIId.Clear();
            textBoxIId.Clear();
            dataGridViewAdd.DataSource = null;
            dataGridViewAdd.Rows.Clear();
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

            /*string sql2 = "SELECT id, ingredients_name, sid, iid FROM vIngredients WHERE sid = :id";
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
                            OracleDataReader reader2 = cmd2.ExecuteReader();
                            while(reader2.Read())
                            {
                                dataGridViewAdd.Rows.Add(reader2["id"].ToString(), reader2["ingredients_name"].ToString(), reader2["sid"].ToString(), reader2["iid"].ToString());

                            }
                            textBoxLog.Text = sCrLf + sql2 + textBoxLog.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
                Console.WriteLine($"エラー: {ex.Message}");
            }*/
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
                        command.Parameters.Add(new OracleParameter("id", int.Parse(textBoxIId.Text)));
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
                            textBoxSIId.Text = BreadMasterAppConstants.getCurrentSequenceValue(connection, sql2).ToString();
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
            /*if (textBoxName.Modified )
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


            }*/

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                /*// 行インデックスと列インデックスを取得
                int rowIndex = hit.RowIndex;
                //textBoxSIId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                textBoxIId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                textBoxIName.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                */

                int rowIndex = hit.RowIndex;
                if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count) return;

                // 先に値をローカルに退避（TextChanged の副作用を防ぐ）
                var row = dataGridView1.Rows[rowIndex];
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
                        command.Parameters.Add(new OracleParameter("id", int.Parse(textBoxIId.Text)));
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
            string filterText = textBoxIName.Text;
            if (string.IsNullOrWhiteSpace(filterText))
            {
                bindingSource1.Filter = null;
            }
            else
            {
                bindingSource1.Filter = string.Format("ingredients_name LIKE '%{0}%'", filterText.Replace("'", "''"));
            }
        }
        // C#
        private void buttonOK_Click(object sender, EventArgs e)
        {
            /*// サンドイッチID を textBoxId から取得
            if (!int.TryParse(textBoxId.Text, out int sandwichId))
            {
                MessageBox.Show("サンドイッチIDが不正です。");
                return;
            }

            // dataGridViewAdd から ingredients_id を集める
            var ids = new List<int>();
            foreach (DataGridViewRow r in dataGridViewAdd.Rows)
            {
                if (r.IsNewRow) continue;
                var v = r.Cells["ID"].Value ?? r.Cells[0].Value;
                if (v == null) continue;
                if (int.TryParse(v.ToString(), out int iid)) ids.Add(iid);
                else
                {
                    MessageBox.Show($"無効な食材ID: {v}");
                    return;
                }
            }

            if (ids.Count == 0)
            {
                MessageBox.Show("追加されている食材がありません。");
                return;
            }

            string sql = "INSERT INTO sandwich_ingredients (sandwich_id, ingredients_id) VALUES (:sid, :iid)";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        // 配列バインドで sandwichId を繰り返す配列を作る
                        int[] sidArray = Enumerable.Repeat(sandwichId, ids.Count).ToArray();
                        int[] iidArray = ids.ToArray();

                        command.ArrayBindCount = ids.Count;
                        command.Parameters.Add(":sid", OracleDbType.Int32, sidArray, ParameterDirection.Input);
                        command.Parameters.Add(":iid", OracleDbType.Int32, iidArray, ParameterDirection.Input);
                        command.ExecuteNonQuery();
                    }
                }
                FormI_Load(sender, e);
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
            }*/
        }

        private void textBoxIId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewAdd_MouseClick_1(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridViewAdd.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                // 行インデックスと列インデックスを取得
                int rowIndex = hit.RowIndex;
                textBoxSIId.Text = dataGridViewAdd.Rows[rowIndex].Cells[0].Value.ToString();
            }
        }
    }
}

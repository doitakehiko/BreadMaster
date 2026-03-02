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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BreadMaster
{

    public partial class FormC : Form
    {
        string connectionString = BreadMasterAppConstants.connectionString;
        string sCrLf = BreadMasterAppConstants.sCrLf;
        private BindingSource bindingSource1 = new BindingSource();

        public FormC()
        {
            InitializeComponent();
        }

        private void FormC_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.AllowUserToAddRows = false; // 必要なら

            string sql = "SELECT * FROM vCountry";
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
        }

        private void textBoxNameJp_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBoxNameJp.Text;
            if (string.IsNullOrWhiteSpace(filterText))
            {
                bindingSource1.Filter = null;
            }
            else
            {
                bindingSource1.Filter = string.Format("country_name_jp LIKE '%{0}%'", filterText.Replace("'", "''"));
            }

        }

        private void textBoxNameEn_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBoxNameEn.Text;
            if (string.IsNullOrWhiteSpace(filterText))
            {
                bindingSource1.Filter = null;
            }
            else
            {
                bindingSource1.Filter = string.Format("country_name_en LIKE '%{0}%'", filterText.Replace("'", "''"));
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                int rowIndex = hit.RowIndex;
                if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count - 1) return;

                // 先に値をローカルに退避（TextChanged の副作用を防ぐ）
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                string id = row.Cells[0].Value?.ToString() ?? "";
                string nameJp = row.Cells[1].Value?.ToString() ?? "";
                string nameEn = row.Cells[2].Value?.ToString() ?? "";
                string code = row.Cells[3].Value?.ToString() ?? "";

                // まとめて UI を更新
                textBoxId.Text = id;
                textBoxNameJp.Text = nameJp;
                textBoxNameEn.Text = nameEn;
                textBoxCode.Text = code;
            }

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            bindingSource1.Filter = null;
            textBoxId.Clear();
            textBoxNameJp.Clear();
            textBoxNameEn.Clear();
            textBoxCode.Clear();
        }
        public string getid()
        {
            return textBoxId.Text;
        }
        public string getnamejp()
        {
            return textBoxNameJp.Text;
        }
        public string getnameen()
        {
            return textBoxNameEn.Text;
        }
        public string getcode()
        {
            return textBoxCode.Text;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bindingSource1.Filter = null;
            DialogResult = DialogResult.OK;
            this.Close();   
        }
    }
}       



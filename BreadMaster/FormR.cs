using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BreadMaster
{
    public partial class FormR : Form
    {
        string connectionString = BreadMasterAppConstants.connectionString;
        string sCrLf = BreadMasterAppConstants.sCrLf;
        private BindingSource bindingSource1 = new BindingSource();

        public FormR()
        {
            InitializeComponent();
        }

        private void FormR_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            string sql = "SELECT * FROM vRegion";
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
                string name = row.Cells[1].Value?.ToString() ?? ""; 
                string nameJp = row.Cells[2].Value?.ToString() ?? "";
                string nameEn = row.Cells[3].Value?.ToString() ?? "";
                string code = row.Cells[4].Value?.ToString() ?? "";
                string cid = row.Cells[5].Value?.ToString() ?? "";

                // まとめて UI を更新
                textBoxId.Text = id;
                textBoxRName.Text = name;    
                textBoxNameJp.Text = nameJp;
                textBoxNameEn.Text = nameEn;
                textBoxCode.Text = code;
                textBoxCId.Text = cid;
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

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBoxCode.Text;
            if (string.IsNullOrWhiteSpace(filterText))
            {
                bindingSource1.Filter = null;
            }
            else
            {
                bindingSource1.Filter = string.Format("Convert(country_code, 'System.String') LIKE '%{0}%'", filterText.Replace("'", "''"));
            }

        }

        private void textBoxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBoxNameEn.Text;
            if (string.IsNullOrWhiteSpace(filterText))
            {
                bindingSource1.Filter = null;
            }
            else
            {
                bindingSource1.Filter = string.Format("region_name LIKE '%{0}%'", filterText.Replace("'", "''"));
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            bindingSource1.Filter = null;
            textBoxId.Clear();
            textBoxRName.Clear();
            textBoxNameJp.Clear();
            textBoxNameEn.Clear();
            textBoxCode.Clear();
            FormR_Load(sender, e);
        }
        public void setTextBoxId(string id)
        {
            textBoxId.Text = id;
        }
        public string getTextBoxId()
        {
            return textBoxId.Text;
        }
        public string getTextBoxRName()
        {
            return textBoxRName.Text;
        }
        public string getTextBoxNameJp()
        {
            return textBoxNameJp.Text;
        }
        public string getTextBoxNameEn()
        {
            return textBoxNameEn.Text;
        }
        public string getTextBoxCode()
        {
            return textBoxCode.Text;
        }
        public string getRId()
        {
            return textBoxId.Text;
        }
        public string getCId()
        {
            return textBoxCId.Text;
        }

        public void setTextBoxRId(string id)
        {
            textBoxId.Text = id;
        }
        public void setTextBoxCId(string id)
        {
            textBoxCId.Text = id;
        }
        private void buttonRIns_Click(object sender, EventArgs e)
        {
            FormRM f = new FormRM();
            f.setid(getTextBoxId());
            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK)
            {
                textBoxId.Text = f.getid();
                textBoxRName.Text = f.getname();
                textBoxNameJp.Text = f.getcnamejp();
                textBoxNameEn.Text = f.getcnameen();
                textBoxCId.Text = f.getcid();
            }
            f.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

        }
    }
}

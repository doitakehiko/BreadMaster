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
        /// <summary>
        /// Handles the Load event of the form by initializing the DataGridView and loading region data from the
        /// database.
        /// </summary>
        /// <remarks>This method configures the DataGridView for read-only, single-row selection and binds
        /// it to data retrieved from the 'vRegion' database view. If a specific ID is present in the associated text
        /// box, the corresponding row is selected automatically. Any connection or data retrieval errors are logged to
        /// the log text box.</remarks>
        /// <param name="sender">The source of the event, typically the form being loaded.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
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
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;

                Console.WriteLine($"エラー: {ex.Message}");
            }
        }
        /// <summary>
        /// Handles the MouseClick event for the DataGridView to populate related text boxes with the values from the
        /// selected row.
        /// </summary>
        /// <remarks>This method updates multiple text boxes with the values from the clicked row in the
        /// DataGridView. Only clicks on valid data rows (excluding header and new row) will trigger the
        /// update.</remarks>
        /// <param name="sender">The source of the event, typically the DataGridView control.</param>
        /// <param name="e">A MouseEventArgs that contains the event data, including mouse position and button information.</param>
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
        /// <summary>
        /// Handles the TextChanged event of the Japanese name text box by updating the filter applied to the data
        /// source based on the current text.
        /// </summary>
        /// <remarks>When the text box is empty or contains only whitespace, any existing filter is
        /// cleared and all items are shown. Otherwise, the filter is updated to display only items whose Japanese
        /// country name contains the entered text. This method is typically used to provide real-time filtering as the
        /// user types.</remarks>
        /// <param name="sender">The source of the event, typically the text box whose text has changed.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
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
        /// <summary>
        /// Handles the TextChanged event of the English name text box to update the filter applied to the data source
        /// based on the current text.
        /// </summary>
        /// <remarks>When the text box is empty or contains only whitespace, any existing filter is
        /// cleared and all items are shown. Otherwise, the filter is updated to display only items whose English
        /// country name contains the entered text. This method is typically used to provide real-time search or
        /// filtering functionality in a data-bound control.</remarks>
        /// <param name="sender">The source of the event, typically the text box whose text has changed.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
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
        /// <summary>
        /// Handles the TextChanged event of the code input TextBox, updating the filter applied to the data source
        /// based on the current text.
        /// </summary>
        /// <remarks>When the TextBox is empty or contains only whitespace, any existing filter is cleared
        /// and all items are shown. Otherwise, the filter is updated to display only items whose country code contains
        /// the entered text. This method is typically used to provide real-time filtering in a data-bound
        /// control.</remarks>
        /// <param name="sender">The source of the event, typically the TextBox whose text has changed.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
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
        /// <summary>
        /// Handles the KeyPress event for the code input TextBox, allowing only numeric digits and the Backspace key.
        /// </summary>
        /// <remarks>This event handler prevents non-numeric input in the associated TextBox, except for
        /// the Backspace key, which allows users to delete characters.</remarks>
        /// <param name="sender">The source of the event, typically the TextBox control.</param>
        /// <param name="e">A KeyPressEventArgs that contains the event data, including the character pressed and a flag to indicate
        /// whether the event is handled.</param>
        private void textBoxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// Handles the Click event of the Reset button by clearing all input fields and removing any applied filters.
        /// </summary>
        /// <remarks>After clearing the fields and filters, this method reloads the form data to its
        /// default state. Use this handler to reset the form to its initial values.</remarks>
        /// <param name="sender">The source of the event, typically the Reset button.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
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

        /// <summary>
        /// Sets the identifier value in the associated text box control.
        /// </summary>
        /// <param name="id">The identifier value to display. Can be null or empty to clear the text box.</param>
        public void setid(string id)
        {
            textBoxId.Text = id;
        }
        /// <summary>
        /// Gets the current text value of the associated text box control.
        /// </summary>
        /// <returns>A string containing the text of the text box. Returns an empty string if the text box is empty.</returns>
        public string getTextBoxId()
        {
            return textBoxId.Text;
        }
        /// <summary>
        /// Gets the current text value of the associated TextBox control.
        /// </summary>
        /// <returns>A string containing the text entered in the TextBox. Returns an empty string if the TextBox is empty.</returns>
        public string getTextBoxRName()
        {
            return textBoxRName.Text;
        }
        /// <summary>
        /// Gets the current text value of the Japanese name text box.
        /// </summary>
        /// <returns>A string containing the text entered in the Japanese name text box. Returns an empty string if the text box
        /// is empty.</returns>
        public string getTextBoxNameJp()
        {
            return textBoxNameJp.Text;
        }
        /// <summary>
        /// Gets the current text value from the English name text box.
        /// </summary>
        /// <returns>A string containing the text entered in the English name text box. Returns an empty string if the text box
        /// is empty.</returns>
        public string getTextBoxNameEn()
        {
            return textBoxNameEn.Text;
        }
        /// <summary>
        /// Gets the current text value from the associated text box control.
        /// </summary>
        /// <returns>A string containing the text currently entered in the text box. Returns an empty string if the text box is
        /// empty.</returns>
        public string getTextBoxCode()
        {
            return textBoxCode.Text;
        }
        /// <summary>
        /// Gets the current text value of the associated ID input field.
        /// </summary>
        /// <returns>A string containing the text entered in the ID input field. Returns an empty string if the field is empty.</returns>
        public string getRId()
        {
            return textBoxId.Text;
        }
        /// <summary>
        /// Handles the Click event of the button that initiates the process of adding or editing a record using the
        /// FormRM dialog.
        /// </summary>
        /// <remarks>If the user completes the dialog with an OK result, the relevant text boxes on the
        /// form are updated with the values entered or selected in the FormRM dialog.</remarks>
        /// <param name="sender">The source of the event, typically the button that was clicked.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
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
                FormR_Load(sender, e);
            }
            f.Dispose();
        }
        /// <summary>
        /// Handles the Click event of the OK button.
        /// </summary>
        /// <param name="sender">The source of the event, typically the OK button.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        private void buttonOK_Click(object sender, EventArgs e)
        {

        }
    }
}

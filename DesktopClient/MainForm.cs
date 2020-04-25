using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Linq;
using SocketCommon.TransportModel;
using SocketCommon.Models;
using SocketCommon.Logging;
using DesktopClient.Sockets;

namespace DesktopClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void calculate_button_Click(object sender, EventArgs e)
        {
            if (AreFieldsNotEmpty())
            {
                ResetDataGridView();
                GetMatrixMultiplicationResult();
            }
            else
            {
               ShowError("Come on friend, fill all the fields!");
            }
        }

        private void GetMatrixMultiplicationResult()
        {
            try
            {
                // TODO: Make TextFileLogger
                MatrixClientSocket socket = new MatrixClientSocket(new ConsoleLogger());
                MxMultiplicationInputModel inputModel = new MxMultiplicationInputModel()
                {
                    MX1Name = fstMxName_textBox.Text,
                    MX2Name = secMxName_textBox.Text,
                    RowBegin = int.Parse(fromRowRange_textBox.Text),
                    RowEnd = int.Parse(toRowRange_textBox.Text),
                    ColBegin = int.Parse(fromColRange_textBox.Text),
                    ColEnd = int.Parse(toColRange_textBox.Text)
                };
                OperationResult<List<List<int>>> response = socket.GetData(inputModel);

                if (response.Status == OperationStatus.Ok)
                {
                    FormDataGridView(response.Data);
                }
                else
                {
                    ShowError(response.Message);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void ResetDataGridView()
        {
            dataGridView.Visible = false;
            dataGridView.Columns.Clear();
        }
        private void FormDataGridView(List<List<int>> matrixData)
        {
            dataGridView.ColumnCount = matrixData.First().Count;
            foreach (var matrixRow in matrixData)
            {
                dataGridView.Rows.Add(matrixRow.Select(item => item.ToString()).ToArray());
            }
            dataGridView.Visible = true;
        }

        private bool AreFieldsNotEmpty()
        {
            return !String.IsNullOrWhiteSpace(fstMxName_textBox.Text) && !String.IsNullOrWhiteSpace(secMxName_textBox.Text)
                && !String.IsNullOrWhiteSpace(fromRowRange_textBox.Text) && !String.IsNullOrWhiteSpace(toRowRange_textBox.Text)
                && !String.IsNullOrWhiteSpace(fromColRange_textBox.Text) && !String.IsNullOrWhiteSpace(toColRange_textBox.Text);
        }

        private void ShowError(string message)
        {
            log_label.ForeColor = Color.Red;
            log_label.Text = message;
        }

        private void fromRowRange_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toRowRange_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void fromColRange_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toColRange_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

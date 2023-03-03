using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinalMVC
{
    public partial class frmNovoArquivo : Form
    {
        public List<string> Arquivos { get; set; }

        public frmNovoArquivo()
        {
            InitializeComponent();
        }

        private void frmNovoArquivo_Load(object sender, EventArgs e)
        {
            try
            {
                this.Arquivos = new List<string>();

                txtNome.Text = "NovoArquivo";
                chbModel.Checked = true;
                chbView.Checked = true;
                chbController.Checked = true;
                chbCRUD.Checked = true;
                chbPOSTGET.Checked = true;
                chbErrorPage.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNome.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Um nome para o projeto deve ser informado.");
                    txtNome.Focus();
                    return;
                }

                this.Arquivos = Form1.CriarArquivo(Form1.RemoveAcentos(txtNome.Text.Trim()), chbModel.Checked, chbView.Checked, chbController.Checked, chbCRUD.Checked, chbPOSTGET.Checked, chbErrorPage.Checked);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar)) && !(char.IsLetter(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

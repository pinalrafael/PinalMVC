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
                chbPageLayout.Checked = false;

                if (Directory.Exists(Form1.ProjectDir + "/" + Form1.Project.pages_layouts))
                {
                    foreach (string item in Directory.GetFiles(Form1.ProjectDir + "/" + Form1.Project.pages_layouts))
                    {
                        FileInfo fileInfo = new FileInfo(item);
                        chbLayout.Items.Add(fileInfo.Name);
                    }

                    if(chbLayout.Items.Count > 0)
                    {
                        chbLayout.SelectedIndex = 0;
                    }
                }
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

                string layout = "Views/Layout/_Layout.php";
                if (chbLayout.Items.Count > 0)
                {
                    layout = Form1.Project.pages_layouts + chbLayout.SelectedItem.ToString();
                }

                this.Arquivos = Form1.CriarArquivo(Form1.RemoveAcentos(txtNome.Text.Trim()), chbModel.Checked, chbView.Checked, chbController.Checked, chbCRUD.Checked, chbPOSTGET.Checked, chbErrorPage.Checked, chbPageLayout.Checked, layout);

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
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else if (e.KeyChar == '_')
                {
                    e.Handled = false;
                }
                else if (!(char.IsDigit(e.KeyChar)) && !(char.IsLetter(e.KeyChar)))
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

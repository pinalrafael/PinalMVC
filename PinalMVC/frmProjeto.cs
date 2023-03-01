using Newtonsoft.Json;
using PinalMVC.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinalMVC
{
    public partial class frmProjeto : Form
    {
        public frmProjeto()
        {
            InitializeComponent();
        }

        private void frmProjeto_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Form1.Project.nameproject;

                this.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";

                string dirincludes = Form1.ProjectDir + "/" + Form1.Project.includes;
                lblMsg.Text = "Criando: " + dirincludes;
                Directory.Delete(dirincludes, true);
                if (!Directory.Exists(dirincludes))
                {
                    Directory.CreateDirectory(dirincludes);
                }

                lblMsg.Text = "Atualizando biblioteca";
                this.Enabled = false;
                backgroundWorker1.RunWorkerAsync(new object[] { Form1.ProjectDir, dirincludes });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNovoArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNovoArquivo frmNovoArquivo = new frmNovoArquivo();
                frmNovoArquivo.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] arg = (object[])e.Argument;
            object[] ret = new object[] { false, arg[0], arg[1] };
            try
            {
                if (Util.BaixarBiblioteca((string)arg[1], Form1.Nome))
                {
                    ret[0] = true;
                }
                else
                {
                    ret[0] = false;
                }
            }
            catch { }
            e.Result = ret;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                object[] ret = (object[])e.Result;

                if ((bool)ret[0])
                {
                    using (ZipArchive zip = ZipFile.Open(ret[2] + "\\" + Form1.Nome + ".zip", ZipArchiveMode.Read))
                    {
                        zip.ExtractToDirectory((string)ret[2]);
                    }
                    if (File.Exists(ret[2] + "\\" + Form1.Nome + ".zip"))
                    {
                        File.Delete(ret[2] + "\\" + Form1.Nome + ".zip");
                    }
                }
                else
                {
                    this.Enabled = true;
                    MessageBox.Show("Não foi possível baixar a biblioteca!!");
                    return;
                }

                string dirproject = (string)ret[1];

                // Criando arquivo config.json
                lblMsg.Text = "Criando arquivo config.json";
                Form1.AtualizaConfig(dirproject);

                lblMsg.Text = "Atualização concluída";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.Enabled = true;
        }
    }
}

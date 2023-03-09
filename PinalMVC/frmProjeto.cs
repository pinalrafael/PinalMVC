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
using System.Diagnostics;
using System.Collections.ObjectModel;
using PinalMVC.Enums;
using System.Runtime.InteropServices;

namespace PinalMVC
{
    public partial class frmProjeto : Form
    {
        private Process process { get; set; }

        public frmProjeto()
        {
            InitializeComponent();
        }

        private void frmProjeto_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Form1.Project.nameproject;
                Form1.SetRecente(Form1.ProjectDir, Form1.Project.nameproject);

                this.OpenNotepad("");

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
                if (Directory.Exists(dirincludes))
                {
                    Directory.Delete(dirincludes, true);
                }
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

                string files = "";
                foreach (var item in frmNovoArquivo.Arquivos)
                {
                    files += item + " ";
                }
                this.OpenNotepad(files);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            try
            {
                bool apacheaberto = false;
                foreach (var item in Process.GetProcesses())
                {
                    if (item.ProcessName == "httpd")
                    {
                        apacheaberto = true;
                        break;
                    }
                }

                if (!apacheaberto)
                {
                    string httpd_modelo = Form1.ExeDir.Replace("\\", "/") + "/apache/conf/httpd_modelo.conf";
                    string httpd = Form1.ExeDir.Replace("\\", "/") + "/apache/conf/httpd.conf";
                    string httpdexe = Form1.ExeDir.Replace("\\", "/") + "/apache/bin/httpd.exe";

                    string config = File.ReadAllText(httpd_modelo);

                    config = config.Replace("{port}", "8098");
                    config = config.Replace("{src_project}", Form1.ProjectDir.Replace("\\", "/"));

                    using (StreamWriter writer = new StreamWriter(httpd, false))
                    {
                        writer.WriteLine(config);
                        writer.Close();
                    }

                    Process.Start(httpdexe);
                }

                Process.Start("http://localhost:8098");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void treeProjeto_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (treeProjeto.SelectedNode != null)
                {
                    object[] tag = (object[])treeProjeto.SelectedNode.Tag;

                    this.OpenNotepad((string)tag[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmProjeto_Activated(object sender, EventArgs e)
        {
            try
            {
                this.UpdateArvore();
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
                if (File.Exists(arg[1] + "\\" + Form1.Nome + ".zip"))
                {
                    File.Delete(arg[1] + "\\" + Form1.Nome + ".zip");
                }

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

                this.UpdateArvore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.Enabled = true;
        }

        private void UpdateArvore() 
        {
            TreeNode treeNode = new TreeNode(Form1.Project.nameproject);
            treeNode.ImageIndex = 0;
            treeNode.Tag = new object[] { Form1.ProjectDir, TypesNodeTree.RAIZ };

            this.AddNode(treeProjeto.Nodes, treeNode);

            this.CreateNodes(treeProjeto.Nodes[0], Form1.ProjectDir);

            treeProjeto.Nodes[0].Expand();

            this.ValidaNode(treeProjeto.Nodes);
        }

        private void ValidaNode(TreeNodeCollection treeNodeCollection)
        {
            volta:
            foreach (TreeNode item in treeNodeCollection)
            {
                object[] tag = (object[])item.Tag;

                if ((TypesNodeTree)tag[1] == TypesNodeTree.FOLDER ||
                    (TypesNodeTree)tag[1] == TypesNodeTree.RAIZ)
                {
                    if (!Directory.Exists((string)tag[0]))
                    {
                        item.Nodes.Clear();
                        treeNodeCollection.Remove(item);
                        goto volta;
                    }
                    this.ValidaNode(item.Nodes);
                }
                else if ((TypesNodeTree)tag[1] == TypesNodeTree.FILE)
                {
                    if (!File.Exists((string)tag[0]))
                    {
                        treeNodeCollection.Remove(item);
                        goto volta;
                    }
                }
            }
        }

        private void AddNode(TreeNodeCollection treeNodeCollection, TreeNode treeNode)
        {
            bool encontrado = false;
            foreach (TreeNode item in treeNodeCollection)
            {
                if(item.Text == treeNode.Text)
                {
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                treeNodeCollection.Add(treeNode);

                List<TreeNode> list = (from a in treeNodeCollection.Cast<TreeNode>()
                                      orderby ((object[])a.Tag)[1], a.Text ascending
                                      select a).ToList();

                treeNodeCollection.Clear();
                treeNodeCollection.AddRange(list.ToArray());
            }
        }

        private void CreateNodes(TreeNode node, string dir)
        {
            int x = 0;
            foreach (var item in Directory.GetDirectories(dir))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(item);

                TreeNode treeNode = new TreeNode(directoryInfo.Name);
                if (directoryInfo.GetFiles().Count() > 0 || directoryInfo.GetDirectories().Count() > 0)
                {
                    treeNode.ImageIndex = 1;
                }
                else
                {
                    treeNode.ImageIndex = 2;
                }
                treeNode.SelectedImageIndex = treeNode.ImageIndex;
                treeNode.Tag = new object[] { directoryInfo.FullName, TypesNodeTree.FOLDER };

                this.AddNode(node.Nodes, treeNode);

                this.CreateNodes(node.Nodes[x], item);

                x++;
            }

            foreach (var item in Directory.GetFiles(dir))
            {
                FileInfo fileInfo = new FileInfo(item);

                TreeNode treeNode = new TreeNode(fileInfo.Name);
                if(fileInfo.Extension == Form1.Ext)
                {
                    treeNode.ImageIndex = 0;
                    continue;
                }
                else if (fileInfo.Extension == ".json")
                {
                    treeNode.ImageIndex = 4;
                }
                else if (fileInfo.Extension == ".png" || 
                    fileInfo.Extension == ".jpg" || 
                    fileInfo.Extension == ".jpeg" || 
                    fileInfo.Extension == ".gif" ||
                    fileInfo.Extension == ".ico")
                {
                    treeNode.ImageIndex = 5;
                }
                else if (fileInfo.Extension == ".php")
                {
                    treeNode.ImageIndex = 6;
                }
                else if (fileInfo.Extension == ".xml")
                {
                    treeNode.ImageIndex = 7;
                }
                else if (fileInfo.Extension == ".txt")
                {
                    treeNode.ImageIndex = 8;
                }
                else if (fileInfo.Extension == ".css")
                {
                    treeNode.ImageIndex = 9;
                }
                else if (fileInfo.Extension == ".html")
                {
                    treeNode.ImageIndex = 10;
                }
                else if (fileInfo.Extension == ".js")
                {
                    treeNode.ImageIndex = 11;
                }
                else if (fileInfo.Extension == ".htaccess")
                {
                    treeNode.ImageIndex = 12;
                }
                else
                {
                    treeNode.ImageIndex = 3;
                }
                treeNode.SelectedImageIndex = treeNode.ImageIndex;
                treeNode.Tag = new object[] { fileInfo.FullName, TypesNodeTree.FILE };

                this.AddNode(node.Nodes, treeNode);
            }
        }

        private void OpenNotepad(string files)
        {
            try
            {
                if (process != null)
                {
                    process.Kill();
                }
            }
            catch { }

            /*
             * Argumentos notepad++
             * https://npp-user-manual.org/docs/command-prompt/
             */
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = Form1.ExeDir + @"\notepad\notepad++.exe";
            startInfo.Arguments = "-alwaysOnTop -x0 -y0 -nosession " + files;

            process = System.Diagnostics.Process.Start(startInfo);
            process.WaitForInputIdle();
            // Coloca o notepad++ no panel
            SetParent(process.MainWindowHandle, panel1.Handle);

            /*
             * Atalhos
             * https://learn.microsoft.com/pt-br/office/vba/language/reference/user-interface-help/sendkeys-statement
             */
            SendKeys.Send("%( X)");
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }
}

using Newtonsoft.Json;
using PinalMVC.Classes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinalMVC
{
    public partial class Form1 : Form
    {
        private string Versao = "1.0.0-dev";
        public static string Nome = "PinalMVC";
        public static string Ext = ".pmvc";
        public static string ExtNome = "Arquivo PinalMVC (*.pmvc)";
        public static string PatchDoc { get; set; }
        public static string SourcesDir { get; set; }
        public static string ProjectDir { get; set; }
        public static string ExeDir { get; set; }
        public static Project Project { get; set; }
        public static List<string> ListaRecentes { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.Text = Nome + " v" + Versao;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ProjectDir = "";
                ListaRecentes = new List<string>();

                PatchDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + Nome;
                ExeDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());

                SourcesDir = PatchDoc + "\\Sources\\";
                if (!Directory.Exists(SourcesDir))
                {
                    Directory.CreateDirectory(SourcesDir);
                }

                this.UpdateRecentes();

                if (!Directory.Exists(ExeDir + "\\notepad\\"))
                {
                    lblMsg.Text = "Baixando Notepad++";
                    this.Enabled = false;
                    backgroundWorker1.RunWorkerAsync(ExeDir);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                frmNovo frmNovo = new frmNovo();
                frmNovo.ShowDialog(this);

                if (frmNovo.isCriado)
                {
                    frmProjeto frmProjeto = new frmProjeto();
                    frmProjeto.ShowDialog(this);
                    this.UpdateRecentes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Visible = true;
            this.Activate();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                string path = SourcesDir;

                openFileDialog1.Title = "Carregar Projeto";
                openFileDialog1.InitialDirectory = path;
                openFileDialog1.Filter = ExtNome + "|*" + Ext;
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;
                openFileDialog1.Multiselect = false;
                openFileDialog1.FileName = "";

                DialogResult dr = openFileDialog1.ShowDialog();

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    this.OpenProject(openFileDialog1.FileName);
                    this.UpdateRecentes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Visible = true;
            this.Activate();
        }

        private void listRecentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(listRecentes.SelectedIndex > -1)
                {
                    this.Visible = false;

                    this.OpenIndex(listRecentes.SelectedIndex);
                    this.UpdateRecentes();

                    this.Visible = true;
                    this.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                this.Visible = true;
                this.Activate();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string arg = (string)e.Argument;
            object[] ret = new object[] { false, arg };
            try
            {
                if (File.Exists(arg + "\\notepad.zip"))
                {
                    File.Delete(arg + "\\notepad.zip");
                }

                if (Util.BaixarBiblioteca(arg, "notepad"))
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
                    using (ZipArchive zip = ZipFile.Open(ret[1] + "\\notepad.zip", ZipArchiveMode.Read))
                    {
                        zip.ExtractToDirectory((string)ret[1]);
                    }
                    if (File.Exists(ret[1] + "\\notepad.zip"))
                    {
                        File.Delete(ret[1] + "\\notepad.zip");
                    }
                }
                else
                {
                    this.Enabled = true;
                    MessageBox.Show("Não foi possível baixar o notepad: adicione manualmente a pasta 'notepad' do projeto para a pasta do exe!!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            lblMsg.Text = "Download Concluído";
            this.Enabled = true;
        }

        public static void AtualizaConfig(string dirproject)
        {
            using (StreamWriter writer = new StreamWriter(dirproject + "/" + Form1.Project.includes + "config.json", false))
            {
                string jsonconfig = JsonConvert.SerializeObject(Project);
                writer.WriteLine(jsonconfig);
                writer.Close();
            }
        }

        public static List<string> CriarArquivo(string pnome, bool pmodel, bool pview, bool pcontroller, bool pcrud, bool ppostget, bool perropage)
        {
            List<string> retorno = new List<string>();
            string caminho = "";

            string nome = pnome;
            if (pmodel)
            {
                caminho = Form1.ProjectDir + "\\" + Form1.Project.models + nome + Form1.Project.models_suffix + ".php";
                using (StreamWriter writer = new StreamWriter(caminho, false))
                {
                    string model = @"<?php
class " + nome + @"{
	function __construct(){
		
	}
}
?>";
                    writer.WriteLine(model);
                    writer.Close();
                }
                retorno.Add(caminho);
            }

            if (pview)
            {
                string namefolder = Form1.Project.views + nome;
                if (!Directory.Exists(Form1.ProjectDir + "\\" + namefolder))
                {
                    Directory.CreateDirectory(Form1.ProjectDir + "\\" + namefolder);
                }

                string pagename = namefolder + "\\Index" + Form1.Project.views_suffix;
                if (perropage)
                {
                    pagename = Form1.Project.page_errors + nome + Form1.Project.page_errors_suffix;
                }

                caminho = Form1.ProjectDir + "\\" + pagename + ".php";
                using (StreamWriter writer = new StreamWriter(caminho, false))
                {
                    string view = @"<h1>" + nome + @" Index</h1>";
                    writer.WriteLine(view);
                    writer.Close();
                }
                retorno.Add(caminho);

                if (pcrud && !perropage)
                {
                    string pagenamecrud = namefolder + "\\Create" + Form1.Project.views_suffix;
                    caminho = Form1.ProjectDir + "\\" + pagenamecrud + ".php";
                    using (StreamWriter writer = new StreamWriter(caminho, false))
                    {
                        string view = @"<h1>" + nome + @" Create</h1>";
                        writer.WriteLine(view);
                        writer.Close();
                    }
                    retorno.Add(caminho);

                    pagenamecrud = namefolder + "\\Update" + Form1.Project.views_suffix;
                    caminho = Form1.ProjectDir + "\\" + pagenamecrud + ".php";
                    using (StreamWriter writer = new StreamWriter(caminho, false))
                    {
                        string view = @"<h1>" + nome + @" Update</h1>";
                        writer.WriteLine(view);
                        writer.Close();
                    }
                    retorno.Add(caminho);

                    pagenamecrud = namefolder + "\\Delete" + Form1.Project.views_suffix;
                    caminho = Form1.ProjectDir + "\\" + pagenamecrud + ".php";
                    using (StreamWriter writer = new StreamWriter(caminho, false))
                    {
                        string view = @"<h1>" + nome + @" Delete</h1>";
                        writer.WriteLine(view);
                        writer.Close();
                    }
                    retorno.Add(caminho);
                }
            }

            if (pcontroller)
            {
                caminho = Form1.ProjectDir + "\\" + Form1.Project.controllers + nome + Form1.Project.controllers_suffix + ".php";
                using (StreamWriter writer = new StreamWriter(caminho, false))
                {
                    string postget = "";
                    string crud = "";

                    if (ppostget)
                    {
                        postget = @"if(isset($_GET)){
		
	} else if(isset($_POST)){
	
	}";
                    }

                    if (pcrud && !perropage)
                    {
                        crud = @"else if(pmvcGetValueFunction() == ""Create""){
	" + postget + @"
}else if(pmvcGetValueFunction() == ""Update""){
    $id = pmvcGetValueId();
	" + postget + @"
}else if(pmvcGetValueFunction() == ""Delete""){
    $id = pmvcGetValueId();
	" + postget + @"
}";
                    }

                    string controller = @"<?php

$pmvc_title = """ + nome + @""";
$pmvc_Model = new " + nome + @"();

if (pmvcGetValueFunction() == ""Index""){
    " + postget + @"
}" + crud + @"else{
    pmvcView(""PagesErrors"", ""Error404"", array('msg' => 'Function not found'));
}

?>";
                    writer.WriteLine(controller);
                    writer.Close();
                }
                retorno.Add(caminho);
            }

            return retorno;
        }

        public static string RemoveAcentos(string _textoNAOFormatado)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = _textoNAOFormatado.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static void SetRecente(string caminho, string name)
        {
            string salvar = "";
            var list = ReadRecentes();

            foreach (var item in list)
            {
                if(item.Contains(name))
                {
                    list.Remove(item);
                    break;
                }
            }

            list.Add(caminho + "|" + name + "|" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

            int cont = 0;
            foreach (var item in list)
            {
                if (cont < 10)
                {
                    salvar += item + "?";
                }
            }

            if(salvar.Length > 0)
            {
                salvar = salvar.Substring(0, salvar.Length - 1);
            }

            PinalMVC.Properties.Settings.Default.Recentes = salvar;
            PinalMVC.Properties.Settings.Default.Save();
        }

        public static List<string> ReadRecentes()
        {
            return PinalMVC.Properties.Settings.Default.Recentes.Split('?').ToList();
        }

        public void OpenProject(string caminho)
        {
            FileInfo fileInfo = new FileInfo(caminho);
            Project = JsonConvert.DeserializeObject<Project>(File.ReadAllText(fileInfo.FullName));
            ProjectDir = fileInfo.Directory.FullName;

            frmProjeto frmProjeto = new frmProjeto();
            frmProjeto.ShowDialog(this);
        }

        public void UpdateRecentes()
        {
            listRecentes.Items.Clear();

            ListaRecentes = ReadRecentes().Reverse<string>().ToList();

            foreach (var item in ListaRecentes)
            {
                if (!item.Equals(""))
                {
                    var it = item.Split('|').ToList();
                    listRecentes.Items.Add(it[1] + " - " + it[2]);
                }
            }
        }

        public void OpenIndex(int index)
        {
            int i = 0;
            foreach (var item in ListaRecentes)
            {
                if (!item.Equals(""))
                {
                    if (i == index)
                    {
                        var it = item.Split('|').ToList();
                        this.OpenProject(it[0] + "\\" + it[1] + Ext);
                        break;
                    }
                    i++;
                }
            }
        }
    }
}

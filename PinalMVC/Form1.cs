﻿using Newtonsoft.Json;
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
        private string Versao = "1.6.0";
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
                    backgroundWorker1.RunWorkerAsync(new object[] { "notepad", ExeDir });
                }
                else
                {
                    if (!Directory.Exists(ExeDir + "\\apache\\"))
                    {
                        lblMsg.Text = "Baixando apache";
                        this.Enabled = false;
                        backgroundWorker1.RunWorkerAsync(new object[] { "apache", ExeDir });
                    }
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
                if (listRecentes.SelectedIndex > -1)
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
            object[] arg = (object[])e.Argument;
            object[] ret = new object[] { false, arg[0].ToString(), arg[1].ToString() };
            try
            {
                if (File.Exists(arg + "\\" + arg[0].ToString() + ".zip"))
                {
                    File.Delete(arg + "\\" + arg[0].ToString() + ".zip");
                }

                if (Util.BaixarBiblioteca(arg[1].ToString(), arg[0].ToString()))
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
            object[] ret = (object[])e.Result;

            try
            {
                if ((bool)ret[0])
                {
                    using (ZipArchive zip = ZipFile.Open(ret[2] + "\\" + ret[1].ToString() + ".zip", ZipArchiveMode.Read))
                    {
                        zip.ExtractToDirectory((string)ret[2]);
                    }
                    if (File.Exists(ret[2] + "\\" + ret[1].ToString() + ".zip"))
                    {
                        File.Delete(ret[2] + "\\" + ret[1].ToString() + ".zip");
                    }
                }
                else
                {
                    this.Enabled = true;
                    MessageBox.Show("Não foi possível baixar o " + ret[1].ToString() + ": adicione manualmente a pasta '" + ret[1].ToString() + "' do projeto para a pasta do exe!!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            lblMsg.Text = "Download Concluído";
            this.Enabled = true;

            if (!ret[1].ToString().Equals("apache"))
            {
                if (!Directory.Exists(ExeDir + "\\apache\\"))
                {
                    lblMsg.Text = "Baixando apache";
                    this.Enabled = false;
                    backgroundWorker1.RunWorkerAsync(new object[] { "apache", ExeDir });
                }
            }
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

        public static List<string> CriarArquivo(string pnome, bool pmodel, bool pview, bool pcontroller, bool pcrud, bool ppostget, bool perropage, bool pagelayout, string errorname, string layout, bool api)
        {
            List<string> retorno = new List<string>();
            string caminho = "";

            string nome = pnome;
            if (!pagelayout)
            {
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

                if (!api)
                {
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
                            pagename = "Views/" + Form1.Project.page_errors + errorname + Form1.Project.page_errors_suffix;
                        }

                        caminho = Form1.ProjectDir + "\\" + pagename + ".php";
                        using (StreamWriter writer = new StreamWriter(caminho, false))
                        {
                            string indexcrud = "";

                            if (pcrud && !perropage)
                            {
                                indexcrud = @"<br><a href='<?php echo $pmvc_root; ?>" + nome + @"/Create'>Cadastro</a><br>
<a href='<?php echo $pmvc_root; ?>" + nome + @"/Details/1'>Details 1</a><br>
<a href='<?php echo $pmvc_root; ?>" + nome + @"/Update/1'>Update 1</a><br>
<a href='<?php echo $pmvc_root; ?>" + nome + @"/Delete/1'>Delete 1</a><br>";
                            }

                            string view = @"<h1>" + nome + @" Index</h1>
" + indexcrud;

                            if (perropage)
                            {
                                view = @"<h1>" + errorname + @"</h1>
" + indexcrud;
                            }
                            writer.WriteLine(view);
                            writer.Close();
                        }
                        retorno.Add(caminho);

                        if (pcrud && !perropage)
                        {
                            string idcrud = "<br><?php echo pmvcGetValueId(); ?>";

                            string pagenamecrud = namefolder + "\\Create" + Form1.Project.views_suffix;
                            caminho = Form1.ProjectDir + "\\" + pagenamecrud + ".php";
                            using (StreamWriter writer = new StreamWriter(caminho, false))
                            {
                                string view = @"<h1>" + nome + @" Create</h1>";
                                writer.WriteLine(view);
                                writer.Close();
                            }
                            retorno.Add(caminho);

                            pagenamecrud = namefolder + "\\Details" + Form1.Project.views_suffix;
                            caminho = Form1.ProjectDir + "\\" + pagenamecrud + ".php";
                            using (StreamWriter writer = new StreamWriter(caminho, false))
                            {
                                string view = @"<h1>" + nome + @" Details</h1>
" + idcrud;
                                writer.WriteLine(view);
                                writer.Close();
                            }
                            retorno.Add(caminho);

                            pagenamecrud = namefolder + "\\Update" + Form1.Project.views_suffix;
                            caminho = Form1.ProjectDir + "\\" + pagenamecrud + ".php";
                            using (StreamWriter writer = new StreamWriter(caminho, false))
                            {
                                string view = @"<h1>" + nome + @" Update</h1>
" + idcrud;
                                writer.WriteLine(view);
                                writer.Close();
                            }
                            retorno.Add(caminho);

                            pagenamecrud = namefolder + "\\Delete" + Form1.Project.views_suffix;
                            caminho = Form1.ProjectDir + "\\" + pagenamecrud + ".php";
                            using (StreamWriter writer = new StreamWriter(caminho, false))
                            {
                                string view = @"<h1>" + nome + @" Delete</h1>
" + idcrud;
                                writer.WriteLine(view);
                                writer.Close();
                            }
                            retorno.Add(caminho);
                        }
                    }
                }

                if (pcontroller)
                {
                    string globals = @"global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
    global $pmvc_Headers;// HTTP headers";

                    if (api)
                    {
                        globals = @"global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $pmvc_APIRequest;// POST request in API
	global $pmvc_Headers;// HTTP headers
	global $pmvc_APIMethod;// Method request API";
                    }

                    caminho = Form1.ProjectDir + "\\" + Form1.Project.controllers + nome + Form1.Project.controllers_suffix + ".php";
                    using (StreamWriter writer = new StreamWriter(caminho, false))
                    {
                        string postget = "";
                        string crud = "";

                        if (ppostget)
                        {
                            postget = @"
    if(isset($_POST)){
	    
	}";
                        }

                        if (api)
                        {
                            if (pcrud && !perropage)
                            {
                                crud = @"
function Create(){
    " + globals + @"   

    return array('response' => true, 'data' => 'Create');
}

function Details($id){
    " + globals + @"   

    return array('response' => true, 'data' => 'Details '.$id);
}

function Update($id){
    " + globals + @"   

    return array('response' => true, 'data' => 'Update '.$id);
}

function Delete($id){
    " + globals + @"   

    return array('response' => true, 'data' => 'Delete '.$id);
}";
                            }

                            string controller = @"<?php
header('Content-Type: application/json');

$pmvc_Model = new " + nome + @"();

function Index(){
    " + globals + @"   
    
    return array('response' => true, 'data' => 'Index');
}
" + crud + @"

?>";
                            writer.WriteLine(controller);
                        }
                        else
                        {
                            if (pcrud && !perropage)
                            {
                                crud = @"
function Create(){
    " + globals + @"   
    
    $pmvc_title = 'Create " + nome + @"';
    " + postget + @"
}

function Details($id){
    " + globals + @"   
    
    $pmvc_title = 'Update " + nome + @" '.$id;
    " + postget + @"
}

function Update($id){
    " + globals + @"   
    
    $pmvc_title = 'Update " + nome + @" '.$id;
    " + postget + @"
}

function Delete($id){
    " + globals + @"   
    
    $pmvc_title = 'Delete " + nome + @" '.$id;
    " + postget + @"
}";
                            }
                            else
                            {
                                crud = @"
function " + errorname + @"(){
    " + globals + @"   
    
    $pmvc_title = '" + errorname + @"';
    " + postget + @"
}";
                            }

                            string controller = @"<?php

$pmvc_layout = """ + layout + @""";
$pmvc_title = """ + nome + @""";
$pmvc_Model = new " + nome + @"();

function Index(){
    " + globals + @"    
    " + postget + @"
}
" + crud + @"

?>";
                            if (perropage)
                            {
                                controller = @"<?php

$pmvc_layout = """ + layout + @""";
$pmvc_title = """ + nome + @""";
$pmvc_Model = new " + nome + @"();

" + crud + @"

?>";
                            }

                            writer.WriteLine(controller);
                        }
                        writer.Close();
                    }
                    retorno.Add(caminho);
                }
            }
            else
            {
                caminho = Form1.ProjectDir + "\\" + Form1.Project.pages_layouts + nome + ".php";
                using (StreamWriter writer = new StreamWriter(caminho, false))
                {
                    string _Layout = @"
<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
		<meta name=""viewport"" content=""width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no"">
		<title>" + Form1.Project.nameproject + @" - " + nome + @" - <?php echo $pmvc_title; ?></title>

		<!-- PAGE HEADER TAGS -->

		<?php pmvcHead(); ?>
	</head>
	<body>

    <!-- HEADER PAGE -->

	<?php require($pmvc_view); ?>

    <!-- FOOTER PAGE -->

	<!-- PAGE SCRIPTS -->

	<?php pmvcBody(); ?>
	</body>
</html>";
                    writer.WriteLine(_Layout);
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
                if (item.Contains(name))
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

            if (salvar.Length > 0)
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

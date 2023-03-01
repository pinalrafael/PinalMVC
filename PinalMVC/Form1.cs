using Newtonsoft.Json;
using PinalMVC.Classes;
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
    public partial class Form1 : Form
    {
        private string Versao = "1.0.0-dev";
        public static string Nome = "PinalMVC";
        public static string Ext = ".pmvc";
        public static string ExtNome = "Arquivo PinalMVC (*.pmvc)";
        public static string PatchDoc { get; set; }
        public static string SourcesDir { get; set; }
        public static Project Project { get; set; }
        public static string ProjectDir { get; set; }

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

                PatchDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + Nome;

                SourcesDir = PatchDoc + "\\Sources\\";
                if (!Directory.Exists(SourcesDir))
                {
                    Directory.CreateDirectory(SourcesDir);
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
                    FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);
                    Project =  JsonConvert.DeserializeObject<Project>(File.ReadAllText(openFileDialog1.FileName));
                    ProjectDir = fileInfo.Directory.FullName;

                    frmProjeto frmProjeto = new frmProjeto();
                    frmProjeto.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Visible = true;
            this.Activate();
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

        public static void CriarArquivo(string pnome, bool pmodel, bool pview, bool pcontroller, bool pcrud, bool ppostget, bool perropage)
        {
            string nome = pnome;
            if (pmodel)
            {
                using (StreamWriter writer = new StreamWriter(Form1.ProjectDir + "\\" + Form1.Project.models + nome + Form1.Project.models_suffix + ".php", false))
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

                using (StreamWriter writer = new StreamWriter(Form1.ProjectDir + "\\" + pagename + ".php", false))
                {
                    string view = @"<h1>" + nome + @" Index</h1>";
                    writer.WriteLine(view);
                    writer.Close();
                }

                if (pcrud && !perropage)
                {
                    string pagenamecrud = namefolder + "\\Create" + Form1.Project.views_suffix;
                    using (StreamWriter writer = new StreamWriter(Form1.ProjectDir + "\\" + pagenamecrud + ".php", false))
                    {
                        string view = @"<h1>" + nome + @" Create</h1>";
                        writer.WriteLine(view);
                        writer.Close();
                    }

                    pagenamecrud = namefolder + "\\Update" + Form1.Project.views_suffix;
                    using (StreamWriter writer = new StreamWriter(Form1.ProjectDir + "\\" + pagenamecrud + ".php", false))
                    {
                        string view = @"<h1>" + nome + @" Update</h1>";
                        writer.WriteLine(view);
                        writer.Close();
                    }

                    pagenamecrud = namefolder + "\\Delete" + Form1.Project.views_suffix;
                    using (StreamWriter writer = new StreamWriter(Form1.ProjectDir + "\\" + pagenamecrud + ".php", false))
                    {
                        string view = @"<h1>" + nome + @" Delete</h1>";
                        writer.WriteLine(view);
                        writer.Close();
                    }
                }
            }

            if (pcontroller)
            {
                using (StreamWriter writer = new StreamWriter(Form1.ProjectDir + "\\" + Form1.Project.controllers + nome + Form1.Project.controllers_suffix + ".php", false))
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
            }
        }
    }
}

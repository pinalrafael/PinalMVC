﻿using Newtonsoft.Json;
using PinalMVC.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinalMVC
{
    public partial class frmNovo : Form
    {
        public bool isCriado { get; set; }

        public frmNovo()
        {
            InitializeComponent();
        }

        private void frmNovo_Load(object sender, EventArgs e)
        {
            try
            {
                this.isCriado = false;

                Form1.Project = new Project();

                txtCaminho.Text = Form1.SourcesDir;
                txtNome.Text = Form1.Project.nameproject;
                txtSufixoModel.Text = Form1.Project.models_suffix;
                txtSufixoView.Text = Form1.Project.views_suffix;
                txtSufixoController.Text = Form1.Project.controllers_suffix;
                txtSufixoPageError.Text = Form1.Project.page_errors_suffix;

                this.Activate();
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
                lblMsg.Text = "";

                if (txtCaminho.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("O caminho do projeto deve ser informado.");
                    txtCaminho.Focus();
                    return;
                }

                if (txtNome.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Um nome para o projeto deve ser informado.");
                    txtNome.Focus();
                    return;
                }

                if(!txtCaminho.Text.Substring(txtCaminho.Text.Length - 1).Equals(@"\"))
                {
                    txtCaminho.Text = txtCaminho.Text + @"\";
                }

                if (!Directory.Exists(txtCaminho.Text.Trim()))
                {
                    Directory.CreateDirectory(txtCaminho.Text.Trim());
                }

                // Carregando configurações
                lblMsg.Text = "Criando configurações";
                Form1.Project.nameproject = Form1.RemoveAcentos(txtNome.Text.Trim());
                Form1.Project.models_suffix = txtSufixoModel.Text.Trim();
                Form1.Project.views_suffix = txtSufixoView.Text.Trim();
                Form1.Project.controllers_suffix = txtSufixoController.Text.Trim();
                Form1.Project.page_errors_suffix = txtSufixoPageError.Text.Trim();
                Form1.Project.api = chbApi.Checked;

                // Criando pastas
                string dirproject = txtCaminho.Text.Trim() + Form1.RemoveAcentos(txtNome.Text.Trim());
                lblMsg.Text = "Criando: " + dirproject;
                if (!Directory.Exists(dirproject))
                {
                    Directory.CreateDirectory(dirproject);
                }

                string dirincludes = dirproject + "/" + Form1.Project.includes;
                lblMsg.Text = "Criando: " + dirincludes;
                if (!Directory.Exists(dirincludes))
                {
                    Directory.CreateDirectory(dirincludes);
                }

                lblMsg.Text = "Baixando biblioteca";
                this.Enabled = false;
                backgroundWorker1.RunWorkerAsync(new object[] { dirproject, dirincludes });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEscolher_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowNewFolderButton = true;
                // Show the FolderBrowserDialog.  
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtCaminho.Text = folderBrowserDialog1.SelectedPath;
                }
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

                string dirmodels = dirproject + "/" + Form1.Project.models;
                lblMsg.Text = "Criando: " + dirmodels;
                if (!Directory.Exists(dirmodels))
                {
                    Directory.CreateDirectory(dirmodels);
                }

                string dirviews = dirproject + "/" + Form1.Project.views;
                lblMsg.Text = "Criando: " + dirviews;
                if (!Directory.Exists(dirviews))
                {
                    Directory.CreateDirectory(dirviews);
                }

                string dircontrollers = dirproject + "/" + Form1.Project.controllers;
                lblMsg.Text = "Criando: " + dircontrollers;
                if (!Directory.Exists(dircontrollers))
                {
                    Directory.CreateDirectory(dircontrollers);
                }

                string dirpageerrors = dirproject + "/Views/" + Form1.Project.page_errors;
                lblMsg.Text = "Criando: " + dirpageerrors;
                if (!Directory.Exists(dirpageerrors))
                {
                    Directory.CreateDirectory(dirpageerrors);
                }

                string dirpagelayout = dirproject + "/" + Form1.Project.pages_layouts;
                lblMsg.Text = "Criando: " + dirpagelayout;
                if (!Directory.Exists(dirpagelayout))
                {
                    Directory.CreateDirectory(dirpagelayout);
                }

                // Criando arquivo .htaccess
                lblMsg.Text = "Criando: .htaccess";
                using (StreamWriter writer = new StreamWriter(dirproject + "/.htaccess", false))
                {
                    string htaccess = @"<IfModule mod_rewrite.c>
RewriteEngine On
RewriteCond %{REQUEST_FILENAME} !-f
RewriteCond %{REQUEST_FILENAME} !-d
RewriteRule ^(.*)$ index.php/?request=$1 [QSA,L,NC]
RewriteRule . - [E=HTTP_AUTHORIZATION:%{HTTP:Authorization}]
</IfModule>";
                    writer.WriteLine(htaccess);
                    writer.Close();
                }

                // Criando arquivo index.php
                lblMsg.Text = "Criando: index.php";
                using (StreamWriter writer = new StreamWriter(dirproject + "/index.php", false))
                {
                    string index = @"<?php
include('" + Form1.Project.includes + @"main.php');
include('" + Form1.Project.includes + @"customhtml.php');
include('" + Form1.Project.includes + @"customroutes.php');

// CREATE CONFIGURATIONS

include('" + Form1.Project.includes + @"setup.php');

?>";
                    writer.WriteLine(index);
                    writer.Close();
                }

                // Criando arquivo _Layout.php
                lblMsg.Text = "Criando: _Layout.php";
                using (StreamWriter writer = new StreamWriter(dirpagelayout + "/_Layout.php", false))
                {
                    string _Layout = @"
<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
		<meta name=""viewport"" content=""width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no"">
		<title>" + Form1.Project.nameproject + @" - <?php echo $pmvc_title; ?></title>

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

                // Criando arquivo de projeto
                lblMsg.Text = "Criando arquivo de projeto";
                using (StreamWriter writer = new StreamWriter(dirproject + "/" + Form1.RemoveAcentos(txtNome.Text) + Form1.Ext, false))
                {
                    string jsonproject = JsonConvert.SerializeObject(Form1.Project);
                    writer.WriteLine(jsonproject);
                    writer.Close();
                }

                // Criando arquivo config.json
                lblMsg.Text = "Criando arquivo config.json";
                Form1.AtualizaConfig(dirproject);

                Form1.ProjectDir = dirproject;

                // Criando home
                lblMsg.Text = "Criando home";
                Form1.CriarArquivo("Home", true, true, true, true, true, false, false, "", "Views/Layout/_Layout.php", Form1.Project.api);

                // Criando arquivo _LayoutError.php
                lblMsg.Text = "Criando: _LayoutError.php";
                using (StreamWriter writer = new StreamWriter(dirpagelayout + "/_LayoutError.php", false))
                {
                    string _Layout = @"
<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
		<meta name=""viewport"" content=""width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no"">
		<title>" + Form1.Project.nameproject + @" - <?php echo $pmvc_title; ?></title>

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

                // Criando página de erro 404
                lblMsg.Text = "Criando página de erro 404";
                Form1.CriarArquivo(Form1.Project.page_errors.Replace("/", ""), true, true, true, false, false, true, false, "Error404", "Views/Layout/_LayoutError.php", Form1.Project.api);

                lblMsg.Text = "Concluído com sucesso";
                this.isCriado = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.Enabled = true;
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar == '\b')
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

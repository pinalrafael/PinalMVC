namespace PinalMVC
{
    partial class frmProjeto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjeto));
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnNovoArquivo = new System.Windows.Forms.Button();
            this.treeProjeto = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(3, 3);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(114, 23);
            this.btnAtualizar.TabIndex = 0;
            this.btnAtualizar.Text = "Atualizar Biblioteca";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(3, 61);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(10, 13);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = " ";
            // 
            // btnNovoArquivo
            // 
            this.btnNovoArquivo.Location = new System.Drawing.Point(123, 3);
            this.btnNovoArquivo.Name = "btnNovoArquivo";
            this.btnNovoArquivo.Size = new System.Drawing.Size(114, 23);
            this.btnNovoArquivo.TabIndex = 8;
            this.btnNovoArquivo.Text = "Novo Arquivo";
            this.btnNovoArquivo.UseVisualStyleBackColor = true;
            this.btnNovoArquivo.Click += new System.EventHandler(this.btnNovoArquivo_Click);
            // 
            // treeProjeto
            // 
            this.treeProjeto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeProjeto.ImageIndex = 0;
            this.treeProjeto.ImageList = this.imageList1;
            this.treeProjeto.Location = new System.Drawing.Point(0, 0);
            this.treeProjeto.Name = "treeProjeto";
            this.treeProjeto.SelectedImageIndex = 0;
            this.treeProjeto.Size = new System.Drawing.Size(246, 277);
            this.treeProjeto.TabIndex = 9;
            this.treeProjeto.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeProjeto_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-url-20.png");
            this.imageList1.Images.SetKeyName(1, "icons8-live-folder-20.png");
            this.imageList1.Images.SetKeyName(2, "icons8-pasta-20.png");
            this.imageList1.Images.SetKeyName(3, "icons8-arquivo-20.png");
            this.imageList1.Images.SetKeyName(4, "icons8-json-20.png");
            this.imageList1.Images.SetKeyName(5, "icons8-fotografia-20.png");
            this.imageList1.Images.SetKeyName(6, "icons8-logo-php-20.png");
            this.imageList1.Images.SetKeyName(7, "icons8-arquivo-xml-20.png");
            this.imageList1.Images.SetKeyName(8, "icons8-txt-20.png");
            this.imageList1.Images.SetKeyName(9, "icons8-ficheiro-css-20.png");
            this.imageList1.Images.SetKeyName(10, "icons8-tipo-de-ficheiro-html-20.png");
            this.imageList1.Images.SetKeyName(11, "icons8-javascript-20.png");
            this.imageList1.Images.SetKeyName(12, "icons8-suporte-em-informatica-20.png");
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 361);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 361);
            this.panel2.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.treeProjeto);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 84);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(246, 277);
            this.panel4.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExecutar);
            this.panel3.Controls.Add(this.btnAtualizar);
            this.panel3.Controls.Add(this.btnNovoArquivo);
            this.panel3.Controls.Add(this.lblMsg);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 84);
            this.panel3.TabIndex = 12;
            // 
            // btnExecutar
            // 
            this.btnExecutar.Location = new System.Drawing.Point(3, 32);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(114, 23);
            this.btnExecutar.TabIndex = 9;
            this.btnExecutar.Text = "Executar Projeto";
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(246, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(693, 361);
            this.panel5.TabIndex = 12;
            // 
            // frmProjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 361);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProjeto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProjeto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmProjeto_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProjeto_FormClosing);
            this.Load += new System.EventHandler(this.frmProjeto_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAtualizar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnNovoArquivo;
        private System.Windows.Forms.TreeView treeProjeto;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnExecutar;
    }
}
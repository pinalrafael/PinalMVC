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
            this.SuspendLayout();
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(12, 12);
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
            this.lblMsg.Location = new System.Drawing.Point(12, 38);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(10, 13);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = " ";
            // 
            // btnNovoArquivo
            // 
            this.btnNovoArquivo.Location = new System.Drawing.Point(132, 12);
            this.btnNovoArquivo.Name = "btnNovoArquivo";
            this.btnNovoArquivo.Size = new System.Drawing.Size(114, 23);
            this.btnNovoArquivo.TabIndex = 8;
            this.btnNovoArquivo.Text = "Novo Arquivo";
            this.btnNovoArquivo.UseVisualStyleBackColor = true;
            this.btnNovoArquivo.Click += new System.EventHandler(this.btnNovoArquivo_Click);
            // 
            // treeProjeto
            // 
            this.treeProjeto.ImageIndex = 0;
            this.treeProjeto.ImageList = this.imageList1;
            this.treeProjeto.Location = new System.Drawing.Point(12, 41);
            this.treeProjeto.Name = "treeProjeto";
            this.treeProjeto.SelectedImageIndex = 0;
            this.treeProjeto.Size = new System.Drawing.Size(234, 308);
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
            // frmProjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 361);
            this.Controls.Add(this.treeProjeto);
            this.Controls.Add(this.btnNovoArquivo);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnAtualizar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProjeto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProjeto";
            this.Activated += new System.EventHandler(this.frmProjeto_Activated);
            this.Load += new System.EventHandler(this.frmProjeto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtualizar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnNovoArquivo;
        private System.Windows.Forms.TreeView treeProjeto;
        private System.Windows.Forms.ImageList imageList1;
    }
}
namespace PinalMVC
{
    partial class frmNovo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNovo));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnEscolher = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblMsg = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtSufixoModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSufixoView = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSufixoController = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSufixoPageError = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Caminho";
            // 
            // txtCaminho
            // 
            this.txtCaminho.Location = new System.Drawing.Point(66, 6);
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.Size = new System.Drawing.Size(303, 20);
            this.txtCaminho.TabIndex = 1;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(66, 32);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(384, 20);
            this.txtNome.TabIndex = 3;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(375, 117);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Criar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnEscolher
            // 
            this.btnEscolher.Location = new System.Drawing.Point(375, 4);
            this.btnEscolher.Name = "btnEscolher";
            this.btnEscolher.Size = new System.Drawing.Size(75, 23);
            this.btnEscolher.TabIndex = 5;
            this.btnEscolher.Text = "Escolher";
            this.btnEscolher.UseVisualStyleBackColor = true;
            this.btnEscolher.Click += new System.EventHandler(this.btnEscolher_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(12, 65);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(10, 13);
            this.lblMsg.TabIndex = 6;
            this.lblMsg.Text = " ";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // txtSufixoModel
            // 
            this.txtSufixoModel.Location = new System.Drawing.Point(85, 58);
            this.txtSufixoModel.Name = "txtSufixoModel";
            this.txtSufixoModel.Size = new System.Drawing.Size(63, 20);
            this.txtSufixoModel.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sufixo Model";
            // 
            // txtSufixoView
            // 
            this.txtSufixoView.Location = new System.Drawing.Point(85, 84);
            this.txtSufixoView.Name = "txtSufixoView";
            this.txtSufixoView.Size = new System.Drawing.Size(63, 20);
            this.txtSufixoView.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sufixo View";
            // 
            // txtSufixoController
            // 
            this.txtSufixoController.Location = new System.Drawing.Point(243, 58);
            this.txtSufixoController.Name = "txtSufixoController";
            this.txtSufixoController.Size = new System.Drawing.Size(63, 20);
            this.txtSufixoController.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sufixo Controller";
            // 
            // txtSufixoPageError
            // 
            this.txtSufixoPageError.Location = new System.Drawing.Point(243, 84);
            this.txtSufixoPageError.Name = "txtSufixoPageError";
            this.txtSufixoPageError.Size = new System.Drawing.Size(63, 20);
            this.txtSufixoPageError.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(154, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Sufixo Page Error";
            // 
            // frmNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 154);
            this.Controls.Add(this.txtSufixoPageError);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSufixoController);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSufixoView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSufixoModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnEscolher);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCaminho);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNovo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Projeto";
            this.Load += new System.EventHandler(this.frmNovo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnEscolher;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblMsg;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtSufixoModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSufixoView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSufixoController;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSufixoPageError;
        private System.Windows.Forms.Label label6;
    }
}
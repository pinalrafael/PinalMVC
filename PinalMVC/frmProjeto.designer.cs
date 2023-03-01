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
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnNovoArquivo = new System.Windows.Forms.Button();
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
            // frmProjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 63);
            this.Controls.Add(this.btnNovoArquivo);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnAtualizar);
            this.Name = "frmProjeto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProjeto";
            this.Load += new System.EventHandler(this.frmProjeto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtualizar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnNovoArquivo;
    }
}
namespace PinalMVC
{
    partial class frmNovoArquivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNovoArquivo));
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbModel = new System.Windows.Forms.CheckBox();
            this.chbView = new System.Windows.Forms.CheckBox();
            this.chbController = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chbCRUD = new System.Windows.Forms.CheckBox();
            this.chbPOSTGET = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbErrorPage = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbLayout = new System.Windows.Forms.ComboBox();
            this.chbPageLayout = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(375, 133);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 7;
            this.btnIniciar.Text = "Criar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(66, 6);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(384, 20);
            this.txtNome.TabIndex = 6;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nome";
            // 
            // chbModel
            // 
            this.chbModel.AutoSize = true;
            this.chbModel.Checked = true;
            this.chbModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbModel.Location = new System.Drawing.Point(66, 32);
            this.chbModel.Name = "chbModel";
            this.chbModel.Size = new System.Drawing.Size(55, 17);
            this.chbModel.TabIndex = 8;
            this.chbModel.Text = "Model";
            this.chbModel.UseVisualStyleBackColor = true;
            // 
            // chbView
            // 
            this.chbView.AutoSize = true;
            this.chbView.Checked = true;
            this.chbView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbView.Location = new System.Drawing.Point(129, 32);
            this.chbView.Name = "chbView";
            this.chbView.Size = new System.Drawing.Size(49, 17);
            this.chbView.TabIndex = 9;
            this.chbView.Text = "View";
            this.chbView.UseVisualStyleBackColor = true;
            // 
            // chbController
            // 
            this.chbController.AutoSize = true;
            this.chbController.Checked = true;
            this.chbController.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbController.Location = new System.Drawing.Point(184, 32);
            this.chbController.Name = "chbController";
            this.chbController.Size = new System.Drawing.Size(70, 17);
            this.chbController.TabIndex = 10;
            this.chbController.Text = "Controller";
            this.chbController.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Criar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Controller";
            // 
            // chbCRUD
            // 
            this.chbCRUD.AutoSize = true;
            this.chbCRUD.Checked = true;
            this.chbCRUD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCRUD.Location = new System.Drawing.Point(66, 55);
            this.chbCRUD.Name = "chbCRUD";
            this.chbCRUD.Size = new System.Drawing.Size(57, 17);
            this.chbCRUD.TabIndex = 12;
            this.chbCRUD.Text = "CRUD";
            this.chbCRUD.UseVisualStyleBackColor = true;
            // 
            // chbPOSTGET
            // 
            this.chbPOSTGET.AutoSize = true;
            this.chbPOSTGET.Checked = true;
            this.chbPOSTGET.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPOSTGET.Location = new System.Drawing.Point(129, 56);
            this.chbPOSTGET.Name = "chbPOSTGET";
            this.chbPOSTGET.Size = new System.Drawing.Size(82, 17);
            this.chbPOSTGET.TabIndex = 14;
            this.chbPOSTGET.Text = "POST/GET";
            this.chbPOSTGET.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Página";
            // 
            // chbErrorPage
            // 
            this.chbErrorPage.AutoSize = true;
            this.chbErrorPage.Location = new System.Drawing.Point(66, 78);
            this.chbErrorPage.Name = "chbErrorPage";
            this.chbErrorPage.Size = new System.Drawing.Size(57, 17);
            this.chbErrorPage.TabIndex = 15;
            this.chbErrorPage.Text = "ERRO";
            this.chbErrorPage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Layout";
            // 
            // chbLayout
            // 
            this.chbLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chbLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbLayout.FormattingEnabled = true;
            this.chbLayout.Location = new System.Drawing.Point(66, 98);
            this.chbLayout.Name = "chbLayout";
            this.chbLayout.Size = new System.Drawing.Size(121, 21);
            this.chbLayout.TabIndex = 18;
            // 
            // chbPageLayout
            // 
            this.chbPageLayout.AutoSize = true;
            this.chbPageLayout.Location = new System.Drawing.Point(129, 78);
            this.chbPageLayout.Name = "chbPageLayout";
            this.chbPageLayout.Size = new System.Drawing.Size(58, 17);
            this.chbPageLayout.TabIndex = 19;
            this.chbPageLayout.Text = "Layout";
            this.chbPageLayout.UseVisualStyleBackColor = true;
            // 
            // frmNovoArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 166);
            this.Controls.Add(this.chbPageLayout);
            this.Controls.Add(this.chbLayout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chbErrorPage);
            this.Controls.Add(this.chbPOSTGET);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chbCRUD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbController);
            this.Controls.Add(this.chbView);
            this.Controls.Add(this.chbModel);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNovoArquivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Arquivo";
            this.Load += new System.EventHandler(this.frmNovoArquivo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbModel;
        private System.Windows.Forms.CheckBox chbView;
        private System.Windows.Forms.CheckBox chbController;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbCRUD;
        private System.Windows.Forms.CheckBox chbPOSTGET;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbErrorPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox chbLayout;
        private System.Windows.Forms.CheckBox chbPageLayout;
    }
}
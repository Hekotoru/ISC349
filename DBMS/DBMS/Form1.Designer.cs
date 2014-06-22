namespace DBMS
{
    partial class Form1
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lbEntrada = new System.Windows.Forms.Label();
            this.ButtonAnalisis = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(13, 54);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(302, 107);
            this.txtInput.TabIndex = 0;
            // 
            // lbEntrada
            // 
            this.lbEntrada.AutoSize = true;
            this.lbEntrada.Location = new System.Drawing.Point(13, 35);
            this.lbEntrada.Name = "lbEntrada";
            this.lbEntrada.Size = new System.Drawing.Size(85, 13);
            this.lbEntrada.TabIndex = 1;
            this.lbEntrada.Text = "Entrada de texto";
            // 
            // ButtonAnalisis
            // 
            this.ButtonAnalisis.Location = new System.Drawing.Point(13, 167);
            this.ButtonAnalisis.Name = "ButtonAnalisis";
            this.ButtonAnalisis.Size = new System.Drawing.Size(302, 40);
            this.ButtonAnalisis.TabIndex = 3;
            this.ButtonAnalisis.Text = "Analisis sintactico";
            this.ButtonAnalisis.UseVisualStyleBackColor = true;
            this.ButtonAnalisis.Click += new System.EventHandler(this.ButtonAnalisis_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Token,
            this.Lexema});
            this.dataGridView1.Location = new System.Drawing.Point(322, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 4;
            // 
            // Token
            // 
            this.Token.HeaderText = "Token";
            this.Token.Name = "Token";
            this.Token.ReadOnly = true;
            // 
            // Lexema
            // 
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.Name = "Lexema";
            this.Lexema.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 262);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ButtonAnalisis);
            this.Controls.Add(this.lbEntrada);
            this.Controls.Add(this.txtInput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lbEntrada;
        private System.Windows.Forms.Button ButtonAnalisis;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
    }
}


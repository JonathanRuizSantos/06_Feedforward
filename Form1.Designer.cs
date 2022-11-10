namespace feedFordward
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lBSalida = new System.Windows.Forms.ListBox();
            this.dGResultados = new System.Windows.Forms.DataGridView();
            this.btFeedfordward = new System.Windows.Forms.Button();
            this.rBXOR = new System.Windows.Forms.RadioButton();
            this.rBEjercicio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // lBSalida
            // 
            this.lBSalida.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lBSalida.FormattingEnabled = true;
            this.lBSalida.ItemHeight = 20;
            this.lBSalida.Location = new System.Drawing.Point(517, 43);
            this.lBSalida.Name = "lBSalida";
            this.lBSalida.Size = new System.Drawing.Size(289, 464);
            this.lBSalida.TabIndex = 0;
            // 
            // dGResultados
            // 
            this.dGResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGResultados.Location = new System.Drawing.Point(29, 221);
            this.dGResultados.Name = "dGResultados";
            this.dGResultados.RowHeadersWidth = 51;
            this.dGResultados.RowTemplate.Height = 29;
            this.dGResultados.Size = new System.Drawing.Size(470, 285);
            this.dGResultados.TabIndex = 1;
            // 
            // btFeedfordward
            // 
            this.btFeedfordward.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btFeedfordward.Location = new System.Drawing.Point(293, 75);
            this.btFeedfordward.Name = "btFeedfordward";
            this.btFeedfordward.Size = new System.Drawing.Size(131, 56);
            this.btFeedfordward.TabIndex = 2;
            this.btFeedfordward.Text = "Feedforward";
            this.btFeedfordward.UseVisualStyleBackColor = true;
            this.btFeedfordward.Click += new System.EventHandler(this.btFeedfordward_Click);
            // 
            // rBXOR
            // 
            this.rBXOR.AutoSize = true;
            this.rBXOR.Checked = true;
            this.rBXOR.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rBXOR.Location = new System.Drawing.Point(40, 75);
            this.rBXOR.Name = "rBXOR";
            this.rBXOR.Size = new System.Drawing.Size(66, 27);
            this.rBXOR.TabIndex = 3;
            this.rBXOR.TabStop = true;
            this.rBXOR.Text = "XOR";
            this.rBXOR.UseVisualStyleBackColor = true;
            // 
            // rBEjercicio
            // 
            this.rBEjercicio.AutoSize = true;
            this.rBEjercicio.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rBEjercicio.Location = new System.Drawing.Point(40, 123);
            this.rBEjercicio.Name = "rBEjercicio";
            this.rBEjercicio.Size = new System.Drawing.Size(93, 27);
            this.rBEjercicio.TabIndex = 4;
            this.rBEjercicio.Text = "Ejercicio";
            this.rBEjercicio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Resultados";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 532);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rBEjercicio);
            this.Controls.Add(this.rBXOR);
            this.Controls.Add(this.btFeedfordward);
            this.Controls.Add(this.dGResultados);
            this.Controls.Add(this.lBSalida);
            this.Name = "Form1";
            this.Text = "Feedforward";
            ((System.ComponentModel.ISupportInitialize)(this.dGResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lBSalida;
        private DataGridView dGResultados;
        private Button btFeedfordward;
        private RadioButton rBXOR;
        private RadioButton rBEjercicio;
        private Label label1;
    }
}
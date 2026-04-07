namespace PryBarreraSP1ER
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEspecialidades = new System.Windows.Forms.TabPage();
            this.btnGuardarEspecialidad = new System.Windows.Forms.Button();
            this.txtNombreEspecialidad = new System.Windows.Forms.TextBox();
            this.txtNumeroEspecialidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMedicos = new System.Windows.Forms.TabPage();
            this.btnGuardarMedico = new System.Windows.Forms.Button();
            this.cmbEspecialidadMedico = new System.Windows.Forms.ComboBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNombreMedico = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.dgvMedicos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbEspecialidadConsulta = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabEspecialidades.SuspendLayout();
            this.tabMedicos.SuspendLayout();
            this.tabConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEspecialidades);
            this.tabControl1.Controls.Add(this.tabMedicos);
            this.tabControl1.Controls.Add(this.tabConsulta);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(502, 280);
            this.tabControl1.TabIndex = 0;
            // 
            // tabEspecialidades
            // 
            this.tabEspecialidades.Controls.Add(this.btnGuardarEspecialidad);
            this.tabEspecialidades.Controls.Add(this.txtNombreEspecialidad);
            this.tabEspecialidades.Controls.Add(this.txtNumeroEspecialidad);
            this.tabEspecialidades.Controls.Add(this.label2);
            this.tabEspecialidades.Controls.Add(this.label1);
            this.tabEspecialidades.Location = new System.Drawing.Point(4, 22);
            this.tabEspecialidades.Name = "tabEspecialidades";
            this.tabEspecialidades.Padding = new System.Windows.Forms.Padding(3);
            this.tabEspecialidades.Size = new System.Drawing.Size(494, 254);
            this.tabEspecialidades.TabIndex = 0;
            this.tabEspecialidades.Text = "Especialidades";
            this.tabEspecialidades.UseVisualStyleBackColor = true;
            // 
            // btnGuardarEspecialidad
            // 
            this.btnGuardarEspecialidad.Location = new System.Drawing.Point(269, 130);
            this.btnGuardarEspecialidad.Name = "btnGuardarEspecialidad";
            this.btnGuardarEspecialidad.Size = new System.Drawing.Size(100, 30);
            this.btnGuardarEspecialidad.TabIndex = 4;
            this.btnGuardarEspecialidad.Text = "Guardar";
            this.btnGuardarEspecialidad.UseVisualStyleBackColor = true;
            this.btnGuardarEspecialidad.Click += new System.EventHandler(this.BtnGuardarEspecialidad_Click);
            // 
            // txtNombreEspecialidad
            // 
            this.txtNombreEspecialidad.Location = new System.Drawing.Point(200, 80);
            this.txtNombreEspecialidad.Name = "txtNombreEspecialidad";
            this.txtNombreEspecialidad.Size = new System.Drawing.Size(200, 20);
            this.txtNombreEspecialidad.TabIndex = 3;
            // 
            // txtNumeroEspecialidad
            // 
            this.txtNumeroEspecialidad.Location = new System.Drawing.Point(200, 40);
            this.txtNumeroEspecialidad.Name = "txtNumeroEspecialidad";
            this.txtNumeroEspecialidad.Size = new System.Drawing.Size(200, 20);
            this.txtNumeroEspecialidad.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre de Especialidad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de Especialidad:";
            // 
            // tabMedicos
            // 
            this.tabMedicos.Controls.Add(this.btnGuardarMedico);
            this.tabMedicos.Controls.Add(this.cmbEspecialidadMedico);
            this.tabMedicos.Controls.Add(this.txtMatricula);
            this.tabMedicos.Controls.Add(this.txtNombreMedico);
            this.tabMedicos.Controls.Add(this.label6);
            this.tabMedicos.Controls.Add(this.label5);
            this.tabMedicos.Controls.Add(this.label4);
            this.tabMedicos.Controls.Add(this.label3);
            this.tabMedicos.Location = new System.Drawing.Point(4, 22);
            this.tabMedicos.Name = "tabMedicos";
            this.tabMedicos.Padding = new System.Windows.Forms.Padding(3);
            this.tabMedicos.Size = new System.Drawing.Size(632, 400);
            this.tabMedicos.TabIndex = 1;
            this.tabMedicos.Text = "Médicos";
            this.tabMedicos.UseVisualStyleBackColor = true;
            // 
            // btnGuardarMedico
            // 
            this.btnGuardarMedico.Location = new System.Drawing.Point(269, 170);
            this.btnGuardarMedico.Name = "btnGuardarMedico";
            this.btnGuardarMedico.Size = new System.Drawing.Size(100, 30);
            this.btnGuardarMedico.TabIndex = 7;
            this.btnGuardarMedico.Text = "Guardar";
            this.btnGuardarMedico.UseVisualStyleBackColor = true;
            this.btnGuardarMedico.Click += new System.EventHandler(this.BtnGuardarMedico_Click);
            // 
            // cmbEspecialidadMedico
            // 
            this.cmbEspecialidadMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidadMedico.FormattingEnabled = true;
            this.cmbEspecialidadMedico.Location = new System.Drawing.Point(200, 120);
            this.cmbEspecialidadMedico.Name = "cmbEspecialidadMedico";
            this.cmbEspecialidadMedico.Size = new System.Drawing.Size(200, 21);
            this.cmbEspecialidadMedico.TabIndex = 6;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(200, 40);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(200, 20);
            this.txtMatricula.TabIndex = 4;
            // 
            // txtNombreMedico
            // 
            this.txtNombreMedico.Location = new System.Drawing.Point(200, 80);
            this.txtNombreMedico.Name = "txtNombreMedico";
            this.txtNombreMedico.Size = new System.Drawing.Size(200, 20);
            this.txtNombreMedico.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Especialidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre del Médico:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Matrícula (Profesional):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(50, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nuevo Médico";
            // 
            // tabConsulta
            // 
            this.tabConsulta.Controls.Add(this.dgvMedicos);
            this.tabConsulta.Controls.Add(this.cmbEspecialidadConsulta);
            this.tabConsulta.Controls.Add(this.label7);
            this.tabConsulta.Location = new System.Drawing.Point(4, 22);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsulta.Size = new System.Drawing.Size(494, 254);
            this.tabConsulta.TabIndex = 2;
            this.tabConsulta.Text = "Consulta";
            this.tabConsulta.UseVisualStyleBackColor = true;
            // 
            // dgvMedicos
            // 
            this.dgvMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvMedicos.Location = new System.Drawing.Point(50, 80);
            this.dgvMedicos.Name = "dgvMedicos";
            this.dgvMedicos.Size = new System.Drawing.Size(444, 178);
            this.dgvMedicos.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Matrícula";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.Width = 350;
            // 
            // cmbEspecialidadConsulta
            // 
            this.cmbEspecialidadConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidadConsulta.FormattingEnabled = true;
            this.cmbEspecialidadConsulta.Location = new System.Drawing.Point(200, 40);
            this.cmbEspecialidadConsulta.Name = "cmbEspecialidadConsulta";
            this.cmbEspecialidadConsulta.Size = new System.Drawing.Size(200, 21);
            this.cmbEspecialidadConsulta.TabIndex = 1;
            this.cmbEspecialidadConsulta.SelectedIndexChanged += new System.EventHandler(this.CmbEspecialidadConsulta_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Especialidad:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 306);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Gestión de Médicos y Especialidades";
            this.tabControl1.ResumeLayout(false);
            this.tabEspecialidades.ResumeLayout(false);
            this.tabEspecialidades.PerformLayout();
            this.tabMedicos.ResumeLayout(false);
            this.tabMedicos.PerformLayout();
            this.tabConsulta.ResumeLayout(false);
            this.tabConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEspecialidades;
        private System.Windows.Forms.TabPage tabMedicos;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.Button btnGuardarEspecialidad;
        private System.Windows.Forms.TextBox txtNombreEspecialidad;
        private System.Windows.Forms.TextBox txtNumeroEspecialidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardarMedico;
        private System.Windows.Forms.ComboBox cmbEspecialidadMedico;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNombreMedico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvMedicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ComboBox cmbEspecialidadConsulta;
        private System.Windows.Forms.Label label7;
    }
}


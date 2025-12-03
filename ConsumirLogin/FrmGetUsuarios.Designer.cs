namespace ConsumirLogin
{
    partial class FrmGetUsuarios
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
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBloqueado = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panelEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarios.Location = new System.Drawing.Point(62, -3);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(97, 25);
            this.lblUsuarios.TabIndex = 12;
            this.lblUsuarios.Text = "Usuarios";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(441, 87);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(537, 271);
            this.dgvUsuarios.TabIndex = 13;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "NOMBRE:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(127, 56);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(164, 20);
            this.txtNombre.TabIndex = 15;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(94, 237);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(65, 17);
            this.chkActivo.TabIndex = 16;
            this.chkActivo.Text = "ACTIVO";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(127, 113);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(164, 20);
            this.txtApellido.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "APELLIDO:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(127, 139);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(164, 20);
            this.txtEmail.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "EMAIL:";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(127, 165);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(164, 20);
            this.txtCedula.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "CÉDULA:";
            // 
            // chkBloqueado
            // 
            this.chkBloqueado.AutoSize = true;
            this.chkBloqueado.Location = new System.Drawing.Point(165, 237);
            this.chkBloqueado.Name = "chkBloqueado";
            this.chkBloqueado.Size = new System.Drawing.Size(93, 17);
            this.chkBloqueado.TabIndex = 23;
            this.chkBloqueado.Text = "BLOQUEADO";
            this.chkBloqueado.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(138, 260);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "EDITAR";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.txtTelefono);
            this.panelEdit.Controls.Add(this.label5);
            this.panelEdit.Controls.Add(this.txtId);
            this.panelEdit.Controls.Add(this.lblId);
            this.panelEdit.Controls.Add(this.lblUsuarios);
            this.panelEdit.Controls.Add(this.btnEdit);
            this.panelEdit.Controls.Add(this.label1);
            this.panelEdit.Controls.Add(this.chkBloqueado);
            this.panelEdit.Controls.Add(this.txtNombre);
            this.panelEdit.Controls.Add(this.txtCedula);
            this.panelEdit.Controls.Add(this.chkActivo);
            this.panelEdit.Controls.Add(this.label4);
            this.panelEdit.Controls.Add(this.label2);
            this.panelEdit.Controls.Add(this.txtEmail);
            this.panelEdit.Controls.Add(this.txtApellido);
            this.panelEdit.Controls.Add(this.label3);
            this.panelEdit.Location = new System.Drawing.Point(12, 34);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(406, 286);
            this.panelEdit.TabIndex = 25;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(64, 90);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 25;
            this.lblId.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(127, 87);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(164, 20);
            this.txtId.TabIndex = 26;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(127, 191);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(164, 20);
            this.txtTelefono.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "TELEFONO:";
            // 
            // FrmGetUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 524);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.dgvUsuarios);
            this.Name = "FrmGetUsuarios";
            this.Text = "FrmGetUsuarios";
            this.Load += new System.EventHandler(this.FrmGetUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBloqueado;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label5;
    }
}
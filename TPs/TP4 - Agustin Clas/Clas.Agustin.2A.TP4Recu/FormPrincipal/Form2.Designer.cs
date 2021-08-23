using System;

namespace FormPrincipal
{
    partial class Form2
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
            this.prenda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.talle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.equipacion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.manga = new System.Windows.Forms.ComboBox();
            this.bolsillo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // prenda
            // 
            this.prenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prenda.FormattingEnabled = true;
            this.prenda.Items.AddRange(new object[] {
            "Pantalon",
            "Camiseta"});
            this.prenda.Location = new System.Drawing.Point(12, 25);
            this.prenda.Name = "prenda";
            this.prenda.Size = new System.Drawing.Size(210, 21);
            this.prenda.TabIndex = 0;
            this.prenda.SelectedIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // talle
            // 
            this.talle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.talle.FormattingEnabled = true;
            this.talle.Items.AddRange(new object[] {
            Entidades.Prenda.ETalle.S,
            Entidades.Prenda.ETalle.M,
            Entidades.Prenda.ETalle.L,
            Entidades.Prenda.ETalle.XL});
            this.talle.Location = new System.Drawing.Point(12, 80);
            this.talle.Name = "talle";
            this.talle.Size = new System.Drawing.Size(142, 21);
            this.talle.TabIndex = 2;
            this.talle.SelectedIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Talle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Equipacion";
            // 
            // equipacion
            // 
            this.equipacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.equipacion.FormattingEnabled = true;
            this.equipacion.Items.AddRange(new object[] {
            Entidades.Prenda.EEquipacion.titular,
            Entidades.Prenda.EEquipacion.suplente});
            this.equipacion.Location = new System.Drawing.Point(11, 130);
            this.equipacion.Name = "equipacion";
            this.equipacion.Size = new System.Drawing.Size(141, 21);
            this.equipacion.TabIndex = 5;
            this.equipacion.SelectedIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Numero";
            // 
            // numero
            // 
            this.numero.Location = new System.Drawing.Point(11, 182);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(167, 20);
            this.numero.TabIndex = 7;
            this.numero.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Manga";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Bolsillo";
            // 
            // manga
            // 
            this.manga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manga.FormattingEnabled = true;
            this.manga.Items.AddRange(new object[] {
            "Manga corta",
            "Manga larga"});
            this.manga.Location = new System.Drawing.Point(11, 238);
            this.manga.Name = "manga";
            this.manga.Size = new System.Drawing.Size(99, 21);
            this.manga.TabIndex = 10;
            this.manga.SelectedIndex = 0;
            // 
            // bolsillo
            // 
            this.bolsillo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bolsillo.FormattingEnabled = true;
            this.bolsillo.Items.AddRange(new object[] {
            "Con bolsillo",
            "Sin bolsillo"});
            this.bolsillo.Location = new System.Drawing.Point(116, 238);
            this.bolsillo.Name = "bolsillo";
            this.bolsillo.Size = new System.Drawing.Size(105, 21);
            this.bolsillo.TabIndex = 11;
            this.bolsillo.SelectedIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(246, 347);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bolsillo);
            this.Controls.Add(this.manga);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.equipacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.talle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prenda);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar producto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox prenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox talle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox equipacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox numero;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox manga;
        private System.Windows.Forms.ComboBox bolsillo;
        private System.Windows.Forms.Button button1;
    }
}
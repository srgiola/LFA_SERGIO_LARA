﻿namespace LFA_Sergio_Lara
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			this.Tabla_Follow = new System.Windows.Forms.DataGridView();
			this.Simbolo_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Follow = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Tabla_Estados = new System.Windows.Forms.DataGridView();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.Tabla_FLN = new System.Windows.Forms.DataGridView();
			this.Simbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.First = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Last = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Nullable = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Tabla_Follow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Tabla_Estados)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Tabla_FLN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Tabla_Follow
			// 
			this.Tabla_Follow.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.Tabla_Follow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Tabla_Follow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Simbolo_,
            this.Follow});
			this.Tabla_Follow.Location = new System.Drawing.Point(462, 32);
			this.Tabla_Follow.Name = "Tabla_Follow";
			this.Tabla_Follow.Size = new System.Drawing.Size(244, 333);
			this.Tabla_Follow.TabIndex = 1;
			// 
			// Simbolo_
			// 
			this.Simbolo_.HeaderText = "Simbolo";
			this.Simbolo_.Name = "Simbolo_";
			// 
			// Follow
			// 
			this.Follow.HeaderText = "Follow";
			this.Follow.Name = "Follow";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tabla Firts, Last y Nullable ";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(459, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Tabla Follow";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// Tabla_Estados
			// 
			this.Tabla_Estados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.Tabla_Estados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Tabla_Estados.Location = new System.Drawing.Point(15, 404);
			this.Tabla_Estados.Name = "Tabla_Estados";
			this.Tabla_Estados.Size = new System.Drawing.Size(691, 297);
			this.Tabla_Estados.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 385);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Tabla de Transiciones";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(1019, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 20);
			this.label4.TabIndex = 7;
			this.label4.Text = "Grafo";
			// 
			// Tabla_FLN
			// 
			this.Tabla_FLN.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.Tabla_FLN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Tabla_FLN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Simbolo,
            this.First,
            this.Last,
            this.Nullable});
			this.Tabla_FLN.Location = new System.Drawing.Point(13, 32);
			this.Tabla_FLN.Name = "Tabla_FLN";
			this.Tabla_FLN.Size = new System.Drawing.Size(440, 333);
			this.Tabla_FLN.TabIndex = 8;
			// 
			// Simbolo
			// 
			this.Simbolo.HeaderText = "Simbolo";
			this.Simbolo.Name = "Simbolo";
			// 
			// First
			// 
			this.First.HeaderText = "First";
			this.First.Name = "First";
			// 
			// Last
			// 
			this.Last.HeaderText = "Last";
			this.Last.Name = "Last";
			// 
			// Nullable
			// 
			this.Nullable.HeaderText = "Nullable";
			this.Nullable.Name = "Nullable";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.pictureBox1.Location = new System.Drawing.Point(722, 96);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(636, 605);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(722, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(636, 44);
			this.button1.TabIndex = 9;
			this.button1.Text = "Generar Programa";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(1370, 749);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.Tabla_FLN);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Tabla_Estados);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Tabla_Follow);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form2";
			this.Text = "Tablas";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form2_Load);
			((System.ComponentModel.ISupportInitialize)(this.Tabla_Follow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Tabla_Estados)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Tabla_FLN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.DataGridView Tabla_Follow;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.DataGridView Tabla_Estados;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView Tabla_FLN;
		private System.Windows.Forms.DataGridViewTextBoxColumn Simbolo;
		private System.Windows.Forms.DataGridViewTextBoxColumn First;
		private System.Windows.Forms.DataGridViewTextBoxColumn Last;
		private System.Windows.Forms.DataGridViewTextBoxColumn Nullable;
		private System.Windows.Forms.DataGridViewTextBoxColumn Simbolo_;
		private System.Windows.Forms.DataGridViewTextBoxColumn Follow;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
	}
}
namespace LFA_Sergio_Lara
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.listBoxTXT = new System.Windows.Forms.ListBox();
			this.listBoxEntrada = new System.Windows.Forms.ListBox();
			this.listBoxMensaje = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// listBoxTXT
			// 
			this.listBoxTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxTXT.FormattingEnabled = true;
			this.listBoxTXT.ItemHeight = 18;
			this.listBoxTXT.Location = new System.Drawing.Point(12, 115);
			this.listBoxTXT.Name = "listBoxTXT";
			this.listBoxTXT.Size = new System.Drawing.Size(592, 490);
			this.listBoxTXT.TabIndex = 0;
			this.listBoxTXT.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxTXT_DrawItem);
			// 
			// listBoxEntrada
			// 
			this.listBoxEntrada.AllowDrop = true;
			this.listBoxEntrada.BackColor = System.Drawing.Color.PaleGreen;
			this.listBoxEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxEntrada.FormattingEnabled = true;
			this.listBoxEntrada.ItemHeight = 31;
			this.listBoxEntrada.Location = new System.Drawing.Point(12, 12);
			this.listBoxEntrada.Name = "listBoxEntrada";
			this.listBoxEntrada.Size = new System.Drawing.Size(916, 97);
			this.listBoxEntrada.TabIndex = 0;
			this.listBoxEntrada.SelectedIndexChanged += new System.EventHandler(this.listBoxEntrada_SelectedIndexChanged);
			this.listBoxEntrada.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxEntrada_DragDrop);
			this.listBoxEntrada.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxEntrada_DragEnter);
			// 
			// listBoxMensaje
			// 
			this.listBoxMensaje.BackColor = System.Drawing.Color.Gainsboro;
			this.listBoxMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBoxMensaje.FormattingEnabled = true;
			this.listBoxMensaje.HorizontalScrollbar = true;
			this.listBoxMensaje.ItemHeight = 20;
			this.listBoxMensaje.Location = new System.Drawing.Point(610, 115);
			this.listBoxMensaje.Name = "listBoxMensaje";
			this.listBoxMensaje.Size = new System.Drawing.Size(318, 484);
			this.listBoxMensaje.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(938, 616);
			this.Controls.Add(this.listBoxMensaje);
			this.Controls.Add(this.listBoxTXT);
			this.Controls.Add(this.listBoxEntrada);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Proyecto LFA";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListBox listBoxTXT;
		private System.Windows.Forms.ListBox listBoxEntrada;
		private System.Windows.Forms.ListBox listBoxMensaje;
	}
}


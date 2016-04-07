namespace FilosofosQueJantam
{
	partial class FilosofoUC
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.acaoFilosofo = new System.Windows.Forms.Button();
			this.nomeFilosofo = new System.Windows.Forms.Label();
			this.estadoFilosofo = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// acaoFilosofo
			// 
			this.acaoFilosofo.Location = new System.Drawing.Point(14, 119);
			this.acaoFilosofo.Name = "acaoFilosofo";
			this.acaoFilosofo.Size = new System.Drawing.Size(133, 23);
			this.acaoFilosofo.TabIndex = 0;
			this.acaoFilosofo.Text = "Exec";
			this.acaoFilosofo.UseVisualStyleBackColor = true;
			// 
			// nomeFilosofo
			// 
			this.nomeFilosofo.AutoSize = true;
			this.nomeFilosofo.Location = new System.Drawing.Point(14, 13);
			this.nomeFilosofo.Name = "nomeFilosofo";
			this.nomeFilosofo.Size = new System.Drawing.Size(0, 13);
			this.nomeFilosofo.TabIndex = 1;
			// 
			// estadoFilosofo
			// 
			this.estadoFilosofo.AutoSize = true;
			this.estadoFilosofo.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.estadoFilosofo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.estadoFilosofo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.estadoFilosofo.Font = new System.Drawing.Font("Arial", 12F);
			this.estadoFilosofo.Location = new System.Drawing.Point(67, 69);
			this.estadoFilosofo.Name = "estadoFilosofo";
			this.estadoFilosofo.Size = new System.Drawing.Size(22, 20);
			this.estadoFilosofo.TabIndex = 2;
			this.estadoFilosofo.Text = "...";
			this.estadoFilosofo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Estado:";
			// 
			// FilosofoUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.estadoFilosofo);
			this.Controls.Add(this.nomeFilosofo);
			this.Controls.Add(this.acaoFilosofo);
			this.Name = "FilosofoUC";
			this.Size = new System.Drawing.Size(166, 158);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button acaoFilosofo;
		private System.Windows.Forms.Label nomeFilosofo;
		private System.Windows.Forms.Label estadoFilosofo;
		private System.Windows.Forms.Label label1;
	}
}

namespace Szyfrowanie
{
	partial class RSA
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Metoda wymagana do obsługi projektanta — nie należy modyfikować
		/// jej zawartości w edytorze kodu.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RSA));
			this.szyfruj1 = new Szyfrowanie.Szyfruj();
			this.SuspendLayout();
			// 
			// szyfruj1
			// 
			this.szyfruj1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.szyfruj1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.szyfruj1.Location = new System.Drawing.Point(0, 0);
			this.szyfruj1.MyParameters = ((System.Security.Cryptography.RSAParameters)(resources.GetObject("szyfruj1.MyParameters")));
			this.szyfruj1.Name = "szyfruj1";
			this.szyfruj1.Size = new System.Drawing.Size(484, 561);
			this.szyfruj1.TabIndex = 0;
			// 
			// RSA
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Menu;
			this.ClientSize = new System.Drawing.Size(484, 561);
			this.Controls.Add(this.szyfruj1);
			this.Name = "RSA";
			this.Text = "RSA";
			this.ResumeLayout(false);

		}

		#endregion

		private Szyfruj szyfruj1;
	}
}


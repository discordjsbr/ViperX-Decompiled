namespace New_Viper_X
{
	// Token: 0x02000004 RID: 4
	public partial class Loading : global::System.Windows.Forms.Form
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00002ADF File Offset: 0x00000CDF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002B00 File Offset: 0x00000D00
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::New_Viper_X.Loading));
			this.ViperIcon = new global::System.Windows.Forms.PictureBox();
			this.StatusLabel = new global::System.Windows.Forms.Label();
			this.guna2ProgressBar1 = new global::Guna.UI2.WinForms.Guna2ProgressBar();
			this.Fechar = new global::Guna.UI2.WinForms.Guna2Button();
			this.Minimizar = new global::Guna.UI2.WinForms.Guna2Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.backgroundWorker1 = new global::System.ComponentModel.BackgroundWorker();
			((global::System.ComponentModel.ISupportInitialize)this.ViperIcon).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.ViperIcon.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("ViperIcon.Image");
			this.ViperIcon.Location = new global::System.Drawing.Point(12, 42);
			this.ViperIcon.Name = "ViperIcon";
			this.ViperIcon.Size = new global::System.Drawing.Size(183, 73);
			this.ViperIcon.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.ViperIcon.TabIndex = 10;
			this.ViperIcon.TabStop = false;
			this.ViperIcon.Click += new global::System.EventHandler(this.ViperIcon_Click);
			this.StatusLabel.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.StatusLabel.ForeColor = global::System.Drawing.Color.White;
			this.StatusLabel.Location = new global::System.Drawing.Point(12, 127);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new global::System.Drawing.Size(183, 29);
			this.StatusLabel.TabIndex = 11;
			this.StatusLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.StatusLabel.Click += new global::System.EventHandler(this.StatusLabel_Click);
			this.guna2ProgressBar1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ProgressBar1.BorderRadius = 5;
			this.guna2ProgressBar1.BorderStyle = global::System.Drawing.Drawing2D.DashStyle.Dash;
			this.guna2ProgressBar1.FillColor = global::System.Drawing.Color.FromArgb(45, 45, 45);
			this.guna2ProgressBar1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.guna2ProgressBar1.ForeColor = global::System.Drawing.Color.White;
			this.guna2ProgressBar1.Location = new global::System.Drawing.Point(12, 165);
			this.guna2ProgressBar1.Name = "guna2ProgressBar1";
			this.guna2ProgressBar1.ProgressColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2ProgressBar1.ProgressColor2 = global::System.Drawing.Color.FromArgb(123, 180, 255);
			this.guna2ProgressBar1.ShadowDecoration.BorderRadius = 50;
			this.guna2ProgressBar1.ShadowDecoration.Depth = 5;
			this.guna2ProgressBar1.ShadowDecoration.Enabled = true;
			this.guna2ProgressBar1.ShowText = true;
			this.guna2ProgressBar1.Size = new global::System.Drawing.Size(183, 22);
			this.guna2ProgressBar1.Style = global::System.Windows.Forms.ProgressBarStyle.Continuous;
			this.guna2ProgressBar1.TabIndex = 12;
			this.guna2ProgressBar1.Text = "guna2ProgressBar1";
			this.guna2ProgressBar1.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.Fechar.Animated = true;
			this.Fechar.BackColor = global::System.Drawing.Color.Transparent;
			this.Fechar.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			this.Fechar.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.Fechar.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.Fechar.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.Fechar.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.Fechar.FillColor = global::System.Drawing.Color.FromArgb(45, 45, 45);
			this.Fechar.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.Fechar.ForeColor = global::System.Drawing.Color.White;
			this.Fechar.HoverState.FillColor = global::System.Drawing.Color.FromArgb(192, 0, 0);
			this.Fechar.Location = new global::System.Drawing.Point(176, -1);
			this.Fechar.Name = "Fechar";
			this.Fechar.Size = new global::System.Drawing.Size(30, 30);
			this.Fechar.TabIndex = 7;
			this.Fechar.Text = "X";
			this.Fechar.UseTransparentBackground = true;
			this.Fechar.Click += new global::System.EventHandler(this.Fechar_Click);
			this.Minimizar.Animated = true;
			this.Minimizar.BackColor = global::System.Drawing.Color.Transparent;
			this.Minimizar.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			this.Minimizar.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.Minimizar.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.Minimizar.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.Minimizar.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.Minimizar.FillColor = global::System.Drawing.Color.FromArgb(45, 45, 45);
			this.Minimizar.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Minimizar.ForeColor = global::System.Drawing.Color.White;
			this.Minimizar.Location = new global::System.Drawing.Point(144, -1);
			this.Minimizar.Name = "Minimizar";
			this.Minimizar.Size = new global::System.Drawing.Size(30, 30);
			this.Minimizar.TabIndex = 8;
			this.Minimizar.Text = "-";
			this.Minimizar.UseTransparentBackground = true;
			this.Minimizar.Click += new global::System.EventHandler(this.Minimizar_Click);
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(45, 45, 45);
			this.panel1.Controls.Add(this.Minimizar);
			this.panel1.Controls.Add(this.Fechar);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(207, 30);
			this.panel1.TabIndex = 0;
			this.panel1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
			this.guna2BorderlessForm1.BorderRadius = 12;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			this.guna2BorderlessForm1.TransparentWhileDrag = true;
			this.backgroundWorker1.DoWork += new global::System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			base.ClientSize = new global::System.Drawing.Size(207, 203);
			base.Controls.Add(this.guna2ProgressBar1);
			base.Controls.Add(this.StatusLabel);
			base.Controls.Add(this.ViperIcon);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Loading";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Carregando...";
			base.Load += new global::System.EventHandler(this.Loading_Load);
			((global::System.ComponentModel.ISupportInitialize)this.ViperIcon).EndInit();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400000C RID: 12
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.PictureBox ViperIcon;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Label StatusLabel;

		// Token: 0x0400000F RID: 15
		private global::Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;

		// Token: 0x04000010 RID: 16
		private global::Guna.UI2.WinForms.Guna2Button Fechar;

		// Token: 0x04000011 RID: 17
		private global::Guna.UI2.WinForms.Guna2Button Minimizar;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000013 RID: 19
		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		// Token: 0x04000014 RID: 20
		private global::System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}

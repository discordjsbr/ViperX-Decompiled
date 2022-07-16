namespace New_Viper_X
{
	// Token: 0x02000003 RID: 3
	public partial class KeySys : global::System.Windows.Forms.Form
	{
		// Token: 0x06000014 RID: 20 RVA: 0x0000221A File Offset: 0x0000041A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000223C File Offset: 0x0000043C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			base.SuspendLayout();
			this.guna2TextBox1.BorderColor = global::System.Drawing.Color.Thistle;
			this.guna2TextBox1.BorderRadius = 6;
			this.guna2TextBox1.BorderThickness = 0;
			this.guna2TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox1.DefaultText = "";
			this.guna2TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.FillColor = global::System.Drawing.Color.FromArgb(35, 35, 35);
			this.guna2TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.guna2TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.Location = new global::System.Drawing.Point(10, 35);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.Size = new global::System.Drawing.Size(238, 21);
			this.guna2TextBox1.TabIndex = 0;
			this.guna2Button1.BorderRadius = 6;
			this.guna2Button1.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button1.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.guna2Button1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.guna2Button1.FillColor = global::System.Drawing.Color.FromArgb(35, 35, 35);
			this.guna2Button1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.Location = new global::System.Drawing.Point(10, 63);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.Size = new global::System.Drawing.Size(100, 31);
			this.guna2Button1.TabIndex = 1;
			this.guna2Button1.Text = "Get key";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.guna2Button2.BorderRadius = 6;
			this.guna2Button2.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button2.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.guna2Button2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.guna2Button2.FillColor = global::System.Drawing.Color.FromArgb(35, 35, 35);
			this.guna2Button2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.Location = new global::System.Drawing.Point(148, 63);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.Size = new global::System.Drawing.Size(100, 31);
			this.guna2Button2.TabIndex = 2;
			this.guna2Button2.Text = "Confirm";
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			this.label1.AutoSize = true;
			this.label1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(54, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(148, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Key System - Oxygen";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
			this.guna2BorderlessForm1.BorderRadius = 15;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			this.guna2BorderlessForm1.DragForm = false;
			this.guna2BorderlessForm1.ResizeForm = false;
			this.guna2BorderlessForm1.TransparentWhileDrag = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			base.ClientSize = new global::System.Drawing.Size(257, 103);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.guna2Button2);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.guna2TextBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "KeySys";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Key System";
			base.Load += new global::System.EventHandler(this.KeySys_Load);
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.KeySys_MouseDown);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000005 RID: 5
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000006 RID: 6
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000007 RID: 7
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000008 RID: 8
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000A RID: 10
		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
	}
}

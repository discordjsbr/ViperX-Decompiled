using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace New_Viper_X
{
	// Token: 0x02000003 RID: 3
	public partial class KeySys : Form
	{
		// Token: 0x06000002 RID: 2
		[DllImport("bin\\CometAuth.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool Verify([MarshalAs(UnmanagedType.LPStr)] string key);

		// Token: 0x06000003 RID: 3
		[DllImport("bin\\CometAuth.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.BStr)]
		public static extern string HWID();

		// Token: 0x06000004 RID: 4
		[DllImport("bin\\oxygen_auth.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool verify_auth(string key);

		// Token: 0x06000005 RID: 5
		[DllImport("bin\\oxygen_auth.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int start_auth();

		// Token: 0x06000006 RID: 6
		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		// Token: 0x06000007 RID: 7
		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002058 File Offset: 0x00000258
		// (set) Token: 0x06000009 RID: 9 RVA: 0x0000205F File Offset: 0x0000025F
		public int KeyType
		{
			get
			{
				return KeySys._KeyType;
			}
			set
			{
				KeySys._KeyType = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002067 File Offset: 0x00000267
		// (set) Token: 0x0600000B RID: 11 RVA: 0x0000206E File Offset: 0x0000026E
		public bool Ready
		{
			get
			{
				return KeySys._Ready;
			}
			set
			{
				KeySys._Ready = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002076 File Offset: 0x00000276
		// (set) Token: 0x0600000D RID: 13 RVA: 0x0000207D File Offset: 0x0000027D
		public string FormName
		{
			get
			{
				return KeySys._Name;
			}
			set
			{
				KeySys._Name = value;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002088 File Offset: 0x00000288
		public KeySys(Form a)
		{
			this.InitializeComponent();
			KeySys.form = a;
			base.Size = new Size(257, 103);
			this.MaximumSize = new Size(257, 103);
			this.MinimumSize = new Size(257, 103);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000020DD File Offset: 0x000002DD
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			if (KeySys._KeyType == 1)
			{
				KeySys.start_auth();
				return;
			}
			if (KeySys._KeyType == 2)
			{
				Process.Start("https://cometrbx.xyz/ks/start.php?HWID=" + KeySys.HWID());
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000210C File Offset: 0x0000030C
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			if (KeySys._KeyType == 1)
			{
				if (!KeySys.verify_auth(this.guna2TextBox1.Text))
				{
					MessageBox.Show("Chave invalida!");
					return;
				}
				File.WriteAllText("bin\\oxygen_key.data", this.guna2TextBox1.Text);
			}
			else if (KeySys._KeyType == 2)
			{
				if (!KeySys.Verify(this.guna2TextBox1.Text))
				{
					MessageBox.Show("Chave invalida!");
					return;
				}
				File.WriteAllText("bin\\comet_key.data", this.guna2TextBox1.Text);
			}
			MessageBox.Show("Chave correta!");
			base.DialogResult = DialogResult.OK;
			KeySys.form.Show();
			this.Ready = true;
			base.Hide();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000021BA File Offset: 0x000003BA
		private void KeySys_Load(object sender, EventArgs e)
		{
			this.label1.Text = "Key System - " + KeySys._Name;
			KeySys.form.Hide();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000021E0 File Offset: 0x000003E0
		private void KeySys_MouseDown(object sender, MouseEventArgs e)
		{
			KeySys.ReleaseCapture();
			KeySys.SendMessage(base.Handle, 274, 61458, 0);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000021FD File Offset: 0x000003FD
		private void label1_MouseDown(object sender, MouseEventArgs e)
		{
			KeySys.ReleaseCapture();
			KeySys.SendMessage(base.Handle, 274, 61458, 0);
		}

		// Token: 0x04000001 RID: 1
		private static int _KeyType;

		// Token: 0x04000002 RID: 2
		private static Form form;

		// Token: 0x04000003 RID: 3
		private static bool _Ready;

		// Token: 0x04000004 RID: 4
		private static string _Name;
	}
}

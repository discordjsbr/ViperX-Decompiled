using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using New_Viper_X.Interface;

namespace New_Viper_X
{
	// Token: 0x02000004 RID: 4
	public partial class Loading : Form
	{
		// Token: 0x06000016 RID: 22
		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		// Token: 0x06000017 RID: 23
		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

		// Token: 0x06000018 RID: 24 RVA: 0x00002892 File Offset: 0x00000A92
		public Loading()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000028AC File Offset: 0x00000AAC
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Loading_Load(object sender, EventArgs e)
		{
			if (Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName.Contains(Path.GetTempPath()))
			{
				if (Globals.SelectedLanguage == "pt")
				{
					MessageBox.Show("Você precisa extrair o Viper X para ele funcionar!", "Viper X - Temp");
				}
				else
				{
					MessageBox.Show("You need to extract Viper X for it to work!", "Viper X - Temp");
				}
				Environment.Exit(0);
			}
			if (!File.Exists("bin\\options.data"))
			{
				Globals.Options = new Data.Options
				{
					SelectedAPI = "WeAreDevs",
					Animations = true,
					RPC = false,
					TopMost = true,
					RblxUnlocker = false,
					ExtremeIJ = false,
					AutoInject = false
				};
				File.WriteAllText("bin\\options.data", JsonConvert.SerializeObject(Globals.Options));
			}
			else
			{
				try
				{
					Globals.Options = JsonConvert.DeserializeObject<Data.Options>(File.ReadAllText("bin\\options.data"));
				}
				catch (Exception)
				{
					Globals.Options = new Data.Options
					{
						SelectedAPI = "WeAreDevs",
						Animations = true,
						RPC = false,
						TopMost = true,
						RblxUnlocker = false,
						ExtremeIJ = false,
						AutoInject = false
					};
					File.WriteAllText("bin\\options.data", JsonConvert.SerializeObject(Globals.Options));
				}
			}
			if (File.Exists(".\\bin\\lang.json"))
			{
				Globals.SelectedLanguage = JToken.Parse(File.ReadAllText(".\\bin\\lang.json"))["Linguagem"].ToString();
			}
			else
			{
				Globals.SelectedLanguage = "pt";
			}
			this.backgroundWorker1.RunWorkerAsync();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002A3C File Offset: 0x00000C3C
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public void SetStatus(string status)
		{
			base.Invoke(new MethodInvoker(delegate()
			{
				this.StatusLabel.Text = status;
				this.guna2ProgressBar1.Value += 20;
			}));
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002A70 File Offset: 0x00000C70
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Fechar_Click(object sender, EventArgs e)
		{
			Environment.Exit(Environment.ExitCode);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002A7C File Offset: 0x00000C7C
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Minimizar_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002A85 File Offset: 0x00000C85
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			Loading.ReleaseCapture();
			Loading.SendMessage(base.Handle, 274, 61458, 0);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002AA4 File Offset: 0x00000CA4
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			Loading.<backgroundWorker1_DoWork>d__9 <backgroundWorker1_DoWork>d__;
			<backgroundWorker1_DoWork>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<backgroundWorker1_DoWork>d__.<>4__this = this;
			<backgroundWorker1_DoWork>d__.<>1__state = -1;
			<backgroundWorker1_DoWork>d__.<>t__builder.Start<Loading.<backgroundWorker1_DoWork>d__9>(ref <backgroundWorker1_DoWork>d__);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002ADB File Offset: 0x00000CDB
		private void StatusLabel_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002ADD File Offset: 0x00000CDD
		private void ViperIcon_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0400000B RID: 11
		private Data.UI UIVER = new Data.UI();
	}
}

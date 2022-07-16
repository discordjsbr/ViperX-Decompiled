using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Controls;
using DiscordRPC;
using DiscordRPC.Logging;
using Guna.UI2.WinForms;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using New_Viper_X.Interface;
using New_Viper_X.Properties;
using New_Viper_X.Watcher;
using ScintillaNET;

namespace New_Viper_X
{
	// Token: 0x02000005 RID: 5
	public partial class Viper : Form
	{
		// Token: 0x06000024 RID: 36
		[DllImport("user32.DLL")]
		private static extern void ReleaseCapture();

		// Token: 0x06000025 RID: 37
		[DllImport("user32.DLL")]
		private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

		// Token: 0x06000026 RID: 38 RVA: 0x000032E8 File Offset: 0x000014E8
		public Viper()
		{
			this.InitializeComponent();
			this.MinimumSize = base.Size;
			this.MaximumSize = base.Size;
			this.Setar(Globals.SelectedLanguage);
			this.customTabControl1.ShowClosingButton = true;
			CustomTabControl.Form1 = this;
			this.SData = Web.GetScriptData("https://cdn-viperx.github.io/data/getscripthubdata");
			this.ScriptH.Hide();
			this.Creditosz.Hide();
			this.Config.Hide();
			this.TabContextMenu.Renderer = new ToolStripProfessionalRenderer(new Viper.MyRenderer());
			this.TabContextList.Renderer = new ToolStripProfessionalRenderer(new Viper.MyRenderer());
			Globals.KeySys = new KeySys(this);
			Globals.KeySys.TopMost = true;
			Globals.API.AttachMessage += delegate(object s, API.AttachStrings e)
			{
				Viper.<<-ctor>b__10_0>d <<-ctor>b__10_0>d;
				<<-ctor>b__10_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
				<<-ctor>b__10_0>d.<>4__this = this;
				<<-ctor>b__10_0>d.e = e;
				<<-ctor>b__10_0>d.<>1__state = -1;
				<<-ctor>b__10_0>d.<>t__builder.Start<Viper.<<-ctor>b__10_0>d>(ref <<-ctor>b__10_0>d);
			};
			foreach (string path in new string[]
			{
				"workspace",
				"scripts",
				"autoexec",
				"logs"
			})
			{
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000343D File Offset: 0x0000163D
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			Viper.ReleaseCapture();
			Viper.SendMessage(base.Handle, 274, 61458, 0);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000345A File Offset: 0x0000165A
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public TreeNode GetNode(string text, string tag)
		{
			return new TreeNode
			{
				ForeColor = Color.White,
				Tag = tag,
				Text = text
			};
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000347C File Offset: 0x0000167C
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public TreeNode CreateDir(DirectoryInfo info)
		{
			TreeNode node = this.GetNode(info.Name, info.FullName);
			foreach (DirectoryInfo info2 in info.GetDirectories())
			{
				node.Nodes.Add(this.CreateDir(info2));
			}
			foreach (FileInfo fileInfo in info.GetFiles())
			{
				node.Nodes.Add(this.GetNode(fileInfo.Name, fileInfo.FullName));
			}
			return node;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003508 File Offset: 0x00001708
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public void CreateItems(DirectoryInfo info)
		{
			TreeNodeCollection nodes = this.treeView1.Nodes;
			foreach (DirectoryInfo info2 in info.GetDirectories())
			{
				nodes.Add(this.CreateDir(info2));
			}
			foreach (FileInfo fileInfo in info.GetFiles())
			{
				nodes.Add(this.GetNode(fileInfo.Name, fileInfo.FullName));
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003580 File Offset: 0x00001780
		public void kpasdas()
		{
			try
			{
				base.Invoke(new MethodInvoker(delegate()
				{
					Viper.<<kpasdas>b__16_0>d <<kpasdas>b__16_0>d;
					<<kpasdas>b__16_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
					<<kpasdas>b__16_0>d.<>4__this = this;
					<<kpasdas>b__16_0>d.<>1__state = -1;
					<<kpasdas>b__16_0>d.<>t__builder.Start<Viper.<<kpasdas>b__16_0>d>(ref <<kpasdas>b__16_0>d);
				}));
			}
			catch
			{
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000035B8 File Offset: 0x000017B8
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public void LoadScriptList()
		{
			try
			{
				string path = Path.Combine(Environment.CurrentDirectory, "scripts");
				this.treeView1.Nodes.Clear();
				DirectoryInfo info = new DirectoryInfo(path);
				this.CreateItems(info);
			}
			catch (Exception)
			{
				MessageBox.Show("Não foi possivel carregar a lista de scripts!", "Viper X - Exception");
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003618 File Offset: 0x00001818
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Fechar_Click(object sender, EventArgs e)
		{
			Viper.<Fechar_Click>d__18 <Fechar_Click>d__;
			<Fechar_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Fechar_Click>d__.<>4__this = this;
			<Fechar_Click>d__.<>1__state = -1;
			<Fechar_Click>d__.<>t__builder.Start<Viper.<Fechar_Click>d__18>(ref <Fechar_Click>d__);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000364F File Offset: 0x0000184F
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Minimizar_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003658 File Offset: 0x00001858
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void viper_Deactivate(object sender, EventArgs e)
		{
			Viper.<viper_Deactivate>d__20 <viper_Deactivate>d__;
			<viper_Deactivate>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<viper_Deactivate>d__.<>4__this = this;
			<viper_Deactivate>d__.<>1__state = -1;
			<viper_Deactivate>d__.<>t__builder.Start<Viper.<viper_Deactivate>d__20>(ref <viper_Deactivate>d__);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003690 File Offset: 0x00001890
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void viper_Activated(object sender, EventArgs e)
		{
			Viper.<viper_Activated>d__21 <viper_Activated>d__;
			<viper_Activated>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<viper_Activated>d__.<>4__this = this;
			<viper_Activated>d__.<>1__state = -1;
			<viper_Activated>d__.<>t__builder.Start<Viper.<viper_Activated>d__21>(ref <viper_Activated>d__);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000036C7 File Offset: 0x000018C7
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void ViperIcon_MouseDown(object sender, MouseEventArgs e)
		{
			Viper.ReleaseCapture();
			Viper.SendMessage(base.Handle, 274, 61458, 0);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000036E4 File Offset: 0x000018E4
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Inicio_Click(object sender, EventArgs e)
		{
			this.inicial.Show();
			this.Creditosz.Hide();
			this.ScriptH.Hide();
			this.Config.Hide();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003712 File Offset: 0x00001912
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void executor_Click(object sender, EventArgs e)
		{
			this.inicial.Hide();
			this.Creditosz.Hide();
			this.ScriptH.Hide();
			this.Config.Hide();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003740 File Offset: 0x00001940
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void opcoes_Click(object sender, EventArgs e)
		{
			this.inicial.Hide();
			this.Creditosz.Hide();
			this.ScriptH.Hide();
			this.Config.Show();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000376E File Offset: 0x0000196E
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void creditos_Click(object sender, EventArgs e)
		{
			this.inicial.Hide();
			this.Creditosz.Show();
			this.ScriptH.Hide();
			this.Config.Hide();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000379C File Offset: 0x0000199C
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Viper_Load(object sender, EventArgs e)
		{
			try
			{
				this.Watcher = new ProcessWatcher("RobloxPlayerBeta.exe");
				this.Watcher.ProcessCreated += delegate(New_Viper_X.Watcher.Process Proc)
				{
					if (!Globals.Options.AutoInject)
					{
						return;
					}
					Globals.API.Inject(Globals.Options.SelectedAPI);
				};
				this.Watcher.ProcessDeleted += delegate(New_Viper_X.Watcher.Process Proc)
				{
					this.CheckApi.Text = "Não injetado!";
					if (Globals.API.PipeTimer.Enabled)
					{
						Globals.API.PipeTimer.Stop();
					}
				};
				this.Watcher.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			this.kpasdas();
			if (!Directory.Exists("bin/tabs"))
			{
				Directory.CreateDirectory("bin/tabs");
			}
			if (Directory.GetFiles("bin/tabs").Length == 0)
			{
				this.customTabControl1.addnewtab();
			}
			else
			{
				for (int i = 0; i < Directory.GetFiles("bin/tabs").Length / 2; i++)
				{
					this.customTabControl1.addnewtab();
					try
					{
						using (FileStream fileStream = new FileStream(string.Format("bin/tabs/{0}_name.txt", i), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
						{
							using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
							{
								this.customTabControl1.TabPages[this.customTabControl1.TabPages.Count - 2].Text = streamReader.ReadToEnd();
								streamReader.Close();
							}
						}
						using (FileStream fileStream2 = new FileStream(string.Format("bin/tabs/{0}_source.lua", i), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
						{
							using (StreamReader streamReader2 = new StreamReader(fileStream2, Encoding.UTF8))
							{
								this.customTabControl1.GetWorkingTextEditor().Text = streamReader2.ReadToEnd();
								streamReader2.Close();
							}
						}
					}
					catch
					{
					}
				}
			}
			this.LoadScriptList();
			this.CarregarScripts();
			this.guna2ComboBox1.SelectedIndex = this.ConvertStringToIndex(Globals.Options.SelectedAPI);
			this.guna2CheckBox2.Checked = Globals.Options.TopMost;
			base.TopMost = Globals.Options.TopMost;
			this.guna2CheckBox3.Checked = Globals.Options.Animations;
			this.guna2CheckBox4.Checked = Globals.Options.RPC;
			this.guna2CheckBox7.Checked = Globals.Options.RblxUnlocker;
			this.guna2CheckBox6.Checked = Globals.Options.ExtremeIJ;
			Data.Theme theme = JsonConvert.DeserializeObject<Data.Theme>(File.ReadAllText(".\\bin\\temas\\theme.json"));
			if (!string.IsNullOrWhiteSpace(theme.Image))
			{
				this.SetBackgroundImage(theme.Image);
			}
			Data.User user = JsonConvert.DeserializeObject<Data.User>(File.ReadAllText(".\\bin\\userconfig.json"));
			if (!string.IsNullOrWhiteSpace(user.Name))
			{
				this.User.Text = ((Globals.SelectedLanguage == "pt") ? ("Bem-vindo: " + user.Name) : ("Welcome: " + user.Name));
				this.Name = user.Name;
			}
			else
			{
				this.User.Text = ((Globals.SelectedLanguage == "pt") ? ("Bem-vindo: " + Environment.UserName) : ("Welcome: " + Environment.UserName));
				this.Name = Environment.UserName;
			}
			if (!string.IsNullOrWhiteSpace(user.Image))
			{
				this.guna2CirclePictureBox1.Load(user.Image);
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003B38 File Offset: 0x00001D38
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public void SetBackgroundImage(string url)
		{
			Bitmap backgroundImage = new Bitmap(new MemoryStream(new WebClient().DownloadData(url)));
			this.BackgroundImage = backgroundImage;
			this.RefreshH.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.ExecuteH.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.Panel_Inicial.BackColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2ShadowPanel1.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2ShadowPanel3.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2ShadowPanel5.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2ShadowPanel6.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2ShadowPanel7.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2ShadowPanel8.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2ShadowPanel11.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2ShadowPanel9.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.Execute.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.Inject.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.Clear.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.Save.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.Open.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.panelLateral.BackColor = Color.FromArgb(90, 39, 39, 39);
			this.inicial.BackColor = Color.Transparent;
			this.Creditosz.BackColor = Color.Transparent;
			this.Config.BackColor = Color.Transparent;
			this.ScriptH.BackColor = Color.Transparent;
			this.guna2ComboBox1.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2ShadowPanel12.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2Button1.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2Button3.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2ShadowPanel13.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2ShadowPanel14.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2ShadowPanel15.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2ShadowPanel10.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2Button9.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2Button10.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2Button2.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2Button5.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2Button4.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2Button6.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2Button8.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2Button1.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2ShadowPanel16.FillColor = Color.FromArgb(90, 45, 45, 45);
			this.guna2Button11.FillColor = Color.FromArgb(90, 25, 25, 25);
			this.guna2Button7.FillColor = Color.FromArgb(90, 25, 25, 25);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003F04 File Offset: 0x00002104
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public int ConvertStringToIndex(string value)
		{
			if (value == "Krnl")
			{
				return 0;
			}
			if (value == "Oxygen")
			{
				return 1;
			}
			if (value == "oydECfGU5Z")
			{
				return 2;
			}
			if (!(value == "WeAreDevs"))
			{
				return 3;
			}
			return 3;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003F50 File Offset: 0x00002150
		private void Panel_Inicial_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003F52 File Offset: 0x00002152
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void scripthub_Click(object sender, EventArgs e)
		{
			this.inicial.Hide();
			this.Creditosz.Hide();
			this.Config.Hide();
			this.ScriptH.Show();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003F80 File Offset: 0x00002180
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			Globals.API.Execute(this.customTabControl1.GetWorkingTextEditor().Text, Globals.Options.SelectedAPI);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003FA6 File Offset: 0x000021A6
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void limparToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Scintilla scintilla = this.customTabControl1.contextTab.Controls[0] as Scintilla;
			scintilla.Text = "";
			scintilla.Refresh();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003FD4 File Offset: 0x000021D4
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void renomearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TabPage contextTab = this.customTabControl1.contextTab;
			if (contextTab != null)
			{
				Form form = new Form
				{
					Width = 200,
					Height = 50,
					MinimumSize = new Size(200, 50),
					MaximumSize = new Size(200, 50),
					FormBorderStyle = FormBorderStyle.None,
					Text = "Você deseja renomear esta aba para?",
					StartPosition = FormStartPosition.CenterParent
				};
				Label value = new Label
				{
					Width = 200,
					Height = 50,
					Text = "Você deseja renomear esta aba para?",
					Top = 0,
					Left = 0
				};
				TextBox textBox = new TextBox
				{
					Left = 0,
					Top = 30,
					Width = 150,
					Text = contextTab.Text
				};
				Button button = new Button
				{
					Text = "Ok",
					Left = 150,
					Width = 50,
					Top = 30,
					DialogResult = DialogResult.OK
				};
				form.TopMost = true;
				button.Click += delegate(object argument0, EventArgs argument1)
				{
					form.Close();
				};
				form.Controls.Add(textBox);
				form.Controls.Add(button);
				form.Controls.Add(value);
				form.AcceptButton = button;
				string text = (form.ShowDialog() == DialogResult.OK) ? textBox.Text : "";
				if (text.Length > 0)
				{
					contextTab.Text = text;
					return;
				}
			}
			else
			{
				MessageBox.Show("null");
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004184 File Offset: 0x00002384
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			object contextTab = this.customTabControl1.contextTab;
			if (Viper.<>o__35.<>p__1 == null)
			{
				Viper.<>o__35.<>p__1 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Viper), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, bool> target = Viper.<>o__35.<>p__1.Target;
			CallSite <>p__ = Viper.<>o__35.<>p__1;
			if (Viper.<>o__35.<>p__0 == null)
			{
				Viper.<>o__35.<>p__0 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Viper), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			if (target(<>p__, Viper.<>o__35.<>p__0.Target(Viper.<>o__35.<>p__0, contextTab, null)))
			{
				throw new Exception("Aba não encontrada");
			}
			if (Viper.<>o__35.<>p__6 == null)
			{
				Viper.<>o__35.<>p__6 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Text", typeof(Viper), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target2 = Viper.<>o__35.<>p__6.Target;
			CallSite <>p__2 = Viper.<>o__35.<>p__6;
			object arg = contextTab;
			if (Viper.<>o__35.<>p__5 == null)
			{
				Viper.<>o__35.<>p__5 = CallSite<Func<CallSite, CustomTabControl, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "OpenSaveDialog", null, typeof(Viper), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, CustomTabControl, object, object, object> target3 = Viper.<>o__35.<>p__5.Target;
			CallSite <>p__3 = Viper.<>o__35.<>p__5;
			CustomTabControl arg2 = this.customTabControl1;
			object arg3 = contextTab;
			if (Viper.<>o__35.<>p__4 == null)
			{
				Viper.<>o__35.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Text", typeof(Viper), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object> target4 = Viper.<>o__35.<>p__4.Target;
			CallSite <>p__4 = Viper.<>o__35.<>p__4;
			if (Viper.<>o__35.<>p__3 == null)
			{
				Viper.<>o__35.<>p__3 = CallSite<Func<CallSite, object, int, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetIndex(CSharpBinderFlags.None, typeof(Viper), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			Func<CallSite, object, int, object> target5 = Viper.<>o__35.<>p__3.Target;
			CallSite <>p__5 = Viper.<>o__35.<>p__3;
			if (Viper.<>o__35.<>p__2 == null)
			{
				Viper.<>o__35.<>p__2 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Controls", typeof(Viper), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			target2(<>p__2, arg, target3(<>p__3, arg2, arg3, target4(<>p__4, target5(<>p__5, Viper.<>o__35.<>p__2.Target(Viper.<>o__35.<>p__2, contextTab), 0))));
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000043E8 File Offset: 0x000025E8
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void carregarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.treeView1.SelectedNode != null)
				{
					if ((File.GetAttributes(this.treeView1.SelectedNode.Tag.ToString()) & FileAttributes.Directory) != FileAttributes.Directory)
					{
						this.customTabControl1.GetWorkingTextEditor().Text = File.ReadAllText(this.treeView1.SelectedNode.Tag.ToString());
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Não foi possivel carregar o script!", "Viper X - Exception");
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004478 File Offset: 0x00002678
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void executarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.treeView1.SelectedNode != null)
				{
					if ((File.GetAttributes(this.treeView1.SelectedNode.Tag.ToString()) & FileAttributes.Directory) != FileAttributes.Directory)
					{
						Globals.API.Execute(File.ReadAllText(this.treeView1.SelectedNode.Tag.ToString()), Globals.Options.SelectedAPI);
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Não foi possivel executar o script!", "Viper X - Exception");
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000450C File Offset: 0x0000270C
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void recarregarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.LoadScriptList();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00004514 File Offset: 0x00002714
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Clear_Click(object sender, EventArgs e)
		{
			this.customTabControl1.GetWorkingTextEditor().Text = "";
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000452B File Offset: 0x0000272B
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Save_Click(object sender, EventArgs e)
		{
			this.customTabControl1.OpenSaveDialog(this.customTabControl1.SelectedTab, this.customTabControl1.GetWorkingTextEditor().Text);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00004554 File Offset: 0x00002754
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Open_Click(object sender, EventArgs e)
		{
			this.customTabControl1.OpenFileDialog(this.customTabControl1.SelectedTab);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00004570 File Offset: 0x00002770
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox1.SelectedIndex == -1)
			{
				return;
			}
			this.SC = this.Scripts[this.listBox1.Items[this.listBox1.SelectedIndex].ToString()];
			this.textBox1.Text = this.SC.SCRIPT_DESCRIPTION;
			this.pictureBox1.Load(this.SC.SCRIPT_IMAGE);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000045EC File Offset: 0x000027EC
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(this.guna2TextBox1.Text))
			{
				if (this.container.Count > 0)
				{
					this.listBox1.Items.Clear();
					ListBox.ObjectCollection items = this.listBox1.Items;
					object[] items2 = (from t in this.container
					where t.ToLower().Contains(this.guna2TextBox1.Text.ToLower())
					select t).ToArray<string>();
					items.AddRange(items2);
					return;
				}
			}
			else
			{
				this.listBox1.Items.Clear();
				this.CarregarScripts();
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00004670 File Offset: 0x00002870
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public void CarregarScripts()
		{
			try
			{
				if (this.container.Count > 0)
				{
					this.container.Clear();
				}
				foreach (Data.ScriptHubData scriptHubData in this.SData.SCRIPTS)
				{
					this.Scripts[scriptHubData.SCRIPT_NAME] = scriptHubData;
					this.container.Add(scriptHubData.SCRIPT_NAME);
					this.listBox1.Items.Add(scriptHubData.SCRIPT_NAME);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Não foi possivel carregar os scripts! Tente novamente mais tarde.", "Viper X - Exception");
				base.Close();
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000473C File Offset: 0x0000293C
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Inject_Click(object sender, EventArgs e)
		{
			Globals.API.Inject(Globals.Options.SelectedAPI);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004754 File Offset: 0x00002954
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void ExecuteH_Click(object sender, EventArgs e)
		{
			if (this.SC == null)
			{
				return;
			}
			string script = "";
			try
			{
				using (WebClient webClient = new WebClient())
				{
					script = webClient.DownloadString(this.SC.SCRIPT_URL);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Não foi possível executar o script, tente novamente!", "Viper X - Script Hub");
			}
			Globals.API.Execute(script, Globals.Options.SelectedAPI);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000047DC File Offset: 0x000029DC
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void RefreshH_Click(object sender, EventArgs e)
		{
			this.listBox1.Items.Clear();
			this.CarregarScripts();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000047F4 File Offset: 0x000029F4
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string a = this.guna2ComboBox1.SelectedItem.ToString();
			if (a == "Krnl")
			{
				Globals.Options.SelectedAPI = "Krnl";
				return;
			}
			if (a == "Oxygen U")
			{
				Globals.Options.SelectedAPI = "Oxygen";
				return;
			}
			if (a == "Comet")
			{
				Globals.Options.SelectedAPI = "oydECfGU5Z";
				return;
			}
			if (!(a == "WeAreDevs"))
			{
				return;
			}
			Globals.Options.SelectedAPI = "WeAreDevs";
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004886 File Offset: 0x00002A86
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void Viper_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004888 File Offset: 0x00002A88
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000488A File Offset: 0x00002A8A
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.guna2CheckBox2.Checked)
			{
				base.TopMost = true;
				Globals.Options.TopMost = true;
				return;
			}
			base.TopMost = false;
			Globals.Options.TopMost = false;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000048BE File Offset: 0x00002ABE
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2CheckBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (this.guna2CheckBox3.Checked)
			{
				Globals.Options.Animations = true;
				return;
			}
			Globals.Options.Animations = false;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000048E4 File Offset: 0x00002AE4
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2CheckBox4_CheckedChanged(object sender, EventArgs e)
		{
			if (this.guna2CheckBox4.Checked)
			{
				DiscordRpcClient discordRpcClient = new DiscordRpcClient("951256420731465728");
				discordRpcClient.Logger = new ConsoleLogger(1, true);
				discordRpcClient.Initialize();
				discordRpcClient.SetPresence(new RichPresence
				{
					Assets = new Assets
					{
						LargeImageKey = "logo",
						LargeImageText = "Viper X 1.0.5"
					},
					Timestamps = Timestamps.Now,
					Details = "The best exploit BR",
					State = "",
					Buttons = new Button[]
					{
						new Button
						{
							Label = "Baixar - Viper X",
							Url = "https://discord.gg/viperx"
						},
						new Button
						{
							Label = "Pegar scripts",
							Url = "https://juninhoscripts.com/"
						}
					}
				});
				Globals.Options.RPC = true;
				return;
			}
			Globals.Options.RPC = false;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000049CC File Offset: 0x00002BCC
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2CheckBox7_CheckedChanged(object sender, EventArgs e)
		{
			if (this.guna2CheckBox7.Checked)
			{
				System.Diagnostics.Process[] processesByName = System.Diagnostics.Process.GetProcessesByName("rbxfpsunlocker");
				for (int i = 0; i < processesByName.Length; i++)
				{
					processesByName[i].Kill();
				}
				System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\bin\\rbxfpsunlocker.exe");
				Globals.Options.RblxUnlocker = true;
				return;
			}
			System.Diagnostics.Process[] processesByName2 = System.Diagnostics.Process.GetProcessesByName("rbxfpsunlocker");
			for (int j = 0; j < processesByName2.Length; j++)
			{
				processesByName2[j].Kill();
			}
			Globals.Options.RblxUnlocker = false;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004A54 File Offset: 0x00002C54
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2CheckBox6_CheckedChanged(object sender, EventArgs e)
		{
			if (this.guna2CheckBox6.Checked)
			{
				System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\bin\\Extreme Injector v3.exe");
				Globals.Options.ExtremeIJ = true;
				return;
			}
			System.Diagnostics.Process[] processesByName = System.Diagnostics.Process.GetProcessesByName("Extreme Injector v3");
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
			Globals.Options.ExtremeIJ = false;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004ABB File Offset: 0x00002CBB
		private void Config_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00004AC0 File Offset: 0x00002CC0
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2Button1_Click_1(object sender, EventArgs e)
		{
			if (MessageBox.Show("Se você quiser tentar corrigir o bug de 'comportamento do cliente' do ROBLOX, clique em 'Sim', caso contrário, clique em 'Não' (Não se esqueça de fechar o roblox.)", "Viper X - Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				try
				{
					using (WebClient webClient = new WebClient())
					{
						string str = webClient.DownloadString("https://versioncompatibility.api.roblox.com/GetCurrentClientVersionUpload/?apiKey=76e5a40c-3ae1-4028-9f10-7c62520bd94f&binaryType=WindowsPlayer").Replace("\"", "");
						string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Roblox\\Versions\\" + str);
						string destFileName;
						if (!Directory.Exists(text))
						{
							text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Roblox\\Versions\\" + str);
							if (!Directory.Exists(text))
							{
								text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Roblox\\Versions\\" + str);
								if (!Directory.Exists(text))
								{
									MessageBox.Show("Não foi possível localizar a pasta do Roblox!", "Viper X - 268 Kick Fix");
									return;
								}
								destFileName = text + "\\XInput1_4.dll";
							}
							else
							{
								destFileName = text + "\\XInput1_4.dll";
							}
						}
						else
						{
							destFileName = text + "\\XInput1_4.dll";
						}
						File.Copy(this.sourceFile, destFileName, true);
						if (File.Exists(this.localappdata + "/Roblox/GlobalBasicSettings_13.xml"))
						{
							try
							{
								File.Delete(this.localappdata + "/Roblox/GlobalBasicSettings_13.xml");
							}
							catch (Exception ex)
							{
								MessageBox.Show("Error: " + ex.Message);
							}
						}
						if (File.Exists(this.localappdata + "/Roblox/GlobalSettings_13.xml"))
						{
							try
							{
								File.Delete(this.localappdata + "/Roblox/GlobalSettings_13.xml");
							}
							catch (Exception ex2)
							{
								MessageBox.Show("Error: " + ex2.Message);
							}
						}
						MessageBox.Show("Sucesso! Você terá que apertar neste botão novamente caso Encontre este problema novamente!");
					}
				}
				catch (Exception ex3)
				{
					MessageBox.Show("Error: " + ex3.Message);
				}
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004CE4 File Offset: 0x00002EE4
		private void guna2Button2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004CE8 File Offset: 0x00002EE8
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			string text = this.UsernameText.Text;
			string text2 = this.ProfileImageLink.Text;
			Data.User user = new Data.User
			{
				Name = text,
				Image = text2
			};
			File.WriteAllText("bin\\userconfig.json", JsonConvert.SerializeObject(user));
			if (!string.IsNullOrWhiteSpace(text2))
			{
				this.guna2CirclePictureBox1.Load(text2);
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				this.User.Text = ((Globals.SelectedLanguage == "pt") ? ("Bem-vindo: " + text) : ("Welcome: " + text));
				return;
			}
			this.User.Text = ((Globals.SelectedLanguage == "pt") ? ("Bem-vindo: " + Environment.UserName) : ("Welcome: " + Environment.UserName));
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004DBE File Offset: 0x00002FBE
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void timer1_Tick(object sender, EventArgs e)
		{
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004DC0 File Offset: 0x00002FC0
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2Button2_Click_1(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://discord.gg/viperx");
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004DCD File Offset: 0x00002FCD
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://discord.gg/a5kaMGhAp3");
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004DDA File Offset: 0x00002FDA
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://discord.gg/sVumRT8mxB");
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004DE8 File Offset: 0x00002FE8
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void guna2Button6_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process[] processesByName = System.Diagnostics.Process.GetProcessesByName("RobloxPlayerBeta");
			int num = 0;
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
				num++;
			}
			MessageBox.Show(string.Format("Finalizado {0} processos do Roblox", num), "Viper X - Info");
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004E38 File Offset: 0x00003038
		private void guna2Button7_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Use este botão caso seu roblox não esteja Carregando corretamente!", "Viper X - Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				try
				{
					using (WebClient webClient = new WebClient())
					{
						string str = webClient.DownloadString("https://versioncompatibility.api.roblox.com/GetCurrentClientVersionUpload/?apiKey=76e5a40c-3ae1-4028-9f10-7c62520bd94f&binaryType=WindowsPlayer").Replace("\"", "");
						string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Roblox\\Versions\\" + str);
						string path;
						if (!Directory.Exists(text))
						{
							text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Roblox\\Versions\\" + str);
							if (!Directory.Exists(text))
							{
								text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Roblox\\Versions\\" + str);
								if (!Directory.Exists(text))
								{
									MessageBox.Show("Não foi possível localizar a pasta do Roblox!", "Viper X - 268 Kick Fix");
									return;
								}
								path = text + "\\XInput1_4.dll";
							}
							else
							{
								path = text + "\\XInput1_4.dll";
							}
						}
						else
						{
							path = text + "\\XInput1_4.dll";
						}
						if (File.Exists(path))
						{
							try
							{
								File.Delete(path);
							}
							catch (Exception ex)
							{
								MessageBox.Show("Error: " + ex.Message);
							}
						}
					}
					MessageBox.Show("Pronto! tente entrar novamente no roblox.");
				}
				catch (Exception ex2)
				{
					MessageBox.Show("Error: " + ex2.Message);
				}
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004FD0 File Offset: 0x000031D0
		private void guna2Button8_Click(object sender, EventArgs e)
		{
			Clipboard.SetText("8ea02da4-2c6f-4f88-92ed-466d5b0a57ac");
			if (Globals.SelectedLanguage == "pt")
			{
				MessageBox.Show("Chave pix copiada para area de transferencia!", "Viper X - Info");
				return;
			}
			MessageBox.Show("Pix key copied to clipboard!", "Viper X - Info");
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000500E File Offset: 0x0000320E
		private void guna2CheckBox8_CheckedChanged(object sender, EventArgs e)
		{
			if (this.guna2CheckBox8.Checked)
			{
				Globals.Options.AutoInject = true;
				return;
			}
			Globals.Options.AutoInject = false;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005034 File Offset: 0x00003234
		private void guna2ShadowPanel7_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00005038 File Offset: 0x00003238
		private void guna2Button1_Click_2(object sender, EventArgs e)
		{
			string text = this.LinkTemaText.Text;
			if (string.IsNullOrWhiteSpace(text) || !text.Contains("http"))
			{
				return;
			}
			this.SetBackgroundImage(text);
			string contents = JsonConvert.SerializeObject(new Data.Theme
			{
				Image = text
			});
			File.WriteAllText("bin\\temas\\theme.json", contents);
			GC.Collect();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00005090 File Offset: 0x00003290
		private void guna2Button7_Click_1(object sender, EventArgs e)
		{
			new System.Diagnostics.Process
			{
				StartInfo = 
				{
					FileName = "bin\\viper-injector-fixer.exe",
					WorkingDirectory = ".\\bin\\",
					UseShellExecute = false
				}
			}.Start();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000050CC File Offset: 0x000032CC
		private void Setar(string lang)
		{
			if (lang == "en")
			{
				this.guna2CheckBox8.Text = "Auto Inject";
				this.guna2Button6.Text = "Kill roblox";
				this.label18.Text = "Language";
				this.label10.Text = "Ui Options";
				this.guna2CheckBox2.Text = "TopMost";
				this.guna2CheckBox3.Text = "Fade in";
				this.label11.Text = "Aplications";
				this.label17.Text = "Themes";
				this.label14.Text = "Profile";
				this.guna2Button1.Text = "Confirm";
				this.LinkTemaText.PlaceholderText = "Image link...";
				this.UsernameText.PlaceholderText = "Username...";
				this.ProfileImageLink.PlaceholderText = "Image link...";
				this.guna2Button3.Text = "Confirm";
				this.guna2TextBox1.PlaceholderText = "Search...";
				this.RefreshH.Text = "Refresh";
				this.ExecuteH.Text = "Execute";
				this.label27.Text = "Patherner";
				this.label28.Text = "Loading...";
				this.label30.Text = "Loading...";
				this.User.Text = "Welcome: " + this.Name;
				this.Execute.Text = "Execute";
				this.Inject.Text = "Inject";
				this.Clear.Text = "Clear";
				this.Save.Text = "Save";
				this.label16.Text = "Want to help the Viper X project with a donation? click the button below any donation and welcome and help the Creators a lot!";
				this.guna2Button8.Text = "Donate";
				this.Open.Text = "Open";
				this.CheckApi.Text = "Not Injected";
				this.label3.Text = "Creators";
				this.label5.Text = "Pathern";
				this.label15.Text = "Donate";
				this.guna2Button7.Text = "Open";
				this.kpasdas();
				return;
			}
			if (!(lang == "pt"))
			{
				return;
			}
			this.guna2CheckBox8.Text = "Auto Injetar";
			this.guna2Button6.Text = "Matar roblox";
			this.label18.Text = "Linguagem";
			this.label10.Text = "Opções da UI";
			this.guna2CheckBox2.Text = "No Topo";
			this.guna2CheckBox3.Text = "Animação";
			this.label11.Text = "Aplicativos";
			this.label17.Text = "Temas";
			this.label14.Text = "Perfil";
			this.guna2Button1.Text = "Confirmar";
			this.LinkTemaText.PlaceholderText = "Link da imagem...";
			this.UsernameText.PlaceholderText = "Nome de usuario...";
			this.ProfileImageLink.PlaceholderText = "Link da imagem...";
			this.guna2Button3.Text = "Confirmar";
			this.guna2TextBox1.PlaceholderText = "Pesquisar...";
			this.RefreshH.Text = "Recarregar";
			this.ExecuteH.Text = "Executar";
			this.guna2Button8.Text = "Doar";
			this.label27.Text = "Parceiros";
			this.label28.Text = "Carregando...";
			this.label30.Text = "Carregando...";
			this.User.Text = "Bem-vindo: " + this.Name;
			this.Execute.Text = "Executar";
			this.Inject.Text = "Injetar";
			this.label16.Text = "Quer ajudar o projeto do VIper X com alguma doação? clique no botão abaixo qualquer doação e bem vinda e ajudara muito os Criadores!";
			this.Clear.Text = "Limpar";
			this.Save.Text = "Salvar";
			this.Open.Text = "Abrir";
			this.CheckApi.Text = "Não Injetado";
			this.label3.Text = "Criadores";
			this.label5.Text = "Parceiros";
			this.label15.Text = "Doar";
			this.guna2Button7.Text = "Abrir";
			this.kpasdas();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000553C File Offset: 0x0000373C
		private void guna2Button9_Click(object sender, EventArgs e)
		{
			Globals.SelectedLanguage = "en";
			this.Setar("en");
			string contents = JsonConvert.SerializeObject(new Data.Lingua
			{
				Linguagem = "en"
			});
			File.WriteAllText(".\\bin\\lang.json", contents);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00005580 File Offset: 0x00003780
		private void guna2Button10_Click(object sender, EventArgs e)
		{
			Globals.SelectedLanguage = "pt";
			this.Setar("pt");
			string contents = JsonConvert.SerializeObject(new Data.Lingua
			{
				Linguagem = "pt"
			});
			File.WriteAllText(".\\bin\\lang.json", contents);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000055C3 File Offset: 0x000037C3
		private void guna2ShadowPanel11_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000055C5 File Offset: 0x000037C5
		private void label23_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000055C7 File Offset: 0x000037C7
		private void guna2Button11_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://discord.gg/axspRFv25B");
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000055D4 File Offset: 0x000037D4
		private void guna2Button7_Click_2(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://raw.githubusercontent.com/ySeuamorkkk/viperx/main/Changelog");
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000055E1 File Offset: 0x000037E1
		private void inicial_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x04000016 RID: 22
		private string sourceFile = Environment.CurrentDirectory + "\\bin\\XInput1_4.dll";

		// Token: 0x04000017 RID: 23
		private readonly Dictionary<string, Data.ScriptHubData> Scripts = new Dictionary<string, Data.ScriptHubData>();

		// Token: 0x04000018 RID: 24
		private Data.ScriptHubData SC;

		// Token: 0x04000019 RID: 25
		private string localappdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

		// Token: 0x0400001A RID: 26
		private Data.ScriptHubHolder SData;

		// Token: 0x0400001B RID: 27
		private ProcessWatcher Watcher;

		// Token: 0x0400001C RID: 28
		private List<string> container = new List<string>();

		// Token: 0x02000015 RID: 21
		public class MyRenderer : ProfessionalColorTable
		{
			// Token: 0x1700006D RID: 109
			// (get) Token: 0x0600017F RID: 383 RVA: 0x000101DE File Offset: 0x0000E3DE
			public override Color ToolStripDropDownBackground
			{
				get
				{
					return Color.FromArgb(30, 30, 30);
				}
			}

			// Token: 0x1700006E RID: 110
			// (get) Token: 0x06000180 RID: 384 RVA: 0x000101EB File Offset: 0x0000E3EB
			public override Color ImageMarginGradientBegin
			{
				get
				{
					return Color.FromArgb(30, 30, 30);
				}
			}

			// Token: 0x1700006F RID: 111
			// (get) Token: 0x06000181 RID: 385 RVA: 0x000101F8 File Offset: 0x0000E3F8
			public override Color ImageMarginGradientMiddle
			{
				get
				{
					return Color.FromArgb(30, 30, 30);
				}
			}

			// Token: 0x17000070 RID: 112
			// (get) Token: 0x06000182 RID: 386 RVA: 0x00010205 File Offset: 0x0000E405
			public override Color ImageMarginGradientEnd
			{
				get
				{
					return Color.FromArgb(30, 30, 30);
				}
			}

			// Token: 0x17000071 RID: 113
			// (get) Token: 0x06000183 RID: 387 RVA: 0x00010212 File Offset: 0x0000E412
			public override Color MenuBorder
			{
				get
				{
					return Color.FromArgb(35, 35, 35);
				}
			}

			// Token: 0x17000072 RID: 114
			// (get) Token: 0x06000184 RID: 388 RVA: 0x0001021F File Offset: 0x0000E41F
			public override Color MenuItemBorder
			{
				get
				{
					return Color.FromArgb(35, 35, 35);
				}
			}

			// Token: 0x17000073 RID: 115
			// (get) Token: 0x06000185 RID: 389 RVA: 0x0001022C File Offset: 0x0000E42C
			public override Color MenuItemSelected
			{
				get
				{
					return Color.FromArgb(35, 35, 35);
				}
			}

			// Token: 0x17000074 RID: 116
			// (get) Token: 0x06000186 RID: 390 RVA: 0x00010239 File Offset: 0x0000E439
			public override Color MenuStripGradientBegin
			{
				get
				{
					return Color.FromArgb(30, 30, 30);
				}
			}

			// Token: 0x17000075 RID: 117
			// (get) Token: 0x06000187 RID: 391 RVA: 0x00010246 File Offset: 0x0000E446
			public override Color MenuStripGradientEnd
			{
				get
				{
					return Color.FromArgb(35, 35, 35);
				}
			}

			// Token: 0x17000076 RID: 118
			// (get) Token: 0x06000188 RID: 392 RVA: 0x00010253 File Offset: 0x0000E453
			public override Color MenuItemSelectedGradientBegin
			{
				get
				{
					return Color.FromArgb(30, 30, 30);
				}
			}

			// Token: 0x17000077 RID: 119
			// (get) Token: 0x06000189 RID: 393 RVA: 0x00010260 File Offset: 0x0000E460
			public override Color MenuItemSelectedGradientEnd
			{
				get
				{
					return Color.FromArgb(30, 30, 30);
				}
			}

			// Token: 0x17000078 RID: 120
			// (get) Token: 0x0600018A RID: 394 RVA: 0x0001026D File Offset: 0x0000E46D
			public override Color MenuItemPressedGradientBegin
			{
				get
				{
					return Color.FromArgb(30, 30, 30);
				}
			}

			// Token: 0x17000079 RID: 121
			// (get) Token: 0x0600018B RID: 395 RVA: 0x0001027A File Offset: 0x0000E47A
			public override Color MenuItemPressedGradientEnd
			{
				get
				{
					return Color.FromArgb(30, 30, 30);
				}
			}
		}
	}
}

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace New_Viper_X.Interface
{
	// Token: 0x0200000C RID: 12
	public class API
	{
		// Token: 0x06000127 RID: 295
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		private static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, int dwFreeType);

		// Token: 0x06000128 RID: 296
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		// Token: 0x06000129 RID: 297
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int CloseHandle(IntPtr hObject);

		// Token: 0x0600012A RID: 298
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x0600012B RID: 299
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x0600012C RID: 300
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x0600012D RID: 301
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [MarshalAs(UnmanagedType.AsAny)] object lpBuffer, int dwSize, out IntPtr lpNumberOfBytesWritten);

		// Token: 0x0600012E RID: 302
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600012F RID: 303 RVA: 0x0000DD3C File Offset: 0x0000BF3C
		// (remove) Token: 0x06000130 RID: 304 RVA: 0x0000DD74 File Offset: 0x0000BF74
		public event API.AttachMessageEventHandler AttachMessage;

		// Token: 0x06000131 RID: 305
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool WaitNamedPipe(string name, int timeout);

		// Token: 0x06000132 RID: 306
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
		private static extern uint LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);

		// Token: 0x06000133 RID: 307
		[DllImport("bin\\oxygen_auth.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool verify_auth(string key);

		// Token: 0x06000134 RID: 308
		[DllImport("bin\\CometAuth.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool Verify([MarshalAs(UnmanagedType.LPStr)] string key);

		// Token: 0x06000135 RID: 309
		[DllImport("Kernel32.dll")]
		public static extern bool FreeLibrary(IntPtr hLibModule);

		// Token: 0x06000136 RID: 310 RVA: 0x0000DDAC File Offset: 0x0000BFAC
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public void Execute(string script, string api)
		{
			if (script.Length == 0)
			{
				return;
			}
			Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
			string pipe = this.Get(api);
			if (processesByName.Length != 0 && this.Exists(pipe, 0))
			{
				this.Send(pipe, script, 50);
				return;
			}
			API.AttachMessageEventHandler attachMessage = this.AttachMessage;
			if (attachMessage == null)
			{
				return;
			}
			attachMessage(this, API.AttachStrings.NOT_INJECTED);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000DE00 File Offset: 0x0000C000
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public void Inject(string api)
		{
			int num;
			if (API.IDOverride != 0)
			{
				num = API.IDOverride;
				API.IDOverride = 0;
			}
			else
			{
				Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
				if (processesByName.Length == 0)
				{
					API.AttachMessageEventHandler attachMessage = this.AttachMessage;
					if (attachMessage == null)
					{
						return;
					}
					attachMessage(this, API.AttachStrings.NO_PROCESS);
					return;
				}
				else
				{
					string pipe = this.Get(Globals.Options.SelectedAPI);
					if (this.Exists(pipe, 0))
					{
						API.AttachMessageEventHandler attachMessage2 = this.AttachMessage;
						if (attachMessage2 == null)
						{
							return;
						}
						attachMessage2(this, API.AttachStrings.ALREADY_INJECTED);
						return;
					}
					else
					{
						num = processesByName[0].Id;
					}
				}
			}
			API.AttachMessageEventHandler attachMessage3 = this.AttachMessage;
			if (attachMessage3 != null)
			{
				attachMessage3(this, API.AttachStrings.CHECKING);
			}
			string text;
			if (!(api == "WeAreDevs"))
			{
				if (!(api == "Oxygen"))
				{
					if (!(api == "Krnl"))
					{
						if (!(api == "oydECfGU5Z"))
						{
							text = "";
						}
						else
						{
							text = "oydECfGU5Z.dll";
						}
					}
					else
					{
						text = "Krnl.dll";
					}
				}
				else
				{
					text = "oxygen.dll";
				}
			}
			else
			{
				text = "exploit-main.dll";
			}
			API.IDTemp = num;
			API.AttachMessageEventHandler attachMessage4 = this.AttachMessage;
			if (attachMessage4 != null)
			{
				attachMessage4(this, API.AttachStrings.CHECKING);
			}
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			Web.DownloadDLL(text);
			if (text == "oxygen.dll")
			{
				if (File.Exists("bin\\oxygen_key.data"))
				{
					if (!API.verify_auth(File.ReadAllText("bin\\oxygen_key.data")))
					{
						Globals.KeySys.FormName = "Oxygen";
						Globals.KeySys.KeyType = 1;
						if (Globals.KeySys.ShowDialog() != DialogResult.OK)
						{
							return;
						}
					}
				}
				else
				{
					Globals.KeySys.FormName = "Oxygen";
					Globals.KeySys.KeyType = 1;
					if (Globals.KeySys.ShowDialog() != DialogResult.OK)
					{
						return;
					}
				}
			}
			else if (text == "oydECfGU5Z.dll")
			{
				if (File.Exists("bin\\comet_key.data"))
				{
					if (!API.Verify(File.ReadAllText("bin\\comet_key.data")))
					{
						Globals.KeySys.FormName = "Comet";
						Globals.KeySys.KeyType = 2;
						if (Globals.KeySys.ShowDialog() != DialogResult.OK)
						{
							return;
						}
					}
				}
				else
				{
					Globals.KeySys.FormName = "Comet";
					Globals.KeySys.KeyType = 2;
					if (Globals.KeySys.ShowDialog() != DialogResult.OK)
					{
						return;
					}
				}
			}
			API.AttachMessageEventHandler attachMessage5 = this.AttachMessage;
			if (attachMessage5 != null)
			{
				attachMessage5(this, API.AttachStrings.INJECTING);
			}
			this.aaInject(text, Convert.ToUInt32(num));
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000E034 File Offset: 0x0000C234
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public string Get(string api)
		{
			if (api == "WeAreDevs")
			{
				return "WeAreDevsPublicAPI_Lua";
			}
			if (api == "Oxygen")
			{
				return "OxygenU";
			}
			if (api == "Krnl")
			{
				return "krnlpipe";
			}
			if (!(api == "oydECfGU5Z"))
			{
				return "";
			}
			return "CometPipe";
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000E094 File Offset: 0x0000C294
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public void Send(string pipe, string data, int timeout = 0)
		{
			NamedPipeClientStream namedPipeClientStream = null;
			try
			{
				namedPipeClientStream = new NamedPipeClientStream(".", pipe, PipeDirection.Out);
				namedPipeClientStream.Connect(timeout);
				using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
				{
					streamWriter.Write(data);
					if (streamWriter != null)
					{
						streamWriter.Dispose();
					}
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (namedPipeClientStream != null)
				{
					namedPipeClientStream.Dispose();
				}
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000E114 File Offset: 0x0000C314
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public bool Exists(string pipe, int timeout = 0)
		{
			bool result;
			try
			{
				if (!API.WaitNamedPipe("\\\\.\\pipe\\" + pipe, timeout))
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					if (lastWin32Error == 0)
					{
						return false;
					}
					if (lastWin32Error == 2)
					{
						return false;
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000E164 File Offset: 0x0000C364
		public bool Load(string libPath = "")
		{
			if (API.plibdll == IntPtr.Zero)
			{
				if (libPath == "")
				{
					libPath = Path.GetFullPath("bin\\injector.dll");
				}
				API.plibdll = (IntPtr)((long)((ulong)API.LoadLibrary(libPath)));
				if (API.plibdll == IntPtr.Zero)
				{
					return false;
				}
			}
			IntPtr procAddress = API.GetProcAddress(API.plibdll, "inject");
			if (procAddress == IntPtr.Zero)
			{
				return false;
			}
			API.pinject = Marshal.GetDelegateForFunctionPointer<API.inject>(procAddress);
			return true;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000E1EA File Offset: 0x0000C3EA
		public static API.inject_status dllinject(string dllpath)
		{
			if (API.pinject != null)
			{
				return API.pinject(dllpath);
			}
			return API.inject_status.failure;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000E200 File Offset: 0x0000C400
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void aaInject(string dll, uint id)
		{
			try
			{
				Injector.DllInjector.GetInstance.Inject("RobloxPlayerBeta", Path.GetFullPath(dll));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				API.AttachMessageEventHandler attachMessage = this.AttachMessage;
				if (attachMessage != null)
				{
					attachMessage(this, API.AttachStrings.FAILED_INJECT);
				}
				return;
			}
			this.PipeTimer.Tick += this.PipeTimer_Tick;
			this.PipeTimer.Interval = 500;
			this.PipeTimer.Start();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000E288 File Offset: 0x0000C488
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void PipeTimer_Tick(object sender, EventArgs e)
		{
			string pipe = this.Get(Globals.Options.SelectedAPI);
			if (this.Exists(pipe, 0))
			{
				API.AttachMessageEventHandler attachMessage = this.AttachMessage;
				if (attachMessage != null)
				{
					attachMessage(this, API.AttachStrings.INJECTED);
				}
				API.AttachMessageEventHandler attachMessage2 = this.AttachMessage;
				if (attachMessage2 != null)
				{
					attachMessage2(this, API.AttachStrings.READY);
				}
				this.PipeTimer.Stop();
				return;
			}
		}

		// Token: 0x0400009A RID: 154
		public Timer PipeTimer = new Timer();

		// Token: 0x0400009B RID: 155
		public IntPtr z = (IntPtr)0;

		// Token: 0x0400009D RID: 157
		private static API.inject pinject;

		// Token: 0x0400009E RID: 158
		private static IntPtr plibdll;

		// Token: 0x0400009F RID: 159
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public static int ID;

		// Token: 0x040000A0 RID: 160
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public static int IDTemp;

		// Token: 0x040000A1 RID: 161
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public static int IDOverride;

		// Token: 0x02000023 RID: 35
		public enum AttachStrings
		{
			// Token: 0x040000F7 RID: 247
			CHECKING,
			// Token: 0x040000F8 RID: 248
			INJECTING,
			// Token: 0x040000F9 RID: 249
			INJECTED,
			// Token: 0x040000FA RID: 250
			READY,
			// Token: 0x040000FB RID: 251
			ALREADY_INJECTED,
			// Token: 0x040000FC RID: 252
			NO_PROCESS,
			// Token: 0x040000FD RID: 253
			NOT_INJECTED,
			// Token: 0x040000FE RID: 254
			FAILED_INJECT
		}

		// Token: 0x02000024 RID: 36
		public enum inject_status
		{
			// Token: 0x04000100 RID: 256
			failure = -1,
			// Token: 0x04000101 RID: 257
			success,
			// Token: 0x04000102 RID: 258
			loadimage_fail,
			// Token: 0x04000103 RID: 259
			no_rbx_proc
		}

		// Token: 0x02000025 RID: 37
		// (Invoke) Token: 0x060001BC RID: 444
		public delegate void AttachMessageEventHandler(object sender, API.AttachStrings str);

		// Token: 0x02000026 RID: 38
		// (Invoke) Token: 0x060001C0 RID: 448
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate API.inject_status inject(string dllpath);
	}
}

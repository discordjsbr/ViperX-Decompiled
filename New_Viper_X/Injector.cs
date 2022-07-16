using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace New_Viper_X
{
	// Token: 0x02000002 RID: 2
	internal class Injector
	{
		// Token: 0x02000011 RID: 17
		public enum DllInjectionResult
		{
			// Token: 0x040000B9 RID: 185
			DllNotFound,
			// Token: 0x040000BA RID: 186
			GameProcessNotFound,
			// Token: 0x040000BB RID: 187
			InjectionFailed,
			// Token: 0x040000BC RID: 188
			Success
		}

		// Token: 0x02000012 RID: 18
		public sealed class DllInjector
		{
			// Token: 0x0600016F RID: 367
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x06000170 RID: 368
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern int CloseHandle(IntPtr hObject);

			// Token: 0x06000171 RID: 369
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

			// Token: 0x06000172 RID: 370
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GetModuleHandle(string lpModuleName);

			// Token: 0x06000173 RID: 371
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x06000174 RID: 372
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

			// Token: 0x06000175 RID: 373
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

			// Token: 0x1700006C RID: 108
			// (get) Token: 0x06000176 RID: 374 RVA: 0x0000FCB3 File Offset: 0x0000DEB3
			public static Injector.DllInjector GetInstance
			{
				get
				{
					if (Injector.DllInjector._instance == null)
					{
						Injector.DllInjector._instance = new Injector.DllInjector();
					}
					return Injector.DllInjector._instance;
				}
			}

			// Token: 0x06000177 RID: 375 RVA: 0x0000FCCB File Offset: 0x0000DECB
			private DllInjector()
			{
			}

			// Token: 0x06000178 RID: 376 RVA: 0x0000FCD4 File Offset: 0x0000DED4
			public Injector.DllInjectionResult Inject(string sProcName, string sDllPath)
			{
				if (!File.Exists(sDllPath))
				{
					return Injector.DllInjectionResult.DllNotFound;
				}
				uint num = 0U;
				Process[] processes = Process.GetProcesses();
				for (int i = 0; i < processes.Length; i++)
				{
					if (processes[i].ProcessName == sProcName)
					{
						num = (uint)processes[i].Id;
						break;
					}
				}
				if (num == 0U)
				{
					return Injector.DllInjectionResult.GameProcessNotFound;
				}
				if (!this.bInject(num, sDllPath))
				{
					return Injector.DllInjectionResult.InjectionFailed;
				}
				return Injector.DllInjectionResult.Success;
			}

			// Token: 0x06000179 RID: 377 RVA: 0x0000FD30 File Offset: 0x0000DF30
			private bool bInject(uint pToBeInjected, string sDllPath)
			{
				IntPtr intPtr = Injector.DllInjector.OpenProcess(1082U, 1, pToBeInjected);
				if (intPtr == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				IntPtr procAddress = Injector.DllInjector.GetProcAddress(Injector.DllInjector.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
				if (procAddress == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				IntPtr intPtr2 = Injector.DllInjector.VirtualAllocEx(intPtr, (IntPtr)null, (IntPtr)sDllPath.Length, 12288U, 64U);
				if (intPtr2 == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);
				if (Injector.DllInjector.WriteProcessMemory(intPtr, intPtr2, bytes, (uint)bytes.Length, 0) == 0)
				{
					return false;
				}
				if (Injector.DllInjector.CreateRemoteThread(intPtr, (IntPtr)null, Injector.DllInjector.INTPTR_ZERO, procAddress, intPtr2, 0U, (IntPtr)null) == Injector.DllInjector.INTPTR_ZERO)
				{
					return false;
				}
				Injector.DllInjector.CloseHandle(intPtr);
				return true;
			}

			// Token: 0x040000BD RID: 189
			private static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

			// Token: 0x040000BE RID: 190
			private static Injector.DllInjector _instance;
		}
	}
}

using System;
using System.Windows.Forms;

namespace New_Viper_X
{
	// Token: 0x02000006 RID: 6
	internal static class Program
	{
		// Token: 0x06000070 RID: 112 RVA: 0x0000C076 File Offset: 0x0000A276
		[STAThread]
		[Obsolete]
		private static void Main()
		{
			AppDomain.CurrentDomain.AppendPrivatePath("bin");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Loading());
		}
	}
}

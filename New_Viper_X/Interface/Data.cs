using System;
using System.Collections.Generic;

namespace New_Viper_X.Interface
{
	// Token: 0x0200000D RID: 13
	public static class Data
	{
		// Token: 0x02000027 RID: 39
		public class Options
		{
			// Token: 0x04000104 RID: 260
			public string SelectedAPI;

			// Token: 0x04000105 RID: 261
			public bool TopMost;

			// Token: 0x04000106 RID: 262
			public bool Animations;

			// Token: 0x04000107 RID: 263
			public bool RPC;

			// Token: 0x04000108 RID: 264
			public bool RblxUnlocker;

			// Token: 0x04000109 RID: 265
			public bool ExtremeIJ;

			// Token: 0x0400010A RID: 266
			public bool AutoInject;
		}

		// Token: 0x02000028 RID: 40
		public class User
		{
			// Token: 0x0400010B RID: 267
			public string Name;

			// Token: 0x0400010C RID: 268
			public string Image;
		}

		// Token: 0x02000029 RID: 41
		public class UI
		{
			// Token: 0x0400010D RID: 269
			public string Version;
		}

		// Token: 0x0200002A RID: 42
		public class Lingua
		{
			// Token: 0x0400010E RID: 270
			public string Linguagem;
		}

		// Token: 0x0200002B RID: 43
		public class Theme
		{
			// Token: 0x0400010F RID: 271
			public string Image;
		}

		// Token: 0x0200002C RID: 44
		public class ScriptHubData
		{
			// Token: 0x04000110 RID: 272
			public string SCRIPT_NAME;

			// Token: 0x04000111 RID: 273
			public string SCRIPT_URL;

			// Token: 0x04000112 RID: 274
			public string SCRIPT_DESCRIPTION;

			// Token: 0x04000113 RID: 275
			public string SCRIPT_IMAGE;
		}

		// Token: 0x0200002D RID: 45
		public class ScriptHubHolder
		{
			// Token: 0x04000114 RID: 276
			public List<Data.ScriptHubData> SCRIPTS;
		}
	}
}

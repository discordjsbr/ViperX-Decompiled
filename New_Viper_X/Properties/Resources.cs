using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace New_Viper_X.Properties
{
	// Token: 0x02000007 RID: 7
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000071 RID: 113 RVA: 0x0000C09C File Offset: 0x0000A29C
		internal Resources()
		{
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000072 RID: 114 RVA: 0x0000C0A4 File Offset: 0x0000A2A4
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("New_Viper_X.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000073 RID: 115 RVA: 0x0000C0D0 File Offset: 0x0000A2D0
		// (set) Token: 0x06000074 RID: 116 RVA: 0x0000C0D7 File Offset: 0x0000A2D7
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000075 RID: 117 RVA: 0x0000C0DF File Offset: 0x0000A2DF
		internal static Bitmap creditos
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("creditos", Resources.resourceCulture);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000076 RID: 118 RVA: 0x0000C0FA File Offset: 0x0000A2FA
		internal static Bitmap executor
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("executor", Resources.resourceCulture);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000077 RID: 119 RVA: 0x0000C115 File Offset: 0x0000A315
		internal static Bitmap Inicio
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("Inicio", Resources.resourceCulture);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000078 RID: 120 RVA: 0x0000C130 File Offset: 0x0000A330
		internal static Bitmap opcoes
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("opcoes", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000079 RID: 121 RVA: 0x0000C14B File Offset: 0x0000A34B
		internal static Bitmap scripthub
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("scripthub", Resources.resourceCulture);
			}
		}

		// Token: 0x0400008A RID: 138
		private static ResourceManager resourceMan;

		// Token: 0x0400008B RID: 139
		private static CultureInfo resourceCulture;
	}
}

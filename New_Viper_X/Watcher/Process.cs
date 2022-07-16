using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Management;

namespace New_Viper_X.Watcher
{
	// Token: 0x02000009 RID: 9
	public class Process
	{
		// Token: 0x0600007D RID: 125 RVA: 0x0000C18B File Offset: 0x0000A38B
		public Process()
		{
			this.InitializeObject(null, null, null);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000C19C File Offset: 0x0000A39C
		public Process(string keyHandle)
		{
			this.InitializeObject(null, new ManagementPath(Process.ConstructPath(keyHandle)), null);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000C1B7 File Offset: 0x0000A3B7
		public Process(ManagementScope mgmtScope, string keyHandle)
		{
			this.InitializeObject(mgmtScope, new ManagementPath(Process.ConstructPath(keyHandle)), null);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000C1D2 File Offset: 0x0000A3D2
		public Process(ManagementPath path, ObjectGetOptions getOptions)
		{
			this.InitializeObject(null, path, getOptions);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000C1E3 File Offset: 0x0000A3E3
		public Process(ManagementScope mgmtScope, ManagementPath path)
		{
			this.InitializeObject(mgmtScope, path, null);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000C1F4 File Offset: 0x0000A3F4
		public Process(ManagementPath path)
		{
			this.InitializeObject(null, path, null);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000C205 File Offset: 0x0000A405
		public Process(ManagementScope mgmtScope, ManagementPath path, ObjectGetOptions getOptions)
		{
			this.InitializeObject(mgmtScope, path, getOptions);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000C218 File Offset: 0x0000A418
		public Process(ManagementObject theObject)
		{
			this.Initialize();
			if (this.CheckIfProperClass(theObject))
			{
				this.PrivateLateBoundObject = theObject;
				this.PrivateSystemProperties = new Process.ManagementSystemProperties(this.PrivateLateBoundObject);
				this.curObj = this.PrivateLateBoundObject;
				return;
			}
			throw new ArgumentException("Class name does not match.");
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000C26C File Offset: 0x0000A46C
		public Process(ManagementBaseObject theObject)
		{
			this.Initialize();
			if (this.CheckIfProperClass(theObject))
			{
				this.embeddedObj = theObject;
				this.PrivateSystemProperties = new Process.ManagementSystemProperties(theObject);
				this.curObj = this.embeddedObj;
				this.isEmbedded = true;
				return;
			}
			throw new ArgumentException("Class name does not match.");
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000086 RID: 134 RVA: 0x0000C2BF File Offset: 0x0000A4BF
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string OriginatingNamespace
		{
			get
			{
				return "root\\cimv2";
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000087 RID: 135 RVA: 0x0000C2C8 File Offset: 0x0000A4C8
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string ManagementClassName
		{
			get
			{
				string text = Process.CreatedClassName;
				if (this.curObj != null && this.curObj.ClassPath != null)
				{
					text = (string)this.curObj["__CLASS"];
					if (text == null || text == string.Empty)
					{
						text = Process.CreatedClassName;
					}
				}
				return text;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000088 RID: 136 RVA: 0x0000C31D File Offset: 0x0000A51D
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Process.ManagementSystemProperties SystemProperties
		{
			get
			{
				return this.PrivateSystemProperties;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000089 RID: 137 RVA: 0x0000C325 File Offset: 0x0000A525
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ManagementBaseObject LateBoundObject
		{
			get
			{
				return this.curObj;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600008A RID: 138 RVA: 0x0000C32D File Offset: 0x0000A52D
		// (set) Token: 0x0600008B RID: 139 RVA: 0x0000C344 File Offset: 0x0000A544
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ManagementScope Scope
		{
			get
			{
				if (!this.isEmbedded)
				{
					return this.PrivateLateBoundObject.Scope;
				}
				return null;
			}
			set
			{
				if (!this.isEmbedded)
				{
					this.PrivateLateBoundObject.Scope = value;
				}
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600008C RID: 140 RVA: 0x0000C35A File Offset: 0x0000A55A
		// (set) Token: 0x0600008D RID: 141 RVA: 0x0000C362 File Offset: 0x0000A562
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AutoCommit
		{
			get
			{
				return this.AutoCommitProp;
			}
			set
			{
				this.AutoCommitProp = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600008E RID: 142 RVA: 0x0000C36B File Offset: 0x0000A56B
		// (set) Token: 0x0600008F RID: 143 RVA: 0x0000C382 File Offset: 0x0000A582
		[Browsable(true)]
		public ManagementPath Path
		{
			get
			{
				if (!this.isEmbedded)
				{
					return this.PrivateLateBoundObject.Path;
				}
				return null;
			}
			set
			{
				if (!this.isEmbedded)
				{
					if (!this.CheckIfProperClass(null, value, null))
					{
						throw new ArgumentException("Class name does not match.");
					}
					this.PrivateLateBoundObject.Path = value;
				}
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000090 RID: 144 RVA: 0x0000C3AE File Offset: 0x0000A5AE
		// (set) Token: 0x06000091 RID: 145 RVA: 0x0000C3B5 File Offset: 0x0000A5B5
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static ManagementScope StaticScope
		{
			get
			{
				return Process.statMgmtScope;
			}
			set
			{
				Process.statMgmtScope = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000092 RID: 146 RVA: 0x0000C3BD File Offset: 0x0000A5BD
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The Caption property is a short textual description (one-line string) of the object.")]
		public string Caption
		{
			get
			{
				return (string)this.curObj["Caption"];
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000093 RID: 147 RVA: 0x0000C3D4 File Offset: 0x0000A5D4
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The CommandLine property specifies the command line used to start a particular process, if applicable.")]
		public string CommandLine
		{
			get
			{
				return (string)this.curObj["CommandLine"];
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000094 RID: 148 RVA: 0x0000C3EB File Offset: 0x0000A5EB
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("CreationClassName indicates the name of the class or the subclass used in the creation of an instance. When used with the other key properties of this class, this property allows all instances of this class and its subclasses to be uniquely identified.")]
		public string CreationClassName
		{
			get
			{
				return (string)this.curObj["CreationClassName"];
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000095 RID: 149 RVA: 0x0000C402 File Offset: 0x0000A602
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsCreationDateNull
		{
			get
			{
				return this.curObj["CreationDate"] == null;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000096 RID: 150 RVA: 0x0000C419 File Offset: 0x0000A619
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Time that the process began executing.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public DateTime CreationDate
		{
			get
			{
				if (this.curObj["CreationDate"] != null)
				{
					return Process.ToDateTime((string)this.curObj["CreationDate"]);
				}
				return DateTime.MinValue;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000097 RID: 151 RVA: 0x0000C44D File Offset: 0x0000A64D
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("CSCreationClassName contains the scoping computer system's creation class name.")]
		public string CSCreationClassName
		{
			get
			{
				return (string)this.curObj["CSCreationClassName"];
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000098 RID: 152 RVA: 0x0000C464 File Offset: 0x0000A664
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The scoping computer system's name.")]
		public string CSName
		{
			get
			{
				return (string)this.curObj["CSName"];
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000099 RID: 153 RVA: 0x0000C47B File Offset: 0x0000A67B
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The Description property provides a textual description of the object. ")]
		public string Description
		{
			get
			{
				return (string)this.curObj["Description"];
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600009A RID: 154 RVA: 0x0000C492 File Offset: 0x0000A692
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The ExecutablePath property indicates the path to the executable file of the process.\nExample: C:\\WINDOWS\\EXPLORER.EXE")]
		public string ExecutablePath
		{
			get
			{
				return (string)this.curObj["ExecutablePath"];
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600009B RID: 155 RVA: 0x0000C4A9 File Offset: 0x0000A6A9
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsExecutionStateNull
		{
			get
			{
				return this.curObj["ExecutionState"] == null;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600009C RID: 156 RVA: 0x0000C4C0 File Offset: 0x0000A6C0
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Indicates the current operating condition of the process. Values include ready (2), running (3), and blocked (4), among others.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public Process.ExecutionStateValues ExecutionState
		{
			get
			{
				if (this.curObj["ExecutionState"] == null)
				{
					return (Process.ExecutionStateValues)Convert.ToInt32(10);
				}
				return (Process.ExecutionStateValues)Convert.ToInt32(this.curObj["ExecutionState"]);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600009D RID: 157 RVA: 0x0000C4F1 File Offset: 0x0000A6F1
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("A string used to identify the process. A process ID is a kind of process handle.")]
		public string Handle
		{
			get
			{
				return (string)this.curObj["Handle"];
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000C508 File Offset: 0x0000A708
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsHandleCountNull
		{
			get
			{
				return this.curObj["HandleCount"] == null;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600009F RID: 159 RVA: 0x0000C51F File Offset: 0x0000A71F
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The HandleCount property specifies the total number of handles currently open by this process. This number is the sum of the handles currently open by each thread in this process. A handle is used to examine or modify the system resources. Each handle has an entry in an internally maintained table. These entries contain the addresses of the resources and the means to identify the resource type.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint HandleCount
		{
			get
			{
				if (this.curObj["HandleCount"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["HandleCount"];
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x0000C54F File Offset: 0x0000A74F
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsInstallDateNull
		{
			get
			{
				return this.curObj["InstallDate"] == null;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x0000C566 File Offset: 0x0000A766
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The InstallDate property is datetime value indicating when the object was installed. A lack of a value does not indicate that the object is not installed.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public DateTime InstallDate
		{
			get
			{
				if (this.curObj["InstallDate"] != null)
				{
					return Process.ToDateTime((string)this.curObj["InstallDate"]);
				}
				return DateTime.MinValue;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x0000C59A File Offset: 0x0000A79A
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsKernelModeTimeNull
		{
			get
			{
				return this.curObj["KernelModeTime"] == null;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x0000C5B1 File Offset: 0x0000A7B1
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Time in kernel mode, in 100 nanoseconds. If this information is not available, a value of 0 should be used.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong KernelModeTime
		{
			get
			{
				if (this.curObj["KernelModeTime"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["KernelModeTime"];
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x0000C5E1 File Offset: 0x0000A7E1
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsMaximumWorkingSetSizeNull
		{
			get
			{
				return this.curObj["MaximumWorkingSetSize"] == null;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x0000C5F8 File Offset: 0x0000A7F8
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The MaximumWorkingSetSize property indicates the maximum working set size of the process. The working set of a process is the set of memory pages currently visible to the process in physical RAM. These pages are resident and available for an application to use without triggering a page fault.\r\nExample: 1413120.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint MaximumWorkingSetSize
		{
			get
			{
				if (this.curObj["MaximumWorkingSetSize"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["MaximumWorkingSetSize"];
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x0000C628 File Offset: 0x0000A828
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsMinimumWorkingSetSizeNull
		{
			get
			{
				return this.curObj["MinimumWorkingSetSize"] == null;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x0000C63F File Offset: 0x0000A83F
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The MinimumWorkingSetSize property indicates the minimum working set size of the process. The working set of a process is the set of memory pages currently visible to the process in physical RAM. These pages are resident and available for an application to use without triggering a page fault.\r\nExample: 20480.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint MinimumWorkingSetSize
		{
			get
			{
				if (this.curObj["MinimumWorkingSetSize"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["MinimumWorkingSetSize"];
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x0000C66F File Offset: 0x0000A86F
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The Name property defines the label by which the object is known. When subclassed, the Name property can be overridden to be a Key property.")]
		public string Name
		{
			get
			{
				return (string)this.curObj["Name"];
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x0000C686 File Offset: 0x0000A886
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The scoping operating system's creation class name.")]
		public string OSCreationClassName
		{
			get
			{
				return (string)this.curObj["OSCreationClassName"];
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000AA RID: 170 RVA: 0x0000C69D File Offset: 0x0000A89D
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The scoping operating system's name.")]
		public string OSName
		{
			get
			{
				return (string)this.curObj["OSName"];
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000AB RID: 171 RVA: 0x0000C6B4 File Offset: 0x0000A8B4
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsOtherOperationCountNull
		{
			get
			{
				return this.curObj["OtherOperationCount"] == null;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000AC RID: 172 RVA: 0x0000C6CB File Offset: 0x0000A8CB
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The OtherOperationCount property specifies the number of I/O operations performed, other than read and write operations.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong OtherOperationCount
		{
			get
			{
				if (this.curObj["OtherOperationCount"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["OtherOperationCount"];
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000AD RID: 173 RVA: 0x0000C6FB File Offset: 0x0000A8FB
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsOtherTransferCountNull
		{
			get
			{
				return this.curObj["OtherTransferCount"] == null;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000AE RID: 174 RVA: 0x0000C712 File Offset: 0x0000A912
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The OtherTransferCount property specifies the amount of data transferred during operations other than read and write operations.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong OtherTransferCount
		{
			get
			{
				if (this.curObj["OtherTransferCount"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["OtherTransferCount"];
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000AF RID: 175 RVA: 0x0000C742 File Offset: 0x0000A942
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsPageFaultsNull
		{
			get
			{
				return this.curObj["PageFaults"] == null;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000C759 File Offset: 0x0000A959
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The PageFaults property indicates the number of page faults generated by the process.\nExample: 10")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint PageFaults
		{
			get
			{
				if (this.curObj["PageFaults"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["PageFaults"];
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x0000C789 File Offset: 0x0000A989
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsPageFileUsageNull
		{
			get
			{
				return this.curObj["PageFileUsage"] == null;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x0000C7A0 File Offset: 0x0000A9A0
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The PageFileUsage property indicates the amountof page file space currently being used by the process.\nExample: 102435")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint PageFileUsage
		{
			get
			{
				if (this.curObj["PageFileUsage"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["PageFileUsage"];
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x0000C7D0 File Offset: 0x0000A9D0
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsParentProcessIdNull
		{
			get
			{
				return this.curObj["ParentProcessId"] == null;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x0000C7E7 File Offset: 0x0000A9E7
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The ParentProcessId property specifies the unique identifier of the process that created this process. Process identifier numbers are reused, so they only identify a process for the lifetime of that process. It is possible that the process identified by ParentProcessId has terminated, so ParentProcessId may not refer to an running process. It is also possible that ParentProcessId incorrectly refers to a process which re-used that process identifier. The CreationDate property can be used to determine whether the specified parent was created after this process was created.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint ParentProcessId
		{
			get
			{
				if (this.curObj["ParentProcessId"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["ParentProcessId"];
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x0000C817 File Offset: 0x0000AA17
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsPeakPageFileUsageNull
		{
			get
			{
				return this.curObj["PeakPageFileUsage"] == null;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x0000C82E File Offset: 0x0000AA2E
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The PeakPageFileUsage property indicates the maximum amount of page file space  used during the life of the process.\nExample: 102367")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint PeakPageFileUsage
		{
			get
			{
				if (this.curObj["PeakPageFileUsage"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["PeakPageFileUsage"];
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x0000C85E File Offset: 0x0000AA5E
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsPeakVirtualSizeNull
		{
			get
			{
				return this.curObj["PeakVirtualSize"] == null;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x0000C875 File Offset: 0x0000AA75
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The PeakVirtualSize property specifies the maximum virtual address space the process has used at any one time. Use of virtual address space does not necessarily imply corresponding use of either disk or main memory pages. However, virtual space is finite, and by using too much, the process might limit its ability to load libraries.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong PeakVirtualSize
		{
			get
			{
				if (this.curObj["PeakVirtualSize"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["PeakVirtualSize"];
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x0000C8A5 File Offset: 0x0000AAA5
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsPeakWorkingSetSizeNull
		{
			get
			{
				return this.curObj["PeakWorkingSetSize"] == null;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000BA RID: 186 RVA: 0x0000C8BC File Offset: 0x0000AABC
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The PeakWorkingSetSize property indicates the peak working set size of the process.\nExample: 1413120")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint PeakWorkingSetSize
		{
			get
			{
				if (this.curObj["PeakWorkingSetSize"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["PeakWorkingSetSize"];
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000BB RID: 187 RVA: 0x0000C8EC File Offset: 0x0000AAEC
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsPriorityNull
		{
			get
			{
				return this.curObj["Priority"] == null;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000BC RID: 188 RVA: 0x0000C903 File Offset: 0x0000AB03
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The Priority property indicates the scheduling priority of the process within the operating system. The higher the value, the higher priority the process receives. Priority values can range from 0 (lowest priority) to 31 (highest priority).\nExample: 7.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint Priority
		{
			get
			{
				if (this.curObj["Priority"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["Priority"];
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000BD RID: 189 RVA: 0x0000C933 File Offset: 0x0000AB33
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsPrivatePageCountNull
		{
			get
			{
				return this.curObj["PrivatePageCount"] == null;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000BE RID: 190 RVA: 0x0000C94A File Offset: 0x0000AB4A
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The PrivatePageCount property specifies the current number of pages allocated that are accessible only to this process ")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong PrivatePageCount
		{
			get
			{
				if (this.curObj["PrivatePageCount"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["PrivatePageCount"];
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000BF RID: 191 RVA: 0x0000C97A File Offset: 0x0000AB7A
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsProcessIdNull
		{
			get
			{
				return this.curObj["ProcessId"] == null;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x0000C991 File Offset: 0x0000AB91
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The ProcessId property contains the global process identifier that can be used to identify a process. The value is valid from the creation of the process until the process is terminated.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint ProcessId
		{
			get
			{
				if (this.curObj["ProcessId"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["ProcessId"];
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x0000C9C1 File Offset: 0x0000ABC1
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsQuotaNonPagedPoolUsageNull
		{
			get
			{
				return this.curObj["QuotaNonPagedPoolUsage"] == null;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x0000C9D8 File Offset: 0x0000ABD8
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The QuotaNonPagedPoolUsage property indicates the quota amount of non-paged pool usage for the process.\nExample: 15")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint QuotaNonPagedPoolUsage
		{
			get
			{
				if (this.curObj["QuotaNonPagedPoolUsage"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["QuotaNonPagedPoolUsage"];
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x0000CA08 File Offset: 0x0000AC08
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsQuotaPagedPoolUsageNull
		{
			get
			{
				return this.curObj["QuotaPagedPoolUsage"] == null;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x0000CA1F File Offset: 0x0000AC1F
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The QuotaPagedPoolUsage property indicates the quota amount of paged pool usage for the process.\nExample: 22")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint QuotaPagedPoolUsage
		{
			get
			{
				if (this.curObj["QuotaPagedPoolUsage"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["QuotaPagedPoolUsage"];
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x0000CA4F File Offset: 0x0000AC4F
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsQuotaPeakNonPagedPoolUsageNull
		{
			get
			{
				return this.curObj["QuotaPeakNonPagedPoolUsage"] == null;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x0000CA66 File Offset: 0x0000AC66
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The QuotaPeakNonPagedPoolUsage property indicates the peak quota amount of non-paged pool usage for the process.\nExample: 31")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint QuotaPeakNonPagedPoolUsage
		{
			get
			{
				if (this.curObj["QuotaPeakNonPagedPoolUsage"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["QuotaPeakNonPagedPoolUsage"];
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x0000CA96 File Offset: 0x0000AC96
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsQuotaPeakPagedPoolUsageNull
		{
			get
			{
				return this.curObj["QuotaPeakPagedPoolUsage"] == null;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x0000CAAD File Offset: 0x0000ACAD
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The QuotaPeakPagedPoolUsage property indicates the peak quota amount of paged pool usage for the process.\n Example: 31")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint QuotaPeakPagedPoolUsage
		{
			get
			{
				if (this.curObj["QuotaPeakPagedPoolUsage"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["QuotaPeakPagedPoolUsage"];
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x0000CADD File Offset: 0x0000ACDD
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsReadOperationCountNull
		{
			get
			{
				return this.curObj["ReadOperationCount"] == null;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000CA RID: 202 RVA: 0x0000CAF4 File Offset: 0x0000ACF4
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The ReadOperationCount property specifies the number of read operations performed.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong ReadOperationCount
		{
			get
			{
				if (this.curObj["ReadOperationCount"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["ReadOperationCount"];
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000CB RID: 203 RVA: 0x0000CB24 File Offset: 0x0000AD24
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsReadTransferCountNull
		{
			get
			{
				return this.curObj["ReadTransferCount"] == null;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000CC RID: 204 RVA: 0x0000CB3B File Offset: 0x0000AD3B
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The ReadTransferCount property specifies the amount of data read.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong ReadTransferCount
		{
			get
			{
				if (this.curObj["ReadTransferCount"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["ReadTransferCount"];
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000CD RID: 205 RVA: 0x0000CB6B File Offset: 0x0000AD6B
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsSessionIdNull
		{
			get
			{
				return this.curObj["SessionId"] == null;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000CE RID: 206 RVA: 0x0000CB82 File Offset: 0x0000AD82
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The SessionId property specifies the unique identifier that is generated by the operating system when the session is created. A session spans a period of time from log in to log out on a particular system.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint SessionId
		{
			get
			{
				if (this.curObj["SessionId"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["SessionId"];
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000CF RID: 207 RVA: 0x0000CBB2 File Offset: 0x0000ADB2
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The Status property is a string indicating the current status of the object. Various operational and non-operational statuses can be defined. Operational statuses are \"OK\", \"Degraded\" and \"Pred Fail\". \"Pred Fail\" indicates that an element may be functioning properly but predicting a failure in the near future. An example is a SMART-enabled hard drive. Non-operational statuses can also be specified. These are \"Error\", \"Starting\", \"Stopping\" and \"Service\". The latter, \"Service\", could apply during mirror-resilvering of a disk, reload of a user permissions list, or other administrative work. Not all such work is on-line, yet the managed element is neither \"OK\" nor in one of the other states.")]
		public string Status
		{
			get
			{
				return (string)this.curObj["Status"];
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x0000CBC9 File Offset: 0x0000ADC9
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsTerminationDateNull
		{
			get
			{
				return this.curObj["TerminationDate"] == null;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x0000CBE0 File Offset: 0x0000ADE0
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Time that the process was stopped or terminated.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public DateTime TerminationDate
		{
			get
			{
				if (this.curObj["TerminationDate"] != null)
				{
					return Process.ToDateTime((string)this.curObj["TerminationDate"]);
				}
				return DateTime.MinValue;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x0000CC14 File Offset: 0x0000AE14
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsThreadCountNull
		{
			get
			{
				return this.curObj["ThreadCount"] == null;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x0000CC2B File Offset: 0x0000AE2B
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The ThreadCount property specifies the number of active threads in this process. An instruction is the basic unit of execution in a processor, and a thread is the object that executes instructions. Every running process has at least one thread. This property is for computers running Windows NT only.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public uint ThreadCount
		{
			get
			{
				if (this.curObj["ThreadCount"] == null)
				{
					return Convert.ToUInt32(0);
				}
				return (uint)this.curObj["ThreadCount"];
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x0000CC5B File Offset: 0x0000AE5B
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsUserModeTimeNull
		{
			get
			{
				return this.curObj["UserModeTime"] == null;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x0000CC72 File Offset: 0x0000AE72
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Time in user mode, in 100 nanoseconds. If this information is not available, a value of 0 should be used.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong UserModeTime
		{
			get
			{
				if (this.curObj["UserModeTime"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["UserModeTime"];
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x0000CCA2 File Offset: 0x0000AEA2
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsVirtualSizeNull
		{
			get
			{
				return this.curObj["VirtualSize"] == null;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x0000CCB9 File Offset: 0x0000AEB9
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The VirtualSize property specifies the current size in bytes of the virtual address space the process is using. Use of virtual address space does not necessarily imply corresponding use of either disk or main memory pages. Virtual space is finite, and by using too much, the process can limit its ability to load libraries.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong VirtualSize
		{
			get
			{
				if (this.curObj["VirtualSize"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["VirtualSize"];
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x0000CCE9 File Offset: 0x0000AEE9
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The WindowsVersion property indicates the version of Windows in which the process is running.\nExample: 4.0")]
		public string WindowsVersion
		{
			get
			{
				return (string)this.curObj["WindowsVersion"];
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x0000CD00 File Offset: 0x0000AF00
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsWorkingSetSizeNull
		{
			get
			{
				return this.curObj["WorkingSetSize"] == null;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000DA RID: 218 RVA: 0x0000CD17 File Offset: 0x0000AF17
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The amount of memory in bytes that a process needs to execute efficiently, for an operating system that uses page-based memory management. If an insufficient amount of memory is available (< working set size), thrashing will occur. If this information is not known, NULL or 0 should be entered.  If this data is provided, it could be monitored to understand a process' changing memory requirements as execution proceeds.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong WorkingSetSize
		{
			get
			{
				if (this.curObj["WorkingSetSize"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["WorkingSetSize"];
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000DB RID: 219 RVA: 0x0000CD47 File Offset: 0x0000AF47
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsWriteOperationCountNull
		{
			get
			{
				return this.curObj["WriteOperationCount"] == null;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000DC RID: 220 RVA: 0x0000CD5E File Offset: 0x0000AF5E
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The WriteOperationCount property specifies the number of write operations performed.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong WriteOperationCount
		{
			get
			{
				if (this.curObj["WriteOperationCount"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["WriteOperationCount"];
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000DD RID: 221 RVA: 0x0000CD8E File Offset: 0x0000AF8E
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsWriteTransferCountNull
		{
			get
			{
				return this.curObj["WriteTransferCount"] == null;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000DE RID: 222 RVA: 0x0000CDA5 File Offset: 0x0000AFA5
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("The WriteTransferCount property specifies the amount of data written.")]
		[TypeConverter(typeof(Process.WMIValueTypeConverter))]
		public ulong WriteTransferCount
		{
			get
			{
				if (this.curObj["WriteTransferCount"] == null)
				{
					return Convert.ToUInt64(0);
				}
				return (ulong)this.curObj["WriteTransferCount"];
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000CDD5 File Offset: 0x0000AFD5
		private bool CheckIfProperClass(ManagementScope mgmtScope, ManagementPath path, ObjectGetOptions OptionsParam)
		{
			return (path != null && string.Compare(path.ClassName, this.ManagementClassName, true, CultureInfo.InvariantCulture) == 0) || this.CheckIfProperClass(new ManagementObject(mgmtScope, path, OptionsParam));
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000CE04 File Offset: 0x0000B004
		private bool CheckIfProperClass(ManagementBaseObject theObj)
		{
			if (theObj != null && string.Compare((string)theObj["__CLASS"], this.ManagementClassName, true, CultureInfo.InvariantCulture) == 0)
			{
				return true;
			}
			Array array = (Array)theObj["__DERIVATION"];
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (string.Compare((string)array.GetValue(i), this.ManagementClassName, true, CultureInfo.InvariantCulture) == 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000CE84 File Offset: 0x0000B084
		private static DateTime ToDateTime(string dmtfDate)
		{
			DateTime minValue = DateTime.MinValue;
			int num = minValue.Year;
			int num2 = minValue.Month;
			int num3 = minValue.Day;
			int num4 = minValue.Hour;
			int num5 = minValue.Minute;
			int num6 = minValue.Second;
			long num7 = 0L;
			DateTime dateTime = DateTime.MinValue;
			string text = string.Empty;
			if (dmtfDate == null)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (dmtfDate.Length == 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (dmtfDate.Length != 25)
			{
				throw new ArgumentOutOfRangeException();
			}
			try
			{
				text = dmtfDate.Substring(0, 4);
				if ("****" != text)
				{
					num = int.Parse(text);
				}
				text = dmtfDate.Substring(4, 2);
				if ("**" != text)
				{
					num2 = int.Parse(text);
				}
				text = dmtfDate.Substring(6, 2);
				if ("**" != text)
				{
					num3 = int.Parse(text);
				}
				text = dmtfDate.Substring(8, 2);
				if ("**" != text)
				{
					num4 = int.Parse(text);
				}
				text = dmtfDate.Substring(10, 2);
				if ("**" != text)
				{
					num5 = int.Parse(text);
				}
				text = dmtfDate.Substring(12, 2);
				if ("**" != text)
				{
					num6 = int.Parse(text);
				}
				text = dmtfDate.Substring(15, 6);
				if ("******" != text)
				{
					num7 = long.Parse(text) * 10L;
				}
				if (num < 0 || num2 < 0 || num3 < 0 || num4 < 0 || num5 < 0 || num5 < 0 || num6 < 0 || num7 < 0L)
				{
					throw new ArgumentOutOfRangeException();
				}
			}
			catch (Exception ex)
			{
				throw new ArgumentOutOfRangeException(null, ex.Message);
			}
			dateTime = new DateTime(num, num2, num3, num4, num5, num6, 0);
			dateTime = dateTime.AddTicks(num7);
			TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(dateTime);
			int num8 = 0;
			long num9 = utcOffset.Ticks / 600000000L;
			text = dmtfDate.Substring(22, 3);
			if (text != "******")
			{
				text = dmtfDate.Substring(21, 4);
				try
				{
					num8 = int.Parse(text);
				}
				catch (Exception ex2)
				{
					throw new ArgumentOutOfRangeException(null, ex2.Message);
				}
				int num10 = (int)(num9 - (long)num8);
				dateTime = dateTime.AddMinutes((double)num10);
			}
			return dateTime;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000D108 File Offset: 0x0000B308
		private static string ToDmtfDateTime(DateTime date)
		{
			string str = string.Empty;
			TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(date);
			long value = utcOffset.Ticks / 600000000L;
			if (Math.Abs(value) > 999L)
			{
				date = date.ToUniversalTime();
				str = "+000";
			}
			else if (utcOffset.Ticks >= 0L)
			{
				str = "+" + (utcOffset.Ticks / 600000000L).ToString().PadLeft(3, '0');
			}
			else
			{
				string text = value.ToString();
				str = "-" + text.Substring(1, text.Length - 1).PadLeft(3, '0');
			}
			string str2 = date.Year.ToString().PadLeft(4, '0') + date.Month.ToString().PadLeft(2, '0') + date.Day.ToString().PadLeft(2, '0') + date.Hour.ToString().PadLeft(2, '0') + date.Minute.ToString().PadLeft(2, '0') + date.Second.ToString().PadLeft(2, '0') + ".";
			DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, 0);
			string text2 = ((date.Ticks - dateTime.Ticks) * 1000L / 10000L).ToString();
			if (text2.Length > 6)
			{
				text2 = text2.Substring(0, 6);
			}
			return str2 + text2.PadLeft(6, '0') + str;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000D2F0 File Offset: 0x0000B4F0
		private bool ShouldSerializeCreationDate()
		{
			return !this.IsCreationDateNull;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000D2FD File Offset: 0x0000B4FD
		private bool ShouldSerializeExecutionState()
		{
			return !this.IsExecutionStateNull;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000D30A File Offset: 0x0000B50A
		private bool ShouldSerializeHandleCount()
		{
			return !this.IsHandleCountNull;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000D317 File Offset: 0x0000B517
		private bool ShouldSerializeInstallDate()
		{
			return !this.IsInstallDateNull;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000D324 File Offset: 0x0000B524
		private bool ShouldSerializeKernelModeTime()
		{
			return !this.IsKernelModeTimeNull;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000D331 File Offset: 0x0000B531
		private bool ShouldSerializeMaximumWorkingSetSize()
		{
			return !this.IsMaximumWorkingSetSizeNull;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000D33E File Offset: 0x0000B53E
		private bool ShouldSerializeMinimumWorkingSetSize()
		{
			return !this.IsMinimumWorkingSetSizeNull;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000D34B File Offset: 0x0000B54B
		private bool ShouldSerializeOtherOperationCount()
		{
			return !this.IsOtherOperationCountNull;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000D358 File Offset: 0x0000B558
		private bool ShouldSerializeOtherTransferCount()
		{
			return !this.IsOtherTransferCountNull;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000D365 File Offset: 0x0000B565
		private bool ShouldSerializePageFaults()
		{
			return !this.IsPageFaultsNull;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000D372 File Offset: 0x0000B572
		private bool ShouldSerializePageFileUsage()
		{
			return !this.IsPageFileUsageNull;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000D37F File Offset: 0x0000B57F
		private bool ShouldSerializeParentProcessId()
		{
			return !this.IsParentProcessIdNull;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000D38C File Offset: 0x0000B58C
		private bool ShouldSerializePeakPageFileUsage()
		{
			return !this.IsPeakPageFileUsageNull;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000D399 File Offset: 0x0000B599
		private bool ShouldSerializePeakVirtualSize()
		{
			return !this.IsPeakVirtualSizeNull;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000D3A6 File Offset: 0x0000B5A6
		private bool ShouldSerializePeakWorkingSetSize()
		{
			return !this.IsPeakWorkingSetSizeNull;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000D3B3 File Offset: 0x0000B5B3
		private bool ShouldSerializePriority()
		{
			return !this.IsPriorityNull;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000D3C0 File Offset: 0x0000B5C0
		private bool ShouldSerializePrivatePageCount()
		{
			return !this.IsPrivatePageCountNull;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000D3CD File Offset: 0x0000B5CD
		private bool ShouldSerializeProcessId()
		{
			return !this.IsProcessIdNull;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000D3DA File Offset: 0x0000B5DA
		private bool ShouldSerializeQuotaNonPagedPoolUsage()
		{
			return !this.IsQuotaNonPagedPoolUsageNull;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000D3E7 File Offset: 0x0000B5E7
		private bool ShouldSerializeQuotaPagedPoolUsage()
		{
			return !this.IsQuotaPagedPoolUsageNull;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000D3F4 File Offset: 0x0000B5F4
		private bool ShouldSerializeQuotaPeakNonPagedPoolUsage()
		{
			return !this.IsQuotaPeakNonPagedPoolUsageNull;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000D401 File Offset: 0x0000B601
		private bool ShouldSerializeQuotaPeakPagedPoolUsage()
		{
			return !this.IsQuotaPeakPagedPoolUsageNull;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000D40E File Offset: 0x0000B60E
		private bool ShouldSerializeReadOperationCount()
		{
			return !this.IsReadOperationCountNull;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000D41B File Offset: 0x0000B61B
		private bool ShouldSerializeReadTransferCount()
		{
			return !this.IsReadTransferCountNull;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000D428 File Offset: 0x0000B628
		private bool ShouldSerializeSessionId()
		{
			return !this.IsSessionIdNull;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000D435 File Offset: 0x0000B635
		private bool ShouldSerializeTerminationDate()
		{
			return !this.IsTerminationDateNull;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000D442 File Offset: 0x0000B642
		private bool ShouldSerializeThreadCount()
		{
			return !this.IsThreadCountNull;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000D44F File Offset: 0x0000B64F
		private bool ShouldSerializeUserModeTime()
		{
			return !this.IsUserModeTimeNull;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000D45C File Offset: 0x0000B65C
		private bool ShouldSerializeVirtualSize()
		{
			return !this.IsVirtualSizeNull;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000D469 File Offset: 0x0000B669
		private bool ShouldSerializeWorkingSetSize()
		{
			return !this.IsWorkingSetSizeNull;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000D476 File Offset: 0x0000B676
		private bool ShouldSerializeWriteOperationCount()
		{
			return !this.IsWriteOperationCountNull;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000D483 File Offset: 0x0000B683
		private bool ShouldSerializeWriteTransferCount()
		{
			return !this.IsWriteTransferCountNull;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000D490 File Offset: 0x0000B690
		[Browsable(true)]
		public void CommitObject()
		{
			if (!this.isEmbedded)
			{
				this.PrivateLateBoundObject.Put();
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000D4A6 File Offset: 0x0000B6A6
		[Browsable(true)]
		public void CommitObject(PutOptions putOptions)
		{
			if (!this.isEmbedded)
			{
				this.PrivateLateBoundObject.Put(putOptions);
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000D4BD File Offset: 0x0000B6BD
		private void Initialize()
		{
			this.AutoCommitProp = true;
			this.isEmbedded = false;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000D4CD File Offset: 0x0000B6CD
		private static string ConstructPath(string keyHandle)
		{
			return "root\\cimv2:Win32_Process" + (".Handle=" + ("\"" + (keyHandle + "\"")));
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000D4F8 File Offset: 0x0000B6F8
		private void InitializeObject(ManagementScope mgmtScope, ManagementPath path, ObjectGetOptions getOptions)
		{
			this.Initialize();
			if (path != null && !this.CheckIfProperClass(mgmtScope, path, getOptions))
			{
				throw new ArgumentException("Class name does not match.");
			}
			this.PrivateLateBoundObject = new ManagementObject(mgmtScope, path, getOptions);
			this.PrivateSystemProperties = new Process.ManagementSystemProperties(this.PrivateLateBoundObject);
			this.curObj = this.PrivateLateBoundObject;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000D54F File Offset: 0x0000B74F
		public static Process.ProcessCollection GetInstances()
		{
			return Process.GetInstances(null, null, null);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000D559 File Offset: 0x0000B759
		public static Process.ProcessCollection GetInstances(string condition)
		{
			return Process.GetInstances(null, condition, null);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000D563 File Offset: 0x0000B763
		public static Process.ProcessCollection GetInstances(string[] selectedProperties)
		{
			return Process.GetInstances(null, null, selectedProperties);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000D56D File Offset: 0x0000B76D
		public static Process.ProcessCollection GetInstances(string condition, string[] selectedProperties)
		{
			return Process.GetInstances(null, condition, selectedProperties);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000D578 File Offset: 0x0000B778
		public static Process.ProcessCollection GetInstances(ManagementScope mgmtScope, EnumerationOptions enumOptions)
		{
			if (mgmtScope == null)
			{
				if (Process.statMgmtScope == null)
				{
					mgmtScope = new ManagementScope();
					mgmtScope.Path.NamespacePath = "root\\cimv2";
				}
				else
				{
					mgmtScope = Process.statMgmtScope;
				}
			}
			ManagementClass managementClass = new ManagementClass(mgmtScope, new ManagementPath
			{
				ClassName = "Win32_Process",
				NamespacePath = "root\\cimv2"
			}, null);
			if (enumOptions == null)
			{
				enumOptions = new EnumerationOptions();
				enumOptions.EnsureLocatable = true;
			}
			return new Process.ProcessCollection(managementClass.GetInstances(enumOptions));
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000D5EF File Offset: 0x0000B7EF
		public static Process.ProcessCollection GetInstances(ManagementScope mgmtScope, string condition)
		{
			return Process.GetInstances(mgmtScope, condition, null);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000D5F9 File Offset: 0x0000B7F9
		public static Process.ProcessCollection GetInstances(ManagementScope mgmtScope, string[] selectedProperties)
		{
			return Process.GetInstances(mgmtScope, null, selectedProperties);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000D604 File Offset: 0x0000B804
		public static Process.ProcessCollection GetInstances(ManagementScope mgmtScope, string condition, string[] selectedProperties)
		{
			if (mgmtScope == null)
			{
				if (Process.statMgmtScope == null)
				{
					mgmtScope = new ManagementScope();
					mgmtScope.Path.NamespacePath = "root\\cimv2";
				}
				else
				{
					mgmtScope = Process.statMgmtScope;
				}
			}
			return new Process.ProcessCollection(new ManagementObjectSearcher(mgmtScope, new SelectQuery("Win32_Process", condition, selectedProperties))
			{
				Options = new EnumerationOptions
				{
					EnsureLocatable = true
				}
			}.Get());
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000D66C File Offset: 0x0000B86C
		[Browsable(true)]
		public static Process CreateInstance()
		{
			ManagementScope managementScope;
			if (Process.statMgmtScope == null)
			{
				managementScope = new ManagementScope();
				managementScope.Path.NamespacePath = Process.CreatedWmiNamespace;
			}
			else
			{
				managementScope = Process.statMgmtScope;
			}
			ManagementPath path = new ManagementPath(Process.CreatedClassName);
			return new Process(new ManagementClass(managementScope, path, null).CreateInstance());
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000D6BD File Offset: 0x0000B8BD
		[Browsable(true)]
		public void Delete()
		{
			this.PrivateLateBoundObject.Delete();
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000D6CC File Offset: 0x0000B8CC
		public uint AttachDebugger()
		{
			if (!this.isEmbedded)
			{
				ManagementBaseObject inParameters = null;
				return Convert.ToUInt32(this.PrivateLateBoundObject.InvokeMethod("AttachDebugger", inParameters, null).Properties["ReturnValue"].Value);
			}
			return Convert.ToUInt32(0);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000D718 File Offset: 0x0000B918
		public static uint Create(string CommandLine, string CurrentDirectory, ManagementBaseObject ProcessStartupInformation, out uint ProcessId)
		{
			if (true)
			{
				ManagementPath path = new ManagementPath(Process.CreatedClassName);
				ManagementClass managementClass = new ManagementClass(Process.statMgmtScope, path, null);
				bool enablePrivileges = managementClass.Scope.Options.EnablePrivileges;
				managementClass.Scope.Options.EnablePrivileges = true;
				ManagementBaseObject methodParameters = managementClass.GetMethodParameters("Create");
				methodParameters["CommandLine"] = CommandLine;
				methodParameters["CurrentDirectory"] = CurrentDirectory;
				methodParameters["ProcessStartupInformation"] = ProcessStartupInformation;
				ManagementBaseObject managementBaseObject = managementClass.InvokeMethod("Create", methodParameters, null);
				ProcessId = Convert.ToUInt32(managementBaseObject.Properties["ProcessId"].Value);
				managementClass.Scope.Options.EnablePrivileges = enablePrivileges;
				return Convert.ToUInt32(managementBaseObject.Properties["ReturnValue"].Value);
			}
			ProcessId = Convert.ToUInt32(0);
			return Convert.ToUInt32(0);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000D7FC File Offset: 0x0000B9FC
		public uint GetOwner(out string Domain, out string User)
		{
			if (!this.isEmbedded)
			{
				ManagementBaseObject inParameters = null;
				bool enablePrivileges = this.PrivateLateBoundObject.Scope.Options.EnablePrivileges;
				this.PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
				ManagementBaseObject managementBaseObject = this.PrivateLateBoundObject.InvokeMethod("GetOwner", inParameters, null);
				Domain = Convert.ToString(managementBaseObject.Properties["Domain"].Value);
				User = Convert.ToString(managementBaseObject.Properties["User"].Value);
				this.PrivateLateBoundObject.Scope.Options.EnablePrivileges = enablePrivileges;
				return Convert.ToUInt32(managementBaseObject.Properties["ReturnValue"].Value);
			}
			Domain = null;
			User = null;
			return Convert.ToUInt32(0);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000D8CC File Offset: 0x0000BACC
		public uint GetOwnerSid(out string Sid)
		{
			if (!this.isEmbedded)
			{
				ManagementBaseObject inParameters = null;
				bool enablePrivileges = this.PrivateLateBoundObject.Scope.Options.EnablePrivileges;
				this.PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
				ManagementBaseObject managementBaseObject = this.PrivateLateBoundObject.InvokeMethod("GetOwnerSid", inParameters, null);
				Sid = Convert.ToString(managementBaseObject.Properties["Sid"].Value);
				this.PrivateLateBoundObject.Scope.Options.EnablePrivileges = enablePrivileges;
				return Convert.ToUInt32(managementBaseObject.Properties["ReturnValue"].Value);
			}
			Sid = null;
			return Convert.ToUInt32(0);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000D97C File Offset: 0x0000BB7C
		public uint SetPriority(int Priority)
		{
			if (!this.isEmbedded)
			{
				bool enablePrivileges = this.PrivateLateBoundObject.Scope.Options.EnablePrivileges;
				this.PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
				ManagementBaseObject methodParameters = this.PrivateLateBoundObject.GetMethodParameters("SetPriority");
				methodParameters["Priority"] = Priority;
				ManagementBaseObject managementBaseObject = this.PrivateLateBoundObject.InvokeMethod("SetPriority", methodParameters, null);
				this.PrivateLateBoundObject.Scope.Options.EnablePrivileges = enablePrivileges;
				return Convert.ToUInt32(managementBaseObject.Properties["ReturnValue"].Value);
			}
			return Convert.ToUInt32(0);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000DA2C File Offset: 0x0000BC2C
		public uint Terminate(uint Reason)
		{
			if (!this.isEmbedded)
			{
				bool enablePrivileges = this.PrivateLateBoundObject.Scope.Options.EnablePrivileges;
				this.PrivateLateBoundObject.Scope.Options.EnablePrivileges = true;
				ManagementBaseObject methodParameters = this.PrivateLateBoundObject.GetMethodParameters("Terminate");
				methodParameters["Reason"] = Reason;
				ManagementBaseObject managementBaseObject = this.PrivateLateBoundObject.InvokeMethod("Terminate", methodParameters, null);
				this.PrivateLateBoundObject.Scope.Options.EnablePrivileges = enablePrivileges;
				return Convert.ToUInt32(managementBaseObject.Properties["ReturnValue"].Value);
			}
			return Convert.ToUInt32(0);
		}

		// Token: 0x0400008D RID: 141
		private static string CreatedWmiNamespace = "root\\cimv2";

		// Token: 0x0400008E RID: 142
		private static string CreatedClassName = "Win32_Process";

		// Token: 0x0400008F RID: 143
		private static ManagementScope statMgmtScope = null;

		// Token: 0x04000090 RID: 144
		private Process.ManagementSystemProperties PrivateSystemProperties;

		// Token: 0x04000091 RID: 145
		private ManagementObject PrivateLateBoundObject;

		// Token: 0x04000092 RID: 146
		private bool AutoCommitProp;

		// Token: 0x04000093 RID: 147
		private ManagementBaseObject embeddedObj;

		// Token: 0x04000094 RID: 148
		private ManagementBaseObject curObj;

		// Token: 0x04000095 RID: 149
		private bool isEmbedded;

		// Token: 0x0200001F RID: 31
		public enum ExecutionStateValues
		{
			// Token: 0x040000E7 RID: 231
			Unknown0,
			// Token: 0x040000E8 RID: 232
			Other0,
			// Token: 0x040000E9 RID: 233
			Ready,
			// Token: 0x040000EA RID: 234
			Running,
			// Token: 0x040000EB RID: 235
			Blocked,
			// Token: 0x040000EC RID: 236
			Suspended_Blocked,
			// Token: 0x040000ED RID: 237
			Suspended_Ready,
			// Token: 0x040000EE RID: 238
			Terminated,
			// Token: 0x040000EF RID: 239
			Stopped,
			// Token: 0x040000F0 RID: 240
			Growing,
			// Token: 0x040000F1 RID: 241
			NULL_ENUM_VALUE
		}

		// Token: 0x02000020 RID: 32
		public class ProcessCollection : ICollection, IEnumerable
		{
			// Token: 0x0600019E RID: 414 RVA: 0x00010C8E File Offset: 0x0000EE8E
			public ProcessCollection(ManagementObjectCollection objCollection)
			{
				this.privColObj = objCollection;
			}

			// Token: 0x1700007A RID: 122
			// (get) Token: 0x0600019F RID: 415 RVA: 0x00010C9D File Offset: 0x0000EE9D
			public virtual int Count
			{
				get
				{
					return this.privColObj.Count;
				}
			}

			// Token: 0x1700007B RID: 123
			// (get) Token: 0x060001A0 RID: 416 RVA: 0x00010CAA File Offset: 0x0000EEAA
			public virtual bool IsSynchronized
			{
				get
				{
					return this.privColObj.IsSynchronized;
				}
			}

			// Token: 0x1700007C RID: 124
			// (get) Token: 0x060001A1 RID: 417 RVA: 0x00010CB7 File Offset: 0x0000EEB7
			public virtual object SyncRoot
			{
				get
				{
					return this;
				}
			}

			// Token: 0x060001A2 RID: 418 RVA: 0x00010CBC File Offset: 0x0000EEBC
			public virtual void CopyTo(Array array, int index)
			{
				this.privColObj.CopyTo(array, index);
				for (int i = 0; i < array.Length; i++)
				{
					array.SetValue(new Process((ManagementObject)array.GetValue(i)), i);
				}
			}

			// Token: 0x060001A3 RID: 419 RVA: 0x00010CFF File Offset: 0x0000EEFF
			public virtual IEnumerator GetEnumerator()
			{
				return new Process.ProcessCollection.ProcessEnumerator(this.privColObj.GetEnumerator());
			}

			// Token: 0x040000F2 RID: 242
			private ManagementObjectCollection privColObj;

			// Token: 0x02000030 RID: 48
			public class ProcessEnumerator : IEnumerator
			{
				// Token: 0x060001CA RID: 458 RVA: 0x00010FE6 File Offset: 0x0000F1E6
				public ProcessEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum)
				{
					this.privObjEnum = objEnum;
				}

				// Token: 0x17000087 RID: 135
				// (get) Token: 0x060001CB RID: 459 RVA: 0x00010FF5 File Offset: 0x0000F1F5
				public virtual object Current
				{
					get
					{
						return new Process((ManagementObject)this.privObjEnum.Current);
					}
				}

				// Token: 0x060001CC RID: 460 RVA: 0x0001100C File Offset: 0x0000F20C
				public virtual bool MoveNext()
				{
					return this.privObjEnum.MoveNext();
				}

				// Token: 0x060001CD RID: 461 RVA: 0x00011019 File Offset: 0x0000F219
				public virtual void Reset()
				{
					this.privObjEnum.Reset();
				}

				// Token: 0x0400012B RID: 299
				private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
			}
		}

		// Token: 0x02000021 RID: 33
		public class WMIValueTypeConverter : TypeConverter
		{
			// Token: 0x060001A4 RID: 420 RVA: 0x00010D11 File Offset: 0x0000EF11
			public WMIValueTypeConverter(Type inBaseType)
			{
				this.baseConverter = TypeDescriptor.GetConverter(inBaseType);
				this.baseType = inBaseType;
			}

			// Token: 0x060001A5 RID: 421 RVA: 0x00010D2C File Offset: 0x0000EF2C
			public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
			{
				return this.baseConverter.CanConvertFrom(context, srcType);
			}

			// Token: 0x060001A6 RID: 422 RVA: 0x00010D3B File Offset: 0x0000EF3B
			public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
			{
				return this.baseConverter.CanConvertTo(context, destinationType);
			}

			// Token: 0x060001A7 RID: 423 RVA: 0x00010D4A File Offset: 0x0000EF4A
			public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
			{
				return this.baseConverter.ConvertFrom(context, culture, value);
			}

			// Token: 0x060001A8 RID: 424 RVA: 0x00010D5A File Offset: 0x0000EF5A
			public override object CreateInstance(ITypeDescriptorContext context, IDictionary dictionary)
			{
				return this.baseConverter.CreateInstance(context, dictionary);
			}

			// Token: 0x060001A9 RID: 425 RVA: 0x00010D69 File Offset: 0x0000EF69
			public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
			{
				return this.baseConverter.GetCreateInstanceSupported(context);
			}

			// Token: 0x060001AA RID: 426 RVA: 0x00010D77 File Offset: 0x0000EF77
			public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributeVar)
			{
				return this.baseConverter.GetProperties(context, value, attributeVar);
			}

			// Token: 0x060001AB RID: 427 RVA: 0x00010D87 File Offset: 0x0000EF87
			public override bool GetPropertiesSupported(ITypeDescriptorContext context)
			{
				return this.baseConverter.GetPropertiesSupported(context);
			}

			// Token: 0x060001AC RID: 428 RVA: 0x00010D95 File Offset: 0x0000EF95
			public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
			{
				return this.baseConverter.GetStandardValues(context);
			}

			// Token: 0x060001AD RID: 429 RVA: 0x00010DA3 File Offset: 0x0000EFA3
			public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
			{
				return this.baseConverter.GetStandardValuesExclusive(context);
			}

			// Token: 0x060001AE RID: 430 RVA: 0x00010DB1 File Offset: 0x0000EFB1
			public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
			{
				return this.baseConverter.GetStandardValuesSupported(context);
			}

			// Token: 0x060001AF RID: 431 RVA: 0x00010DC0 File Offset: 0x0000EFC0
			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
			{
				if (this.baseType.BaseType == typeof(Enum))
				{
					if (value.GetType() == destinationType)
					{
						return value;
					}
					if (value == null && context != null && !context.PropertyDescriptor.ShouldSerializeValue(context.Instance))
					{
						return "NULL_ENUM_VALUE";
					}
					return this.baseConverter.ConvertTo(context, culture, value, destinationType);
				}
				else if (this.baseType == typeof(bool) && this.baseType.BaseType == typeof(ValueType))
				{
					if (value == null && context != null && !context.PropertyDescriptor.ShouldSerializeValue(context.Instance))
					{
						return "";
					}
					return this.baseConverter.ConvertTo(context, culture, value, destinationType);
				}
				else
				{
					if (context != null && !context.PropertyDescriptor.ShouldSerializeValue(context.Instance))
					{
						return "";
					}
					return this.baseConverter.ConvertTo(context, culture, value, destinationType);
				}
			}

			// Token: 0x040000F3 RID: 243
			private TypeConverter baseConverter;

			// Token: 0x040000F4 RID: 244
			private Type baseType;
		}

		// Token: 0x02000022 RID: 34
		[TypeConverter(typeof(ExpandableObjectConverter))]
		public class ManagementSystemProperties
		{
			// Token: 0x060001B0 RID: 432 RVA: 0x00010EB9 File Offset: 0x0000F0B9
			public ManagementSystemProperties(ManagementBaseObject ManagedObject)
			{
				this.PrivateLateBoundObject = ManagedObject;
			}

			// Token: 0x1700007D RID: 125
			// (get) Token: 0x060001B1 RID: 433 RVA: 0x00010EC8 File Offset: 0x0000F0C8
			[Browsable(true)]
			public int GENUS
			{
				get
				{
					return (int)this.PrivateLateBoundObject["__GENUS"];
				}
			}

			// Token: 0x1700007E RID: 126
			// (get) Token: 0x060001B2 RID: 434 RVA: 0x00010EDF File Offset: 0x0000F0DF
			[Browsable(true)]
			public string CLASS
			{
				get
				{
					return (string)this.PrivateLateBoundObject["__CLASS"];
				}
			}

			// Token: 0x1700007F RID: 127
			// (get) Token: 0x060001B3 RID: 435 RVA: 0x00010EF6 File Offset: 0x0000F0F6
			[Browsable(true)]
			public string SUPERCLASS
			{
				get
				{
					return (string)this.PrivateLateBoundObject["__SUPERCLASS"];
				}
			}

			// Token: 0x17000080 RID: 128
			// (get) Token: 0x060001B4 RID: 436 RVA: 0x00010F0D File Offset: 0x0000F10D
			[Browsable(true)]
			public string DYNASTY
			{
				get
				{
					return (string)this.PrivateLateBoundObject["__DYNASTY"];
				}
			}

			// Token: 0x17000081 RID: 129
			// (get) Token: 0x060001B5 RID: 437 RVA: 0x00010F24 File Offset: 0x0000F124
			[Browsable(true)]
			public string RELPATH
			{
				get
				{
					return (string)this.PrivateLateBoundObject["__RELPATH"];
				}
			}

			// Token: 0x17000082 RID: 130
			// (get) Token: 0x060001B6 RID: 438 RVA: 0x00010F3B File Offset: 0x0000F13B
			[Browsable(true)]
			public int PROPERTY_COUNT
			{
				get
				{
					return (int)this.PrivateLateBoundObject["__PROPERTY_COUNT"];
				}
			}

			// Token: 0x17000083 RID: 131
			// (get) Token: 0x060001B7 RID: 439 RVA: 0x00010F52 File Offset: 0x0000F152
			[Browsable(true)]
			public string[] DERIVATION
			{
				get
				{
					return (string[])this.PrivateLateBoundObject["__DERIVATION"];
				}
			}

			// Token: 0x17000084 RID: 132
			// (get) Token: 0x060001B8 RID: 440 RVA: 0x00010F69 File Offset: 0x0000F169
			[Browsable(true)]
			public string SERVER
			{
				get
				{
					return (string)this.PrivateLateBoundObject["__SERVER"];
				}
			}

			// Token: 0x17000085 RID: 133
			// (get) Token: 0x060001B9 RID: 441 RVA: 0x00010F80 File Offset: 0x0000F180
			[Browsable(true)]
			public string NAMESPACE
			{
				get
				{
					return (string)this.PrivateLateBoundObject["__NAMESPACE"];
				}
			}

			// Token: 0x17000086 RID: 134
			// (get) Token: 0x060001BA RID: 442 RVA: 0x00010F97 File Offset: 0x0000F197
			[Browsable(true)]
			public string PATH
			{
				get
				{
					return (string)this.PrivateLateBoundObject["__PATH"];
				}
			}

			// Token: 0x040000F5 RID: 245
			private ManagementBaseObject PrivateLateBoundObject;
		}
	}
}

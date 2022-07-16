using System;
using System.Management;

namespace New_Viper_X.Watcher
{
	// Token: 0x0200000B RID: 11
	public class ProcessWatcher : ManagementEventWatcher
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600011D RID: 285 RVA: 0x0000DAF8 File Offset: 0x0000BCF8
		// (remove) Token: 0x0600011E RID: 286 RVA: 0x0000DB30 File Offset: 0x0000BD30
		public event ProcessEventHandler ProcessCreated;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600011F RID: 287 RVA: 0x0000DB68 File Offset: 0x0000BD68
		// (remove) Token: 0x06000120 RID: 288 RVA: 0x0000DBA0 File Offset: 0x0000BDA0
		public event ProcessEventHandler ProcessDeleted;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000121 RID: 289 RVA: 0x0000DBD8 File Offset: 0x0000BDD8
		// (remove) Token: 0x06000122 RID: 290 RVA: 0x0000DC10 File Offset: 0x0000BE10
		public event ProcessEventHandler ProcessModified;

		// Token: 0x06000123 RID: 291 RVA: 0x0000DC45 File Offset: 0x0000BE45
		public ProcessWatcher(string processName)
		{
			this.Init(processName);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000DC54 File Offset: 0x0000BE54
		private void Init(string processName)
		{
			base.Query.QueryLanguage = "WQL";
			base.Query.QueryString = string.Format(ProcessWatcher.processEventQuery, processName);
			base.EventArrived += this.watcher_EventArrived;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000DC90 File Offset: 0x0000BE90
		private void watcher_EventArrived(object sender, EventArrivedEventArgs e)
		{
			string className = e.NewEvent.ClassPath.ClassName;
			Process proc = new Process(e.NewEvent["TargetInstance"] as ManagementBaseObject);
			if (!(className == "__InstanceCreationEvent"))
			{
				if (!(className == "__InstanceDeletionEvent"))
				{
					if (!(className == "__InstanceModificationEvent"))
					{
						return;
					}
					if (this.ProcessModified != null)
					{
						this.ProcessModified(proc);
					}
				}
				else if (this.ProcessDeleted != null)
				{
					this.ProcessDeleted(proc);
					return;
				}
			}
			else if (this.ProcessCreated != null)
			{
				this.ProcessCreated(proc);
				return;
			}
		}

		// Token: 0x04000099 RID: 153
		private static readonly string processEventQuery = "SELECT * FROM \r\n             __InstanceOperationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_Process' \r\n             and TargetInstance.Name = '{0}'";
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;
using New_Viper_X;
using ScintillaNET;

namespace Controls
{
	// Token: 0x02000010 RID: 16
	public class CustomTabControl : TabControl
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000143 RID: 323 RVA: 0x0000E494 File Offset: 0x0000C694
		// (set) Token: 0x06000144 RID: 324 RVA: 0x0000E49C File Offset: 0x0000C69C
		[Browsable(true)]
		[Category("Colors")]
		[Description("The color of the selected page")]
		public Color ActiveColor
		{
			get
			{
				return this.activeColor;
			}
			set
			{
				this.activeColor = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000145 RID: 325 RVA: 0x0000E4A5 File Offset: 0x0000C6A5
		// (set) Token: 0x06000146 RID: 326 RVA: 0x0000E4AD File Offset: 0x0000C6AD
		[Browsable(true)]
		[Category("Colors")]
		[Description("The color of the background of the tab")]
		public Color BackTabColor
		{
			get
			{
				return this.backTabColor;
			}
			set
			{
				this.backTabColor = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000147 RID: 327 RVA: 0x0000E4B6 File Offset: 0x0000C6B6
		// (set) Token: 0x06000148 RID: 328 RVA: 0x0000E4BE File Offset: 0x0000C6BE
		[Browsable(true)]
		[Category("Colors")]
		[Description("The color of the border of the control")]
		public Color BorderColor
		{
			get
			{
				return this.borderColor;
			}
			set
			{
				this.borderColor = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000149 RID: 329 RVA: 0x0000E4C7 File Offset: 0x0000C6C7
		// (set) Token: 0x0600014A RID: 330 RVA: 0x0000E4CF File Offset: 0x0000C6CF
		[Browsable(true)]
		[Category("Colors")]
		[Description("The color of the closing button")]
		public Color ClosingButtonColor
		{
			get
			{
				return this.closingButtonColor;
			}
			set
			{
				this.closingButtonColor = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600014B RID: 331 RVA: 0x0000E4D8 File Offset: 0x0000C6D8
		// (set) Token: 0x0600014C RID: 332 RVA: 0x0000E4E0 File Offset: 0x0000C6E0
		[Browsable(true)]
		[Category("Options")]
		[Description("The message that will be shown before closing.")]
		public string ClosingMessage
		{
			get
			{
				return this.closingMessage;
			}
			set
			{
				this.closingMessage = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600014D RID: 333 RVA: 0x0000E4E9 File Offset: 0x0000C6E9
		// (set) Token: 0x0600014E RID: 334 RVA: 0x0000E4F1 File Offset: 0x0000C6F1
		[Browsable(true)]
		[Category("Colors")]
		[Description("The color of the header.")]
		public Color HeaderColor
		{
			get
			{
				return this.headerColor;
			}
			set
			{
				this.headerColor = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600014F RID: 335 RVA: 0x0000E4FA File Offset: 0x0000C6FA
		// (set) Token: 0x06000150 RID: 336 RVA: 0x0000E502 File Offset: 0x0000C702
		[Browsable(true)]
		[Category("Colors")]
		[Description("The color of the horizontal line which is located under the headers of the pages.")]
		public Color HorizontalLineColor
		{
			get
			{
				return this.horizLineColor;
			}
			set
			{
				this.horizLineColor = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000151 RID: 337 RVA: 0x0000E50B File Offset: 0x0000C70B
		// (set) Token: 0x06000152 RID: 338 RVA: 0x0000E513 File Offset: 0x0000C713
		[Browsable(true)]
		[Category("Colors")]
		[Description("The color of the title of the page")]
		public Color SelectedTextColor
		{
			get
			{
				return this.selectedTextColor;
			}
			set
			{
				this.selectedTextColor = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000153 RID: 339 RVA: 0x0000E51C File Offset: 0x0000C71C
		// (set) Token: 0x06000154 RID: 340 RVA: 0x0000E524 File Offset: 0x0000C724
		public bool ShowClosingButton { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000155 RID: 341 RVA: 0x0000E52D File Offset: 0x0000C72D
		// (set) Token: 0x06000156 RID: 342 RVA: 0x0000E535 File Offset: 0x0000C735
		[Browsable(true)]
		[Category("Options")]
		[Description("Show a Yes/No message before closing?")]
		public bool ShowClosingMessage { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000157 RID: 343 RVA: 0x0000E53E File Offset: 0x0000C73E
		// (set) Token: 0x06000158 RID: 344 RVA: 0x0000E546 File Offset: 0x0000C746
		[Browsable(true)]
		[Category("Colors")]
		[Description("The color of the title of the page")]
		public Color TextColor
		{
			get
			{
				return this.textColor;
			}
			set
			{
				this.textColor = value;
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000E550 File Offset: 0x0000C750
		public CustomTabControl()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.SizeMode = TabSizeMode.Normal;
			base.ItemSize = new Size(240, 16);
			this.AllowDrop = true;
			base.Selecting += this.TabChanging;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000E65C File Offset: 0x0000C85C
		public void AddEvent(string name = "Script.lua", string content = "")
		{
			if (!string.IsNullOrEmpty(this.GetWorkingTextEditor().Text) || string.IsNullOrEmpty(content))
			{
				this.addnewtab();
				if (name.Contains("Script" + this.count.ToString() + ".lua"))
				{
					base.SelectedTab.Text = "Script " + this.count.ToString() + ".lua";
				}
			}
			else
			{
				this.addnewtab();
				base.SelectedTab.Text = "Script " + this.count.ToString() + ".lua";
				base.SelectedTab.Controls[0].Text = content;
				base.SelectedTab.Controls[0].Refresh();
			}
			this.count++;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000E738 File Offset: 0x0000C938
		public void addnewtab()
		{
			int num = base.TabCount - 1;
			base.TabPages.Insert(num, string.Format("Script{0}.lua", base.TabCount));
			base.TabPages[num].Controls.Add(this.NewEditor(""));
			base.SelectedIndex = num;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000E798 File Offset: 0x0000C998
		public void CloseTab(TabPage tab)
		{
			Scintilla scintilla = tab.Controls[0] as Scintilla;
			int num = base.TabPages.IndexOf(tab);
			if (num != 0 || base.TabCount > 2)
			{
				base.TabPages.RemoveAt(num);
				this.count--;
				return;
			}
			TabPage tabPage = base.TabPages[0];
			tab.Text = "Sem nome.lua";
			scintilla.Text = "";
			scintilla.Refresh();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000E814 File Offset: 0x0000CA14
		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.Alignment = TabAlignment.Top;
			CustomTabControl.SendMessage(base.Handle, 4913, IntPtr.Zero, (IntPtr)16);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000E840 File Offset: 0x0000CA40
		private void DragDropHandler(object sender, DragEventArgs e)
		{
			foreach (string path in (string[])e.Data.GetData(DataFormats.FileDrop, false))
			{
				this.AddEvent(Path.GetFileNameWithoutExtension(path), File.ReadAllText(path));
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000E888 File Offset: 0x0000CA88
		private void DragOverEnterHandler(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
				return;
			}
			e.Effect = DragDropEffects.None;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000E8AC File Offset: 0x0000CAAC
		private TabPage GetPointedTab()
		{
			for (int i = 0; i <= base.TabPages.Count - 1; i++)
			{
				if (base.GetTabRect(i).Contains(base.PointToClient(Cursor.Position)))
				{
					return base.TabPages[i];
				}
			}
			return null;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000E8FC File Offset: 0x0000CAFC
		public Scintilla GetWorkingTextEditor()
		{
			if (base.SelectedTab.Controls.Count == 0)
			{
				return null;
			}
			if (base.SelectedTab != null)
			{
				return base.SelectedTab.Controls[0] as Scintilla;
			}
			this.addnewtab();
			return base.SelectedTab.Controls[0] as Scintilla;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000E958 File Offset: 0x0000CB58
		public Scintilla NewEditor(string script)
		{
			Scintilla scintilla = new Scintilla
			{
				AllowDrop = true,
				AutomaticFold = 7,
				BackColor = Color.Black,
				BorderStyle = BorderStyle.None,
				Lexer = 15,
				Name = "scintilla",
				Dock = DockStyle.Fill,
				ScrollWidth = 1,
				TabIndex = 0
			};
			scintilla.Styles[32].Size = 15;
			scintilla.Styles[32].Size = 15;
			scintilla.Styles[32].Size = 15;
			scintilla.SetSelectionBackColor(true, Color.FromArgb(17, 177, 255));
			scintilla.SetSelectionForeColor(true, Color.Black);
			scintilla.Margins[1].Width = 0;
			scintilla.StyleResetDefault();
			scintilla.Styles[32].Font = "Consolas";
			scintilla.Styles[32].Size = 10;
			scintilla.Styles[32].BackColor = Color.FromArgb(40, 40, 40);
			scintilla.Styles[32].ForeColor = Color.White;
			scintilla.StyleClearAll();
			scintilla.Styles[11].ForeColor = Color.White;
			scintilla.Styles[1].ForeColor = Color.FromArgb(79, 81, 98);
			scintilla.Styles[2].ForeColor = Color.FromArgb(79, 81, 98);
			scintilla.Styles[3].ForeColor = Color.FromArgb(58, 64, 34);
			scintilla.Styles[4].ForeColor = Color.FromArgb(165, 112, 255);
			scintilla.Styles[6].ForeColor = Color.FromArgb(255, 192, 115);
			scintilla.Styles[7].ForeColor = Color.FromArgb(255, 192, 115);
			scintilla.Styles[8].ForeColor = Color.FromArgb(255, 192, 115);
			scintilla.Styles[9].ForeColor = Color.FromArgb(138, 175, 238);
			scintilla.Styles[10].ForeColor = Color.White;
			scintilla.Styles[5].ForeColor = Color.FromArgb(255, 60, 122);
			scintilla.Styles[13].ForeColor = Color.FromArgb(89, 255, 172);
			scintilla.Styles[13].Bold = true;
			scintilla.Styles[14].ForeColor = Color.FromArgb(89, 255, 172);
			scintilla.Styles[14].Bold = true;
			scintilla.Lexer = 15;
			scintilla.SetProperty("fold", "1");
			scintilla.SetProperty("fold.compact", "1");
			scintilla.Margins[0].Width = 15;
			scintilla.Margins[0].Type = 1;
			scintilla.Margins[1].Type = 0;
			scintilla.Margins[1].Mask = 4261412864U;
			scintilla.Margins[1].Sensitive = true;
			scintilla.Margins[1].Width = 8;
			for (int i = 25; i <= 31; i++)
			{
				scintilla.Markers[i].SetForeColor(Color.White);
				scintilla.Markers[i].SetBackColor(Color.White);
			}
			scintilla.Markers[30].Symbol = 12;
			scintilla.Markers[31].Symbol = 14;
			scintilla.Markers[25].Symbol = 13;
			scintilla.Markers[27].Symbol = 11;
			scintilla.Markers[26].Symbol = 15;
			scintilla.Markers[29].Symbol = 9;
			scintilla.Markers[28].Symbol = 10;
			scintilla.Styles[33].BackColor = Color.FromArgb(40, 40, 40);
			scintilla.AutomaticFold = 7;
			scintilla.SetFoldMarginColor(true, Color.FromArgb(40, 40, 40));
			scintilla.SetFoldMarginHighlightColor(true, Color.FromArgb(40, 40, 40));
			scintilla.SetKeywords(0, "and break do else elseif end false for function if in local nil not or repeat return then true until while continue");
			scintilla.SetKeywords(1, "warn CFrame CFrame.fromEulerAnglesXYZ Synapse Decompile Synapse Copy Synapse Write CFrame.Angles CFrame.fromAxisAngle CFrame.new gcinfo os os.difftime os.time tick UDim UDim.new Instance Instance.Lock Instance.Unlock Instance.new pairs NumberSequence NumberSequence.new assert tonumber getmetatable Color3 Color3.fromHSV Color3.toHSV Color3.fromRGB Color3.new load Stats _G UserSettings Ray Ray.new coroutine coroutine.resume coroutine.yield coroutine.status coroutine.wrap coroutine.create coroutine.running NumberRange NumberRange.new PhysicalProperties Physicalnew printidentity PluginManager loadstring NumberSequenceKeypoint NumberSequenceKeypoint.new Version Vector2 Vector2.new wait game. game.Players game.ReplicatedStorage Game delay spawn string string.sub string.upper string.len string.gfind string.rep string.find string.match string.char string.dump string.gmatch string.reverse string.byte string.format string.gsub string.lower CellId CellId.new Delay version stats typeof UDim2 UDim2.new table table.setn table.insert table.getn table.foreachi table.maxn table.foreach table.concat table.sort table.remove settings LoadLibrary require Vector3 Vector3.FromNormalId Vector3.FromAxis Vector3.new Vector3int16 Vector3int16.new setmetatable next ypcall ipairs Wait rawequal Region3int16 Region3int16.new collectgarbage game newproxy Spawn elapsedTime Region3 Region3.new time xpcall shared rawset tostring print Workspace Vector2int16 Vector2int16.new workspace unpack math math.log math.noise math.acos math.huge math.ldexp math.pi math.cos math.tanh math.pow math.deg math.tan math.cosh math.sinh math.random math.randomseed math.frexp math.ceil math.floor math.rad math.abs math.sqrt math.modf math.asin math.min math.max math.fmod math.log10 math.atan2 math.exp math.sin math.atan ColorSequenceKeypoint ColorSequenceKeypoint.new pcall getfenv ColorSequence ColorSequence.new type ElapsedTime select Faces Faces.new rawget debug debug.traceback debug.profileend debug.profilebegin Rect Rect.new BrickColor BrickColor.Blue BrickColor.White BrickColor.Yellow BrickColor.Red BrickColor.Gray BrickColor.palette BrickColor.New BrickColor.Black BrickColor.Green BrickColor.Random BrickColor.DarkGray BrickColor.random BrickColor.new setfenv dofile Axes Axes.new error loadfile ");
			scintilla.SetKeywords(2, "getrawmetatable loadstring getnamecallmethod setreadonly islclosure getgenv unlockModule lockModule mousemoverel debug.getupvalue debug.getupvalues debug.setupvalue debug.getmetatable debug.getregistry setclipboard setthreadcontext getthreadcontext checkcaller getgc debug.getconstant getrenv getreg ");
			scintilla.ScrollWidth = 1;
			scintilla.ScrollWidthTracking = true;
			scintilla.CaretForeColor = Color.White;
			scintilla.BackColor = Color.White;
			scintilla.BorderStyle = BorderStyle.None;
			scintilla.TextChanged += this.scintilla1_TextChanged;
			scintilla.WrapIndentMode = 2;
			scintilla.WrapVisualFlagLocation = 1;
			scintilla.BorderStyle = BorderStyle.None;
			scintilla.Text = script;
			return scintilla;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000EE70 File Offset: 0x0000D070
		protected override void OnDragOver(DragEventArgs drgevent)
		{
			if (this.predraggedTab != null)
			{
				TabPage tabPage = (TabPage)drgevent.Data.GetData(typeof(TabPage));
				TabPage pointedTab = this.GetPointedTab();
				int num = base.TabPages.IndexOf(tabPage);
				if (tabPage != null && num != base.TabCount)
				{
					TabPage tabPage2 = base.TabPages[base.TabCount - 1];
					if (tabPage != tabPage2 && tabPage == this.predraggedTab && pointedTab != null)
					{
						drgevent.Effect = DragDropEffects.Move;
						if (pointedTab != tabPage2 && pointedTab != tabPage)
						{
							this.ReplaceTabPages(tabPage, pointedTab);
						}
					}
				}
			}
			base.OnDragOver(drgevent);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000EF04 File Offset: 0x0000D104
		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.predraggedTab = this.GetPointedTab();
			Point location = e.Location;
			for (int i = 0; i < base.TabCount; i++)
			{
				object obj = base.GetTabRect(i);
				if (CustomTabControl.<>o__60.<>p__2 == null)
				{
					CustomTabControl.<>o__60.<>p__2 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Offset", null, typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Action<CallSite, object, object, int> target = CustomTabControl.<>o__60.<>p__2.Target;
				CallSite <>p__ = CustomTabControl.<>o__60.<>p__2;
				object arg = obj;
				if (CustomTabControl.<>o__60.<>p__1 == null)
				{
					CustomTabControl.<>o__60.<>p__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Subtract, typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, int, object> target2 = CustomTabControl.<>o__60.<>p__1.Target;
				CallSite <>p__2 = CustomTabControl.<>o__60.<>p__1;
				if (CustomTabControl.<>o__60.<>p__0 == null)
				{
					CustomTabControl.<>o__60.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Width", typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				target(<>p__, arg, target2(<>p__2, CustomTabControl.<>o__60.<>p__0.Target(CustomTabControl.<>o__60.<>p__0, obj), 15), 2);
				if (CustomTabControl.<>o__60.<>p__3 == null)
				{
					CustomTabControl.<>o__60.<>p__3 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Width", typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				CustomTabControl.<>o__60.<>p__3.Target(CustomTabControl.<>o__60.<>p__3, obj, 10);
				if (CustomTabControl.<>o__60.<>p__4 == null)
				{
					CustomTabControl.<>o__60.<>p__4 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Height", typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				CustomTabControl.<>o__60.<>p__4.Target(CustomTabControl.<>o__60.<>p__4, obj, 10);
				if (CustomTabControl.<>o__60.<>p__6 == null)
				{
					CustomTabControl.<>o__60.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.Not, typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, object> target3 = CustomTabControl.<>o__60.<>p__6.Target;
				CallSite <>p__3 = CustomTabControl.<>o__60.<>p__6;
				if (CustomTabControl.<>o__60.<>p__5 == null)
				{
					CustomTabControl.<>o__60.<>p__5 = CallSite<Func<CallSite, object, Point, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Contains", null, typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				object arg2 = target3(<>p__3, CustomTabControl.<>o__60.<>p__5.Target(CustomTabControl.<>o__60.<>p__5, obj, location));
				if (CustomTabControl.<>o__60.<>p__8 == null)
				{
					CustomTabControl.<>o__60.<>p__8 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, bool> target4 = CustomTabControl.<>o__60.<>p__8.Target;
				CallSite <>p__4 = CustomTabControl.<>o__60.<>p__8;
				if (CustomTabControl.<>o__60.<>p__7 == null)
				{
					CustomTabControl.<>o__60.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.Not, typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				if (target4(<>p__4, CustomTabControl.<>o__60.<>p__7.Target(CustomTabControl.<>o__60.<>p__7, arg2)) && e.Button == MouseButtons.Left)
				{
					if (i != base.TabCount - 1)
					{
						this.predraggedTab = null;
						TabPage tabPage = base.TabPages[i];
						if (this.ShowClosingMessage)
						{
							this.CloseTab(tabPage);
						}
						else
						{
							if (base.TabCount == 2)
							{
								if (MessageBox.Show("Tem certeza de que deseja limpar esta guia?\nA razão pela qual você vê esse prompt é porque há apenas uma guia aberta no momento.", "GUIA ÚNICA DETECTADA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
								{
									tabPage.Text = "Sem nome.lua";
									this.GetWorkingTextEditor().Text = "";
								}
								return;
							}
							if (tabPage.Controls.Count > 0)
							{
								tabPage.Controls[0].Dispose();
							}
							base.TabPages.RemoveAt(i);
							break;
						}
					}
					else if (base.GetTabRect(base.TabCount - 1).Contains(e.Location))
					{
						this.AddEvent("Script.lua", "");
						this.predraggedTab = null;
						break;
					}
				}
			}
			base.OnMouseDown(e);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000F31F File Offset: 0x0000D51F
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this.predraggedTab != null)
			{
				base.DoDragDrop(this.predraggedTab, DragDropEffects.Move);
			}
			base.OnMouseMove(e);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000F34C File Offset: 0x0000D54C
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.predraggedTab = null;
			this.contextTab = null;
			if (e.Button == MouseButtons.Right)
			{
				CustomTabControl.Form1.TabContextMenu.Show(Cursor.Position);
				this.contextTab = this.GetPointedTab();
			}
			base.OnMouseUp(e);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000F39C File Offset: 0x0000D59C
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics.Clear(this.headerColor);
			try
			{
				base.SelectedTab.BackColor = this.backTabColor;
			}
			catch
			{
			}
			try
			{
				base.SelectedTab.BorderStyle = BorderStyle.None;
			}
			catch
			{
			}
			int i = 0;
			while (i <= base.TabCount - 1)
			{
				TabPage tabPage = base.TabPages[i];
				int width = (int)e.Graphics.MeasureString(tabPage.Text, this.Font).Width + 16;
				tabPage.Width = width;
				int x = base.GetTabRect(i).Location.X + 2;
				Point location = new Point(x, base.GetTabRect(i).Location.Y);
				int width2 = base.GetTabRect(i).Width;
				Rectangle tabRect = base.GetTabRect(i);
				Rectangle rectangle = new Rectangle(location, new Size(width2, tabRect.Height));
				Rectangle rectangle2 = new Rectangle(rectangle.Location, new Size(rectangle.Width, rectangle.Height));
				Brush brush = new SolidBrush(this.closingButtonColor);
				if (i == base.SelectedIndex)
				{
					graphics.FillRectangle(new SolidBrush(this.headerColor), rectangle2);
					graphics.FillRectangle(new SolidBrush(Color.FromArgb(36, 36, 36)), new Rectangle(rectangle.X - 5, rectangle.Y - 3, rectangle.Width, rectangle.Height + 5));
					graphics.DrawString(tabPage.Text, this.Font, new SolidBrush(this.selectedTextColor), rectangle2, this.CenterSringFormat);
				}
				else
				{
					graphics.DrawString(tabPage.Text, this.Font, new SolidBrush(this.textColor), rectangle2, this.CenterSringFormat);
				}
				if (i == base.TabCount - 1)
				{
					using (Font font = new Font(SystemFonts.DefaultFont.FontFamily, 14f, FontStyle.Bold))
					{
						e.Graphics.DrawString("+", font, brush, (float)(rectangle2.Right - 22), (float)(rectangle2.Top / 2 - 4));
						goto IL_26A;
					}
					goto IL_23A;
				}
				goto IL_23A;
				IL_26A:
				brush.Dispose();
				i++;
				continue;
				IL_23A:
				if (this.ShowClosingButton)
				{
					e.Graphics.DrawString("X", this.Font, brush, (float)(rectangle2.Right - 17), 3f);
					goto IL_26A;
				}
				goto IL_26A;
			}
			graphics.DrawLine(new Pen(Color.FromArgb(36, 36, 36), 5f), new Point(0, 19), new Point(base.Width, 19));
			graphics.FillRectangle(new SolidBrush(this.backTabColor), new Rectangle(0, 20, base.Width, base.Height - 20));
			graphics.DrawRectangle(new Pen(this.borderColor, 2f), new Rectangle(0, 0, base.Width, base.Height));
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000F6DC File Offset: 0x0000D8DC
		public bool OpenFileDialog(TabPage tab)
		{
			bool result;
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					result = false;
				}
				else
				{
					this.GetWorkingTextEditor().Text = File.ReadAllText(openFileDialog.FileName);
					tab.Text = Path.GetFileName(openFileDialog.FileName);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000F754 File Offset: 0x0000D954
		public string OpenSaveDialog(TabPage tab, string text)
		{
			string result;
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
				saveFileDialog.RestoreDirectory = true;
				saveFileDialog.FileName = tab.Text;
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
				{
					result = tab.Text;
				}
				else
				{
					File.WriteAllText(saveFileDialog.FileName, text);
					result = new FileInfo(saveFileDialog.FileName).Name;
				}
			}
			return result;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000F7D4 File Offset: 0x0000D9D4
		public void RenameTab(string text)
		{
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000F7D8 File Offset: 0x0000D9D8
		private void ReplaceTabPages(TabPage Source, TabPage Destination)
		{
			object obj = base.TabPages.IndexOf(Source);
			object obj2 = base.TabPages.IndexOf(Destination);
			if (CustomTabControl.<>o__67.<>p__0 == null)
			{
				CustomTabControl.<>o__67.<>p__0 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(CustomTabControl), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			object obj3 = CustomTabControl.<>o__67.<>p__0.Target(CustomTabControl.<>o__67.<>p__0, obj, -1);
			if (CustomTabControl.<>o__67.<>p__1 == null)
			{
				CustomTabControl.<>o__67.<>p__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CustomTabControl), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			if (!CustomTabControl.<>o__67.<>p__1.Target(CustomTabControl.<>o__67.<>p__1, obj3))
			{
				if (CustomTabControl.<>o__67.<>p__4 == null)
				{
					CustomTabControl.<>o__67.<>p__4 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, bool> target = CustomTabControl.<>o__67.<>p__4.Target;
				CallSite <>p__ = CustomTabControl.<>o__67.<>p__4;
				if (CustomTabControl.<>o__67.<>p__3 == null)
				{
					CustomTabControl.<>o__67.<>p__3 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Or, typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, object, object> target2 = CustomTabControl.<>o__67.<>p__3.Target;
				CallSite <>p__2 = CustomTabControl.<>o__67.<>p__3;
				object arg = obj3;
				if (CustomTabControl.<>o__67.<>p__2 == null)
				{
					CustomTabControl.<>o__67.<>p__2 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(CustomTabControl), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				if (!target(<>p__, target2(<>p__2, arg, CustomTabControl.<>o__67.<>p__2.Target(CustomTabControl.<>o__67.<>p__2, obj2, -1))))
				{
					if (CustomTabControl.<>o__67.<>p__5 == null)
					{
						CustomTabControl.<>o__67.<>p__5 = CallSite<Func<CallSite, TabControl.TabPageCollection, object, TabPage, object>>.Create(Binder.SetIndex(CSharpBinderFlags.None, typeof(CustomTabControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					CustomTabControl.<>o__67.<>p__5.Target(CustomTabControl.<>o__67.<>p__5, base.TabPages, obj2, Source);
					if (CustomTabControl.<>o__67.<>p__6 == null)
					{
						CustomTabControl.<>o__67.<>p__6 = CallSite<Func<CallSite, TabControl.TabPageCollection, object, TabPage, object>>.Create(Binder.SetIndex(CSharpBinderFlags.None, typeof(CustomTabControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					CustomTabControl.<>o__67.<>p__6.Target(CustomTabControl.<>o__67.<>p__6, base.TabPages, obj, Destination);
					if (CustomTabControl.<>o__67.<>p__8 == null)
					{
						CustomTabControl.<>o__67.<>p__8 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CustomTabControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> target3 = CustomTabControl.<>o__67.<>p__8.Target;
					CallSite <>p__3 = CustomTabControl.<>o__67.<>p__8;
					if (CustomTabControl.<>o__67.<>p__7 == null)
					{
						CustomTabControl.<>o__67.<>p__7 = CallSite<Func<CallSite, int, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(CustomTabControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					if (target3(<>p__3, CustomTabControl.<>o__67.<>p__7.Target(CustomTabControl.<>o__67.<>p__7, base.SelectedIndex, obj)))
					{
						if (CustomTabControl.<>o__67.<>p__9 == null)
						{
							CustomTabControl.<>o__67.<>p__9 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(CustomTabControl)));
						}
						base.SelectedIndex = CustomTabControl.<>o__67.<>p__9.Target(CustomTabControl.<>o__67.<>p__9, obj2);
					}
					else
					{
						if (CustomTabControl.<>o__67.<>p__11 == null)
						{
							CustomTabControl.<>o__67.<>p__11 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(CustomTabControl), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, bool> target4 = CustomTabControl.<>o__67.<>p__11.Target;
						CallSite <>p__4 = CustomTabControl.<>o__67.<>p__11;
						if (CustomTabControl.<>o__67.<>p__10 == null)
						{
							CustomTabControl.<>o__67.<>p__10 = CallSite<Func<CallSite, int, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(CustomTabControl), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						if (target4(<>p__4, CustomTabControl.<>o__67.<>p__10.Target(CustomTabControl.<>o__67.<>p__10, base.SelectedIndex, obj2)))
						{
							if (CustomTabControl.<>o__67.<>p__12 == null)
							{
								CustomTabControl.<>o__67.<>p__12 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(CustomTabControl)));
							}
							base.SelectedIndex = CustomTabControl.<>o__67.<>p__12.Target(CustomTabControl.<>o__67.<>p__12, obj);
						}
					}
					this.Refresh();
				}
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000FC48 File Offset: 0x0000DE48
		private void scintilla1_TextChanged(object sender, EventArgs e)
		{
			Scintilla scintilla = (Scintilla)sender;
			int length = scintilla.Lines.Count.ToString().Length;
			scintilla.Margins[0].Width = scintilla.TextWidth(10, new string('9', length + 1)) + 2;
		}

		// Token: 0x0600016D RID: 365
		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x0600016E RID: 366 RVA: 0x0000FC9A File Offset: 0x0000DE9A
		public void TabChanging(object sender, TabControlCancelEventArgs e)
		{
			if (e.TabPageIndex == base.TabCount - 1)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x040000A8 RID: 168
		private readonly StringFormat CenterSringFormat = new StringFormat
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Center
		};

		// Token: 0x040000A9 RID: 169
		private Color activeColor = Color.FromArgb(36, 36, 36);

		// Token: 0x040000AA RID: 170
		private Color backTabColor = Color.FromArgb(0, 0, 0);

		// Token: 0x040000AB RID: 171
		private Color borderColor = Color.FromArgb(30, 30, 30);

		// Token: 0x040000AC RID: 172
		private Color closingButtonColor = Color.WhiteSmoke;

		// Token: 0x040000AD RID: 173
		private string closingMessage;

		// Token: 0x040000AE RID: 174
		private Color headerColor = Color.FromArgb(45, 45, 48);

		// Token: 0x040000AF RID: 175
		private Color horizLineColor = Color.FromArgb(36, 36, 36);

		// Token: 0x040000B0 RID: 176
		private TabPage predraggedTab;

		// Token: 0x040000B1 RID: 177
		public TabPage contextTab;

		// Token: 0x040000B2 RID: 178
		private Color textColor = Color.FromArgb(255, 255, 255);

		// Token: 0x040000B3 RID: 179
		public Color selectedTextColor = Color.FromArgb(255, 255, 255);

		// Token: 0x040000B4 RID: 180
		public static Viper Form1;

		// Token: 0x040000B5 RID: 181
		private int count = 1;
	}
}

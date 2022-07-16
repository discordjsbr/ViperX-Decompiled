using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace New_Viper_X.Interface
{
	// Token: 0x0200000F RID: 15
	public static class Web
	{
		// Token: 0x06000141 RID: 321 RVA: 0x0000E310 File Offset: 0x0000C510
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public static Data.ScriptHubHolder GetScriptData(string url)
		{
			string text = "";
			try
			{
				using (WebClient webClient = new WebClient())
				{
					text = webClient.DownloadString(url);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Não foi possível baixar o script hub!", "Viper X - Web Exception");
				return new Data.ScriptHubHolder();
			}
			return JsonConvert.DeserializeObject<Data.ScriptHubHolder>(text);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000E37C File Offset: 0x0000C57C
		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public static bool DownloadDLL(string name)
		{
			bool result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					if (!(name == "Krnl.dll"))
					{
						if (!(name == "exploit-main.dll"))
						{
							if (!(name == "oydECfGU5Z.dll"))
							{
								if (name == "oxygen.dll")
								{
									webClient.DownloadFile("https://github.com/iDevastate/Oxygen-v2/raw/main/OxygenBytecode.vmp.dll", "oxygen.dll");
								}
							}
							else
							{
								webClient.DownloadFile(JToken.Parse(webClient.DownloadString("https://cometrbx.xyz/external-files/CometJSONVer.json")).ToList<JToken>()[0]["DLLInstall"].ToString(), "oydECfGU5Z.dll");
							}
						}
						else
						{
							webClient.DownloadFile(JObject.Parse(webClient.DownloadString("https://cdn.wearedevs.net/software/exploitapi/latestdata.json"))["exploit-module"]["download"].ToString(), "exploit-main.dll");
						}
					}
					else
					{
						webClient.DownloadFile("https://k-storage.com/bootstrapper/files/krnl.dll", "Krnl.dll");
					}
				}
				result = File.Exists(name);
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}

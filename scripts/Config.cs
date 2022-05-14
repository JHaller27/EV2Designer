using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EV2Designer
{
	public class Config
	{
		public List<FileConfigItem> ResourcePaths { get; set; }
		public List<FileConfigItem> RolloutPaths { get; set; }
		public List<FileConfigItem> ServiceModelPaths { get; set; }
		public List<FileConfigItem> ScopeBindingPaths { get; set; }

		public static Config LoadFromFile(string path)
		{
			string configText = File.ReadAllText(path);
			return JsonConvert.DeserializeObject<Config>(configText);
		}
	}

	public class FileConfigItem
	{
		public string Path { get; set; }
		public string Name { get; set; }
	}
}

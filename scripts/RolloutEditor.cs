using Godot;
using EV2Designer;

public class RolloutEditor : Control
{
	private MetadataHandler Metadata { get; set; }
	private Config Config { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Metadata = new MetadataHandler(this);
	}

	public void LoadConfig(Config config, FileConfigItem fileConfigItem)
	{
		this.Config = config;

		foreach (FileConfigItem serviceModelItem in this.Config.ServiceModelPaths)
		{
			this.Metadata.AddServiceModel(serviceModelItem.Name, serviceModelItem.Path);
		}

		foreach (FileConfigItem scopeBindingsItem in this.Config.ScopeBindingPaths)
		{
			this.Metadata.AddScopeBindings(scopeBindingsItem.Name, scopeBindingsItem.Path);
		}
	}

	private class MetadataHandler
	{
		private OptionButton ServiceModelOption { get; }
		private OptionButton ScopeBindingsOption { get; }

		public MetadataHandler(Node root)
		{
			Node metadataRoot = root.GetNode("VSplitContainer").GetNode("VBoxContainer");

			this.ServiceModelOption = metadataRoot.GetNode("ServiceModelContainer").GetNode<OptionButton>("Input");
			this.ScopeBindingsOption = metadataRoot.GetNode("ScopeBindingsContainer").GetNode<OptionButton>("Input");
		}

		public void AddServiceModel(string name, string path) => AddOptionItem(this.ServiceModelOption, name, path);

		public void AddScopeBindings(string name, string path) => AddOptionItem(this.ScopeBindingsOption, name, path);

		private static void AddOptionItem(OptionButton optionButton, string name, object metadata)
		{
			int newIdx = optionButton.GetItemCount();

			optionButton.AddItem(name, newIdx);
			optionButton.SetItemMetadata(newIdx, metadata);
		}
	}
}

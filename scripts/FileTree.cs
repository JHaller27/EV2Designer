using System.Collections.Generic;
using EV2Designer;
using Godot;

public class FileTree : Tree
{
	private TreeItem ResourcesSection { get; set; }
	private TreeItem ServiceModelSection { get; set; }
	private TreeItem ScopeBindingSection { get; set; }
	private TreeItem RolloutSection { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.HideRoot = true;

		TreeItem root = this.CreateItem();

		root.SetText(0, "ROOT");

		this.ResourcesSection = this.CreateItem();
		this.ResourcesSection.SetText(0, "Resources");

		this.ServiceModelSection = this.CreateItem();
		this.ServiceModelSection.SetText(0, "Service Models");

		this.ScopeBindingSection = this.CreateItem();
		this.ScopeBindingSection.SetText(0, "Scope Bindings");

		this.RolloutSection = this.CreateItem();
		this.RolloutSection.SetText(0, "Rollouts");
	}

	public void LoadProject(Config config)
	{
		this.LoadFileConfigs(config.ResourcePaths, this.ResourcesSection);
		this.LoadFileConfigs(config.ServiceModelPaths, this.ServiceModelSection);
		this.LoadFileConfigs(config.ScopeBindingPaths, this.ScopeBindingSection);
		this.LoadFileConfigs(config.RolloutPaths, this.RolloutSection);
	}

	private void LoadFileConfigs(List<FileConfigItem> configItems, Object sectionRoot)
	{
		foreach (FileConfigItem fileItem in configItems)
		{
			TreeItem item = this.CreateItem(sectionRoot);
			item.SetText(0, fileItem.Name);
		}
	}
}

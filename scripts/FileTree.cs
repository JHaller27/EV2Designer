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

		// TODO Use file dialog to load file
		Config config = Config.LoadFromFile("examples/example.evproj");
		this.LoadProject(config);
	}

	public void LoadProject(Config config)
	{
		foreach (FileConfigItem fileItem in config.ResourcePaths)
		{
			TreeItem item = this.CreateItem(this.ResourcesSection);
			item.SetText(0, fileItem.Name);
		}

		foreach (FileConfigItem fileItem in config.ServiceModelPaths)
		{
			TreeItem item = this.CreateItem(this.ServiceModelSection);
			item.SetText(0, fileItem.Name);
		}

		foreach (FileConfigItem fileItem in config.ScopeBindingPaths)
		{
			TreeItem item = this.CreateItem(this.ScopeBindingSection);
			item.SetText(0, fileItem.Name);
		}

		foreach (FileConfigItem fileItem in config.RolloutPaths)
		{
			TreeItem item = this.CreateItem(this.RolloutSection);
			item.SetText(0, fileItem.Name);
		}
	}
}

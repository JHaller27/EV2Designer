using Godot;

public class FileTree : Tree
{
	private TreeItem RolloutSection { get; set; }
	private TreeItem ResourcesSection { get; set; }
	private TreeItem ServiceModelSection { get; set; }
	private TreeItem ScopeBindingSection { get; set; }

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
}

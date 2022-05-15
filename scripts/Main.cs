using EV2Designer;
using Godot;

public class Main : Control
{
	private Config Config { get; set; }

	private FileTree FileTree { get; set; }
	private RolloutEditor RolloutEditor { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// TODO Use file dialog to load file
		Config config = Config.LoadFromFile("examples/example.evproj");

		this.FileTree = this.GetNode<FileTree>("Panel/HSplitContainer/FileTree");
		this.RolloutEditor = this.GetNode<RolloutEditor>("Panel/HSplitContainer/TabContainer/RolloutEditor");

		this.FileTree.LoadProject(config);
		this.RolloutEditor.LoadConfig(config, config.RolloutPaths[0]);
	}
}

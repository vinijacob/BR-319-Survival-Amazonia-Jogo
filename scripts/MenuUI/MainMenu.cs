using Godot;
using System;

public partial class MainMenu : Control
{
	private Button _startGameBtn;
	private Button _settingsBtn;
	private Button _quitBtn;

	public override void _Ready()
	{
		_startGameBtn = GetNode<Button>("VBoxContainer/VBoxContainer/StartBtn");
		_startGameBtn.Pressed += OnStartPressed;

		_settingsBtn = GetNode<Button>("VBoxContainer/VBoxContainer/HBoxContainer/SettingsBtn");
		_settingsBtn.Pressed += OnSettingsPressed;

		_quitBtn = GetNode<Button>("VBoxContainer/VBoxContainer/HBoxContainer/QuitBtn");
		_quitBtn.Pressed += OnQuitPressed;

	}

	public override void _Process(double delta)
	{
	}

	public void OnStartPressed()
	{
		GD.Print("Jogo Começando!");
		// GetTree().ChangeSceneToFile("res://scenes/levels/fase_01.tscn");
	}

	public void OnSettingsPressed()
	{
		GD.Print("Configurações");
	}

	public void OnQuitPressed()
	{
		GetTree().Quit();
	}

}

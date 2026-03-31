using Godot;
using System;

public partial class PhoneUi : Control
{
	private Control fundoCelular;
	private Label textoAlerta;
	private AudioStreamPlayer somSirene;

	// Posições de animação
	private Vector2 posEscondido = new Vector2(800, 700);
	private Vector2 posVisivel = new Vector2(800, 300);

	public override void _Ready()
	{
		fundoCelular = GetNode<Control>("FramePhone");
		textoAlerta = GetNode<Label>("FramePhone/TextAlert");
		somSirene = GetNode<AudioStreamPlayer>("AudioStreamPlayer2D");

		fundoCelular.Position = posEscondido;
	}

	public async void DispararAlerta(string mensagem)
	{
		textoAlerta.Text = mensagem;
		somSirene.Play();

		// Faz o celular subir "quicando"
		var tween = CreateTween();
		tween.TweenProperty(fundoCelular, "position", posVisivel, 0.5)
			 .SetTrans(Tween.TransitionType.Bounce);

		// Espera 3 segundos (sem pausar o jogo)
		await ToSignal(GetTree().CreateTimer(3.0), "timeout");

		// Faz o celular descer
		var tweenVolta = CreateTween();
		tweenVolta.TweenProperty(fundoCelular, "position", posEscondido, 0.5);
	}

	// Conecte o botão a este método
	private void OnBotaoTestePressed()
	{
		DispararAlerta("ALERTA: TROMBA D'ÁGUA!");
	}
}
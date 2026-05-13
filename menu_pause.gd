extends CanvasLayer

func _ready():
	# Garante que o menu comece invisível quando o jogo abrir
	visible = false

func _process(delta):
	# Aperte a tecla ESC (ui_cancel) para pausar ou despausar
	if Input.is_action_just_pressed("ui_cancel"):
		alternar_pause()

# Função que liga/desliga o pause
func alternar_pause():
	var novo_estado = not get_tree().paused
	get_tree().paused = novo_estado
	visible = novo_estado

# Sinal do botão "VOLTAR PRO BARRO"
func _on_botao_continuar_pressed():
	alternar_pause() # Tira o pause e esconde o menu

# Sinal do botão "DESISTIR"
func _on_botao_sair_pressed():
	# É muito importante tirar o pause ANTES de sair, senão o Menu Principal abre congelado!
	get_tree().paused = false 
	get_tree().change_scene_to_file("res://MenuPrincipal.tscn")

func _on_botao_voltar_pressed() -> void:
	pass # Replace with function body.

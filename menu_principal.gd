extends Control

# Função que roda quando clica no botão ACELERAR (Jogar)
func _on_botao_jogar_pressed():
	print("Botão Jogar foi clicado! Tentando abrir a seleção de fases...")
	get_tree().change_scene_to_file("res://selecao_fases.tscn")

# Função que roda quando clica no botão SAIR
func _on_botao_sair_pressed():
	print("Fechando o jogo...")
	get_tree().quit() # Esse comando fecha a janela do jogo de verdade

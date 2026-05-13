extends Control

# --- LINHA 1 DA GRADE ---

func _on_botao_fase_1_pressed():
	print("Iniciando: Trecho 1 - Saída de Manaus")
	# get_tree().change_scene_to_file("res://fases/Fase1.tscn")

func _on_botao_fase_2_pressed():
	print("Iniciando: Trecho 2 - O Grande Atoleiro")
	# get_tree().change_scene_to_file("res://fases/Fase2.tscn")

func _on_botao_fase_3_pressed():
	print("Iniciando: De novo, esse alerta civil!!!")
	# get_tree().change_scene_to_file("res://fases/Fase3.tscn")


# --- LINHA 2 DA GRADE ---

func _on_botao_fase_4_pressed():
	print("Iniciando: Teleze")
	# get_tree().change_scene_to_file("res://fases/Fase4.tscn")

func _on_botao_fase_5_pressed():
	print("Iniciando: Um dia me aposento")
	# get_tree().change_scene_to_file("res://fases/Fase5.tscn")

func _on_botao_fase_6_pressed():
	print("Iniciando: E esse buraco, meu prefeito?")
	# get_tree().change_scene_to_file("res://fases/Fase6.tscn")


# --- BOTÃO DE VOLTAR (Fora da Grade) ---

func _on_botao_voltar_pressed():
	print("Botão Voltar clicado! Retornando ao Menu Principal...")
	get_tree().change_scene_to_file("res://menu_principal.tscn")

func _on_voltar_pressed() -> void:
	pass # Replace with function body.

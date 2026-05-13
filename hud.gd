extends CanvasLayer

# Variáveis do jogo
var tempo_restante = 60.0
var entregas_feitas = 0
var jogo_rodando = true

# Aqui nós CRIAMOS os textos direto no código, sem depender da árvore de nós!
var label_tempo = Label.new()
var label_entregas = Label.new()

func _ready():
	# Configura e adiciona o texto do Tempo na tela
	label_tempo.position = Vector2(50, 50) # Posição na tela
	label_tempo.add_theme_font_size_override("font_size", 40) # Tamanho da letra
	add_child(label_tempo) # Faz o texto aparecer!
	
	# Configura e adiciona o texto das Entregas na tela
	label_entregas.position = Vector2(50, 120)
	label_entregas.add_theme_font_size_override("font_size", 40)
	add_child(label_entregas)
	
	atualizar_textos()

func _process(delta):
	if jogo_rodando:
		tempo_restante -= delta
		label_tempo.text = "⏳ " + str(int(tempo_restante)) + "s"
		
		if tempo_restante <= 0:
			jogo_rodando = false
			label_tempo.text = "TEMPO ESGOTADO!"

func atualizar_textos():
	label_entregas.text = "📦 Entregas: %d / 5" % entregas_feitas

func _input(event):
	if event.is_action_pressed("ui_accept"):
		if jogo_rodando:
			entregas_feitas += 1
			atualizar_textos()

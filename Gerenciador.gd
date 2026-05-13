extends Node

# Esse sinal avisa o HUD que os números mudaram
signal atualizou_hud

var tempo_restante = 60.0
var entregas_feitas = 0
var entregas_meta = 5
var jogo_rodando = false

# Função que dá o "Play" no jogo
func iniciar_partida():
	tempo_restante = 60.0
	entregas_feitas = 0
	jogo_rodando = true
	atualizou_hud.emit()

# Função que soma os pontos
func pontuar_entrega():
	entregas_feitas += 1
	atualizou_hud.emit()
	
	if entregas_feitas >= entregas_meta:
		jogo_rodando = false
		print("VITÓRIA! Você entregou tudo na BR-319!")

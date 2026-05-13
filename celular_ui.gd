extends Control

@onready var fundo_celular = $FundoCelular
@onready var texto_alerta = $FundoCelular/TextoAlerta
@onready var som_sirene = $SomSirene

# Posições de animação (Ajuste esses números dependendo do tamanho da sua tela)
var pos_escondido = Vector2(800, 700) # Fora da tela
var pos_visivel = Vector2(800, 300)   # No meio da tela

func _ready():
	fundo_celular.position = pos_escondido

func disparar_alerta(mensagem: String):
	texto_alerta.text = mensagem
	som_sirene.play()
	
	# Faz o celular subir "quicando"
	var tween = create_tween()
	tween.tween_property(fundo_celular, "position", pos_visivel, 0.5).set_trans(Tween.TRANS_BOUNCE)
	
	# Espera 3 segundos (O jogo NÃO pausa)
	await get_tree().create_timer(3.0).timeout
	
	# Faz o celular descer
	var tween_volta = create_tween()
	tween_volta.tween_property(fundo_celular, "position", pos_escondido, 0.5)

# Sinal do Botão de Teste (Conecte o sinal 'pressed' do botão aqui)
func _on_botao_teste_pressed():
	disparar_alerta("ALERTA: TROMBA D'ÁGUA!")

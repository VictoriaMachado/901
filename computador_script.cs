using UnityEngine;
using System.Collections;

public class computador_script : MonoBehaviour {

	// variavel para manipular o elemento que parece a tela do monitor ligado
	public GameObject telaMonitor;

	// variavel de controle de quando o jogador interagiu com o computador
	public static bool videoEncontrado = false;

	// temporizador para desativar a tela do monitor apos o fim do audio de teclado
	public static float timer = 3.0f;


	// Use this for initialization
	void Start () {

		// reset de variaveis
		videoEncontrado = false;
		timer = 3.0f;

		// desativa a tela do monitor
		telaMonitor.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {

		// quando houver coletado todas as notas e ainda nao interagiu com o computador, executa
		if((notasUI.notasColetadas == 5) && (!videoEncontrado))
		{
			// ativa a tela do monitor
			telaMonitor.SetActive (true);
		}
		// quando o jogador interagiu com o computador, executa
		if(videoEncontrado)
		{
			// contagem regressiva do temporizador da tela
			timer -= Time.deltaTime;
		}
		// quando o tempo terminar, executa
		if(timer <= 0)
		{
			// desativa a tela do monitor
			telaMonitor.SetActive (false);
		}
	
	}
}

using UnityEngine;
using System.Collections;

public class susto_visao : MonoBehaviour {

	// variavel que coleta o nome do objeto em que o script esta anexado
	private string nomeObjeto;
	// variavel que controla se foi detectado que o jogador esta olhando para o susto
	private bool JogadorVendo = false;


	// Use this for initialization
	void Start () {

		// armazena o nome do objeto
		nomeObjeto = gameObject.name;
		
	}
	
	// Update is called once per frame
	void Update () {

		// executa se o jogador esta olhando na direcao e na distancia correta
		if(JogadorVendo)
		{
			// identifica de qual sistema de susto o objeto pertence e ativa a deteccao da visao do jogador
			switch(nomeObjeto)
			{
				case "GhostF":
					susto_script.SustoFundoV = true;
					break;
				case "GhostH":
					susto_script.SustoHallV = true;
					break;
				case "GhostC":
					susto_script.SustoCorredorV = true;
					break;
				case "GhostL":
					susto_script.SustoLabV = true;
					break;
				default: break;
			}
		}
		
	}

	// metodo que executa sempre que algum objeto entrar no Trigger
	void OnTriggerEnter (Collider other) {

		// caso o objeto detectado dentro do Trigger seja a visao do jogador, executa
		if(other.CompareTag("PlayerView"))
		{
			// define que o jogador esta olhando para o susto
			JogadorVendo = true;
		}
		
	}


}

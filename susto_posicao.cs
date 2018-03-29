using UnityEngine;
using System.Collections;

public class susto_posicao : MonoBehaviour {

	// variavel que coleta o nome do objeto em que o script esta anexado
	private string nomeObjeto;
	// variavel que controla se o jogador foi detectado na posicao de susto
	private bool JogadorPosicionado = false;


	// Use this for initialization
	void Start () {

		// armazena o nome do objeto
		nomeObjeto = gameObject.name;
	
	}
	
	// Update is called once per frame
	void Update () {

		// executa se o jogador esta ou estava na posicao
		if(JogadorPosicionado)
		{
			// identifica de qual sistema de susto o objeto pertence e ativa a deteccao da posicao do jogador
			switch(nomeObjeto)
			{
			case "SustoFundo":
				susto_script.SustoFundoP = true;
				break;
			case "SustoHall":
				susto_script.SustoHallP = true;
				break;
			case "SustoCorredor":
				susto_script.SustoCorredorP = true;
				break;
			case "SustoLab":
				susto_script.SustoLabP = true;
				break;
			default: break;
			}
		}
	
	}

	// metodo que executa sempre que algum objeto entrar no Trigger
	void OnTriggerEnter (Collider other) {

		// caso o objeto detectado dentro do Trigger seja o jogador, executa
		if(other.CompareTag("Player"))
		{
			// define que o jogador esta na posicao do susto
			JogadorPosicionado = true;
		}

	}


}

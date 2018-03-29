using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuControlador : MonoBehaviour {

	// variaveis para ativar e desativar os elementos do jogo
	public GameObject jogador;
	public GameObject hudUI;
	public GameObject menuCamera;
	public GameObject menuUI;
	public GameObject botaoJogar;
	public GameObject botaoContinue;
	public GameObject botaoConfiguracoes;
	public GameObject configuracaoCamera;
	public GameObject configuracaoUI;
	public GameObject introUI;
	public GameObject introducaoUI;
	public GameObject instrucoesUI;
	public GameObject luzes;
	public GameObject creditosUI;

	// temporizador de visibilidade das instrucoes na tela
	private float timerInstrucao = 8.0f;
	// controle de quando o jogador clicou para comecar o jogo (apos introducao)
	private bool comecarJogo = false;


	// Use this for initialization
	void Start () {

		// define o jogador (FPC) e a hud in game como desativadas
		jogador.SetActive (false);
		hudUI.SetActive (false);

		// define o menu principal como ativo
		menuUI.SetActive (true);
		menuCamera.SetActive (true);

		// define o botao de continue como falso
		botaoContinue.SetActive (false);

		// define o menu de configuracoes como desativado
		configuracaoUI.SetActive (false);
		configuracaoCamera.SetActive (false);

		// prepara a tela de introducao e instrucoes e define como desativada
		introducaoUI.SetActive (true);
		instrucoesUI.SetActive (false);
		introUI.SetActive (false);

		// define as luzes como desligadas
		luzes.SetActive (false);

		// define a tela de creditos como desativada
		creditosUI.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

		// executa quando o jogador finalizou o jogo (encontrou todas as notas, o video e passou o tempo de interacao do computador)
		if(computador_script.videoEncontrado)
		{
			// acende as luzes apos o som do teclado parar
			if(computador_script.timer <= 0)
			{
				// define as luzes como ligadas
				luzes.SetActive (true);
			}
			// exibicao dos creditos apos 2 segundos
			if(computador_script.timer <= -2)
			{
				// define o jogador (FPC) e a hud in game como desativadas
				jogador.SetActive (false);
				hudUI.SetActive (false);
				// ativa a camera do menu
				menuCamera.SetActive (true);
				// ativa os creditos na tela
				creditosUI.SetActive (true);
			}
			// volta ao menu principal de encerramento de jogo apos 15 segundos
			if(computador_script.timer <= -17)
			{
				// habilitando o cursor do mouse
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				// desativa os creditos na tela
				creditosUI.SetActive (false);
				// ativa o menu principal
				menuUI.SetActive (true);
				// desativa os botoes de jogar, continue e configuraçoes
				botaoJogar.SetActive (false);
				botaoContinue.SetActive (false);
				botaoConfiguracoes.SetActive (false);
			}
		}

		// executa quando o jogador clicou no botao Comecar na tela de introducao
		if(comecarJogo)
		{
			// contagem regressiva do temporizador de exibicao das instrucoes
			timerInstrucao -= Time.deltaTime;

			// executa quando o tempo de exibicao das instrucoes acaba
			if(timerInstrucao <= 0)
			{
				// desativa a tela de introducao e instrucoes
				introUI.SetActive (false);
				// desativa a camera do menu
				menuCamera.SetActive (false);
				// ativa o jogador na cena e a hud
				jogador.SetActive (true);
				hudUI.SetActive (true);
				// desativa o controle
				comecarJogo = false;

			}
		}

		// quando o jogador pressiona ESC
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			// impede do menu de pause ser acessado sem ser durante o jogo (ou seja, apenas quando o jogador esta ativo pode executar)
			if(jogador.activeInHierarchy)
			{
				// define o jogador (FPC) e a hud in game como desativadas
				jogador.SetActive (false);
				hudUI.SetActive (false);

				// habilitando o cursor do mouse
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

				// ativa o menu de pausa
				menuUI.SetActive (true);
				menuCamera.SetActive (true);

				// troca o botao de jogar por continue
				botaoJogar.SetActive (false);
				botaoContinue.SetActive (true);

			}

		}

	}

	// metodo que inicia o jogo quando o jogador clica no botao Jogar no menu principal
	public void StartGame () {

		// desativa o menu principal para dar inicio ao jogo
		menuUI.SetActive (false);

		// ativa a tela de introducao e instrucoes
		introUI.SetActive (true);
		introducaoUI.SetActive (true);
		instrucoesUI.SetActive (false);

	}

	// metodo que inicia o jogo quando o jogador clica no botao de Comecar na tela de introducao
	public void ComecarGame () {

		// desabilitando o cursor do mouse
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		// ativa a exibicao das intrucoes do jogo na tela
		instrucoesUI.SetActive (true);
		introducaoUI.SetActive (false);

		comecarJogo = true;
	}

	// metodo que inicia o jogo quando o jogador clica no botao Continue no menu de pausa
	public void ContinueGame () {
		
		// desabilitando o cursor do mouse
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		
		// desativa o menu principal para dar inicio ao jogo
		menuUI.SetActive (false);
		menuCamera.SetActive (false);
		
		// ativa o jogador na cena e a hud
		jogador.SetActive (true);
		hudUI.SetActive (true);
		
	}

	// metodo que abre o menu de configuracoes do jogo quando o jogador clica no botao Configuracoes no menu principal
	public void SettingsGame () {

		// desativa o menu principal
		menuUI.SetActive (false);
		menuCamera.SetActive (false);

		// ativa o menu de configuracoes
		configuracaoUI.SetActive (true);
		configuracaoCamera.SetActive (true);

	}

	// metodo ativado toda vez que o jogador muda o valor do Slider de audio no menu de configuracoes
	public void MudaVolume () {
		
		// ajusta o volume do audio de acordo com o valor do Slider
		AudioListener.volume = GameObject.FindGameObjectWithTag("Volume").GetComponent<Slider>().value;

	}

	// metodo ativado toda vez que o jogador muda o valor do Slider de video no menu de configuracoes
	public void MudaQualidade () {

		// coleta o valor atual no slider
		float quali = GameObject.FindGameObjectWithTag("Qualidade").GetComponent<Slider>().value;

		// define qual a qualidade selecionada
		if(quali >=0 && quali < 1)
		{
			// Fastest
			QualitySettings.SetQualityLevel(0);
		}
		else if(quali >=1 && quali < 2)
		{
			// Fast
			QualitySettings.SetQualityLevel(1);
		}
		else if(quali >=2 && quali < 3)
		{
			// Simple
			QualitySettings.SetQualityLevel(2);
		}
		else if(quali >=3 && quali < 4)
		{
			// Good
			QualitySettings.SetQualityLevel(3);
		}
		else if(quali >=4 && quali < 5)
		{
			// Beautiful
			QualitySettings.SetQualityLevel(4);
		}
		else if(quali >=5 && quali < 6)
		{
			// Fantastic
			QualitySettings.SetQualityLevel(5);
		}
	}

	// metodo que abre novamente o menu principal depois do jogador clicar em Voltar no menu de configuracoes
	public void QuitSettings () {

		// desativa o menu de configuracoes
		configuracaoUI.SetActive (false);
		configuracaoCamera.SetActive (false);

		// ativa o menu principal
		menuUI.SetActive (true);
		menuCamera.SetActive (true);

	}

	// metodo que encerra o jogo quando o jogador clica no botao Sair no menu principal
	public void QuitGame () {

		// fecha o jogo
		Application.Quit();

	}

}

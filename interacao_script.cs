using UnityEngine;
using System.Collections;

public class interacao_script : MonoBehaviour {

	// variavel da distancia maxima de interacao com portas e elevadores
	public float distancia1Interacao = 2.0f;
	// variavel da distancia maxima de interacao com portas de armarios
	public float distancia2Interacao = 2.5f;
	// variavel da distancia maxima de interacao com notas
	public float distancia3Interacao = 1.0f;
	// variavel da distancia maxima de interacao com computador
	public float distancia4Interacao = 1.5f;
	// variavel que armazena o valor a ser mudado no campo de visao da camera principal para ocorrer o zoom
	public float zoom = 30f;
	// variavel que armazena o valor padrao do campo de visao da camera principal
	public float normal = 60f;
	// variavel para suavizar a transicao da camera com zoom e sem zoom
	public float smooth = 5f;


	// variavel para manipular a exibicao do aviso de porta trancada na HUD
	public GameObject avisoTrancado;
	// variavel para manipular a exibicao do aviso do elevador na HUD
	public GameObject avisoElevador;
	// temporizador para a exibicao de aviso na HUD
	private float timerAviso = 0.0f;

	// variavel para o elemento com a imagem de fundo das notas
	public GameObject notaImagem;
	// variaveis para cada elemento diferente da HUD com o texto especifico de cada nota
	public GameObject nota1;
	public GameObject nota2;
	public GameObject nota3;
	public GameObject nota4;
	public GameObject nota5;
	// variavel para manipular a exibicao do aviso de como fechar notas
	public GameObject avisoNota;
	
	// variavel de controle de visualizacao de notas
	public bool verNota;
	// variavel de temporizador de tempo minimo de exibicao de uma nota na HUD
	private float timerNotamin = 0.0f;

	// variavel para ativar e desativar avisos de interacao na HUD
	public GameObject avisoInteracao;

	// variavel de temporizador de tempo minimo de exibicao de avisoInteracao na HUD
	private float timerInter = 0.0f;

	// variavel que armazena a posicao do ray da camera do jogador a cada frame
	Ray ray1;



	// Use this for initialization
	void Start () {

		// reset de variaveis
		distancia1Interacao = 2.0f;
		distancia2Interacao = 2.5f;
		distancia3Interacao = 1.0f;
		distancia4Interacao = 1.5f;
		zoom = 30f;
		normal = 60f;
		smooth = 5f;
		timerNotamin = 0.0f;
		timerInter = 0.0f;


		// define o estado de visualizacao de nota
		verNota = false;

		// desabilita os elementos das notas
		notaImagem.SetActive (false);
		nota1.SetActive (false);
		nota2.SetActive (false);
		nota3.SetActive (false);
		nota4.SetActive (false);
		nota5.SetActive (false);
		avisoNota.SetActive (false);

		// desabilita os avisos na HUD
		avisoTrancado.SetActive (false);
		avisoElevador.SetActive (false);
		avisoInteracao.SetActive (false);
	
	}


	// Update is called once per frame
	void Update () {

				/* COMANDO DE AVISO DE INTERACAO */

		// armazena a posicao do ray da camera do jogador a cada frame
		ray1.origin = transform.position;
		ray1.direction = transform.forward;
		// variavel que recebe informacao do raycast declarado
		RaycastHit hit1;

		// possivel interacao com portas
		if(Physics.Raycast(ray1, out hit1, distancia1Interacao))
		{
			// PORTAS
			if(hit1.collider.CompareTag("Door"))
			{
				// ativa aviso de possivel interacao na HUD
				avisoInteracao.SetActive (true);
				timerInter = 0.1f;
			}
			// PORTAS TRANCADAS
			else if(hit1.collider.CompareTag("DoorL"))
			{
				// ativa aviso de possivel interacao na HUD
				avisoInteracao.SetActive (true);
				timerInter = 0.1f;
			}
		}
		// possivel interacao com portas de armarios
		if(Physics.Raycast(ray1, out hit1, distancia2Interacao))
		{
			// PORTAS DE ARMARIOS
			if(hit1.collider.CompareTag("DoorA"))
			{
				// ativa aviso de possivel interacao na HUD
				avisoInteracao.SetActive (true);
				timerInter = 0.1f;
			}
			// PORTAS DE ARMARIOS
			else if(hit1.collider.CompareTag("DoorAr"))
			{
				// ativa aviso de possivel interacao na HUD
				avisoInteracao.SetActive (true);
				timerInter = 0.1f;
			}
		}
		// possivel interacao com notas
		if(Physics.Raycast(ray1, out hit1, distancia3Interacao))
		{
			// NOTAS
			if(hit1.collider.CompareTag("Note"))
			{
				// ativa aviso de possivel interacao na HUD
				avisoInteracao.SetActive (true);
				timerInter = 0.1f;
			}
		}
		// possivel interacao com computador
		if(Physics.Raycast(ray1, out hit1, distancia4Interacao))
		{
			// controla que so sera ativado o aviso apos o jogador coletar todas as notas, quando o computador estiver ligado
			if(notasUI.notasColetadas == 5)
			{
				// COMPUTADOR
				if(hit1.collider.CompareTag("Keyboard"))
				{
					// ativa aviso de possivel interacao na HUD
					avisoInteracao.SetActive (true);
					timerInter = 0.1f;
				}
			}
		}
		


		/* COMANDO DE ZOOM */

		// quando o botao direito do mouse eh pressionado (comando de zoom), executa o if
		if(Input.GetMouseButton(1))
		{
			// acessa o componente da camera principal e altera o campo de visao (fieldOfView) para o valor de zoom, de forma suavizada
			GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);

		}
		// quando o botao direito do mouse nao esta pressionado, executa o else
		else
		{
			// acessa o componente da camera principal e altera o campo de visao (fieldOfView) para o valor normal (padrao, sem zoom), de forma suavizada
			GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);

		}


				/* COMANDO DE INTERACAO COM PORTAS, NOTAS E ELEVADORES */

		// contagem regressiva do temporizador a cada frame (sera usado na linha 111)
		timerAviso -= Time.deltaTime;

		// contagem regressiva do temporizador de visualizacao minima da nota
		timerNotamin -= Time.deltaTime;

		// contagem regressiva do temporizador de visualizacao minima do aviso de interacao
		timerInter -= Time.deltaTime;


		// quando a tecla E eh pressionada (comando de interacao com portas), executa o if
		if (Input.GetKeyDown(KeyCode.E)) 
		{
			// estabelece uma variavel que armazena a posicao dos rays do objeto (no caso eh usado o da camera)
			Ray ray2 = new Ray(transform.position, transform.forward);
			// variavel que recebe informacao do raycast declarado
			RaycastHit hit2;

			// se a interacao do jogador for feita dentro da distancia estabelecida como valida, executa o if
			if(Physics.Raycast(ray2, out hit2, distancia1Interacao))
			{
				// INICIO PORTAS
				// analiza se o objeto colidido com o raycast tem a tag de porta, se sim, executa o if
				if(hit2.collider.CompareTag("Door"))
				{
					// obtem o conteudo do script no objeto pai (necessario para correcao do pivot da porta) e executa a mudanca do estado da porta
					hit2.collider.transform.parent.GetComponent<porta_scritpt>().ChangeDoorState();
				}
				// se o objeto colidido tiver tag de porta trancada, executa o else if
				else if(hit2.collider.CompareTag("DoorL"))
				{
					// habilita o aviso de porta trancada na HUD
					avisoTrancado.SetActive(true);

					// inicia o contador
					timerAviso = 2.0f;
				}
				// FIM PORTAS
				// INICIO ELEVADOR
				// se o objeto colidido tiver tag de elevador, executa o else if
				else if(hit2.collider.CompareTag("Elevator"))
				{
					// habilita o aviso de elevador na HUD
					avisoElevador.SetActive(true);
					
					// inicia o contador
					timerAviso = 2.0f;
				}
				// FIM ELEVADOR
			}
			// INICIO PORTAS (armario)
			// se a interacao do jogador for feita dentro da distancia estabelecida como valida, executa o if
			if(Physics.Raycast(ray2, out hit2, distancia2Interacao))
			{
				// analiza se o objeto colidido com o raycast tem a tag de porta de armario, se sim, executa o if
				if(hit2.collider.CompareTag("DoorA"))
				{
					// obtem o conteudo do script no objeto pai (necessario para correcao do pivot da porta) e executa a mudanca do estado da porta
					hit2.collider.transform.parent.GetComponent<porta_scritpt>().ChangeDoorState();
				}
				// analiza se o objeto colidido com o raycast tem a tag de porta de armario (com o pivot nativo na posicao correta), se sim, executa o else if
				else if(hit2.collider.CompareTag("DoorAr"))
				{
					// obtem o conteudo do script no objeto e executa a mudanca do estado da porta
					hit2.collider.GetComponent<porta_scritpt>().ChangeDoorState();
				}
			}
			// FIM PORTAS (armario)
			// INICIO NOTAS
			// se a interacao do jogador for feita dentro da distancia estabelecida como valida, executa o if
			if(Physics.Raycast(ray2, out hit2, distancia3Interacao))
			{
				// analiza se o objeto colidido com o raycast tem a tag de notas, se sim, executa o if
				if(hit2.collider.CompareTag("Note"))
				{
					// modifica o estado da variavel de controle
					verNota = true;
					
					// acessa o objeto colidido e desativa ele de cena
					hit2.collider.gameObject.SetActive(false);
					
					// adiciona uma nota ao contador de notas que esta no script de notas da HUD
					notasUI.notasColetadas++;
					
					// inicia o contador
					timerNotamin = 2.0f;
				}
			}
			// FIM NOTAS
			//INICIO COMPUTADOR
			if(Physics.Raycast(ray2, out hit2, distancia4Interacao))
			{
				if(notasUI.notasColetadas == 5)
				{
					if(hit2.collider.CompareTag("Keyboard"))
					{
						hit2.collider.GetComponent<AudioSource>().Play();
						computador_script.videoEncontrado = true;
					}
				}
			}
			// FIM COMPUTADOR
		}

		// INICIO NOTAS
		// caso o jogador esteja visualizando uma nota, executa
		if(verNota)
		{
			// ativa a imagem de fundo da visualizacao de nota e o aviso de como fechar a nota
			notaImagem.SetActive (true);
			avisoNota.SetActive (true);

			// confere qual a nota que deve ser exibida
			switch (notasUI.notasColetadas){
				
				// exibe a primeira nota
				case 1:
					nota1.SetActive (true);
					break;
				
				// exibe a segunda nota
				case 2:
					nota2.SetActive (true);
					break;
				
				// exibe a terceira nota
				case 3:
					nota3.SetActive (true);
					break;
				
				// exibe a quarta nota
				case 4:
					nota4.SetActive (true);
					break;
				
				// exibe a quinta nota
				case 5:
					nota5.SetActive (true);
					break;
				
				default: break;	
			}
			
			// executa se jogador quiser fechar a visualizacao da nota (apertando E)
			if((Input.GetKeyDown(KeyCode.E)) && (timerNotamin <= 0))
			{
				// desabilita os elementos das notas
				notaImagem.SetActive (false);
				nota1.SetActive (false);
				nota2.SetActive (false);
				nota3.SetActive (false);
				nota4.SetActive (false);
				nota5.SetActive (false);
				avisoNota.SetActive (false);
				
				// modifica o estado da variavel de controle
				verNota = false;
			}
		}
		// FIM NOTAS

		// INICIO PORTA
		// se o aviso de porta trancada estiver ativo e o timer tiver chegado a zero, executa o if
		if((avisoTrancado.activeInHierarchy) && (timerAviso <= 0))
		{
			// desabilita o aviso de porta trancada na HUD
			avisoTrancado.SetActive(false);
		}
		// FIM PORTA

		// INICIO ELEVADOR
		// se o aviso de elevador estiver ativo e o timer tiver chegado a zero, executa o if
		if((avisoElevador.activeInHierarchy) && (timerAviso <= 0))
		{
			// desabilita o aviso de porta trancada na HUD
			avisoElevador.SetActive(false);
		}
		// FIM ELEVADOR

		// INICIO AVISO INTERACAO
		// se o aviso de elevador estiver ativo e o timer tiver chegado a zero, executa o if
		if((avisoInteracao.activeInHierarchy) && (timerInter <= 0))
		{
			// desabilita o aviso de interacao na HUD
			avisoInteracao.SetActive(false);
		}
		// FIM AVISO INTERACAO

	
	}

}

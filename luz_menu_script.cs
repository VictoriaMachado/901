using UnityEngine;
using System.Collections;

public class luz_menu_script : MonoBehaviour {

	// variaveis para estabelecer um tempo randomico entre as piscadas da luz
	public float minTimeOn = 2.5f;
	public float maxTimeOn = 4.0f;
	public float minTimeOff = 0.1f;
	public float maxTimeOff = 0.5f;
	private float timerOn;
	private float timerOff;
	

	// variaveis que irao manipular a luz e o som do objeto em que o script esta
	private Light l;
	public AudioSource somEstatica;


	// Use this for initialization
	void Start () {

		// reset de variaveis
		minTimeOn = 1.0f;
		maxTimeOn = 2.0f;
		minTimeOff = 0.1f;
		maxTimeOff = 0.5f;

		// obtem o conteudo da luz do objeto para manipulacao
		l = GetComponent<Light> ();

		// obtem o conteudo da audio source para manipulacao
		somEstatica = GetComponent<AudioSource> ();


		// estabelece um tempo aleatorio entre o valor maximo e minimo estabelecido
		timerOn = Random.Range (minTimeOn, maxTimeOn);
		timerOff = Random.Range (minTimeOff, maxTimeOff);
	
	}
	
	// Update is called once per frame
	void Update () {

		// enquanto o jogador nao tiver zerado o jogo, a luz do menu pisca
		if(!computador_script.videoEncontrado)
		{
			// executa quando a luz estiver ligada
			if(l.enabled)
			{
				// contagem regressiva do tempo da luz ligada a cada frame
				timerOn -= Time.deltaTime;
				
				// quando o tempo da luz ligada acaba, executa o if
				if(timerOn <= 0)
				{
					// desliga a luz
					l.enabled = false;
					
					// executa o audio
					somEstatica.Play();
					
					// estabelece um novo tempo aleatorio
					timerOn = Random.Range (minTimeOn, maxTimeOn);
					
				}
				
			}
			// executa quando a luz estiver desligada
			else
			{
				// contagem regressiva do tempo da luz desligada a cada frame
				timerOff -= Time.deltaTime;
				
				// quando o tempo da luz desligada acaba, executa o if
				if(timerOff <= 0)
				{
					// liga a luz
					l.enabled = true;
					
					// executa o audio
					somEstatica.Play();
					
					// estabelece um novo tempo aleatorio
					timerOff = Random.Range (minTimeOff, maxTimeOff);
					
				}
			}
		}

	
	}
}

using UnityEngine;
using System.Collections;

public class porta_scritpt : MonoBehaviour {

	// variavel que verifica o estado da porta (se aberta = true / se fechada = false)
	public bool aberto = false;
	// variaveis que definem os valores da angulacao da porta aberta e fechada
	public float anguloAberto = 90f;
	public float anguloFechado = 0f;
	// variavel para suavizar a abertura e fechamento da porta quando ocorre a mudanca de estado
	public float suave = 3f;
	

	public AudioClip soundOpen;
	public AudioClip soundClose;


	// Use this for initialization
	void Start () {
	
	}

	// metodo que muda o estado da porta
	public void ChangeDoorState () {

		// caso a porta esteja aberta (true), sera mudada para fechada (false), ou vice-versa
		aberto = !aberto;

		// caso o estado da porta esteja como aberto, executa o if
		if (aberto) 
		{
			// coleta o componente de audio
			AudioSource audio = GetComponent<AudioSource>();
			// define o audio como o som de abrir porta
			audio.clip = soundOpen;
			// executa o audio
			audio.Play();
		}
		// caso o estado da porta esteja como fechado, executa o else
		else 
		{
			// coleta o componente de audio
			AudioSource audio = GetComponent<AudioSource>();
			// define o audio como o som de fechar porta
			audio.clip = soundClose;
			// executa o audio
			audio.Play();
		}


	}
	
	// Update is called once per frame
	void Update () {

		// caso o estado da porta esteja como aberto, executa o if
		if (aberto) 
		{
			// cria uma variavel local para rotacionar a porta
			Quaternion rotacionadoA = Quaternion.Euler(0, anguloAberto, 0);
			// rotaciona a porta para a posicao de aberta e com suavidade
			transform.localRotation = Quaternion.Slerp(transform.localRotation, rotacionadoA, suave * Time.deltaTime);
		}
		// caso o estado da porta esteja como fechado, executa o else
		else 
		{
			// cria uma variavel local para rotacionar a porta
			Quaternion rotacionadoF = Quaternion.Euler(0, anguloFechado, 0);
			// rotaciona a porta para a posicao de fechada e com suavidade
			transform.localRotation = Quaternion.Slerp(transform.localRotation, rotacionadoF, suave * Time.deltaTime);
		}

	}
}

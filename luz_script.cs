using UnityEngine;
using System.Collections;

public class luz_script : MonoBehaviour {

	// variaveis que definem o som de ligar e desligar da lanterna
	public AudioClip soundOn;
	public AudioClip soundOff;
	// variavel que acessa o componente de luz da lanterna
	private Light l;

	// Use this for initialization
	void Start () {
		// acessa o componente de luz para manipulacao
		l = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown(KeyCode.F)) 
		{
			// troca o estado da luz entre ligado e desligado
			l.enabled = !l.enabled;

			// se a luz estiver ligada, executa
			if(l.enabled == true)
			{
				// coleta o componente de audio
				AudioSource audio = GetComponent<AudioSource>();
				// define o audio como o som de ligar
				audio.clip = soundOn;
				// executa o audio
				audio.Play();
			}
			// se a luz estiver desligada, executa
			else
			{
				// coleta o componente de audio
				AudioSource audio = GetComponent<AudioSource>();
				// define o audio como o som de desligar
				audio.clip = soundOff;
				// executa o audio
				audio.Play();
			}

		}
	
	}
}

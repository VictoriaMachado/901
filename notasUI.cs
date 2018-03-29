using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class notasUI : MonoBehaviour {

	// variaveis de controle de quantas notas existem e quantas foram coletadas
	public static int notasColetadas = 0;
	public int notasTotal = 5;

	// variavel para manipulacao do texto dentro a UI
	public Text notaUI;


	// Use this for initialization
	void Start () {

		// reset de variaveis
		notasColetadas = 0;
		notasTotal = 5;
	
	}
	
	// Update is called once per frame
	void Update () {

		// coleta o conteudo de texto
		notaUI = GetComponent<Text>();

		// manipulacao do texto a cada frame com os valores atualizados (sera manipulado em outro script)
		notaUI.text = ("Notas: " + notasColetadas + "/" + notasTotal);


	
	}
}

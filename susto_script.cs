using UnityEngine;
using System.Collections;

public class susto_script : MonoBehaviour {

	// variaveis para controle de ativacao do SustoFundo
	public static bool SustoFundoV = false;
	public static bool SustoFundoP = false;
	// variaveis para controle de ativacao do SustoHall
	public static bool SustoHallV = false;
	public static bool SustoHallP = false;
	// variaveis para controle de ativacao do SustoCorredor
	public static bool SustoCorredorV = false;
	public static bool SustoCorredorP = false;
	// variaveis para controle de ativacao do SustoLab
	public static bool SustoLabV = false;
	public static bool SustoLabP = false;

	// variaveis para ativacao dos sustos
	public GameObject SFundoV;		// contem a deteccao de posicao da visao do jogador
	public GameObject SFundoP;		// contem todo o sistema de deteccao de susto e a deteccao de posicao do jogador
	public GameObject SFundoF;		// contem o fantasma do sistema

	public GameObject SHallV;		// contem a deteccao de posicao da visao do jogador
	public GameObject SHallP;		// contem todo o sistema de deteccao de susto e a deteccao de posicao do jogador
	public GameObject SHallF;		// contem o fantasma do sistema

	public GameObject SCorredorV;	// contem a deteccao de posicao da visao do jogador
	public GameObject SCorredorP;	// contem todo o sistema de deteccao de susto e a deteccao de posicao do jogador
	public GameObject SCorredorF;	// contem o fantasma do sistema

	public GameObject SLabF;		// contem o fantasma do sistema
	public GameObject SLabP;		// contem todo o sistema de deteccao de susto e a deteccao de posicao do jogador
	public GameObject SLabV;		// contem a deteccao de posicao da visao do jogador
	public GameObject TargetL;		// contem o alvo do fantasma

	// variaveis de temporizadores de sustos
	private float timerF = 1.8f;	// SustoFundo
	private float timerH = 5.0f;	// SustoHall
	private float timerC = 1.8f;	// SustoCorredor
	private float timerL = 7.0f;	// SustoLab


	// Use this for initialization
	void Start () {
		// ativa todos os sistemas de susto e deteccao de posicao do jogador
		SFundoP.SetActive (true);
		SHallP.SetActive (true);
		SCorredorP.SetActive (true);
		SLabP.SetActive (true);

		// desativa deteccoes de visao do jogador e fantasmas
		SFundoV.SetActive (false);
		SFundoF.SetActive (false);
		SHallV.SetActive (false);
		SHallF.SetActive (false);
		SCorredorV.SetActive (false);
		SCorredorF.SetActive (false);
		SLabV.SetActive (false);
		SLabF.SetActive (false);
		TargetL.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {

		// executa apenas quando o jogador for detectado na posicao do SustoCorredor
		if(SustoCorredorP)
		{
			// ativa a deteccao de visao do jogador
			SCorredorV.SetActive (true);
		}
		// executa apenas quando o jogador for detectado na posicao do SustoFundo
		if(SustoFundoP)
		{
			// ativa a deteccao de visao do jogador
			SFundoV.SetActive (true);
		}
		// executa apenas quando o jogador for detectado na posicao do SustoHall
		if(SustoHallP)
		{
			// ativa a deteccao de visao do jogador
			SHallV.SetActive (true);
		}
		// executa apenas quando o jogador for detectado na posicao do SustoLab
		if(SustoLabP)
		{
			// ativa a deteccao de visao do jogador
			SLabV.SetActive (true);
		}

		// executa quando a posicao do jogador e posicao da visao do jogador de um mesmo susto sao validas
		if(SustoFundoP && SustoFundoV)
		{
			// ativa o fantasma
			SFundoF.SetActive (true);
		}
		else if(SustoHallP && SustoHallV)
		{
			// ativa o fantasma
			SHallF.SetActive (true);
		}
		else if(SustoCorredorP && SustoCorredorV)
		{
			// ativa o fantasma
			SCorredorF.SetActive (true);
		}
		else if(SustoLabP && SustoLabV)
		{
			// ativa o alvo do fantasma e o fantasma
			TargetL.SetActive (true);
			SLabF.SetActive (true);
		}

		// executa quando o fantasma respectivo de cada sistema esta ativado
		if(SFundoF.activeInHierarchy)
		{
			// inicia o temporizador do SustoFundo
			timerF -= Time.deltaTime;
		}
		else if(SHallF.activeInHierarchy)
		{
			// inicia o temporizador do SustoHall
			timerH -= Time.deltaTime;
		}
		else if(SCorredorF.activeInHierarchy)
		{
			// inicia o temporizador do SustoCorredor
			timerC -= Time.deltaTime;
		}
		else if(SLabF.activeInHierarchy)
		{
			// inicia o temporizador do SustoLab
			timerL -= Time.deltaTime;
		}

		// executa quando os tempos dos respectivos temporizadores chega ao fim
		if(timerF <= 0)
		{
			// desativa o sistema do SustoFundo
			SFundoP.SetActive (false);
		}
		if(timerH <= 0)
		{
			// desativa o sistema do SustoHall
			SHallP.SetActive (false);
		}
		if(timerC <= 0)
		{
			// desativa o sistema do SustoCorredor
			SCorredorP.SetActive (false);
		}
		if(timerL <= 0)
		{
			// desativa o sistema do SustoLab
			SLabP.SetActive (false);
		}
		
	}


}

using UnityEngine;
using System.Collections;

public class fantasma_script : MonoBehaviour {

	// variavel que coleta o nome do objeto em que o script esta anexado
	private string nomeObjeto;

	// variavel para definir o alvo do fantasma
	public GameObject navTarget;
	// variavel para manipulacao do navegador do objeto (fantasma)
	NavMeshAgent navAgent;


	// Use this for initialization
	void Start () {

		// armazena o nome do objeto
		nomeObjeto = gameObject.name;
		// executa apenas quando o fantasma estiver ativo
		if(gameObject.activeInHierarchy)
		{
			// executa apenas quando o objeto tiver o nome de fantasma
			if(nomeObjeto == "fantasma")
			{
				// obtem o conteudo do navmeshagent dentro do objeto para manipulacao
				navAgent = GetComponent<NavMeshAgent> ();
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		// executa apenas quando o fantasma estiver ativo
		if(gameObject.activeInHierarchy)
		{
			// executa apenas quando o objeto tiver o nome de fantasma
			if(nomeObjeto == "fantasma")
			{
				// a cada frame atualiza o destino do navegador do objeto (fantasma) para a posicao do alvo
				navAgent.SetDestination (navTarget.transform.position);
			}
		}
	
	}
}

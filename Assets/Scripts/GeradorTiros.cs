using UnityEngine;
using System.Collections;

public class GeradorTiros : MonoBehaviour
{
    public GameObject tiroPrefab; // Objeto do tiro
    public float intervaloDeTiro = 0.1f; // Intervalo de tempo entre os tiros
    private float tempoDecorrido = 0f; // Tempo decorrido desde o último tiro
    public float forca;

    void Update()
    {
        // Incrementa o tempo decorrido
        tempoDecorrido += Time.deltaTime;

        // Verifica se o tempo decorrido é maior ou igual ao intervalo de tiro
        if (tempoDecorrido >= intervaloDeTiro)
        {
            // Instancia um novo tiro
            GameObject novoTiro = Instantiate(tiroPrefab, transform.position, transform.rotation);

            // Adiciona uma velocidade ao tiro na direção Z negativo
            novoTiro.GetComponent<Rigidbody>().velocity = Vector3.forward * forca;

            // Reinicia o tempo decorrido
            tempoDecorrido = 0f;

            // Inicia a rotina para aguardar o próximo tiro
            StartCoroutine(AguardarProximoTiro());
        }
    }

    IEnumerator AguardarProximoTiro()
    {
        // Aguarda o intervalo de tempo antes de permitir o próximo tiro
        yield return new WaitForSeconds(intervaloDeTiro);
    }
}

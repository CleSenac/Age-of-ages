using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocidade = 5f; // Velocidade de movimento
    public float limiteEsquerdo = -5f; // Limite esquerdo do movimento
    public float limiteDireito = 5f; // Limite direito do movimento

    void Update()
    {
        // Verifica entrada do teclado
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        // Verifica entrada de toque na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
                movimentoHorizontal = -1f; // Toque à esquerda, movimento para a esquerda
            else
                movimentoHorizontal = 1f; // Toque à direita, movimento para a direita
        }

        // Calcula o movimento apenas no eixo X
        Vector3 movimento = new Vector3(movimentoHorizontal, 0f, 0f) * velocidade * Time.deltaTime;

        // Calcula a nova posição do objeto
        Vector3 novaPosicao = transform.position + movimento;

        // Limita a nova posição dentro dos limites definidos
        novaPosicao.x = Mathf.Clamp(novaPosicao.x, limiteEsquerdo, limiteDireito);

        // Aplica o movimento ao transform do objeto
        transform.position = novaPosicao;
    }
}

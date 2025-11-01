using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Material mat;
    private float distance;

    // Controla a velocidade do deslocamento da textura
    [Range(0f, 5f)]
    public float speed = 0.5f;

    void Start()
    {
        // Pega o material do Renderer (SpriteRenderer ou MeshRenderer)
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Calcula deslocamento com base no tempo
        distance += Time.deltaTime * speed;

        // Aplica deslocamento no eixo X (direita → esquerda)
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}

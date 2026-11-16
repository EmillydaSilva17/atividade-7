using UnityEngine;

[RequireComponent(typeof(Light))]
public class LuzFogueira : MonoBehaviour
{
    [Header("Intensidade")]
    public float intensidadeMinima = 3f;
    public float intensidadeMaxima = 7f;

    [Header("Movimento")]
    public float velocidade = 3f;
    public float deslocamento = 0.05f;

    private Light luz;
    private Vector3 posicaoInicial;
    private float semente;

    void Awake()
    {
        luz = GetComponent<Light>();
        posicaoInicial = transform.localPosition;
        semente = Random.Range(0f, 100f);
    }

    void Update()
    {
        float t = Time.time * velocidade;

        // Ruído suave para a intensidade tremular
        float ruido = Mathf.PerlinNoise(t, semente);
        luz.intensity = Mathf.Lerp(intensidadeMinima, intensidadeMaxima, ruido);

        // Pequeno balanço da posição, como se a chama dançasse
        float x = Mathf.PerlinNoise(t, semente + 10f) - 0.5f;
        float z = Mathf.PerlinNoise(t, semente + 20f) - 0.5f;
        transform.localPosition = posicaoInicial + new Vector3(x, 0f, z) * deslocamento * 2f;
    }
}
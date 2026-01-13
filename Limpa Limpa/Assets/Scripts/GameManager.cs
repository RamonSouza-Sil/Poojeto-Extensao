using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int _pontos;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AdicionarPontos(int valor)
    {
        _pontos += valor;
        Debug.Log("Pontos atuais: " + _pontos);
    }
}

using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int _pontos;

    public event Action<int> OnPontosAlterados;

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

        OnPontosAlterados?.Invoke(_pontos);
    }
}

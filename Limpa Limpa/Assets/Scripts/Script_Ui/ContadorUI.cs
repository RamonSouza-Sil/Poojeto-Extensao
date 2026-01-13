using TMPro;
using UnityEngine;

public class ContadorUI : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI _textoPontos;

    private void Start()
    {
        // Atualiza ao iniciar
        AtualizarTexto(GameManager.Instance._pontos);

        // Escuta mudanças
        GameManager.Instance.OnPontosAlterados += AtualizarTexto;
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnPontosAlterados -= AtualizarTexto;
    }

    void AtualizarTexto(int valor)
    {
        _textoPontos.text = $"Pontos: {valor}";
    }
}

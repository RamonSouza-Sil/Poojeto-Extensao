using UnityEngine;
using UnityEngine.InputSystem;

public class Coletaveis : MonoBehaviour
{
    [Header("Configuração do item")]
    public int _valorDoItem;

    public void Coletar()
    {
        GameManager.Instance.AdicionarPontos(_valorDoItem);
        Destroy(gameObject);
    }
}

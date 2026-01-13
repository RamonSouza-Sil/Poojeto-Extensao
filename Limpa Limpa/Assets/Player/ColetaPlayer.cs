using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColetaPlayer : MonoBehaviour
{
    private List<Coletaveis> coletaveisEmContato = new List<Coletaveis>();

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            ColetarTodos();
        }
    }

    void ColetarTodos()
    {
        foreach (var coletavel in coletaveisEmContato)
        {
            if (coletavel != null)
                coletavel.Coletar();
        }

        coletaveisEmContato.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coletaveis c = collision.GetComponent<Coletaveis>();
        if (c != null)
            coletaveisEmContato.Add(c);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Coletaveis c = collision.GetComponent<Coletaveis>();
        if (c != null)
            coletaveisEmContato.Remove(c);
    }
}


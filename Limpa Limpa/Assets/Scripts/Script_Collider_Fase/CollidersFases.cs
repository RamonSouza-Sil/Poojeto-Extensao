using UnityEngine;

public class CollidersFases : MonoBehaviour
{

    public GameObject colisorParade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            colisorParade.SetActive(false);
        }
    }
}

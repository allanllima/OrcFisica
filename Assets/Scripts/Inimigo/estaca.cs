using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estaca : MonoBehaviour
{
    public GameObject diretor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Orc"))
        {
            
            //destruir();
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}

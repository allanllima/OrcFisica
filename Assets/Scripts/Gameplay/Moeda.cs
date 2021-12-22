using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moeda : MonoBehaviour
{
    public GameObject pontuacao;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orc"))
        {
            pontuacao.GetComponent<Pontuacao>().pontuar();

            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orc"))
        {
            destruir();
        }

    }

    private void destruir()
    {
        Destroy(gameObject);
    }
}

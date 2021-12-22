using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuar : MonoBehaviour
{
    public GameObject inimigo;
    public GameObject pontuacao;
    //private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orc"))
        {
            pontuacao.GetComponent<Pontuacao>().pontuar();
            Destroy(inimigo);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

    }


}

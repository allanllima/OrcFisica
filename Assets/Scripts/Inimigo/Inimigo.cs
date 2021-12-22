using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 3;
    [SerializeField]
    private bool moveDireita = true;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDireita)
        {
            rb.transform.Translate(2 * Time.deltaTime * velocidade, 0, 0);            
        }
        else
        {
            rb.transform.Translate(-2 * Time.deltaTime * velocidade, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (moveDireita)
            {
                moveDireita = false;
                sprite.flipX = false;
            }
            else
            {
                moveDireita = true;
                sprite.flipX = true;
            }
    }
}

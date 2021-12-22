using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caixa : MonoBehaviour
{
  
    public bool moverCaixa = false;
    public GameObject cx;
    public Rigidbody2D rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb.bodyType = RigidbodyType2D.Static;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moverCaixa)
        {          
            //cx.transform.Translate(new Vector2(10 * Time.deltaTime, 0));
            rb.AddForce(new Vector2(10 * Time.deltaTime, 0), ForceMode2D.Force);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Orc")
        {
            print("Tocou na caixa");
            moverCaixa = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
           
            
        }
    }
}

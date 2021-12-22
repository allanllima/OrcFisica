using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class Jogador : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator playerAnimator;
    public Joystick joystick;
    public Diretor diretor;



    public bool morto = false;
    private bool isChao;
    private bool frente;
    private bool andar;
    private bool cliqueiNoBotao;

    public float forcaPulo;
    public float velocidade = 5.0f;
    public float alturaSalto;
    public AudioSource pulo;

    private Vector3 posicaoInicial;



    private void Awake()
    {
        this.posicaoInicial = this.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

    }



    private void Update()
    {
        pular();
        mover();

        playerAnimator.SetBool("pulo", isChao);
        playerAnimator.SetBool("andar", andar);
        playerAnimator.SetBool("die", morto);


    }
    private void FixedUpdate()
    {


    }

    public void pular()
    {
        if (isChao && cliqueiNoBotao)
        {
            rb.AddForce(new Vector2(alturaSalto - (alturaSalto / 1.5f), alturaSalto), ForceMode2D.Impulse);
            //rb.AddForce(new Vector2(0, forcaPulo*Time.deltaTime), ForceMode2D.Impulse);
            pulo.Play();

            playerAnimator.SetBool("pulo", true);

        }
        else
        {
            cliqueiNoBotao = false;
        }
    }

    public void BotaoPular(bool cliquei)
    {
        cliqueiNoBotao = true;
    }

    private void mover()
    {
        float moverHorizontal = Input.GetAxis("Horizontal") * velocidade;
        float moverJoystick = joystick.Horizontal * velocidade;

        rb.velocity = new Vector2(moverJoystick * velocidade + moverHorizontal * velocidade, rb.velocity.y);


        if ((moverJoystick < 0 && !frente) || (moverJoystick > 0 && frente)
            || (moverHorizontal < 0 && !frente) || (moverHorizontal > 0 && frente))
        {
            andar = true;
            flip();



        }
        if (moverJoystick == 0)
        {
            andar = false;
        }
    }

    private void flip()
    {
        frente = !frente;
        Vector3 virar = transform.localScale;
        virar.x *= -1;
        this.transform.localScale = virar;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            isChao = true;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("dano"))
        {
            this.morto = true;

            diretor.gameOver();


        }

        if (collision.gameObject.CompareTag("fim"))
        {
            diretor.painelFimDejogo.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            isChao = false;
            playerAnimator.SetBool("pulo", true);

        }

        



    }

    public void reiniciar()
    {
        this.transform.position = this.posicaoInicial;
        this.rb.simulated = true;
    }




    private void Destruir(GameObject obj)
    {
        Destroy(obj);
    }




}

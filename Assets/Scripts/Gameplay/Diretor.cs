using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Diretor : MonoBehaviour
{

    public GameObject painelGameOver;
    public GameObject painelFimDejogo;

    public Text pontosTexto;
    private AudioSource audiopontuação;
    private int energia;
    private Jogador orc;
    private Pontuacao pontuacao;





    void Awake()
    {
        this.audiopontuação = this.GetComponent<AudioSource>();
        this.orc = GameObject.FindObjectOfType<Jogador>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        //this.painelFimDejogo.SetActive(false);
        //this.painelGameOver.SetActive(false);
    }

    private void Update()
    {
        if (orc.morto)
        {
            gameOver();
        }
    }



    public void continuarJogo()
    {
        Time.timeScale = 1;
    }

    public void pausarJogo()
    {
        Time.timeScale = 0;
    }



    public void gameOver()
    {
        orc.morto = true;
        orc.rb.simulated = false;
        orc.velocidade = 0;
        
        
        painelGameOver.SetActive(true);      
    }

    //public void SalvarRecorde()
    //{
    //    int recordeAtual = PlayerPrefs.GetInt("recorde");
    //    if (this.pontos > recordeAtual)
    //    {
    //        PlayerPrefs.SetInt("recorde", this.pontos);
    //    }
    //}


    public void reiniciar()
    {        
        this.pontuacao.reiniciar();
        painelGameOver.SetActive(false);
        this.painelFimDejogo.SetActive(false);
        SceneManager.LoadScene("fase1");
    }

    public void fimJogo()
    {
        this.painelFimDejogo.SetActive(true);
    }
}

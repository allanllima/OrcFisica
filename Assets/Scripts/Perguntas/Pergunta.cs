using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pergunta : MonoBehaviour
{
    //painel pergunta

    public Diretor diretor;
    public GameObject obstaculo;
    public Pontuacao pontuacao;

    public GameObject painelPergunta;
    public Text questionTxt;    
    public Text questionOption1;
    public Text questionOption2;    
    public Toggle Topt1;
    public Toggle Topt2;
    public Button btnConfirmar;

    protected string pergunta;
    protected string opt1;
    protected string opt2;

    public void painel(string pergunta, string opt1, string opt2)
    {
        questionTxt.text = pergunta;
        questionOption1.text = opt1;
        questionOption2.text = opt2;
    }

    public void ocultarPainelPergunta()
    {


        diretor.continuarJogo();
        painelPergunta.SetActive(false);
    }

    public void exibirPainelPergunta()
    {
        painelPergunta.SetActive(true);

    }


}

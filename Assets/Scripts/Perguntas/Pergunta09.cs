using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pergunta09 : Pergunta
{

    public bool respostaCorreta()
    {
        if (Topt1.isOn == true) { return true; }
        if (Topt2.isOn == true) { return false; }
        return false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        pergunta = "Um corpo de 100kg sofre uma aceleração de 2m/s². Qual o valor da força resultante sobre corpo?";
        opt1 = "200N";
        opt2 = "50N";

        if (collision.gameObject.CompareTag("Orc"))
        {
            exibirPainelPergunta();
            painel(pergunta, opt1, opt2);
            diretor.pausarJogo();
            btnConfirmar.onClick.AddListener(delegate () { this.ButtonClicked(); });
        }
    }

    public void ButtonClicked()
    {
        if (this.respostaCorreta())
        {
            pontuacao.pontuarExtra();
            obstaculo.SetActive(true);
        }
        else
        {
            diretor.gameOver();
            diretor.pausarJogo();
        }

        ocultarPainelPergunta();
        Topt1.isOn = false;
        Topt2.isOn = false;
        Destroy(this.gameObject);
    }

}

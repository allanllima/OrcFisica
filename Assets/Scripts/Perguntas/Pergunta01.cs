using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pergunta01 : Pergunta
{

    //painel pergunta





    public bool respostaCorreta()
    {
        if (Topt1.isOn == true) { return true; }
        if (Topt2.isOn == true) { return false; }
        return false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        pergunta = "O que é inércia?";
        opt1 = "É a propriedade geral da matéria de permanecer em repouso ou MRU, quando sobre ela não " +
            "atuam forças ou a resultante é nula.";
        opt2 = "É a interação entre corpos que causa uma mudança na sua velocidade, de modo que " +
            "a força resultante seja nula.";

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

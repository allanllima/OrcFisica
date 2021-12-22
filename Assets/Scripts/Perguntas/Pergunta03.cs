using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pergunta03 : Pergunta
{

    //painel pergunta





    public bool respostaCorreta()
    {
        if (Topt1.isOn == true) { return false; }
        if (Topt2.isOn == true) { return true; }
        return false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        pergunta = "Quem puxa mais forte: A Lua, ao atrair a Terra, ou a Terra ao atrair a Lua?";
        opt1 = "A Terra, pois possui massa maior.";
        opt2 = "As duas exercem a mesma força, logo os dois \"puxões\" são iguais.";

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

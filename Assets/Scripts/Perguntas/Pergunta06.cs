using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pergunta06 : Pergunta
{

    public bool respostaCorreta()
    {
        if (Topt1.isOn == true) { return false; }
        if (Topt2.isOn == true) { return true; }
        return false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        pergunta = "Quando duas forças horizontais são exercidas sobre um objeto, uma de 600N para frente, e outra de " +
            "400N, para trás, o objeto acelera. Qual a força necessária para tornar nula a aceleração?  ";
        opt1 = "200N para frente.";
        opt2 = "200N para trás.";

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

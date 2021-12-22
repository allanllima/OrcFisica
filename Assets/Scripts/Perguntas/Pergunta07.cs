using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pergunta07 : Pergunta
{

    public bool respostaCorreta()
    {
        if (Topt1.isOn == true) { return false; }
        if (Topt2.isOn == true) { return true; }
        return false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        pergunta = "Sobre um objeto de 5kg é aplicada duas forças de 3N e 4N perpendiculares entre si. " +
            "Qual a aceleração sofrida pelo objeto?";
        opt1 = "2m/s².";
        opt2 = "1m/s²";

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

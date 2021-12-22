using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    public int pontos;    
    public Text txtPontos;

    private void Update()
    {
        txtPontos.text = pontos.ToString();
    }

    public void pontuar()
    {
        this.pontos++;
        this.txtPontos.text = this.pontos.ToString();
    }

    public void pontuarExtra()
    {
        this.pontos += 10;
    }


    public void perderPontos()
    {
        this.pontos--;
    }

    public void reiniciar()
    {
        this.pontos = 0;
        this.txtPontos.text = this.pontos.ToString();
    }
}

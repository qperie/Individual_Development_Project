using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceControleur : MonoBehaviour
{
    public Text scoreTxt;
    public Text vieTxt;
    public Text munitionTxt;
    
    void Start ()
    {
        this.scoreTxt.text = GameObject.Find("scoreTxt").GetComponent<Text>().text;
        this.vieTxt.text = GameObject.Find("vieTxt").GetComponent<Text>().text;
        this.munitionTxt.text = GameObject.Find("munitionTxt").GetComponent<Text>().text;
    }

    public void afficheScore(int score)
    {
        this.scoreTxt.text = "SCORE : " + score;
    }

    public void afficheVies(int vies)
    {
        this.vieTxt.text = "VIES : " + vies;
    }

    public void afficheMunitions(int munitions)
    {
        if (munitions == 100) // Si on est en modeBonus
        {
            this.munitionTxt.text = "MUNITIONS : MAX";
        }
        else
        {
            this.munitionTxt.text = "MUNITIONS : " + munitions;
        }
    }
}

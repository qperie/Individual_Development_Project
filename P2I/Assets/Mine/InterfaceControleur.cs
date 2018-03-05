using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceControleur : MonoBehaviour {

    public Text scoreTxt;
    public Text vieTxt;
    public Text munitionTxt;

    // Use this for initialization
    void Start ()
    {
        scoreTxt.text = GameObject.Find("scoreTxt").GetComponent<Text>().text;
        vieTxt.text = GameObject.Find("vieTxt").GetComponent<Text>().text;
        munitionTxt.text = GameObject.Find("munitionTxt").GetComponent<Text>().text;
    }

    public void afficheScore(int score)
    {
        scoreTxt.text = "Score : " + score;
    }

    public void afficheVies(int vies)
    {
        vieTxt.text = "Vies : " + vies;
    }
    public void afficheMunitions(int munitions)
    {
        munitionTxt.text = "Munitions : " + munitions;
    }
}

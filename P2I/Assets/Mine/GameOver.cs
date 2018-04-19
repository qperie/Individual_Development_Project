using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text scoreTxt;
    public Joueur monJoueur;

    void Start()
    {
        this.monJoueur = GameObject.Find("Joueur").GetComponent<Joueur>();
        monJoueur.vies = 10;
        this.scoreTxt = GameObject.Find("scoreTxt").GetComponent<Text>();
        this.scoreTxt.text = "" + monJoueur.score;
    }

    public void Rejouer()
    {
        Destroy(GameObject.Find("Joueur"));
        SceneManager.LoadScene("Jeu", LoadSceneMode.Single);
    }

    public void Menu()
    {
        Destroy(GameObject.Find("Joueur"));
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}

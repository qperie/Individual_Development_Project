using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour {

    public bool aPerdu = false;
    public int score = 0;
    public int vies = 10;
    public int munitions = 10;
    private InterfaceControleur monInterfaceControleur;

	// Use this for initialization
	void Start ()
    {
        monInterfaceControleur = GameObject.Find("Interface").GetComponent<InterfaceControleur>();
        monInterfaceControleur.afficheScore(score);
        monInterfaceControleur.afficheVies(vies);
        monInterfaceControleur.afficheMunitions(munitions);
    }

    public void MAJPoints(int points)
    {
        score = score + points;
        monInterfaceControleur.afficheScore(score);
    }

    public void MAJVies(int degats)
    {
        vies = vies - degats;
        if (vies <= 0)
        {
            vies = 0;
            this.aPerdu = true;
        }
        monInterfaceControleur.afficheVies(vies);
    }

    public void MAJMunitions(int unTir)
    {
        if (unTir == -10) // Rechargement de l'arme
        {
            munitions = 10;
        }
        else // Tir classique
        {
            munitions = munitions - unTir;
        }
        if (munitions <= 0)
        {
            munitions = 0;
            //on peut plus tirer
        }
        monInterfaceControleur.afficheMunitions(munitions);
    }


}

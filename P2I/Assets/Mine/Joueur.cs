using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Joueur : MonoBehaviour
{
    public bool aPerdu;
    public int score;
    public int vies;
    public int munitions;
    public bool modeBonus;
    public float tempsBonusRestant;
    public float tempsJeu;
    private InterfaceControleur monInterfaceControleur;
    public Sprite spriteViseurOn;
    public Sprite spriteViseurOff;
    
    void Start ()
    {
        this.monInterfaceControleur = GameObject.Find("Interface").GetComponent<InterfaceControleur>();
        this.monInterfaceControleur.afficheScore(this.score);
        this.monInterfaceControleur.afficheVies(this.vies);
        this.monInterfaceControleur.afficheMunitions(this.munitions);
        DontDestroyOnLoad(this.gameObject);
    }

    void Update ()
    {
        this.tempsJeu += Time.deltaTime;
        if (this.tempsBonusRestant != 0) // Chronométrage du Mode Bonus
        {
            this.tempsBonusRestant = this.tempsBonusRestant - Time.deltaTime;
        }
        if (this.tempsBonusRestant < 0) // Arret du Mode Bonus
        {
            this.modeBonus = false;
            this.tempsBonusRestant = 0;
        }
    }

    public void MAJPoints(int points)
    {
        if (this.modeBonus == true) // En Mode Bonus le score est doublé
        {
            this.score = this.score + 2 * points;
        }
        else
        {
            this.score = this.score + points;
        }
        this.monInterfaceControleur.afficheScore(this.score); // On affiche le nouveau score dans le jeu
    }

    public void MAJVies(int degats)
    {
        this.vies = this.vies - degats;
        if (this.vies <= 0) // Si le joueur n'a plus de vies, il a perdu
        {
            this.vies = 0;
            this.aPerdu = true;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        this.monInterfaceControleur.afficheVies(this.vies); // On affiche le nouveau nombre de vies dans le jeu
    }

    public void MAJMunitions(int unTir)
    {
        if (this.modeBonus == false) // Si on est en mode normal
        {
            if (unTir == 0) // Rechargement de l'arme et retour du desgin normal des viseurs
            {
                this.munitions = 10;
                GameObject.Find("viseurGauche").GetComponent<SpriteRenderer>().sprite = this.spriteViseurOn;
                GameObject.Find("viseurDroit").GetComponent<SpriteRenderer>().sprite = this.spriteViseurOn;
            }
            else // Tir classique
            {
                this.munitions = this.munitions - unTir;
            }
            if (this.munitions <= 0) // Si on n'a plus de munitions on affiche 0 et on change le design des viseurs
            {
                this.munitions = 0;
                GameObject.Find("viseurGauche").GetComponent<SpriteRenderer>().sprite = this.spriteViseurOff;
                GameObject.Find("viseurDroit").GetComponent<SpriteRenderer>().sprite = this.spriteViseurOff;
            }
            this.monInterfaceControleur.afficheMunitions(this.munitions); // On affiche le nouveau nombre de munitions dans le jeu
        }
        else // Si on est en Mode Bonus
        {
            this.monInterfaceControleur.afficheMunitions(100); // On affiche le nouveau nombre de munitions (100 est le code pour afficher XMAX)
            this.munitions = 10; // On maintient le nombre de munitions toujours à 10
        }
    }
}

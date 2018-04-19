using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirDroit : MonoBehaviour
{
    public Vector3 positions = new Vector3(2, -4, 0);
    private MoveViseur viseur;
    private TailleViseur tailleViseur;
    private Joueur monJoueur;
    private Rect touchZone;

    void Start()
    {
        this.viseur = GameObject.Find("viseurDroit").GetComponent<MoveViseur>();
        this.tailleViseur = GameObject.Find("viseurGauche").GetComponent<TailleViseur>();
        this.monJoueur = GameObject.Find("Joueur").GetComponent<Joueur>();
        this.touchZone = new Rect(Screen.width * 2 / 3, 0, Screen.width, Screen.height / 2);
    }
    
    void Update()
    {
        bool test = false;
        if (Input.GetKeyDown(KeyCode.RightArrow)) // Sur ordi
        {
            test = true;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // Sur mobile
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (touchZone.Contains(touchPosition))
            {
                test = true;
            }
        }

        if (test == true) // Si l'entrée est correcte pour recharger
        {
            if (this.monJoueur.munitions > 0)
            {
                GameObject ennemisPlusProche = this.viseur.ennemis[this.viseur.indice];
                float scaleViseur = this.tailleViseur.myScale;
                float coordX = ennemisPlusProche.transform.position.x;
                // On compare les coordonnées de la cible la plus proche du viseur avec celles du viseur
                if ((coordX < this.viseur.positions.x + 2*scaleViseur) && (coordX > this.viseur.positions.x - 2*scaleViseur))
                {
                    int points = 0;
                    // Si le tir était bon on calcule le nombre de points gagnés selon la cible
                    if (ennemisPlusProche.name == "pouleGauche(Clone)" || ennemisPlusProche.name == "pouleDroite(Clone)")
                    {
                        points = 10;
                    }
                    else if (ennemisPlusProche.name == "batGauche(Clone)" || ennemisPlusProche.name == "batDroite(Clone)")
                    {
                        int alea = new System.Random().Next(0, 10);
                        points = 100 + alea * 10;
                    }
                    else if (ennemisPlusProche.name == "coqGauche(Clone)" || ennemisPlusProche.name == "coqDroite(Clone)")
                    {
                        int alea = new System.Random().Next(0, 10);
                        points = 1000 + alea * 100;
                        this.monJoueur.modeBonus = true; // Le joueur passe en Mode Bonus
                        this.monJoueur.tempsBonusRestant = 10; // On intialise en temps de Mode Bonus
                    }
                    this.monJoueur.MAJPoints(points); // On met à jour le score
                    Destroy(ennemisPlusProche); // On détruit la cible atteinte
                }
                this.monJoueur.MAJMunitions(1); // On met à jour les munitions
            }
            else
            {
                // Bruit d'échec
            }
        }
    }
}

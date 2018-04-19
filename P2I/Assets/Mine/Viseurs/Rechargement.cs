using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rechargement : MonoBehaviour
{
    private Joueur monJoueur;
    private Rect touchZone1;
    private Rect touchZone2;
    
    void Start ()
    {
        this.monJoueur = GameObject.Find("Joueur").GetComponent<Joueur>();
        this.touchZone1 = new Rect(0, Screen.height / 2, Screen.width / 3, Screen.height);
        this.touchZone2 = new Rect(Screen.width * 2 / 3, Screen.height / 2, Screen.width, Screen.height);
    }
	
	void Update ()
    {
        bool test = false;
        if (Input.GetKeyDown(KeyCode.UpArrow)) // Sur ordi
        {
            test = true;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) // Sur mobile version slide
        {
            Vector2 ecartTouch = Input.GetTouch(0).deltaPosition; // Recupère l'écart entre la position avant et après
            if (ecartTouch.y > 0)
            {
                test = true;
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // Sur mobile version touch en haut
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (touchZone1.Contains(touchPosition) || touchZone2.Contains(touchPosition))
            {
                test = true;
            }
        }
        if (test == true) // Si l'entrée est correcte pour recharger
        {
            if (this.monJoueur.modeBonus == false) // Si on est en mode normal on recharge à 10 munitions
            {
                this.monJoueur.MAJMunitions(0); // 0 est le code pour dire de recharger
            }
            // Sinon on reste à la valeur XMAX, il n'y a pas de décompte de munition
        }
    }
}

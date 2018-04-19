using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyJoueur : MonoBehaviour
{
    // Permet de détruire les informations du joueur gardées pour afficher le score en finde partie
    // Sans ça en rejouant on aurait deux objets Joueur, ce qui créerrait des problèmes
    void DetruitJoueur ()
    {
		Destroy(GameObject.Find("Joueur"));
	}
}

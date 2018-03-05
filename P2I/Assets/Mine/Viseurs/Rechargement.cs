using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rechargement : MonoBehaviour {

    Joueur monJoueur;

    // Use this for initialization
    void Start ()
    {
        monJoueur = GameObject.Find("Joueur").GetComponent<Joueur>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Vous RECHARGEZ");
            monJoueur.MAJMunitions(-10);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailleViseur : MonoBehaviour {

    Transform myTransform;
    public float scaleMax = (float)0.45;
    public float scaleStep = (float)0.015;
    float myScale;
    int score;
    int vie;
    Joueur joueur;

    // Use this for initialization
    void Start ()
    {
        this.myTransform = GetComponent<Transform>();
        this.myScale = myTransform.localScale.x;
        this.joueur = GameObject.FindGameObjectWithTag("Joueur").GetComponent<Joueur>();
        this.score = this.joueur.score;
        this.vie = this.joueur.vies;
    }
	
	// Update is called once per frame
	void Update ()
    {
        int newVie = this.joueur.vies;
        if (newVie < this.vie) // Si le joueur perd une vie
        {
            this.myScale = (float)0.3;
            this.myTransform.gameObject.transform.localScale = new Vector3(this.myScale, this.myScale, 0);
            this.vie = newVie;
        }
        int newScore = this.joueur.score;
        if (newScore > this.score) // Si une cible a été détruite (le score a augmenté)
        {
            if (this.myTransform.localScale.x < this.scaleMax) // Si le viseur n'est pas encore à sa taille maximale
            {
                this.myScale = this.myScale + this.scaleStep;
                this.myTransform.gameObject.transform.localScale = new Vector3(this.myScale, this.myScale, 0);
            }
            this.score = newScore;
        }
	}
}

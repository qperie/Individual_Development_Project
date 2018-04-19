using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailleViseur : MonoBehaviour
{
    private Transform myTransform;
    public float scaleMax;
    public float scaleStep;
    public float myScale;
    private int vieLocal;
    private int scoreLocal;
    private Joueur monJoueur;
    
    void Start ()
    {
        this.myTransform = GetComponent<Transform>();
        this.myScale = myTransform.localScale.x;
        this.monJoueur = GameObject.Find("Joueur").GetComponent<Joueur>();
        this.vieLocal = this.monJoueur.vies;
        this.scoreLocal = this.monJoueur.score;
    }
	
	void Update ()
    {
		if (this.monJoueur.vies < this.vieLocal) // Si le nombre de vies a diminué par rapport à l'update précédent
        {
            this.myScale = (float)0.3; // Les viseurs reviennent à leur taille initiale
            this.myTransform.gameObject.transform.localScale = new Vector3(this.myScale, this.myScale, 0);
            this.vieLocal = this.monJoueur.vies; // On enregistre le nombre de vie lors de cette frame
        }
        if (this.monJoueur.score > this.scoreLocal && myTransform.localScale.x < scaleMax) // Si le score a augmenté par rapport à l'update précédent
        {
            this.myScale = this.myScale + this.scaleStep; // Les viseurs grossissent
            this.myTransform.gameObject.transform.localScale = new Vector3(this.myScale, this.myScale, 0);
            this.scoreLocal = this.monJoueur.score; // On enregistre le score lors de cette frame
        }
	}
}

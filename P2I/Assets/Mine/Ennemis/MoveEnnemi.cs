using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnnemi : MonoBehaviour
{
    public float speed; // Va dépendre du temps et/ou du score
    public int degats;
    private Transform myTransform;
    public Vector3 translationMin;
    public Vector3 translationMax; // abs(limiteEcranX - viseurDroit.position.x + 2) / limiteEcranY
    public int limiteEcranX;
    private Joueur monJoueur;
    
    void Start()
    {
        this.myTransform = GetComponent<Transform>();
        this.monJoueur = GameObject.Find("Joueur").GetComponent<Joueur>();
    }
    
    void Update()
    {
        calculVitesse();
        float aleaPente = UnityEngine.Random.Range(this.translationMax.x, this.translationMin.x); // Définit une trajectoire aléatoire dans un certain intervalle
        if (this.myTransform.tag == "EnnemiGauche") // Si ma cible vient de gauche
        {
            if (this.myTransform.name == "coqGauche(Clone)") // Si c'est un coq
            {
                float facteurSpeed = (float) new System.Random().NextDouble() + 1; // Il bougera entre 1x et 2x plus vite
                this.myTransform.Translate(new Vector3(aleaPente, 1, 0) * Time.deltaTime * this.speed * facteurSpeed);
            }
            else
            {
                this.myTransform.Translate(new Vector3(aleaPente, 1, 0) * Time.deltaTime * this.speed);
            }
            if (this.myTransform.position.x > this.limiteEcranX) // Si ma cible sort de l'écran on enlève ou non des vies ( de base c'est 1 vie)
            {
                if (this.myTransform.name == "batGauche(Clone)")
                {
                    this.degats = 3;
                }
                if (this.myTransform.name == "coqGauche(Clone)")
                {
                    this.degats = 0;
                }
                this.monJoueur.MAJVies(this.degats); // On met à jour le nombre de vies
                Destroy(this.gameObject); // On détruit l'objet puisqu'il ne sert plus à rien
            }
        }
        else // Si ma cible vient de droite
        {
            if (this.myTransform.name == "coqDroite(Clone)") // Si c'est un coq
            {
                float facteurSpeed = (float)new System.Random().NextDouble() + 1; // Il bougera entre 1x et 2x plus vite
                this.myTransform.Translate(new Vector3(-aleaPente, 1, 0) * Time.deltaTime * this.speed * facteurSpeed);
            }
            else
            {
                this.myTransform.Translate(new Vector3(-aleaPente, 1, 0) * Time.deltaTime * this.speed);
            }
            if (this.myTransform.position.x < -this.limiteEcranX) // Si ma cible sort de l'écran on enlève ou non des vies ( de base c'est 1 vie)
            {
                if (this.myTransform.name == "batDroite(Clone)")
                {
                    this.degats = 3;
                }
                if (this.myTransform.name == "coqDroite(Clone)")
                {
                    this.degats = 0;
                }
                this.monJoueur.MAJVies(this.degats); // On met à jour le nombre de vies
                Destroy(this.gameObject); // On détruit l'objet puisqu'il ne sert plus à rien
            }
        }
    }

    public void calculVitesse() // Calcule la vitesse à donner aux cibles selon le score atteint (fonctionnement par palier)
    {
        int score = monJoueur.score;
        if (score < 5000)
        {
            this.speed = 1;
        }
        else if (score < 10000)
        {
            this.speed = (float)1.3;
        }
        else if (score < 20000)
        {
            this.speed = (float)1.7;
        }
        else if (score < 30000)
        {
            this.speed = (float)2.2;
        }
        else if (score < 50000)
        {
            this.speed = (float)2.8;
        }
        else if (score < 70000)
        {
            this.speed = (float)3.5;
        }
        else
        {
            this.speed = 4;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveViseur : MonoBehaviour
{

    public float speed = 6f;
    public Vector3 positions;
    private Transform myTransform;
    //public Vector3 tailleViseur;
    private GameObject[] ennemisGauches;
    private GameObject[] ennemisDroits;
    public GameObject[] ennemis;
    public int indice;

    // Use this for initialization
    void Start()
    {
        this.myTransform = GetComponent<Transform>();
        this.positions = this.myTransform.position;
        //this.tailleViseur = this.myTransform.GetComponent<Collider>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        this.ennemisGauches = GameObject.FindGameObjectsWithTag("EnnemiGauche");
        this.ennemisDroits = GameObject.FindGameObjectsWithTag("EnnemiDroit");
        this.ennemis = new GameObject[ennemisDroits.Length + ennemisGauches.Length];
        int compteur = 0;
        for (int i = 0; i < this.ennemisGauches.Length; i++)
        {
            if (this.ennemisGauches[i].transform.position.x <= this.myTransform.position.x)
            {
                this.ennemis[compteur] = this.ennemisGauches[i];
                compteur++;
            }
        }
        int longeur = compteur;
        compteur = 0;
        for (int i = 0; i < ennemisDroits.Length; i++)
        {
            if (this.ennemisDroits[i].transform.position.x >= this.myTransform.position.x)
            {
                this.ennemis[longeur + compteur] = this.ennemisDroits[i];
                compteur++;
            }
        }
        if (this.ennemis.Length > 0 && this.ennemis[0] != null)
        {
            trouveEnnemiPlusProche(ennemis);
            this.positions.y = this.ennemis[this.indice].transform.position.y;
        }
        else
        {
            this.positions.y = -4;
        }
        this.myTransform.SetPositionAndRotation(this.positions, Quaternion.identity);
    }

    private void trouveEnnemiPlusProche(GameObject[] ennemis)
    {
        this.indice = 0;
        float distancei = 0;
        float distanceMin = 0;
        for (int i = 0; i < ennemis.Length; i++) // Pour chaque ennemi valide
        {
            if (ennemis[i] != null) // On vérifie que y'a bien encore un autre ennemi
            {
                if (i == 0) // Si c'est le premier on initialise distanceMin avec
                {
                    distancei = myTransform.position.x - ennemis[0].transform.position.x;
                    distanceMin = Mathf.Abs(distancei);
                }
                else // Sinon on calcule la distance et on compare avec la distanceMin existante
                {
                    distancei = myTransform.position.x - ennemis[i].transform.position.x; // distance = ecart entre position X (horizontale)
                    if (Mathf.Abs(distancei) < distanceMin)
                    {
                        distanceMin = distancei;
                        this.indice = i;
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoule : MonoBehaviour {

    public float speed = 6; // Va dépendre du temps et/ou du score
    public int degats = 1;
    Transform myTransform;
    public Vector3 translationMin = new Vector3(7, 1, 0);
    public Vector3 translationMax = new Vector3(12/10, 1, 0); // abs(limiteEcranX - viseurDroit.position.x + 2) / limiteEcranY
    public int limiteEcranX = 10;
    private Joueur monJoueur;

    // Use this for initialization
    void Start()
    {
        myTransform = GetComponent<Transform>();
        monJoueur = GameObject.Find("Joueur").GetComponent<Joueur>();
    }

    // Update is called once per frame
    void Update()
    {
        float aleaPente = UnityEngine.Random.Range(translationMax.x,translationMin.x);
        if (myTransform.tag == "EnnemiGauche")
        {
            myTransform.Translate(new Vector3(aleaPente, 1, 0) * Time.deltaTime * speed);
            if (myTransform.position.x > limiteEcranX)
            {
                monJoueur.MAJVies(degats);
                Destroy(this.gameObject);
            }
        }
        else
        {
            myTransform.Translate(new Vector3(-aleaPente, 1, 0) * Time.deltaTime * speed);
            if (myTransform.position.x < -limiteEcranX)
            {
                monJoueur.MAJVies(degats);
                Destroy(this.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveViseurDroit : MonoBehaviour
{

    public float speed = 6f;
    public Vector3 positions;
    Transform myTransform;

    // Use this for initialization
    void Start()
    {
        myTransform = GetComponent<Transform>();
        positions = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] ennemisGauches = GameObject.FindGameObjectsWithTag("EnnemiGauche");
        GameObject[] ennemisDroits = GameObject.FindGameObjectsWithTag("EnnemiDroit");
        GameObject[] ennemis = new GameObject[ennemisDroits.Length + ennemisGauches.Length];
        int compteur = 0;
        for (int i = 0; i < ennemisGauches.Length; i++)
        {
            if (ennemisGauches[i].transform.position.x <= myTransform.position.x)
            {
                ennemis[compteur] = ennemisGauches[i];
                compteur++;
            }
        }
        int longeur = compteur;
        compteur = 0;
        for (int i = 0; i < ennemisDroits.Length; i++)
        {
            if (ennemisDroits[i].transform.position.x >= myTransform.position.x)
            {
                ennemis[longeur + compteur] = ennemisDroits[i];
                compteur++;
            }
        }
        if (ennemis.Length > 0 && ennemis[0] != null)
        {
            int indice = trouveEnnemiPlusProche(ennemis);
            positions.y = ennemis[indice].transform.position.y;
        }
        else
        {
            positions.y = -4;
        }
        myTransform.SetPositionAndRotation(positions, Quaternion.identity);
    }

    int trouveEnnemiPlusProche(GameObject[] ennemis)
    {
        int indice = 0;
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
                        indice = i;
                    }
                }
            }
        }
        return (indice);
    }
}

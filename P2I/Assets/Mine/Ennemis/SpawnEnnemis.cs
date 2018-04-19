using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnnemis : MonoBehaviour
{
    public GameObject pouleGauchePrefab;
    public GameObject pouleDroitePrefab;
    public GameObject batGauchePrefab;
    public GameObject batDroitPrefab;
    public GameObject coqGauchePrefab;
    public GameObject coqDroitePrefab;
    public Vector3 definisseurDeSpawn;
    public float delaiSpawnEnnemi;
    public Joueur monJoueur;
    public bool aPerdu;
    
	void Start ()
    {
        this.monJoueur = GameObject.Find("Joueur").GetComponent<Joueur>();
        this.aPerdu = monJoueur.aPerdu;
        StartCoroutine(genereEnnemi());
	}

    // Génère un type d'ennemi aléatoirement selon des probabilités indiquées
    IEnumerator genereEnnemi()
    {
        System.Random rnd = new System.Random();
        GameObject myEnnemiPrefab = new GameObject();
        while (this.aPerdu == false)
        {
            double alea = rnd.NextDouble();
            float x = definisseurDeSpawn.x;
            if (alea > 0.65)
            {
                x = -definisseurDeSpawn.x;
                myEnnemiPrefab = pouleGauchePrefab;
            }
            else if (alea > 0.30)
            {
                myEnnemiPrefab = pouleDroitePrefab;
            }
            else if (alea > 0.17)
            {
                x = -definisseurDeSpawn.x;
                myEnnemiPrefab = batGauchePrefab;
            }
            else if (alea > 0.04)
            {
                myEnnemiPrefab = batDroitPrefab;
            }
            else if (alea > 0.02)
            {
                x = -definisseurDeSpawn.x;
                myEnnemiPrefab = coqGauchePrefab;
            }
            else
            {
                myEnnemiPrefab = coqDroitePrefab;
            }
            Vector3 spawn = new Vector3(x, UnityEngine.Random.Range(-definisseurDeSpawn.y, 0), 0); // Position d'apparition de l'ennemi choisi
            Instantiate(myEnnemiPrefab, spawn, Quaternion.identity); // Création de l'ennemi à la position prévue
            yield return (new WaitForSeconds(delaiSpawnEnnemi)); // Attente avant de continuer et générer un nouvel ennemi
            this.aPerdu = monJoueur.aPerdu; // Mise a jour du statut du joueur, pour savoir si oui ou non il a perdu
        }
    }
}

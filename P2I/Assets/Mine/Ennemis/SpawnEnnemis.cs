using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnnemis : MonoBehaviour {

    public GameObject pouleGauchePrefab;
    public GameObject pouleDroitPrefab;
    public Vector3 definisseurDeSpawn;
    public float delaiSpawnEnnemi;
    public Joueur monJoueur;
    public bool aPerdu;

	// Use this for initialization
	void Start ()
    {
        this.monJoueur = GameObject.Find("Joueur").GetComponent<Joueur>();
        this.aPerdu = monJoueur.aPerdu;
        StartCoroutine(genereEnnemi());
	}

    IEnumerator genereEnnemi()
    {
        System.Random rnd = new System.Random();
        GameObject myEnnemiPrefab = new GameObject();
        while (this.aPerdu == false)
        {
            int alea = rnd.Next(0, 2);
            float x = definisseurDeSpawn.x;
            if (alea == 0)
            {
                x = -definisseurDeSpawn.x;
                myEnnemiPrefab = pouleGauchePrefab;
            }
            else
            {
                myEnnemiPrefab = pouleDroitPrefab;
            }
            Vector3 spawn = new Vector3(x, UnityEngine.Random.Range(-definisseurDeSpawn.y, 0), 0);
            Instantiate(myEnnemiPrefab, spawn, Quaternion.identity);
            yield return (new WaitForSeconds(delaiSpawnEnnemi));
            this.aPerdu = monJoueur.aPerdu;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

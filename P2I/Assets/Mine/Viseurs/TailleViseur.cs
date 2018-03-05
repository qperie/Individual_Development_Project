using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailleViseur : MonoBehaviour {

    Transform myTransform;
    public float scaleMax = (float)3;
    public float scaleStep = (float)0.5;
    float myScale;
    // Transform joueur;

    // Use this for initialization
    void Start ()
    {
        myTransform = GetComponent<Transform>();
        myScale = myTransform.localScale.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (true) // true -> (joueur.vie < joueur.vie.framed'avant)
        {
            myScale = (float)0.2;
            myTransform.gameObject.transform.localScale = new Vector3(myScale, myScale, 0);
        }
        if (true && myTransform.localScale.x < scaleMax) // true -> cibleDetruite = scoreAugmente
        {
            myScale = myScale + scaleStep;
            myTransform.gameObject.transform.localScale = new Vector3(myScale, myScale, 0);
        }
	}
}

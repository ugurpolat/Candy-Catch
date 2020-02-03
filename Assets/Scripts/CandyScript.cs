using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //increment Score
            GameManager.instance.IncrementScore();
            Destroy(gameObject);

        }
        else if (col.gameObject.tag == "Baundary")
        {
            //Decrease Lives
            GameManager.instance.DecreaseLife();
            Destroy(gameObject);
        }

    }



}

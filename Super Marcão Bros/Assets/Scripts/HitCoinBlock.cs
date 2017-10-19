using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCoinBlock : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Marcão")
        {
            Debug.Log("block");
        }
    }
}

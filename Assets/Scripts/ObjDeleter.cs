using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDeleter : MonoBehaviour {

    public Transform player;
    public Spawner spawner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(transform.position.y > player.position.y)
        {
            spawner.ObjReturn(this.gameObject);
        }
	}
}

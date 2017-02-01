using UnityEngine;
using System.Collections;

public class CubeDeleter : MonoBehaviour {

	public Spawner sp;

	public enum SpawnType{
		cube,ring
	}


	public SpawnType type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.transform.tag == "cube" || col.transform.tag == "powerup"){
			//Debug.Log(col.transform.name);
			sp.ObjReturn(col.gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.transform.tag == type.ToString()){
			Debug.Log(col.transform.name);
			sp.ObjReturn(col.gameObject);
		}
	}
}

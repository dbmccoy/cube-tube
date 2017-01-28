using UnityEngine;
using System.Collections;

public class HomingCube : MonoBehaviour {

	public Transform Target;
	public float speed;
	Spawner sp;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		Target = GameObject.Find("Player").transform;
		sp = GameObject.Find("HomingCubeSpawner").GetComponent<Spawner>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.MoveTowards(transform.position,Target.position,Time.deltaTime * speed);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "cube"){
			sp.ObjReturn(this.gameObject);
		}
	}
}

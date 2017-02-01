using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public bool homing;
	Rigidbody rb;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
	}

	public void Attack(Transform target, float amt){
		Vector3 direction = Random.insideUnitSphere;
		rb.AddRelativeForce(direction.normalized * amt, ForceMode.Force);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}
    
}

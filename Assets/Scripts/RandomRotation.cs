using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

	public float targetR;
	public float rotationDir;

	// Use this for initialization
	void Start () {
		rotationDir = Random.Range(-1,2);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,rotationDir,0));
	}
}

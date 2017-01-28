using UnityEngine;
using System.Collections;

public class LockPosToObj : MonoBehaviour {

	public GameObject ObjToTrack;
	Vector3 offset;
	Vector3 startPos;

	public bool _x;
	public bool _y;
	public bool _z;

	private float xx;
	private float yy;
	private float zz;

	// Use this for initialization
	void Start () {
		offset = ObjToTrack.transform.position - transform.position;
		startPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(transform.position.x,ObjToTrack.transform.position.y + startPos.y,
										 transform.position.z);
	}
}

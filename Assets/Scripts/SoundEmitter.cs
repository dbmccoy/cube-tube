using UnityEngine;
using System.Collections;

public class SoundEmitter : MonoBehaviour {

	public AudioSource _as;

	// Use this for initialization
	void Start () {
		_as.pitch = 1 - 1/(transform.localScale.x *3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedMultiplier : MonoBehaviour {

	public Text counter;
	public float multiplier;
	private float _distance;
	private Vector3 _pos;
	private PlayerMove pm;

	// Use this for initialization
	void Start () {
		pm = GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		_pos = new Vector3(transform.position.x,0,transform.position.z);
		multiplier = Vector3.Distance(_pos,Vector3.zero);
		multiplier = Utils.round(1.5f - multiplier/10,2);
		//pm.multiplier = multiplier;
		counter.text = ("x"+multiplier);
	}
}

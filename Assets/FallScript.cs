using UnityEngine;
using System.Collections;

public class FallScript : MonoBehaviour {

	Rigidbody rb;
	public float fallSpeed;
    public float damper;
    public bool constantSpeed;
    private float _timer;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
        _fallSpeed = 10;
        _timer = 0;
	}
    private float _fallSpeed;
	// Update is called once per frame
	void FixedUpdate () {
        //_fallSpeed = Mathf.Lerp(fallSpeed, 70, Time.deltaTime);
        _timer = _timer + Time.deltaTime;
        
        rb.MovePosition(transform.position + new Vector3(0, -fallSpeed, 0) * Time.deltaTime);

        if (!constantSpeed) {
            
        }



    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spedometer : MonoBehaviour {

    Text speed;
	public string preText;

	// Use this for initialization
	void Start () {
        speed = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateSpeed(float f) {
        f = Utils.round(f, 1);
		speed.text = (preText+f.ToString());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public AudioSource sourceA;
    public AudioSource sourceB;
    GameObject[] bgObject;
    

    // Use this for initialization
    void Start()
    {
        bgObject = GameObject.FindGameObjectsWithTag("background");
        if (bgObject.Length == 1)
        {
            vol_b = 1;
            vol_a = 0;
            sourceB.volume = 1;
            sourceA.volume = 0;
        }
        else
        {
            for (int i = 1; i < bgObject.Length; i++)
            {
                Destroy(bgObject[i]);
            }
        }
    }

    public void Restart()
    {
        step = 4;
        vol_b = 1;
        vol_a = 0;
    }

    public void Begin()
    {
        step = 1;
        vol_a = 1;
        vol_b = 0;
    }
    // Update is called once per frame

    int vol_a;
    int vol_b;
    float step;
    void Update () {
        sourceA.volume = Mathf.Lerp(sourceA.volume, vol_a, Time.deltaTime*step);
        sourceB.volume = Mathf.Lerp(sourceB.volume, vol_b, Time.deltaTime*step);
    }
}

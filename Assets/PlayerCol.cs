using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCol : MonoBehaviour {

    public PlayerMove player;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "cube")
        {
            //PlayerPrefs.SetFloat("highscore",speed);
            player.Restart();
        }
    }
}

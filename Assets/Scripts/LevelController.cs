using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

	public int level;
	public Spawner spwnr;
	public Material mat;

	private PlayerMove plyr;
	private float initSpeed;

	private Color[] colors;
	private Color currentColor;
	private Color targetColor;

	float[] levels;

    // Use this for initialization
    void Awake(){
        QualitySettings.vSyncCount = 0;  // VSync must be disabled or disable in quality manually 
        Application.targetFrameRate = 60;
    }

	void Start () {
		levels = new float[]{20,40,60,80,100,120,140,160,180,200};
		level = 0;
		plyr = GetComponent<PlayerMove>();
		initSpeed = plyr.speed;
		colors = new Color[]{Color.cyan,Color.blue, Color.magenta, Color.red, new Color32(30, 144, 255, 255), Color.green,  new Color32(255, 140, 0,255) };
		currentColor = Color.cyan;
		targetColor = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {
		if(plyr.timer >= levels[level]){
			initSpeed = plyr.speed;
			NextLevel();
		}

		mat.color = Color.Lerp(mat.color, targetColor, Time.deltaTime);
	
	}

	void NextLevel() {
		level++;
		spwnr.density = spwnr.density +.1f;
		spwnr.cubeEnergy = spwnr.cubeEnergy + 100f;
		currentColor = mat.color;
		int index = Random.Range(0,colors.Length);
		targetColor = colors[level];
	}
}

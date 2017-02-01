using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

	public bool invulnerable;
	public float speed;
	public float timer;
    public float fallSpeed;
	public float aclAmt;
	public float incrementalAclInc;
	public float aclIncTimer;
	public GameObject cam;
    public Spedometer spd;
	public float stepSpeed;
	float h;
	float v;
	public float moveSpeed;
	Rigidbody rb;
	float step;
	//make this global
	bool running;
	public Text splash;
	public Text highscore;
	public GameObject cubeHolder;
	public Spawner ringSpawner;
	public Spawner cubeSpawner;
    CharacterController cc;
	float hoff;
	float voff;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll();
		step = Time.deltaTime;
		rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
		highscore.text = PlayerPrefs.GetFloat("highscore").ToString();
		h = 0; v = 0;
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			hoff = Input.acceleration.y;
			voff = Input.acceleration.z;
		}
	}

	void Begin(){
		running = true;
		GameObject.Find("CubeSpawner").GetComponent<Spawner>().Begin();
        GameObject.FindGameObjectWithTag("background").GetComponent<DontDestroy>().Begin();

		splash.enabled = false;
		StartCoroutine(Timer(aclIncTimer));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!running){
			if(Input.anyKeyDown || Input.touchCount > 0){
				Begin();
			}
            cc.Move(new Vector3(h * moveSpeed, -fallSpeed, v * moveSpeed) * Time.deltaTime * stepSpeed);

            return;
		}

		timer = timer + Time.deltaTime;
		//timer = Utils.round(timer,1);

		//platform specific input

		if(Application.platform == RuntimePlatform.IPhonePlayer){
			h = Input.acceleration.y - hoff;
			v = Input.acceleration.z - voff;
		}
		else{
			h = Input.GetAxis("Horizontal");
			v = Input.GetAxis("Vertical");
		}

		float _aclAmt = aclAmt;

		//do moving

        cc.Move(rb.velocity + new Vector3(h*moveSpeed,-fallSpeed,v*moveSpeed)*Time.deltaTime*stepSpeed);

		//rb.MovePosition(transform.position + new Vector3(h * moveSpeed,-fallSpeed,v * moveSpeed)
		//									*Time.deltaTime*stepSpeed);

		cam.transform.rotation = Quaternion.Euler(90+(6*-v*.5f),0,6*-h);
		rb.AddForce(new Vector3(0, -1f, 0) * Time.deltaTime * _aclAmt, ForceMode.Acceleration);

        //speed update
        //fallSpeed = fallSpeed + .1f * Time.deltaTime;
		speed = Utils.round((rb.velocity.y * -1)+fallSpeed,1);
		spd.UpdateSpeed(timer);
		if(timer > PlayerPrefs.GetFloat("highscore")){
			highscore.text = timer.ToString();
			PlayerPrefs.SetFloat("highscore",timer);
		}
		else{
			highscore.text = PlayerPrefs.GetFloat("highscore").ToString();
		}

		DistanceCheck();

	}

	void DistanceCheck(){
		if(Vector2.Distance(new Vector2(transform.position.x,transform.position.z),new Vector2(0,0))
			> 5f){
			Restart();
		}
	}

	IEnumerator Timer(float f){
		yield return new WaitForSeconds(f);
		IncreaseAcl(incrementalAclInc);
		StartCoroutine(Timer(aclIncTimer));
	}

	public void IncreaseAcl(float amt){
		aclAmt += amt;
	}

	void OnCollisionEnter(Collision other){
        if (other.transform.tag == "cube" && !invulnerable){
            //PlayerPrefs.SetFloat("highscore",speed);
            Restart();
        }
	}

	void OnTriggerEnter(Collider other){
		if(other.transform.tag == "ring"){
			Debug.Log("ring");
			ringSpawner.ObjReturn(other.gameObject);
		}
		if(other.transform.tag == "powerup"){
			cubeSpawner.ObjReturn(other.gameObject);
			Debug.Log("powerup");
			speed = speed -5f;
		}
	}
		

	public void Restart(){
        if (!invulnerable)
        {
            GameObject.FindGameObjectWithTag("background").GetComponent<DontDestroy>().Restart();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }




}

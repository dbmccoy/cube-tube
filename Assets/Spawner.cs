using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject objToSpawn;
    public float frequency;
    public float radius;
    public float density;
	public int poolAmt;

	public int poolAmt_Current;

    float _nextTimer;
    int _quantity;

	public bool multiple;
	public bool scatter;
	public bool running;
	public bool spawnToAxis;
	public bool spawnAtAngle;

	public float scaleMax;
	private float _aclAdd;
	public Transform axis;
	public GameObject cubeHolder;
	Transform pool;

	// Use this for initialization
	List<GameObject> PoolObjs;

	void Start () {
        _nextTimer = 0;
        _quantity = RollDensity(density);
        Spawn(_quantity);
		PoolObjs = new List<GameObject>();
		pool = GameObject.Find("pool").transform;
		GeneratePool(poolAmt);
	}

	void GeneratePool(int amt){
		for (int i = 0; i < amt; i++) {
			GameObject obj = Instantiate(objToSpawn,Vector3.zero,Quaternion.identity) as GameObject;
			PoolObjs.Add(obj);
			obj.transform.parent = pool;
		}
	}

	public void ObjReturn(GameObject obj){
		obj.SetActive(false);
		PoolObjs.Add(obj);
	}

    IEnumerator Timer(float f) {
        yield return new WaitForSeconds(f);
		if(multiple){
			Spawn(RollDensity(density));
		}
		else{
			Spawn(1);
		}
    }

	public void Begin(){
		running = true;
		StartCoroutine(NewAxis());
		Spawn(_quantity);
	}

    void Spawn(int n, float angle = 0, float _x = 0, float _y = 0, float _z = 0) {
		if(!running){
			return;
		}
        Vector3 v = new Vector3(_x, _y, _z);
        for (int i = 0; i < n; i++) {
			if(scatter){
				v = Random.insideUnitSphere * radius;
			}

			GameObject obj = PoolObjs[0];
			PoolObjs.Remove(PoolObjs[0]);
			obj.transform.position = transform.position + v;
			obj.transform.rotation = Quaternion.Euler(0,angle,0);
			obj.SetActive(true);
            Vector3 r = Random.insideUnitSphere * radius;
			if(obj.GetComponent<Rigidbody>()){
				obj.GetComponent<Rigidbody>().AddTorque(r);    
			}
			if(spawnAtAngle){
				obj.transform.rotation = Quaternion.Euler(0,Random.Range(-180,180),0);
			}
			obj.transform.localScale = new Vector3(1,1,1) * Random.Range(1f,scaleMax);
			if(spawnToAxis){
				obj.transform.parent = axis;
			}
        }
        _nextTimer = Random.Range(0, 1) * (frequency);
		StartCoroutine(Timer(frequency));
    }

    int RollDensity(float n) {
        int d = Mathf.RoundToInt(n * Random.Range(1, 10));
        return d;
    }

	IEnumerator NewAxis(){
		GameObject holder = Instantiate(cubeHolder,Vector3.zero,Quaternion.identity) as GameObject;
		axis = holder.transform;
		yield return new WaitForSeconds(Random.Range(5f,10f));
		StartCoroutine(NewAxis());
	}
	
	// Update is called once per frame
	void Update () {
		poolAmt_Current = PoolObjs.Count;
	}
}

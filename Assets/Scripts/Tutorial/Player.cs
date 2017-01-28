﻿using UnityEngine;

public class Player : MonoBehaviour {

	public PipeSystem pipeSystem;

	public float velocity;
	private Transform world;
	private Rigidbody rb;
	public Pipe currentPipe;

	private float distanceTraveled;
	private float deltaToRotation;
	private float systemRotation;
	private float worldRotation;

	private void Start () {
		rb = GetComponent<Rigidbody>();

		world = pipeSystem.transform.parent;
		currentPipe = pipeSystem.SetupFirstPipe();
		SetupCurrentPipe();
		deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.CurveRadius);
	}

	private void Update () {
		float delta = velocity * Time.deltaTime;
		distanceTraveled += delta;
		systemRotation += delta * deltaToRotation;

		if (systemRotation >= currentPipe.CurveAngle) {
			Debug.Log("turn");
			delta = (systemRotation - currentPipe.CurveAngle) / deltaToRotation;
			currentPipe = pipeSystem.SetupNextPipe();
			SetupCurrentPipe();
			//deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.CurveRadius);
			systemRotation = delta * deltaToRotation;
		}

		pipeSystem.transform.localRotation =
			Quaternion.Euler(0f, 0f, systemRotation);

		//////

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		rb.MovePosition(transform.position + new Vector3(0,v ,-h)
			*Time.deltaTime*5);
	}

	private void SetupCurrentPipe () {
		deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.CurveRadius);
		worldRotation += currentPipe.RelativeRotation;
		if (worldRotation < 0f) {
			worldRotation += 360f;
		}
		else if (worldRotation >= 360f) {
			worldRotation -= 360f;
		}
		world.localRotation = Quaternion.Euler(worldRotation, 0f, 0f);
	}

}
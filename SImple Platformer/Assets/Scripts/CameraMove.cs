using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Camera myCamera;
	public float cameraSpeed = .0001f;
	private float x;
	Vector3 cameraVector;
	// Use this for initialization
	void Start () {
		myCamera = GetComponent<Camera> ();
		cameraVector = myCamera.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		cameraVector.x += cameraSpeed;
		myCamera.transform.position = cameraVector;
	}
}

using UnityEngine;
using System.Collections;

public class CameraCollison : MonoBehaviour {

	public Camera myCamera; 
	public GameObject player;
	// Use this for initialization
	void Start () {
		myCamera.GetComponent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
		var dist = (transform.position - myCamera.transform.position).z;
		var leftBorder = myCamera.ViewportToWorldPoint(new Vector3(0,0,dist));
		var rightBorder = myCamera.ViewportToWorldPoint(new Vector3(1,0,dist));
		if (transform.position.x < leftBorder.x)
			player.transform.position = new Vector3 (leftBorder.x +.5f, player.transform.position.y, player.transform.position.z);
		if (transform.position.x > rightBorder.x)
			player.transform.position = new Vector3 (rightBorder.x -.5f, player.transform.position.y, player.transform.position.z);
		}
	}


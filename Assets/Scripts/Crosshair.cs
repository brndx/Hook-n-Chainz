using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    private Camera mainCamera;
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	void Update () {
        transform.position = new Vector3(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, -15f, mainCamera.ScreenToWorldPoint(Input.mousePosition).z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour {

    [SerializeField] private float startRot = 0;
    float timer = 0f;
    public int mod = 0;
    [SerializeField] public bool beingOpened = false;
    //Increasing the rotation on the Z axis makes the door move anticlockwise
    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
        startRot = this.transform.eulerAngles.z;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void rotateClockwiseMethod()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 rot = new Vector3(0, 0, 0);
            float z = this.transform.eulerAngles.z;
            rot.z = z -= mod;
            this.transform.eulerAngles = rot;
            timer = 0f;
        }
    }
    public void rotateAntiClockwiseMethod()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 rot = new Vector3(0, 0, 0);
            float z = this.transform.eulerAngles.z;
            rot.z = z += mod;
            this.transform.eulerAngles = rot;
            timer = 0f;
        }
    }
}

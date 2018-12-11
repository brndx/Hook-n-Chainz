using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour {

    [SerializeField] private float startRot = 0.0f;
    [SerializeField] private float timer = 0.0f;
    public int mod = 0;
    [SerializeField] public bool beingOpened = false;
    //Increasing the rotation on the y axis makes the door move anticlockwise
    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
        startRot = this.transform.eulerAngles.y;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void rotateClockwiseMethod()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 rot = new Vector3(90, 0, 0);
            float y = this.transform.eulerAngles.y;
            rot.y = y += mod;
            this.transform.eulerAngles = rot;
            timer = 0.0f;
        }
    }
    public void rotateAntiClockwiseMethod()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 rot = new Vector3(90, 0, 0);
            float y = this.transform.eulerAngles.y;
            rot.y = y -= mod;
            this.transform.eulerAngles = rot;
            timer = 0.0f;
        }
    }
}

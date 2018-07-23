// Copyright © 2018 Brandon Gallo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public GameObject Camera;
    public float horizontalSpeed = 3.0f;
    public float verticalSpeed = 3.0f;
    static float interpolatorTime = 0.0f;
    public float CameraMoveSpeed = 0.1f;
    void Start()
    {

    }
    void Update()
    {
        Movement();
        UpdateCamera();
    }
    void UpdateCamera()
    {
        Camera.transform.position = new Vector3(Mathf.Lerp(Camera.transform.position.x, transform.position.x, interpolatorTime), Mathf.Lerp(Camera.transform.position.y, transform.position.y, interpolatorTime), Camera.transform.position.z);
    }
    void Movement()
    {
        var x = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        var y = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
        if (x != 0 || y != 0)
            interpolatorTime += CameraMoveSpeed * Time.deltaTime;
        else
            interpolatorTime = 0.0f;

        transform.Translate(x, y, 0);
    }
}

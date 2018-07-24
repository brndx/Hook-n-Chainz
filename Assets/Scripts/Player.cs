// Copyright © 2018 Brandon Gallo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject crosshair;
    [SerializeField]
    private float turnSpeed = 10.0f;
    [SerializeField]
    private Camera mainCamera;
    static float interpolatorTime = 0.0f;
    [SerializeField]
    private float horizontalSpeed = 0.1f;
    [SerializeField]
    private float verticalSpeed = 0.1f;
    [SerializeField]
    private float CameraMoveSpeed = 0.1f;
    void Update()
    {
        Point();
        Crosshair();

    }
    void FixedUpdate()
    {
        Movement();
        UpdateCamera();
    }
    void UpdateCamera()
    {
        mainCamera.transform.position = new Vector3(Mathf.Lerp(mainCamera.transform.position.x, transform.position.x, interpolatorTime), Mathf.Lerp(mainCamera.transform.position.y, transform.position.y, interpolatorTime), mainCamera.transform.position.z);
    }
    void Movement()
    {
        var x = Input.GetAxisRaw("Horizontal") * horizontalSpeed * Time.deltaTime;
        var y = Input.GetAxisRaw("Vertical") * verticalSpeed * Time.deltaTime;
        if (x != 0 || y != 0)
            interpolatorTime += CameraMoveSpeed * Time.deltaTime;
        else
            interpolatorTime = 0.0f;
        // Translate player in global space coordinates
        transform.Translate(x, y, 0, Space.World);
    }
    void Point()
    {
        Vector2 direction = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // Calculate angle between two vectors
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // Interpolate player rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }
    void Crosshair()
    {
            crosshair.transform.position = new Vector3(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, mainCamera.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }
}




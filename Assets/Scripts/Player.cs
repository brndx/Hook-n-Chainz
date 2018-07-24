// Copyright © 2018 Brandon Gallo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public float crosshairScale = 1;
    [SerializeField]
    private float turnSpeed = 10.0f;
    public Camera mainCamera;
    static float interpolatorTime = 0.0f;
    [SerializeField]
    private float horizontalSpeed = 0.1f;
    [SerializeField]
    private float verticalSpeed = 0.1f;
    [SerializeField]
    private float CameraMoveSpeed = 0.1f;
    void Start()
    {

    }
    void Update()
    {
        LookTowardsMouse1();
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

        transform.Translate(x, y, 0);
    }
    //Makes the player face towards the current position of the mouse.
    void LookTowardsMouse1()
    {
        Vector2 direction = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        //transform.rotation = rotation;
        //Include this into the function too, please: Debug.DrawLine(ray.origin, lookTarget, Color.red); - Delete This Line When Done. 
  

        //"Old Code" to be deleted or used if you want.
        /* RaycastHit hit;
          Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out hit))
         {
             Vector2 lookTarget = hit.point;
             Debug.DrawLine(ray.origin, lookTarget, Color.red);
         }
         // rotate towards target
          var lookDelta = (hit.point - transform.position);
          var targetRot = Quaternion.LookRotation(lookDelta);
          var rotSpeed = turnSpeed * Time.deltaTime;
          transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed);
          */
    }
    void Crosshair()
    {
        //if not paused
        if (Time.timeScale != 0)
        {
            if (crosshairTexture != null)
                GUI.DrawTexture(new Rect((Screen.width - crosshairTexture.width * crosshairScale) / 2, (Screen.height - crosshairTexture.height * crosshairScale) / 2, crosshairTexture.width * crosshairScale, crosshairTexture.height * crosshairScale), crosshairTexture);
            else
                Debug.Log("No crosshair texture set in the Inspector");
        }
    }
}




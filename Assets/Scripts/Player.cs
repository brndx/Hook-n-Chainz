using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
  

    [SerializeField] GameObject crosshair;

    //Camera Variables
    [SerializeField] private float turnSpeed = 10.0f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float cameraSpeed = 4.0f;
    [SerializeField] private float rotOffset = 90.0f;
    [SerializeField] private float cameraHeight = -15.0f;

    //Player Moovement Speed
    [SerializeField] private float horizontalSpeed = 0.1f;
    [SerializeField] private float verticalSpeed = 0.1f;
    [SerializeField] private float speedMultiplier;

    //Animation
    [SerializeField] private Animator animator;

 void Start()
    {

    }
    void Update()
    {
       
        Point();
        Run(); 

    }
    void FixedUpdate()
    {
        Movement();
    }
    private void LateUpdate()
    {
        UpdateCamera();
    }
    void UpdateCamera()
    {
        mainCamera.transform.position = new Vector3(Mathf.Lerp(mainCamera.transform.position.x, transform.position.x, cameraSpeed * Time.deltaTime), mainCamera.transform.position.y, Mathf.Lerp(mainCamera.transform.position.z, transform.position.z, cameraSpeed * Time.deltaTime));
    }
    void Movement()
    {

        //Sprinting with LeftShift
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            var x = Input.GetAxisRaw("Horizontal") * horizontalSpeed * speedMultiplier * Time.deltaTime;
            var z = Input.GetAxisRaw("Vertical") * verticalSpeed * speedMultiplier * Time.deltaTime;
            // Translate player in global space coordinates
            transform.Translate(x, 0, z, Space.World);
            animator.SetFloat("Speed", 1);
        }

        else
        {
            var x = Input.GetAxisRaw("Horizontal") * horizontalSpeed * Time.deltaTime;
            var z = Input.GetAxisRaw("Vertical") * verticalSpeed * Time.deltaTime;
            // Translate player in global space coordinates
            transform.Translate(x, 0, z, Space.World);
            animator.SetFloat("Speed", 0);
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                animator.SetFloat("Speed", 1);
            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }
    }
 
    void Point()
    {
        Vector3 lookPos = new Vector3(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, cameraHeight, mainCamera.ScreenToWorldPoint(Input.mousePosition).z);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.z, lookPos.x) * Mathf.Rad2Deg - rotOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Euler(90.0f, transform.rotation.y, Mathf.LerpAngle(transform.rotation.z, angle, turnSpeed * Time.deltaTime));
    }

    void Run()
    {
        //TODO
    }
}




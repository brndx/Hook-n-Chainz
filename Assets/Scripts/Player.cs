using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
  
    //Camera Variables
    [SerializeField] private float turnSpeed = 10.0f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float cameraSpeed = 4.0f;
    [SerializeField] private int rotOffset = 90;
   
    //Player Moovement Speed
    [SerializeField] private float horizontalSpeed = 0.1f;
    [SerializeField] private float verticalSpeed = 0.1f;
    [SerializeField] private float speedMultiplier;
 void Start()
    {

    }
    void Update()
    {
       
        Point();
        

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
        mainCamera.transform.position = new Vector3(Mathf.Lerp(mainCamera.transform.position.x, transform.position.x, cameraSpeed * Time.deltaTime), Mathf.Lerp(mainCamera.transform.position.y, transform.position.y, cameraSpeed * Time.deltaTime), mainCamera.transform.position.z);
    }
    void Movement()
    {
        //Sprinting with LeftShift
        if (Input.GetKey(KeyCode.LeftShift)) {
            var x = Input.GetAxisRaw("Horizontal") * horizontalSpeed * speedMultiplier * Time.deltaTime;
            var y = Input.GetAxisRaw("Vertical") * verticalSpeed * speedMultiplier * Time.deltaTime;
        // Translate player in global space coordinates
        transform.Translate(x, y, 0, Space.World);
        }
        else {
            var x = Input.GetAxisRaw("Horizontal") * horizontalSpeed * Time.deltaTime;
            var y = Input.GetAxisRaw("Vertical") * verticalSpeed * Time.deltaTime;
            // Translate player in global space coordinates
            transform.Translate(x, y, 0, Space.World);
        }
    }

    void Point()
    {
        Vector2 direction = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // Calculate angle between two vectors
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - rotOffset;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // Interpolate player rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }
}




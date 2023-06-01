using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera _cam;
    private CharacterController _controller;
    private float _camRotation = 0f;
    private Vector3 _velocity;
    private bool _isGrounded;

    [Header("Player Movement")]
    public float lookSensitivity = 50f;
    public float moveSpeed = 3f;
    public float gravity;

    [Header("Ground Checking")]
    public float groundDistance = 0.09f; 
    public Transform groundCheck; 
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _cam = GetComponentInChildren<Camera>();

        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }

    private void GetInputs(){
        //################################################## Camera Movement ########################################################
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(Vector3.up * lookSensitivity * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(-Vector3.up * lookSensitivity * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.UpArrow)){
            _camRotation -= lookSensitivity * Time.deltaTime;
            _camRotation = Mathf.Clamp(_camRotation, -90f, 90f);
            _cam.transform.localRotation = Quaternion.Euler(_camRotation, 0f, 0f);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            _camRotation += lookSensitivity * Time.deltaTime;
            _camRotation = Mathf.Clamp(_camRotation, -90f, 90f);
            _cam.transform.localRotation = Quaternion.Euler(_camRotation, 0f, 0f);
        }

        //################################################## Player Movement ########################################################
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(_isGrounded && _velocity.y < 0){
            _velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * moveSpeed * Time.deltaTime);

        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}

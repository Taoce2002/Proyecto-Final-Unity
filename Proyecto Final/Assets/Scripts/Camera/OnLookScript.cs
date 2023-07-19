using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnLookScript : MonoBehaviour
{

    private float mouseSense = 150f;
    public Transform playerBody;
    private float xRotation = 0;
    private float ejeInvertido= -1;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSense * Time.deltaTime;
        xRotation +=mouseY*ejeInvertido;

        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        playerBody.Rotate(Vector3.up*mouseX);


    }

    
}

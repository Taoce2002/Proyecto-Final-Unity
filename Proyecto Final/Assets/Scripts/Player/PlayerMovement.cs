using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController  characterController;
    private Vector2 mDirection;
    private float speed = 10f;
    private float gravity = -9.81f;
    
    private Vector3 velocity;

    public PhotonView pv;

    private float jumpHeight = 3f;

    public Transform groundCheck;
    private float groundRadius = 0.5f;
    public LayerMask groundMask;
    private bool isGround;

    // Update is called once per frame
    void Update()
    {
        if(pv.IsMine){
            isGround = Physics.CheckSphere(groundCheck.position, groundRadius,groundMask);
            if(isGround && velocity.y<0){
                //gravedad
                velocity.y =-2f;
            }
            if(Input.GetKeyDown(KeyCode.Space) && isGround){
                //salto
                velocity.y = Mathf.Sqrt(jumpHeight*-2*gravity);
            }

        }
    }

    void Start(){
        pv = GetComponent<PhotonView>();
    }

    private void OnMove(InputValue value)
    {
        //movimiento
        if(pv.IsMine){
        mDirection = value.Get<Vector2>();
        }
    }

    private void FixedUpdate()
    {
        if(pv.IsMine){
            velocity.y +=gravity*Time.deltaTime;
            characterController.Move(velocity*Time.deltaTime);

            Vector3 moveCharacter = transform.right * mDirection.x + transform.forward * mDirection.y;
            characterController.Move(moveCharacter*speed*Time.deltaTime);

            
        }
    }


}

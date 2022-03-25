using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;

    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Image[] HP;
    public int h;
 
    
    Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Start() {
        h = 3;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);



        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool hasHorizontalInput = !Mathf.Approximately(x, 0f);
        bool hasVerticalInput = !Mathf.Approximately(z, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;


        
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    public void damageHealth(){
        h -= 1;
        HP[h].enabled.Equals(false);
    }


}

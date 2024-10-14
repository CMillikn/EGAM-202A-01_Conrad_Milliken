using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playCont;

    public float speed = 10f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    void Update()
    {
        if ((Physics.Raycast(groundCheck.position, Vector3.down, out RaycastHit hit, groundDistance)) && hit.transform.tag == "Ground")
        {
            isGrounded = true;
        }

        if(!isGrounded  && velocity.y < 0)
        {
            velocity.y = -5f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 globalForward = Vector3.Cross(transform.right, Vector3.up); 

        
        Vector3 move = transform.right * x + globalForward * z;
        move.y = 0;

        playCont.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded )
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        playCont.Move(velocity * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<GoalTag>() != null)
        {
            SceneManager.LoadScene(1);
        }
        if (collider.gameObject.GetComponent<KillTag>() != null)
        {
            SceneManager.LoadScene(2);
        }
    }
}
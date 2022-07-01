using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed = 5f;

    public float jump = 10f;
    bool canJump;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        canJump = true;
    }

    void FixedUpdate()
    {

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rigidbody.MovePosition(transform.position + input * Time.deltaTime * speed);

        if(Input.GetKeyUp(KeyCode.Space) && canJump)
        {
            Debug.Log("cant jump");
            canJump = false;
            Vector3 jumpPos = new Vector3(0, jump, 0);
            rigidbody.AddForce(jumpPos);
        }
    }

    void OnCollisionEnter()
    {
        Debug.Log("canjump");
        canJump = true;
    }
}

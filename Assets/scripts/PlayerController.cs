using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody rigidbody;

    Material material;

    public float speed = 5f;
    public float jump = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 1.5f;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        material = GetComponent<Renderer>().material;
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            rigidbody.velocity = Vector3.up * jump;
        }

        #region falling
        if (rigidbody.velocity.y < 0) {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rigidbody.velocity.y > 0 && !Input.GetButton("Jump")) {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        #endregion
    }

    private void FixedUpdate() {

        if (Input.GetButton("Horizontal")) {
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            rigidbody.MovePosition(transform.position + input * Time.deltaTime * speed);
        }
    }

}

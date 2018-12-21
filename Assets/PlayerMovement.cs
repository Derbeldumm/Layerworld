using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float runSpeed = 40f;
    float horizontal                ;
    bool jump;
    public CharacterController2D controller;
	
	// Update is called once per frame
	void Update () {
        horizontal = Input.GetAxis("Horizontal") * runSpeed;
        jump = Input.GetButton("Jump");
	}

    void FixedUpdate()
    {
        controller.Move(horizontal * Time.fixedDeltaTime, false, jump);
    }
}

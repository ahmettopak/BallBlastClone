using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    Camera cam;
    Rigidbody2D rb;

    [SerializeField] HingeJoint2D[] wheels;
    JointMotor2D motor;

    [SerializeField] float CannonSpeed;
    bool isMoving=false;
    Vector2 pos;
    float screenBounds;
    Vector3 oldPos;
    Vector3 movement;
    float speed;
    void Start()
    {
        cam = Camera.main;

		rb = GetComponent<Rigidbody2D> ();
		pos = rb.position;

		motor = wheels [0].motor;

		screenBounds = Game.Instance.screenWidth - 0.56f;
        oldPos=transform.position;
    }


    void Update()
    {
        isMoving=Input.GetMouseButton(0);
        if(isMoving)
        {
            pos.x=cam.ScreenToWorldPoint(Input.mousePosition).x;
        }

       
    }
    void FixedUpdate()
    {
       //Move the cannon
		if (isMoving) {
			rb.MovePosition (Vector2.Lerp (rb.position, pos, CannonSpeed * Time.fixedDeltaTime));
		} else {
			rb.velocity = Vector2.zero;
		}

		//Rotate wheels
		
        movement =transform.position - oldPos;
        speed = Vector3.Distance (oldPos, transform.position)*100; 
		if (isMoving) {
        
            if(movement.x > 0) {
                motor.motorSpeed = speed*150f;
            } else if(movement.x < 0) {
                motor.motorSpeed = -speed*150f;
            }
			
			MotorActivate (true);
		} else {
			motor.motorSpeed = 0f;
			MotorActivate (false);
		}

        oldPos = transform.position;
    }

    void MotorActivate(bool isActive)
    {
        wheels[0].useMotor=isActive;
        wheels[1].useMotor=isActive;

        wheels[0].motor=motor;
        wheels[1].motor=motor;
    }
}

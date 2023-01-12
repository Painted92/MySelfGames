using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class RunController : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] FixedJoystick joystick;
    [Header("Speed element")]
    [SerializeField] private float movespeed;


    private void FixedUpdate()
    {
        MovesPlayer();
    }
    private void MovesPlayer()
    {
        rigidbody.velocity = new Vector3(joystick.Horizontal * movespeed, rigidbody.velocity.y, joystick.Vertical * movespeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
         transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   [SerializeField] public WheelCollider[] wheel = new WheelCollider[4];
    [SerializeField] public int torque= 100;
    [SerializeField] public float StearingSpeed = 4;
    [SerializeField] // Start is called before the first frame update
    void Start()
    {
       Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate() 
    {
        if (Input.GetKey(KeyCode.W))
        {
            
            for (int i = 0; i < wheel.Length; i++)
            {
                wheel[i].motorTorque = torque;
            }
            
        }
        if (Input.GetAxis("Horizontal") != 0) 
        {
            for (int i = 0; i < wheel.Length - 2; i++) 
            {
                wheel[i].steerAngle = Input.GetAxis("Horizontal")*StearingSpeed;
            };
        }
    }
}

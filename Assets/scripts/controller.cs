using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] public WheelCollider[] wheel = new WheelCollider[4];
    [SerializeField] Transform frontrightransform;
    [SerializeField] Transform frontleftransform;
    [SerializeField] Transform backrightransform;
    [SerializeField] Transform backleftransform;
    [SerializeField] private float acceleration = 600;
    [SerializeField] private float breakingforce = 300;
    [SerializeField] private float maxTurnAngle = 15;
    [SerializeField] private float currentAcceleration = 0;
    [SerializeField] private float currentBreakForce =0;
    [SerializeField] private float currentTurnAngle =0;
    void Start()
    {
    
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        { 
            currentAcceleration = acceleration * Input.GetAxis("Vertical") * Time.deltaTime;
            acceleration += 60;
        }
        if (Input.GetKey(KeyCode.Space)) 
        {
            currentBreakForce = breakingforce;
            
        }
        else
        {
             breakingforce = 0;
        }
        for (int i = 0; i < 2; i++)
        {
            wheel[i].motorTorque = currentAcceleration;
            Debug.Log("speed " + wheel[i].motorTorque);
        }
        for (int i = 0; i < 2; i++) 
        {
            wheel[i].brakeTorque = currentBreakForce;
        }
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        for (int i = 0; i < 2; i++) 
        {
            wheel[i].steerAngle = currentTurnAngle;
        }
        Updatewheel(wheel[0], frontrightransform);
        Updatewheel(wheel[1], frontleftransform);
        Updatewheel(wheel[2], backrightransform);
        Updatewheel(wheel[3], backleftransform);

    }   
    public void Updatewheel(WheelCollider wheelCollider,Transform transform) 
    {//getting wheel collider state
        Vector3 position; 
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        //set wheel transform state
        transform.position = position;
        transform.rotation = rotation;
    }
}

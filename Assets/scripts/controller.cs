using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] public WheelCollider[] wheel = new WheelCollider[4];//sets up class for the wheel collider
    [SerializeField] Transform frontrightransform;//sets up this class
    [SerializeField] Transform frontleftransform;//sets up this class
    [SerializeField] Transform backrightransform;//sets up this class
    [SerializeField] Transform backleftransform;//sets up this class
    [SerializeField] private float acceleration
    {
        get;
        set;
    }//sets acceleration
    [SerializeField] private float breakingforce = 300;//sets breaking force
    [SerializeField] private float maxTurnAngle = 15;//sets the turn angle
    [SerializeField] private float currentAcceleration = 0;//sets the current acceleration
    [SerializeField] private float currentBreakForce = 0;//sets the current break force
    [SerializeField] private float currentTurnAngle = 0;// sets the current turn angle
    void Start()
    {
        acceleration = 66000;
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)//reading input data from controller
        {
            currentAcceleration = acceleration * Input.GetAxis("Vertical") * Time.deltaTime;//keeps acceleration addition at a framerate cap
            if (acceleration >= 66000) //if acceleration is higher than 600,
            {
                acceleration = 66000;//keep it at 600
            }
            else { acceleration += 100; }// other wise speed up at 60 units per frame/second
        }
        if (Input.GetKey(KeyCode.Space)) // if player hits space
        {
            currentBreakForce = breakingforce;//break force

        }
        else
        {
            breakingforce = 0;// otherwise dont break
        }
        for (int i = 0; i < 2; i++)//for loop
        {
            wheel[i].motorTorque = currentAcceleration;//not sure
            Debug.Log("speed " + wheel[i].motorTorque);//not sure
        }
        for (int i = 0; i < 2; i++) //for loop
        {
            wheel[i].brakeTorque = currentBreakForce;//not sure
        }
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");//not sure
        for (int i = 0; i < 2; i++) //for loop 
        {
            wheel[i].steerAngle = currentTurnAngle;// for loop
        }
        Updatewheel(wheel[0], frontrightransform); //update wheel
        Updatewheel(wheel[1], frontleftransform);//same thing
        Updatewheel(wheel[2], backrightransform);//same thing
        Updatewheel(wheel[3], backleftransform);//same thing

    }
    public void Updatewheel(WheelCollider wheelCollider, Transform transform)
    {//getting wheel collider state
        Vector3 position; //to rotate in a certain position
        Quaternion rotation;//used to rotate an object around one spot i think
        wheelCollider.GetWorldPose(out position, out rotation);//??
        //set wheel transform state
        transform.position = position;//transform where the wheel is?  
        transform.rotation = rotation;//rotate wheel?
    }
    public float getAcceleration()
    {
        return wheel[0].motorTorque ;
 
    }
    public float grabAccel() => acceleration;
    }

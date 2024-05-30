using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class controller : MonoBehaviour
{
    [SerializeField] private Quaternion ogrotate;
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
        ogrotate = transform.rotation;
        acceleration = 66000;
    }
    //if the cars current rotation is < -10 AND we click a key on our keyboard we want to 
    //• Reset the cars current rotation to be equal to our ogrotate variable.
    //if you need to grab the current rotation use transform.rotate
    //bonus hint, you only need to check the z value of the cars current rotation so you want to compare if it's z value is < -10
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
    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (transform.rotation.z <= -10 || transform.rotation.z >= 10)//if z axis of rotation is less than -10 and f key is pressed,
            {
                transform.eulerAngles = new Vector3(0,0,0);//current rotation = 0(origanl/starting rotation)
            }
        }
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


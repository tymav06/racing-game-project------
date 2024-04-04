using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lapmanager1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("crossed it!");
        if (other.tag == "Player") 
        {
            Debug.Log("crossed it!"); 
        }
    }
}

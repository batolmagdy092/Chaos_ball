using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityScript : MonoBehaviour
{
    [SerializeField] private float startSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(startSpeed, 0, startSpeed); //move on x and z direction
    }

    // Update is called once per frame
     void Update()
    {
        
    }
}
 
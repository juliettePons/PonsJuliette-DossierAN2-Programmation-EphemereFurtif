using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsUPDOWN : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float speed;
    void Start()
    {


    }
    void Update()
    {
        if (Input.GetKey("space"))
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
            
        }
    }
   
}

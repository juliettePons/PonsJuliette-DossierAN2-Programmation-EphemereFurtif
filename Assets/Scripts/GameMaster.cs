using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Fondation;
    
    float x;
    float y;
    float z;
    Vector3 pos;
   

    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate() {
     
         
        x = UnityEngine.Random.Range(-10, 10);
        y = 1;
        z = UnityEngine.Random.Range(-10, 10);
        pos = new Vector3(x, y, z);
        
        

        if (Input.GetKey("space")&& GameObject.FindGameObjectsWithTag("Metal").Length <= 3)
        {
            Instantiate(Fondation, pos, Quaternion.identity, this.gameObject.transform.parent);
           
        }

        //if (children.Length >= 3)
       // {
                //Destroy(transform.GetChild(1).gameObject);
            //}
            
                        }

    }




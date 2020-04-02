using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class InstatiateCube : MonoBehaviour
{
    
    public GameObject[] pieces;
    private GameObject Bismuth;
    private Vector3 Magnetpoint;
    void Start()
    {
        Bismuth = Instantiate(pieces[UnityEngine.Random.Range(0, 3)], this.transform.position, Quaternion.Euler(0, 0,0));
    }

    
    void Update()
    {

        

          if (Input.GetKey("space"))
            {
               GameObject magnet = Bismuth.transform.GetChild(UnityEngine.Random.Range(1,2)).gameObject;
               Vector3 Magnetpoint = magnet.transform.position;
                Spawn();

        }
    }

    void Spawn()
    {
        /* int spawnPointX = Random.Range(-30, 30);
         int spawnPointY = Random.Range(-20 , 20);
         Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, 0);
         */
        
        Bismuth = Instantiate(pieces[UnityEngine.Random.Range(0, 3)], Magnetpoint, Quaternion.Euler(0, 0, 90));

        
    }
}



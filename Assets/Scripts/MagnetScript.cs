using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    public GameObject[] pieces;
    private GameObject Bismuth;
    public float[] rotationValues;
    public bool donotdestroy;

    bool destroyThis;

    // Start is called before the first frame update
    void Start()
    {
        destroyThis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
           
            Spawn();

        }

        if (destroyThis == true && donotdestroy == false)
        {
            Destroy(this.gameObject);
        }
    }

    void Spawn()
    {
        /* int spawnPointX = Random.Range(-30, 30);
         int spawnPointY = Random.Range(-20 , 20);
         Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, 0);
         */

        Bismuth = Instantiate(pieces[UnityEngine.Random.Range(0, 3)], this.transform.position, Quaternion.Euler(90, 90, rotationValues[Random.Range(0,rotationValues.Length)]));

        destroyThis = true;


    }
}

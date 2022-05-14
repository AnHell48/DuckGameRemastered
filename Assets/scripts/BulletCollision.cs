using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    GameObject invisibleWall;

    // Start is called before the first frame update
    void Start()
    {
        invisibleWall = GameObject.Find("InvisibleWall");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Delete bullet if it go behind the wall
        if(transform.position.z > invisibleWall.transform.position.z)
        {
            //Debug.Log("deletion point reached ...");
            DeleteBullet();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        string quack = col.gameObject.name;
        //Debug.Log("REEEEEE");

        //if the bullet hit a duck then play the sound effect
        if (quack.Contains("duck"))
        {
            //play sound
            col.gameObject.GetComponent<AudioSource>().Play();
        }
        DeleteBullet();
    }

    private void DeleteBullet()
    {
        Destroy(gameObject);
    }
}



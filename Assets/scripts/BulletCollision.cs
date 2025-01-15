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
            Debug.Log("bullet have been DELETED");
            DeleteBullet();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("onColl "+ collision.gameObject.name);

        if(collision.gameObject.name.Contains("duck"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.SetActive(false);
            DeleteBullet();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        string quack = col.gameObject.name;
        Debug.Log("onTrigger");

        //if the bullet hit a duck then play the sound effect
        if (quack.Contains("duck"))
        {
            //play sound
            col.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("quakyty quack MF >:C");
        }
        DeleteBullet();
    }

    private void DeleteBullet()
    {
        Destroy(gameObject);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    float gunRotSpeed, gunBounds;
    List<GameObject> gunList;
    public GameObject bulletSpawner;
    Transform bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        gunList = new List<GameObject>();
        bulletSpawnPoint = GameObject.Find("bulletSpawnPoint").transform;
        gunRotSpeed = 0.2f;
        gunBounds = 0.18f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController();
        Debug.Log("spawnPoint: "+bulletSpawnPoint.position);
        Debug.Log("gun: "+transform.localPosition);
    }

    private void PlayerController()
    {

        if (Input.GetKey(KeyCode.D) && transform.rotation.y <= gunBounds)
        {
            transform.Rotate(new Vector3(0, gunRotSpeed, 0));
        }

        if (Input.GetKey(KeyCode.A) && transform.rotation.y >= -gunBounds)
        {
            transform.Rotate(new Vector3(0, -gunRotSpeed, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet();
            print("pew pew");
        }
    }

    private void SpawnBullet()
    {
        //GameObject bullet = new GameObject();
        GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject)), bulletSpawnPoint.position, this.transform.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 50f);
       // bullet.transform.position = bulletSpawnPoint.position;

    }
    
}

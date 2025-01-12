using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuackManager : MonoBehaviour
{
    [SerializeField] int objectsInRing;
    List<GameObject> objectsInRingList = new List<GameObject>();
    #region Ring
    float ringRadius = 0.08f, deltaringRotation = 0.0f;
    Vector3 ringCenter;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.position = GetComponentInParent<Transform>().position;
        //gameObject.transform.localPosition = Vector3.zero;
        ringCenter = transform.localPosition;
        LoadDucks();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(new Vector3(0, 10f * Time.deltaTime,0)) ;
        RotateRing();
    }

    private void LoadDucks()
    {
        for (int i = 0; i < objectsInRing; i++)
        {
            float newPosX = ringCenter.x + (float)(ringRadius * Mathf.Cos((float)i * ((Mathf.PI *2) / objectsInRing)));
            float newPosZ = ringCenter.z + (float)(ringRadius * Mathf.Sin((float)i * ((Mathf.PI *2) / objectsInRing)));

            GameObject d;

            /*TODO 
             * add a random to select between the different types of ducks
             */
            d = Instantiate(Resources.Load("nduck", typeof(GameObject)), new Vector3(newPosX, ringCenter.y, newPosZ), Quaternion.identity) as GameObject;
            d.transform.parent = transform;
            // (-1.0f * (float) q * (MathHelper.TwoPi / (float)elements_in_ring)) + MathHelper.PiOver2;
            d.transform.Rotate(new Vector3((-1.0f * (float)i *((Mathf.PI * 2) / (float)objectsInRing)) + Mathf.PI / 2, 0, 0));
            objectsInRingList.Add(d);
        }
    }

    private void RotateRing()
    {
        deltaringRotation += 0.002f;

        for (int i = 0; i < objectsInRing; i++)
        {
            float newPosX = ringCenter.x + (float)(ringRadius * Mathf.Cos((float)i * ((Mathf.PI * 2) / objectsInRing) + deltaringRotation));
            float newPosZ = ringCenter.z + (float)(ringRadius * Mathf.Sin((float)i * ((Mathf.PI * 2) / objectsInRing) + deltaringRotation));

            objectsInRingList.ElementAt(i).transform.position = new Vector3(newPosX, ringCenter.y, newPosZ);
           // objectsInRingList.ElementAt(i).transform.Rotate(new Vector3(0,(-1.0f * (float)i *((Mathf.PI * 2) / (float)objectsInRing)) + Mathf.PI / 2, 0));
            
        } 
    }
}

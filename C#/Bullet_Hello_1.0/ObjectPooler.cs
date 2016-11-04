using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {


    public GameObject pooled_object;
    public int pooled_amount;

    public List<GameObject> pooled_objects;
    
	// Use this for initialization
	void Start () {

        pooled_objects = new List<GameObject>();

        for (int i = 0; i < pooled_amount; i++)
        {
            GameObject temp_obj = (GameObject)Instantiate(pooled_object);
            temp_obj.SetActive(false);
            pooled_objects.Add(temp_obj);
            
        }
	}
	
	public GameObject getPooledObject()
    {
        for(int i = 0; i < pooled_objects.Count; i++)
        {
            if(!pooled_objects[i].activeInHierarchy)
            {
                return pooled_objects[i];
            }
        }

        GameObject temp_obj = (GameObject)Instantiate(pooled_object);
        temp_obj.SetActive(false);
        pooled_objects.Add(temp_obj);
        return temp_obj;

    }
}

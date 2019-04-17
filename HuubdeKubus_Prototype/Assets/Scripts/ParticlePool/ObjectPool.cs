using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
}

public class ObjectPool : MonoBehaviour {

    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;

    // Use this for initialization
    void Awake () {
        SharedInstance = this;
	}

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++){
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    //Gets an object from the pool
    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    //Call this to place particle systems from the pool 
    /*public IEnumerator PlaceParticles(string tag, Vector3 pos, float time)
    {
        GameObject particles = GetPooledObject(tag);

        if (particles != null)
        {
            particles.transform.position = pos;
            particles.transform.rotation = this.transform.rotation;
            particles.SetActive(true);
            particles.GetComponent<ParticleSystem>().Play();
        }

        yield return new WaitForSeconds(time);

        //particles.GetComponent<ParticleSystem>().Clear();
        particles.SetActive(false);
    }*/

    //NOT WORKING ATM
    /*public ParticleSystem GetParticleSystem()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i].GetComponent<ParticleSystem>();
            }
        }
        return null;
    }*/
}

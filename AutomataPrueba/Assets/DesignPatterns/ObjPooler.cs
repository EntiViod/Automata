using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPooledObject
{

    void OnObjectSpawn();
    void OnObjectSpawn(Vector3 direccion);


}
public class ObjPooler : MonoBehaviour
{


    [System.Serializable]

    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public Transform InstanceAccumulator;

    #region Singleton
    public static ObjPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    private GameObject objectToSpawn;

    void Start()
    {

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                obj.transform.SetParent(InstanceAccumulator);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    internal void SpawnFromPool(object objTag, Vector3 position, Quaternion identity)
    {
        throw new NotImplementedException();
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;

    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Vector3 direccion)
    {

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObject != null)
        {
            if (direccion != null)
                pooledObject.OnObjectSpawn(direccion);
            else
                pooledObject.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;

    }

    public void destroyAll()
    {
        foreach (Transform child in InstanceAccumulator.transform)
        {

            child.gameObject.SetActive(false);
        }
    }
}
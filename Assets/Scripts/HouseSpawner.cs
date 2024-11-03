using System;
using System.Security.Cryptography;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    private float R = 0;
    private float X = 0;
    private float Y = 32;
    private GameObject House;
    private float time = 0.0f;
    public float interpolationPeriod = 10f;
    [SerializeField] private int houseIndex;

    public GameObject[] houses;

    public void SpawnHouse()
    {
        X = UnityEngine.Random.Range(-25f, 25f);
        Y = UnityEngine.Random.Range(-30f, 30f);
        R = UnityEngine.Random.Range(0, 360f);
        houseIndex = UnityEngine.Random.Range(0, houses.Length - 1);
        Debug.Log(R.ToString());
        House = Instantiate(houses[houseIndex], new Vector3(X, 4.6f, Y), new Quaternion(0, R, 0, 0));
        //House.transform.position = new Vector3(House.transform.position.x,32)

    }
    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;

            SpawnHouse();
        }
    }
    
}


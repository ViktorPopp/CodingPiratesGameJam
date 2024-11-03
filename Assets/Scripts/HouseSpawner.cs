using System;
using System.Security.Cryptography;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    private float R = 0;
    private float X = 0;
    private float Y = 0;
    [SerializeField] private int houseIndex;

    public GameObject[] houses;

    public void SpawnHouse()
    {
        X = UnityEngine.Random.Range(-10f, 10f);
        Y = UnityEngine.Random.Range(-10f, 10f);
        R = UnityEngine.Random.Range(0, 360f);
        houseIndex = UnityEngine.Random.Range(0, houses.Length - 1);
        Debug.Log(R.ToString());
        Instantiate(houses[houseIndex], new Vector3(X, 0.6f, Y), new Quaternion(0, R, 0, 0));
    }
}

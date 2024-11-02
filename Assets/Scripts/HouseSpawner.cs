using System;
using System.Security.Cryptography;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    private static float X = 0;
    private static float Y = 0;
    public GameObject[] houses;
    private System.Random rng = new System.Random();

    public void SpawnHouse()
    {
        Debug.Log("Instantiate House!");
        X = UnityEngine.Random.Range(-10f, 10f);
        Y = UnityEngine.Random.Range(-10f, 10f);
        Instantiate(houses[rng.Next(0, houses.Length - 1)], new Vector3(X, 0.6f, Y), new Quaternion(0,0,0,0));
    }
}

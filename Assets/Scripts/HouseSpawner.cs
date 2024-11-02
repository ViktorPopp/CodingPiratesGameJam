using System;
using System.Security.Cryptography;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    static public GameObject[] houses;
    [SerializeField] static private System.Random rng = new System.Random();

    public static void SpawnHouse()
    {
        Debug.Log("Instantiate House!");
        Instantiate(houses[rng.Next(0, houses.Length - 1)], new Vector3(), Quaternion.identity);
    }
}

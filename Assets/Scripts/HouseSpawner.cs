using System;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
public class HouseSpawner : MonoBehaviour
{
    public TMP_Text text;
    
    private float R = 0;
    private float X = 0;
    private float Y = 32;
    private float bb = 2;
    static public int connHouses;
    private GameObject House;
    //static public GameObject[] houseIdents = { };
    static public List<GameObject> houseIdents = new List<GameObject>();
    private float time = 0.0f;
    public float interpolationPeriod = 10f;
    [SerializeField] private int houseIndex;
    public GameObject[] houses;

    void Start()
    {
        SpawnHouse();
    }

    public void SpawnHouse()
    {
        X = UnityEngine.Random.Range(-25f, 25f);
        Y = UnityEngine.Random.Range(-30f, 30f);
        R = UnityEngine.Random.Range(0, 360f);
        houseIndex = UnityEngine.Random.Range(0, houses.Length - 1);
        House = Instantiate(houses[houseIndex], new Vector3(X, 4.6f, Y), new Quaternion(0, R, 0, 0));

    }
    void Update()
    {
        connHouses = 0;
 
        foreach (GameObject gobj in houseIdents)
        {
            if (gobj.GetComponent<house_con>().conn)
                connHouses++;
        }
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            
            SpawnHouse();
            text.text = bb.ToString();
            bb++;
        }
    }

}


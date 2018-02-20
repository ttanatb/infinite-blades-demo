using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlaneMngr : MonoBehaviour
{
    public GameObject planePrefab;
    public int count = 4;
    public float speed = 2;

    private InfinitePlane[] planes;
    // Use this for initialization
    void Start()
    {
        planes = new InfinitePlane[count];
        for (int i = 0; i < count; i++)
            planes[i] = Instantiate(planePrefab).GetComponent<InfinitePlane>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < count; i++)
        {
            planes[i].speed = speed;
        }
    }
}

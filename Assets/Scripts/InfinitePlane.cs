using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlane : MonoBehaviour
{
    static int count = 0;
    private float size = 10f;

    public float speed = 1f;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0, 0, count * size);
        count += 1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckResetPos();
    }

    private void Move()
    {
        transform.Translate(0, 0, -1 * speed * Time.deltaTime);
    }

    private void CheckResetPos()
    {
        if (transform.position.z < -size  / 2f)
        {
            transform.Translate(0, 0, size * count);
        }
    }
}

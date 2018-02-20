using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const int LANE_COUNT = 3;
    int laneIndex = 0;
    float size = 5f;

    Vector3 lerpPos;
    Vector3 lastPos;
    public float ANIM_TIME = 1f;
    float timer;
    float swayAmount;
    public float SWAY_MAX = 2;
    Vector3 dir;

    private Vector3 prevPos;
    private Vector3 prevVel;
    private Vector3 vel;

    // Use this for initialization
    void Start()
    {
        lerpPos = transform.position;
        lastPos = lerpPos;
        prevPos = lerpPos;
        timer = ANIM_TIME;
        swayAmount = SWAY_MAX;
        dir = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        UpdatePos();
        UpdateForward();
    }

    private void UpdateForward()
    {
        Quaternion prevRot = transform.rotation;
        transform.rotation = Quaternion.Lerp(prevRot, Quaternion.Euler(0f, vel.x * 10f, 0f), Time.deltaTime * 10f);
    }

    void CheckInput()
    {
        if (timer < ANIM_TIME) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            laneIndex -= 1;
            if (laneIndex < -LANE_COUNT / 2)
            {
                laneIndex = -LANE_COUNT / 2;
                return;
            }
            lastPos = transform.position;
            lerpPos.x = laneIndex * size / 2f + Mathf.Sin(Time.time * 5f) / 5f;
            timer = 0f;
            dir = -Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            laneIndex += 1;
            if (laneIndex > LANE_COUNT / 2)
            {
                laneIndex = LANE_COUNT / 2;
                return;
            }
            lastPos = transform.position;
            lerpPos.x = laneIndex * size / 2f;
            timer = 0f;
            dir = Vector3.right;
        }
    }

    void UpdatePos()
    {
        prevPos = transform.position;
        prevVel = vel;

        if (timer < ANIM_TIME)
        {
            transform.position = Vector3.Lerp(lastPos, lerpPos, timer / ANIM_TIME);
        }
        else
        {
            Vector3 swayVec = dir * swayAmount;
            transform.position = Vector3.Lerp(lerpPos - swayVec, lerpPos + swayVec, Mathf.Sin((timer - ANIM_TIME) * 3f) / 2f + 0.5f);
        }

        vel = (transform.position - prevPos) / Time.deltaTime;

        timer += Time.deltaTime;
    }
}

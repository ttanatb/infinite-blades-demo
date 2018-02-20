using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const int LANE_COUNT = 3;
    int laneIndex = 0;
    float size = 5f;

    Vector3 lerpPos;
    Vector3 prevPos;
    public float ANIM_TIME = 1f;
    float timer;
    float swayAmount;
    public float SWAY_MAX = 2;
    Vector3 dir;

    // Use this for initialization
    void Start()
    {
        lerpPos = transform.position;
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
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            laneIndex -= 1;
            if (laneIndex < -LANE_COUNT / 2)
            {
                laneIndex = -LANE_COUNT / 2;
            }
            prevPos = transform.position;
            lerpPos.x = laneIndex * size / 2f + Mathf.Sin(Time.time * 5f) / 5f;
            timer = 0f;
            dir = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            laneIndex += 1;
            if (laneIndex > LANE_COUNT / 2)
            {
                laneIndex = LANE_COUNT / 2;
            }
            prevPos = transform.position;
            lerpPos.x = laneIndex * size / 2f;
            timer = 0f;
            dir = -Vector3.right;
        }
    }

    void UpdatePos()
    {
        if (timer / ANIM_TIME < 1f)
        {
            transform.position = Vector3.Lerp(prevPos, lerpPos, timer / ANIM_TIME);
        }
        else
        {
            Vector3 swayVec = -dir * swayAmount;
            transform.position = Vector3.Lerp(lerpPos - swayVec, lerpPos + swayVec, Mathf.Sin(timer / ANIM_TIME - 1f) / 2f + 0.5f);
        }

        timer += Time.deltaTime;
    }
}

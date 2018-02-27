using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModels : MonoBehaviour
{
    public Mesh shipMesh;
    public Mesh fakeMesh;
    public Material shipMat;
    public Material fakeMat;

    MeshFilter mFilter;
    MeshRenderer mRenderer;

    bool isUsingShip = false;

    // Use this for initialization
    void Start()
    {
        mFilter = GetComponent<MeshFilter>();
        mRenderer = GetComponent<MeshRenderer>();

        //transform.localScale /= 0.125f;
        //transform.Translate(0.5f * Vector3.up);
        //mFilter.mesh = fakeMesh;
        //mRenderer.material = fakeMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isUsingShip)
            {
                transform.Translate(0.5f * Vector3.up);
                transform.localScale /= 0.125f;
                mRenderer.material = fakeMat;
                mFilter.mesh = fakeMesh;
            }
            else
            {
                transform.localScale *= 0.125f;
                transform.Translate(-0.5f * Vector3.up);
                mRenderer.material = shipMat;
                mFilter.mesh = shipMesh;
            }
            isUsingShip = !isUsingShip;
        }
    }
}

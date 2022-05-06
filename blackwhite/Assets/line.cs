using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public LineRenderer li;
    public int length;
    public Vector3[] segpos;
    public Vector3[] segv;

    public Transform targetDir;
    public float targetdist;

    public float speed;

    // Start is called before the first frame update
    private void Start()
    {
        li.positionCount = length;
        segpos = new Vector3[length];
        segv = new Vector3[length];
    }

    // Update is called once per frame
    private void Update()
    {
        segpos[0] = targetDir.position;
        for (int i = 1; i < segpos.Length; i++)
        {
            segpos[i] = Vector3.SmoothDamp(segpos[i], segpos[i - 1] + targetDir.right * targetdist,ref segv[i],speed);
        }
        //for (int i = 0; i < segpos.Length; i++)
        //{
        //    segpos[i] -= targetDir.position;
        //}
        li.SetPositions(segpos);
    }
}

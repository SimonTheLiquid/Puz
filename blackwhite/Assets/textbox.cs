using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textbox : MonoBehaviour
{
    public GameObject tb;

    // Start is called before the first frame update
    void Start()
    {
        tb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On()
    {
        tb.SetActive(true);
    }
    public void Off()
    {
        tb.SetActive(false);
    }

}

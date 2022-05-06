using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveball : MonoBehaviour
{
    public float rotationspeed;
    private Vector2 direction;

    public float movespeed;

    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ran());
    }

    // Update is called once per frame
    void Update()
    {
        //direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction = pos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationspeed * Time.deltaTime);

        //Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, pos,movespeed*Time.deltaTime);
        if (Vector3.Distance(this.transform.position, pos) <= 0.5)
        {
            pos = new Vector3(Random.Range(5f, 12f), Random.Range(-3f, 7f), 0);
            StopCoroutine(Ran());
            StartCoroutine(Ran());
        }
    }

    IEnumerator Ran()
    {
        float t = 0;
        while (t <= 1)
        {
            t += Time.deltaTime;
            yield return 0;
        }
        pos = new Vector3(Random.Range(6f, 11f), Random.Range(-2.5f, 2.5f), 0);
    }
}

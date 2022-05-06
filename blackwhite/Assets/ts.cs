using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ts : MonoBehaviour
{
    public TMP_Text stage_no;
    public AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void In(int n, int s)
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        if (n >= 0)
        {
            stage_no.text = n.ToString();
        }
        else
        {
            stage_no.text = "";
        }

        //this.GetComponent<Image>().color = new Color(0.78f, 0.78f, 0.98f, 0);
        //stage_no.color = new Color(0.3f, 0.3f, 0.3f, 0);
        if (s == 1)
        {
            StartCoroutine(Fade());
        }
        if (s == 2)
        {
            StartCoroutine(Fade2());
        }
    }

    public void Out()
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(1000, 0, 0);
        this.GetComponent<Image>().color = new Color(0.78f, 0.78f, 0.98f, 0);
        stage_no.color = new Color(0.3f, 0.3f, 0.3f, 0);
    }

    IEnumerator Fade()
    {
        float a = 0;
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        stage_no.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        while (a <= 1)
        {
            a += Time.deltaTime;
            this.GetComponent<Image>().color = new Color(0.78f, 0.78f, 0.98f, curve.Evaluate(a));
            stage_no.color = new Color(0.3f, 0.3f, 0.3f, curve.Evaluate(a));
            yield return 0;
        }
        a = 1;
        while (a >= 0)
        {
            a -= Time.deltaTime;
            this.GetComponent<Image>().color = new Color(0.78f, 0.78f, 0.98f, curve.Evaluate(a));
            stage_no.color = new Color(0.3f, 0.3f, 0.3f, curve.Evaluate(a));
            stage_no.GetComponent<RectTransform>().localScale = new Vector3(curve.Evaluate(a)/2f+0.5f, curve.Evaluate(a)/2f+0.5f, 1);
            yield return 0;
        }
        Out();
    }
    IEnumerator Fade2()
    {
        float a = 1;
        this.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        while (a >= 0)
        {
            a -= Time.deltaTime;
            this.GetComponent<Image>().color = new Color(0.78f, 0.78f, 0.98f, curve.Evaluate(a));
            stage_no.color = new Color(0.3f, 0.3f, 0.3f, curve.Evaluate(a));
            stage_no.GetComponent<RectTransform>().localScale = new Vector3(curve.Evaluate(a) / 2f + 0.5f, curve.Evaluate(a) / 2f + 0.5f, 1);
            yield return 0;
        }
        Out();
    }
}

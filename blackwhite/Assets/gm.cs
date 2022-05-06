using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gm : MonoBehaviour
{
    public float[] cor;
    public GameObject[] dots;
    public GameObject p_dots;
    public int[] change;

    public int n_stage;
    public GameObject[] ssource;

    public Vector2 o_cor;
    public int selectchange;
    public GameObject[] bsource;

    public GameObject origin;
    public GameObject[] ind;
    public GameObject p_ind;

    public bool on;
    public float sens;

    public int rot;

    public Canvas can;
    public GameObject[] butsource;
    public GameObject[] buttons;

    public GameObject transaction;
    public bool ting;
    public bool ming;

    public AnimationCurve movec;

    public GameObject p_npc;
    public GameObject[] npcs;

    // Start is called before the first frame update
    void Start()
    {
        //Stage(0,1);
    }

    public void Callstage(int stage)
    {
        if (!ting)
        {
            Stage(stage,1);
            View(2);
        }
    }

    public void View(int type)
    {
        if (!ming)
        {
            StartCoroutine(Movecam(type));
        }
        if (type == 0)
        {
            transaction.GetComponent<ts>().In(-1, 1);
        }
    }

    IEnumerator Movecam(int type)
    {
        float t = 0;
        ming = true;
        while (t <= 1)
        {
            t += Time.deltaTime*1.5f;
            if (type == 1)
            {
                Camera.main.transform.position = new Vector3(15 * movec.Evaluate(t), 30, -10);
            }
            yield return 0;
        }
        if (type == 0)
        {
            Camera.main.transform.position = new Vector3(0, 30, -10);
        }
        if (type == 1)
        {
            Camera.main.transform.position = new Vector3(15, 30, -10);
        }
        if (type == 2)
        {
            Camera.main.transform.position = new Vector3(2, 2, -10);
        }
        ming = false;
    }

    public void Stage(int stage,int s)
    {
        n_stage = stage;
        Spawnnpc(ssource[n_stage].GetComponent<setstage>().d.Length);
        transaction.GetComponent<ts>().In(stage+1,s);
        buttons[selectchange].GetComponent<Image>().color = new Color(1, 1, 1);
        StartCoroutine(Transition(s));
    }

    IEnumerator Transition(int s)
    {
        if(s == 2)
        {
            Vector3 o = ssource[n_stage].GetComponent<setstage>().ori;
            origin.transform.position = o;
            if (dots != null)
            {
                for (int i = 1; i < dots.Length; i++)
                {
                    Destroy(dots[i]);
                }
            }
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(1000, 1000, 0);
            }
            cor = new float[ssource[n_stage].GetComponent<setstage>().d.Length];
            dots = new GameObject[ssource[n_stage].GetComponent<setstage>().d.Length];
            dots[0] = origin;
            cor[0] = ssource[n_stage].GetComponent<setstage>().d[0].z;
            Changecolour(cor[0], dots[0], npcs[0]);
            for (int i = 1; i < dots.Length; i++)
            {
                Vector3 v = ssource[n_stage].GetComponent<setstage>().d[i];
                GameObject g = Instantiate(p_dots, V3(v.x, v.y), Quaternion.identity);
                Debug.Log("test");
                dots[i] = g;
                cor[i] = v.z;
                Changecolour(v.z, g, npcs[i]);
            }
            //buttons = new GameObject[ssource[n_stage].GetComponent<setstage>().b.Length];
            for (int u = 0; u < ssource[n_stage].GetComponent<setstage>().b.Length; u++)
            {
                //buttons[u] = Instantiate(butsource[(int)ssource[n_stage].GetComponent<setstage>().b[u].x], can.transform);
                Vector3 v = buttons[(int)ssource[n_stage].GetComponent<setstage>().b[u].x].GetComponent<RectTransform>().anchoredPosition;
                buttons[(int)ssource[n_stage].GetComponent<setstage>().b[u].x].GetComponent<RectTransform>().anchoredPosition = new Vector3(-340, (float)(50 * (ssource[n_stage].GetComponent<setstage>().b.Length * 0.5 - 0.5 - u)), 0);
                buttons[(int)ssource[n_stage].GetComponent<setstage>().b[u].x].GetComponent<but>().set((int)ssource[n_stage].GetComponent<setstage>().b[u].z);
            }
            for (int j = 0; j < buttons.Length; j++)
            {
                buttons[j].GetComponent<Button>().interactable = true;
            }
            Selectb(-1);
        }
        float t = 0;
        ting = true;
        while (t <= 1)
        {
            t += Time.deltaTime;
            yield return 0;
        }
        ting = false;
        if (s == 1)
        {
            Vector3 o = ssource[n_stage].GetComponent<setstage>().ori;
            origin.transform.position = o;
            if (dots != null)
            {
                for (int i = 1; i < dots.Length; i++)
                {
                    Destroy(dots[i]);
                }
            }
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(1000, 1000, 0);
            }
            cor = new float[ssource[n_stage].GetComponent<setstage>().d.Length];
            dots = new GameObject[ssource[n_stage].GetComponent<setstage>().d.Length];
            dots[0] = origin;
            cor[0] = ssource[n_stage].GetComponent<setstage>().d[0].z;
            Changecolour(cor[0], dots[0], npcs[0]);
            for (int i = 1; i < dots.Length; i++)
            {
                Vector3 v = ssource[n_stage].GetComponent<setstage>().d[i];
                GameObject g = Instantiate(p_dots, V3(v.x, v.y), Quaternion.identity);
                dots[i] = g;
                cor[i] = v.z;
                Changecolour(v.z, g, npcs[i]);
                Debug.Log("test");
            }
            //buttons = new GameObject[ssource[n_stage].GetComponent<setstage>().b.Length];
            for (int u = 0; u < ssource[n_stage].GetComponent<setstage>().b.Length; u++)
            {
                //buttons[u] = Instantiate(butsource[(int)ssource[n_stage].GetComponent<setstage>().b[u].x], can.transform);
                Vector3 v = buttons[(int)ssource[n_stage].GetComponent<setstage>().b[u].x].GetComponent<RectTransform>().anchoredPosition;
                buttons[(int)ssource[n_stage].GetComponent<setstage>().b[u].x].GetComponent<RectTransform>().anchoredPosition = new Vector3(-340, (float)(50 * (ssource[n_stage].GetComponent<setstage>().b.Length * 0.5 - 0.5 - u)), 0);
                buttons[(int)ssource[n_stage].GetComponent<setstage>().b[u].x].GetComponent<but>().set((int)ssource[n_stage].GetComponent<setstage>().b[u].z);
            }
            for (int j = 0; j < buttons.Length; j++)
            {
                buttons[j].GetComponent<Button>().interactable = true;
            }
            Selectb(-1);
        }
    }

    public void Spawnnpc(int number)
    {
        for (int i = 0; i < npcs.Length; i++)
        {
            Destroy(npcs[i]);
        }
        npcs = new GameObject[number];
        for (int i = 0; i < npcs.Length; i++)
        {
            npcs[i] = Instantiate(p_npc, new Vector3(8, 0, -1), Quaternion.identity);
            if (ssource[n_stage].GetComponent<setstage>().d[i].z == 0)
            {
                foreach (LineRenderer line in npcs[i].GetComponentsInChildren<LineRenderer>())
                {
                    line.startColor = Color.white;
                    line.endColor = Color.white;
                }
                npcs[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
            if (ssource[n_stage].GetComponent<setstage>().d[i].z == 1)
            {
                foreach (LineRenderer line in npcs[i].GetComponentsInChildren<LineRenderer>())
                {
                    line.startColor = Color.black;
                    line.endColor = Color.black;
                }
                npcs[i].GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }

    public void Flip()
    {
        if (selectchange != -1)
        {
            Vector2[] temp = new Vector2[bsource[selectchange].GetComponent<setblock>().e.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = Rotate(bsource[selectchange].GetComponent<setblock>().e[i]);
            }          
            change = t(temp);
            if (change != null)
            {
                int left = buttons[selectchange].GetComponentInChildren<but>().uses();
                if (left != -1)
                {
                    for (int i = 0; i < change.Length; i++)
                    {
                        switch (cor[change[i]])
                        {
                            case 1:
                                Changecolour(0, dots[change[i]], npcs[change[i]]);
                                cor[change[i]] = 0;
                                break;

                            default:
                                Changecolour(1, dots[change[i]], npcs[change[i]]);
                                cor[change[i]] = 1;
                                break;
                        }
                    }
                    if (Check())
                    {
                        Debug.Log("allsame");
                        Stage(n_stage+1,1);
                    }
                    if(left == 0)
                    {
                        buttons[selectchange].GetComponent<Image>().color = new Color(1, 1, 1);
                        buttons[selectchange].GetComponent<Button>().interactable = false;
                        Selectb(-1);
                        Debug.Log("a");
                    }
                }
                else
                {
                    Debug.Log("no left");
                }
            }
        }
    }

    public int[] t(Vector2[] e)
    {
        Vector2 o = ssource[n_stage].GetComponent<setstage>().ori;
        Vector3[] v = ssource[n_stage].GetComponent<setstage>().d;
        int[] temp = new int[e.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            float x = e[i].x;
            float y = e[i].y;
            bool k = false;
            for (int u = 0; u < v.Length; u++)
            {
                if(x+o_cor.x-o.x == v[u].x && y + o_cor.y-o.y == v[u].y)
                {
                    temp[i] = u;
                    k = true;
                }
            }
            if(k == false)
            {
                return null;
            }
        }
        return temp;
    }

    Vector3 V3(float x, float y)
    {
        return new Vector3(origin.transform.position.x + x, origin.transform.position.y + y, 0);
    }

    public void Changecolour(float c, GameObject dot, GameObject npc)
    {
        switch (c)
        {
            case 1:
                dot.GetComponent<SpriteRenderer>().color = Color.black;
                foreach (LineRenderer line in npc.GetComponentsInChildren<LineRenderer>())
                {
                    line.startColor = Color.black;
                    line.endColor = Color.black;
                }
                npc.GetComponent<SpriteRenderer>().color = Color.black;
                break;

            default:
                dot.GetComponent<SpriteRenderer>().color = Color.white;
                foreach (LineRenderer line in npc.GetComponentsInChildren<LineRenderer>())
                {
                    line.startColor = Color.white;
                    line.endColor = Color.white;
                }
                npc.GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
    }

    bool Check()
    {
        float x = cor[0];
        for (int i = 1; i < dots.Length; i++)
        {
            if (cor[i] != x)
            {
                return false;
            }
        }
        return true;
    }

    void Update()
    {
        if (!ting)
        {
            Vector2 temp = o_cor;
            Vector3 m = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 temp2 = new Vector2(Mathf.Round(m.x), Mathf.Round(m.y));
            if (Vector2.Distance(m, temp2) <= sens && Top(temp2))
            {
                on = true;
                o_cor = temp2;
            }
            else
            {
                if (on == true)
                {
                    o_cor = new Vector2(1000, 1000);
                    Moveind();
                }
                on = false;
            }

            if (o_cor != temp && on)
            {
                Moveind();
            }

            if (Input.GetMouseButtonUp(1) && on)
            {
                Flip();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rot += 1;
                if (rot == 4)
                {
                    rot = 0;
                }
                Moveind();
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                Stage(n_stage, 2);
            }
        }
    }

    public void Selectb(int s)
    {
        rot = 0;
        int os = selectchange;
        if (ind != null)
        {
            for (int i = 0; i < ind.Length; i++)
            {
                Destroy(ind[i]);
            }
        }
        selectchange = s;
        if (s != -1)
        {
            ind = new GameObject[bsource[selectchange].GetComponent<setblock>().e.Length];
            for (int i = 0; i < bsource[selectchange].GetComponent<setblock>().e.Length; i++)
            {
                GameObject g = Instantiate(p_ind);
                ind[i] = g;
            }
            if (os != -1)
            {
                buttons[os].GetComponent<Image>().color = new Color(1, 1, 1);
            }
            buttons[s].GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.9f);
        }
    }

    void Moveind()
    {
        if (selectchange != -1)
        {
            for (int i = 0; i < ind.Length; i++)
            {
                Vector2 v = Rotate(bsource[selectchange].GetComponent<setblock>().e[i]);
                ind[i].transform.position = new Vector3(o_cor.x + v.x, o_cor.y + v.y, -1);
                if (Top(ind[i].transform.position))
                {
                    ind[i].GetComponent<SpriteRenderer>().color = Color.white;
                }
                else
                {
                    ind[i].GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
    }

    bool Top(Vector2 pos)
    {
        for (int i = 0; i < dots.Length; i++)
        {
            if(pos == (Vector2)dots[i].transform.position)
            {
                return true;
            }
        }
        return false;
    }

    Vector2 Rotate(Vector2 v)
    {
        if (rot == 1)
        {
            return new Vector2(v.y, -v.x);
        }
        if (rot == 2)
        {
            return new Vector2(-v.x, -v.y);
        }
        if (rot == 3)
        {
            return new Vector2(-v.y, v.x);
        }
        return v;
    }
}

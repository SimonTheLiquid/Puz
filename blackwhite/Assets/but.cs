using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class but : MonoBehaviour
{
    private int left;
    public TextMeshProUGUI text1;

    public void set(int l)
    {
        left = l;
        text1.text = left.ToString();
    }
    public int uses()
    {
        if (left == 0)
        {
            return -1;
        }
        else
        {
            left -= 1;
            text1.text = left.ToString();
            if(left == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    public void enter()
    {
        if (this.GetComponent<Button>().IsInteractable())
        {
            this.GetComponent<RectTransform>().localScale = Vector3.one * 1.3f;
        }
    }

    public void leave()
    {
        this.GetComponent<RectTransform>().localScale = Vector3.one;
    }
}

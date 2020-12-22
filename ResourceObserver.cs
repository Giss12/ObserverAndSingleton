using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceObserver : MonoBehaviour
{
    public TextMeshProUGUI money;
    public ResType res;
    private void Start()
    {
        Singlton.ResourceBank.OnResChanged += ResourceText;
    }
    private void ResourceText(ResType arg1, int arg2)
    {
        if (arg1 == res)
        {
            money.text = arg2.ToString();
        }
    }
}

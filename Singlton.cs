using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlton : MonoBehaviour
{
    public static Singlton ResourceBank;
    Dictionary<ResType, int> Res = new Dictionary<ResType, int>(4);
    public Action<ResType, int> OnResChanged = (res, i) => { };
    private void Start()
    {
        Res.Add(ResType.Деньги, 0);
        Res.Add(ResType.Дерево, 0);
        Res.Add(ResType.Дом, 0);
        Res.Add(ResType.Рабочий, 5);
        StartCoroutine(OnChangedWood());
    }

    private void Awake()
    {
        if (ResourceBank == null)
        {
            ResourceBank = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public void ChangeResource(ResType res, int val)
    {
        Res[res] += val;
        OnResChanged(res, GetResource(res));
    }

    public int GetResource(ResType res)
    {
        return Res[res];
    }

    IEnumerator OnChangedWood()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            ChangeResource(ResType.Дерево, GetResource(ResType.Рабочий));
        }
    }
}

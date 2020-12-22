using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceExchanger : MonoBehaviour
{
    private void Update()
    {
        Singlton.ResourceBank.OnResChanged += ResourceText;
    }
    private void ResourceText(ResType arg1, int arg2)
    {
        if(Singlton.ResourceBank.GetResource(ResType.Дерево) >= 10)
        {
            Singlton.ResourceBank.ChangeResource(ResType.Дерево, -10);
            Singlton.ResourceBank.ChangeResource(ResType.Дом, 1);
        }
        if (Singlton.ResourceBank.GetResource(ResType.Дом) >= 5)
        {
            int a = UnityEngine.Random.Range(1, 5);
            int b = 100;
            Singlton.ResourceBank.ChangeResource(ResType.Дом, -a);
            Singlton.ResourceBank.ChangeResource(ResType.Деньги, b * a);
        }
        if (Singlton.ResourceBank.GetResource(ResType.Деньги) >= 1000)
        {
            int a = 250;
            int b = UnityEngine.Random.Range(1, 4);
            Singlton.ResourceBank.ChangeResource(ResType.Деньги, -b * a);
            Singlton.ResourceBank.ChangeResource(ResType.Рабочий, b);
        }
    }
}

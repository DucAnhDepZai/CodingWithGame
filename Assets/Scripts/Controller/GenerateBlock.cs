using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class GenerateBlock : MonoBehaviour
{
    public int childNum;
    public void Initialize()
    {

        GameObject otherBlock = Instantiate(gameObject, new Vector3(0.65f, 0, 0), Quaternion.identity);
        otherBlock.transform.SetParent(transform, false);
        otherBlock.transform.localScale = new Vector3(0, 1, 1);
        otherBlock.transform.DOScaleX(1, 0.5f)
            .SetEase(Ease.OutBack)
            .OnComplete(() =>
            {

            });
    }
    public void Clear()
    {

    }
}

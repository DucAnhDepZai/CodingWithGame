using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class GenerateBlock : MonoBehaviour
{
    public int childNum;
    public void Spawn()
    {       
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        gameObject.transform.DOScale(1, 0.5f)
            .SetEase(Ease.OutBack)
            .OnComplete(() =>
            {

            });
    }
    public void Clear()
    {     
        gameObject.transform.DOScale(0, 0.5f)
            .SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });
    }
}

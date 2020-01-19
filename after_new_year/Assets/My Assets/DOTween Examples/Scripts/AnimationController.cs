using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DoRotate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoRotate()
    {
        transform.DORotate(new Vector3(0, 360, 0), 1, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).OnComplete(DoRotate);
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HoverScript : MonoBehaviour
{
    public float wiggleDistance = 1;
    public float wiggleSpeed = 1;
    private float originalY;

    private void Start()
    {
        originalY = transform.localPosition.y;
    }

    void Update()
    {
        float yPosition = Mathf.Sin(Time.time * wiggleSpeed) * wiggleDistance;
        transform.localPosition = new Vector3(transform.localPosition.x, originalY + yPosition, transform.localPosition.z);
    }

}

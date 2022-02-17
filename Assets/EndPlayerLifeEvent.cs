using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndPlayerLifeEvent : MonoBehaviour
{
    public Image blackScreen;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gameobject entered trigger: " + other.gameObject.name);

        if (other.gameObject.name.Contains("bus"))
        {
            blackScreen.DOFade(255, 0.1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMover : MonoBehaviour
{
    private float speed = 0;
    public float busSpeed = 10;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.right * (speed / 10);
    }

    public void StartMoving()
    {
        speed = busSpeed;
        audioSource.Play();
    }
}

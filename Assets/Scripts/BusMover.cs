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

    private void FixedUpdate()
    {
        transform.position = transform.position - transform.right * (speed / 10);

        if (transform.position.x <= -60)
            transform.position = new Vector3(60, transform.position.y, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMoving()
    {
        Debug.Log("Setting speed to: " + speed);
        speed = busSpeed;
        audioSource.Play();
    }
}

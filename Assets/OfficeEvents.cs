using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class OfficeEvents : MonoBehaviour
{
    public Image blackScreenCamera;

    public GameObject[] lights;

    public AudioSource lightClickSource;

    public GameObject ElevatorDoorLeft;
    public GameObject ElevatorDoorRight;

    public Ease elevatorDoorsEase;

    public int startingElevatorFloor = 10;
    private int currentElevatorFloor;
    public float elevatorTimePerFloor = 1.5f;
    public TextMeshProUGUI currentFloorUI;

    private bool hasElevatorButtonPressed = false;
    private bool hasElevatorStarted = false;
    private float elevatorTimeElapsed = 0;

    public GameObject player;
    public GameObject elevator;
    public Transform elevatorDestination;

    public AudioSource elevatorMusicSource;
    public AudioSource elevatorDingSource;

    // Start is called before the first frame update
    void Start()
    {
        currentElevatorFloor = startingElevatorFloor;
        StartCoroutine(OnGameStart());
    }

    IEnumerator OnGameStart()
    {
        yield return new WaitForSeconds(4);
        blackScreenCamera.DOFade(0, 3);

        yield return null;
    }


    // Update is called once per frame
    void Update()
    {
        if (hasElevatorStarted && currentElevatorFloor > 0)
        {
            elevatorTimeElapsed += Time.deltaTime;
            currentElevatorFloor = startingElevatorFloor - (int) Mathf.Floor((elevatorTimeElapsed / elevatorTimePerFloor));
            currentFloorUI.text = currentElevatorFloor.ToString();

            if (currentElevatorFloor == 0)
            {
                OnElevatorArrived();
            }
        }
    }

    public void OnLightButtonPressed()
    {
        Debug.Log("Turning lights off...");
        bool isLightsTurnedOff = false;

        lightClickSource.Play();

        foreach (GameObject light in lights)
        {
            GameObject pointLight = light.transform.GetChild(0).gameObject;
            pointLight.SetActive(!pointLight.activeSelf);

            isLightsTurnedOff = !pointLight.activeSelf;
        }

        Debug.Log("Setting Statemanager lights off to: " + isLightsTurnedOff);
        GameStateManager.IsLightsTurnedOff = isLightsTurnedOff;
    }

    public void OnElevatorButtonPressed()
    {
        if (!GameStateManager.IsLightsTurnedOff || hasElevatorButtonPressed)
            return;

        hasElevatorButtonPressed = true;

        ElevatorDoorLeft.transform.DOLocalMove(Vector3.zero, 2).SetEase(elevatorDoorsEase);
        ElevatorDoorLeft.transform.DOScale(new Vector3(100, 100, 100), 2).SetEase(elevatorDoorsEase);

        ElevatorDoorRight.transform.DOLocalMove(Vector3.zero, 2).SetEase(elevatorDoorsEase).OnComplete(StartElevatorMovement);
        ElevatorDoorRight.transform.DOScale(new Vector3(100, 100, 100), 2).SetEase(elevatorDoorsEase);
    }

    private void StartElevatorMovement()
    {
        Debug.Log("Starting elevator");
        hasElevatorStarted = true;
        elevatorMusicSource.Play();
            
        player.transform.SetParent(elevator.transform);
        elevator.transform.position = elevatorDestination.position;
    }

    private void OnElevatorArrived()
    {
        Debug.Log("Elevator arrived");
        elevatorMusicSource.Stop();
        elevatorDingSource.Play();
        


        ElevatorDoorLeft.transform.DOLocalMove(new Vector3(0, 0, -2.5f), 2).SetEase(elevatorDoorsEase);
        ElevatorDoorLeft.transform.DOScale(new Vector3(100, 60, 100), 2).SetEase(elevatorDoorsEase);

        ElevatorDoorRight.transform.DOLocalMove(new Vector3(0, 0, 2.5f), 2).SetEase(elevatorDoorsEase);
        ElevatorDoorRight.transform.DOScale(new Vector3(100, 60, 100), 2).SetEase(elevatorDoorsEase);
    }
}

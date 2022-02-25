using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PastMemory : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool memory = true;

    private PlayerMovementFuture playerMovementFuture;
    private PlayerMovementPast playerMovementPast;

    private GameObject[] past;
    private GameObject[] future;

    private float coolDown = 5f;
    private float coolDownTimer;

    [SerializeField] private Text cooldownText;
    [SerializeField] private TextMeshPro text;

    private void Awake()
    {
        past = GameObject.FindGameObjectsWithTag("Past");
        future = GameObject.FindGameObjectsWithTag("Future");

        SetPastActive(false);
        SetFutureActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMovementFuture = GetComponent<PlayerMovementFuture>();
        playerMovementPast = GetComponent<PlayerMovementPast>();

        Memory();
        CoolDown();
    }

    private void Memory()
    {
        if (memory == true)
        {
            playerMovementPast.enabled = true;
            playerMovementFuture.enabled = false;

            SetPastActive(true);
            SetFutureActive(false);

            animator.SetBool("Past", true);
        }

        else if (memory == false)
        {
            playerMovementPast.enabled = false;
            playerMovementFuture.enabled = true;

            SetPastActive(false);
            SetFutureActive(true);

            animator.SetBool("Past", false);
        }
    }

    private void SetPastActive(bool val)
    {
        for (int i = 0; i < past.Length; i++)
        {
            past[i].SetActive(val);
        }
    }

    private void SetFutureActive(bool val)
    {
        for (int i = 0; i < future.Length; i++)
        {
            future[i].SetActive(val);
        }
    }

    private void CoolDown()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
            cooldownText.text = coolDownTimer.ToString("0");
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (Input.GetButtonDown("Memory") == true && coolDownTimer == 0)
        {
            memory = true;
            coolDownTimer = coolDown;
        }

        if (coolDownTimer == 0)
        {
            memory = false;
        }
    }
}

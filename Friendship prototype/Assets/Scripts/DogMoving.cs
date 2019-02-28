using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMoving : MonoBehaviour
{

    public GameObject currentDog;
    public GameObject nextRightDog;
    public bool XDirection;
    AudioSource currentDogBark;
    AudioSource nextDogBark;
    Animator currentDogAnimator;
    Animator nextDogAnimator;

    void Start () {
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            currentDogBark = currentDog.GetComponent<AudioSource>();
            currentDogBark.Stop();
            nextDogBark = nextRightDog.GetComponent<AudioSource>();
            nextDogBark.Play();
            nextDogAnimator = nextRightDog.GetComponent<Animator>();

            currentDogAnimator = currentDog.GetComponent<Animator>();
        }
    }
 }

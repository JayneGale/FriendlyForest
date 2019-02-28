using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMoving : MonoBehaviour
{

    public GameObject currentDog;
    public GameObject nextRightDog;
    public bool ZDirection;
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
            currentDogAnimator = currentDog.GetComponent<Animator>();
            currentDogAnimator.enabled = false;
            if (nextRightDog == null)
            {
                return;
            } 
            nextDogBark = nextRightDog.GetComponent<AudioSource>();
            nextDogBark.Play();
            nextDogAnimator = nextRightDog.GetComponent<Animator>();
            nextDogAnimator.enabled = true;
            if (ZDirection)
            {
                nextDogAnimator.Play("DogY");
            }
            if(!ZDirection)
            {
                nextDogAnimator.Play("Dog2");
            }
        }
    }
 }

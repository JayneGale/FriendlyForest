using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DogMoving : MonoBehaviour
{

    public GameObject nextDog;
    AudioSource nextDogBark;
    AudioSource forestAmbient;
    public AudioClip[] dogBarks;
    Animator nextDogAnimator;
    AudioClip randomisedClip;
    public float maxSecondsEachBark;
    public float maxSecondsTilNextBarking;


    private void Start()
    {
        if (nextDog == null)
        {
            Debug.Log("No dog assigned to " + gameObject.name);
        }
        nextDogBark = nextDog.GetComponent<AudioSource>();
        forestAmbient = gameObject.GetComponent<AudioSource>();
        nextDogAnimator = nextDog.GetComponent<Animator>();
        if (dogBarks.Length < 1)
        {
            Debug.Log("No audio clips assigned to " + gameObject.name);
            Application.Quit();
        }

    }

    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChooseBark(randomisedClip);
            nextDogBark.Play();
        }
    }

    private void ChooseBark(AudioClip randomisedClip)
    {
        int barkSelected = UnityEngine.Random.Range(0, dogBarks.Length);
        this.randomisedClip = dogBarks[barkSelected];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            forestAmbient.enabled = true;
            forestAmbient.Play();
            ChooseBark(randomisedClip);
            nextDogAnimator.enabled = true;
            nextDogBark.Play();
   //         nextDogBark.PlayOneShot(dogBarks[barkSelected]);
            //I don't want it to play one shot I want it to loop
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nextDogBark.Stop();
            forestAmbient.Stop();
            nextDogAnimator.enabled = false;
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMoving : MonoBehaviour
{

    public AudioSource thisDogBark;
    public AudioSource nextDogBark;
    public AudioSource nextAudio;
    AudioSource thisAudio;

    void Start () {
        thisAudio = GetComponent<AudioSource>();
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            thisAudio.Stop();
            thisDogBark.Stop();
  //          nextAudio.Play();
   //         nextDogBark.Play();
        }
    }
 }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMoving : MonoBehaviour
{

    public GameObject nextDog;
    AudioSource nextDogBark;
    AudioSource forestAmbient;
  //  public AudioClip[] dogBarks;
    Animator nextDogAnimator;

    private void Start()
    {
        if (nextDog == null)
        {
            Debug.Log("No dog assigned to " + gameObject.name);
        }
        nextDogBark = nextDog.GetComponent<AudioSource>();
        forestAmbient = gameObject.GetComponent<AudioSource>();
        nextDogAnimator = nextDog.GetComponent<Animator>();
  /*      if (dogBarks.Length < 1)
        {
            Debug.Log("No audio clips assigned to " + gameObject.name);
            Application.Quit();
        }
  */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
  /*          {
                int barkSelected = Random.Range(0, dogBarks.Length);
                nextDogBark.PlayOneShot(dogBarks[barkSelected]);
//I don't want it to play one shot I want it to loop
                }
*/
            nextDogBark.Play();
            forestAmbient.enabled = true;
            forestAmbient.Play();
//            }
            nextDogAnimator.enabled = true;
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


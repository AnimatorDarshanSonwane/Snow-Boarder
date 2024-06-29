using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
   bool hasCrashed = false;
   [SerializeField] ParticleSystem crashEffect;
   [SerializeField] float loadDelay = 0.5f;
   [SerializeField] AudioClip crashSFX;

   private AudioSource audioSource;

   private void Start() {

      audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If the AudioSource component is missing, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }
   }
      private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.CompareTag("Ground") && !hasCrashed){
         hasCrashed = true;
         FindObjectOfType<PlayerController>().DisableControls();
         Debug.Log("Hit my head ");
         crashEffect.Play();

         PlaySound();

         Invoke("ReloadScene",loadDelay);
        
      }
   }

   void ReloadScene (){
      SceneManager.LoadScene(0);
   }

   // Method to play the audio clip using PlayOneShot

    public void PlaySound()
    {
        if (crashSFX != null)
        {
            audioSource.PlayOneShot(crashSFX);
        }
        else
        {
            Debug.LogWarning("AudioClip is not assigned.");
        }
    }

}

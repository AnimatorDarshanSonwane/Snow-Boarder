

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class SurfDetector : MonoBehaviour
{

[SerializeField] ParticleSystem surfEffect;
[SerializeField] float boostSpeed = 15f;
[SerializeField] float baseSpeed = 10f;



private void Update() {
    RespondToBoost();
}


void RespondToBoost (){

 if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IncreaseStartSpeed();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DecreaseStartSpeed();
        }

}

 public void IncreaseStartSpeed()
    {
        var mainModule = surfEffect.main;
        mainModule.startSpeed = mainModule.startSpeed.constant + boostSpeed;
    }

    public void DecreaseStartSpeed()

    {
        var mainModule = surfEffect.main;
        mainModule.startSpeed = Mathf.Max(10, mainModule.startSpeed.constant - baseSpeed); // Ensure speed does not go below 0
    }

void OnCollisionEnter2D(Collision2D other) {

    if (other.gameObject.CompareTag("Ground"))
    {
       surfEffect.Play(); 
    }
    
  
}

private void OnCollisionExit2D(Collision2D other) {
    
    surfEffect.Stop();
}

}


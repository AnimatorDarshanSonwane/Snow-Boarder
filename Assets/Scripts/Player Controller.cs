using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    bool canMove = true; 
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float baseSpeed = 10f;
    Rigidbody2D rb2d;
    SurfaceEffector2D  surfaceEffector2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
        RotatePlayer();
        RespondToBoost();
        }
        
    }
    public void DisableControls(){
        canMove = false;
    }

    void RespondToBoost (){

        if (Input.GetKey(KeyCode.UpArrow)){

            surfaceEffector2D.speed = boostSpeed;

        }else if (Input.GetKey(KeyCode.DownArrow)){
            surfaceEffector2D.speed = baseSpeed;
        }

    }
    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            rb2d.AddTorque(torqueAmount);

        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {

            rb2d.AddTorque(-torqueAmount);

        }
    }

}


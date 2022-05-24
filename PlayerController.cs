using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public CharacterController charControl;
    public PlayerMovement PMS;
    public bool isArmed;
    public bool isTorch;
    public ThirdPersonAim TPA;
    public GameObject myTorch;
    public GameObject gun;
    public GameObject mainBody;
    bool bodyRotated = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        charControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isArmed && !isTorch && !anim.GetBool("isDriving"))
        {
            if (Input.GetKeyDown("z") && gun.activeSelf == false && !anim.GetBool("isWalking") && !anim.GetBool("isWalkingBackwards") && !anim.GetBool("isRunning"))
            {
                anim.SetBool("isPullRifleOut", true);
                isArmed = true;
                gun.SetActive(true);
            }

            if (Input.GetKeyDown("x") && !anim.GetBool("isWalking") && !anim.GetBool("isWalkingBackwards") && !anim.GetBool("isRunning"))
            {
                myTorch.SetActive(true);
                anim.SetBool("isGrabTorch", true);
                isTorch = true;
            }            

            if (Input.GetKey("w"))
            {
                anim.SetBool("isWalking", true);
            }

            else
            {
                anim.SetBool("isWalking", false);
            }

            if (Input.GetKey("s"))
            {
                anim.SetBool("isWalkingBackwards", true);
            }
            else
            {
                anim.SetBool("isWalkingBackwards", false);
            }
            if (Input.GetKey("a") && !anim.GetBool("isWalkingBackwards"))
            {
                var speed = 90.0f;  // Degrees per second;
                var y = speed * Time.deltaTime;
                transform.Rotate(0, -y, 0); // World rotation;
            }
            if (Input.GetKey("a") && anim.GetBool("isWalkingBackwards"))
            {
                var speed = 90.0f;  
                var y = speed * Time.deltaTime;
                transform.Rotate(0, y, 0);
            }

            if (Input.GetKey("d") && !anim.GetBool("isWalkingBackwards"))
            {
                var speed = 90.0f; 
                var y = speed * Time.deltaTime;
                transform.Rotate(0, y, 0);
            }
            if (Input.GetKey("d") && anim.GetBool("isWalkingBackwards"))
            {
                var speed = 90.0f; 
                var y = speed * Time.deltaTime;
                transform.Rotate(0, -y, 0); 
            }
        }

        else if (isTorch == true) {

            if (Input.GetKeyDown("x") && anim.GetBool("isGrabTorch")) //push z again for no rifle
            {
                myTorch.SetActive(false);
                anim.SetBool("isGrabTorch", false);
                isTorch = false;
            }

            if (Input.GetKey("w"))
            {
                anim.SetBool("isTorchWalkFW", true);

            }
            else
            {
                anim.SetBool("isTorchWalkFW", false);
            }

            if (Input.GetKey("s"))
            {
                anim.SetBool("isTorchWalkBW", true);
            }
            else
            {
                anim.SetBool("isTorchWalkBW", false);
            }

            if (Input.GetKey("a") && !anim.GetBool("isTorchWalkBW"))
            {
                var speed = 90.0f;  // Degrees per second;
                var y = speed * Time.deltaTime;
                transform.Rotate(0, -y, 0); // World rotation;
            }
            if (Input.GetKey("a") && anim.GetBool("isTorchWalkBW"))
            {
                var speed = 90.0f;
                var y = speed * Time.deltaTime;
                transform.Rotate(0, y, 0);
            }

            if (Input.GetKey("d") && !anim.GetBool("isTorchWalkBW"))
            {
                var speed = 90.0f;
                var y = speed * Time.deltaTime;
                transform.Rotate(0, y, 0);
            }
            if (Input.GetKey("d") && anim.GetBool("isTorchWalkBW"))
            {
                var speed = 90.0f;
                var y = speed * Time.deltaTime;
                transform.Rotate(0, -y, 0);
            }
        }

        else if (isArmed == true) //if armed
        {
            if (TPA.isAiming == false)
            {
                if (Input.GetKeyDown("z") && anim.GetBool("isPullRifleOut") && gun.activeSelf == true) //push z again for no rifle
                {
                    gun.SetActive(false);
                    anim.SetBool("isPullRifleOut", false);
                    isArmed = false;
                    
                }

                if (Input.GetMouseButton(1))
                {
                    anim.SetBool("isRifleAimIdle", true);
                }

                else
                {
                    anim.SetBool("isRifleAimIdle", false);
                }

                if (Input.GetKey("w"))
                {
                    anim.SetBool("isRifleWalkFW", true);

                }
                else
                {
                    anim.SetBool("isRifleWalkFW", false);
                }

                if (Input.GetKey("s"))
                {
                    anim.SetBool("isRifleWalkBW", true);
                }
                else
                {
                    anim.SetBool("isRifleWalkBW", false);
                }

                if (Input.GetKey("a") && !anim.GetBool("isRifleWalkBW"))
                {
                    var speed = 90.0f;  // Degrees per second;
                    var y = speed * Time.deltaTime;
                    transform.Rotate(0, -y, 0); // World rotation;
                }
                if (Input.GetKey("a") && anim.GetBool("isRifleWalkBW"))
                {
                    var speed = 90.0f;
                    var y = speed * Time.deltaTime;
                    transform.Rotate(0, y, 0);
                }

                if (Input.GetKey("d") && !anim.GetBool("isRifleWalkBW"))
                {
                    var speed = 90.0f;
                    var y = speed * Time.deltaTime;
                    transform.Rotate(0, y, 0);
                }
                if (Input.GetKey("d") && anim.GetBool("isRifleWalkBW"))
                {
                    var speed = 90.0f;
                    var y = speed * Time.deltaTime;
                    transform.Rotate(0, -y, 0);
                }

            } else //if aiming true
            {
                Vector3 mousePos = Input.mousePosition;
                Vector3 bodyRotatePlus = new Vector3(mainBody.transform.eulerAngles.x, mainBody.transform.eulerAngles.y + 35.0f, mainBody.transform.eulerAngles.z);
                Vector3 bodyRotateMin = new Vector3(mainBody.transform.eulerAngles.x, mainBody.transform.eulerAngles.y - 35.0f, mainBody.transform.eulerAngles.z);

                if (Input.GetMouseButton(0)) //schieten
                {
                    anim.SetBool("isRifleFiringIdle", true);
                }

                else
                {
                    anim.SetBool("isRifleFiringIdle", false);
                }

                if (Input.GetMouseButton(1) && !Input.GetKey("w") && mousePos.x > (Screen.width / 2f)) 
                {
                    anim.SetBool("isRifleAimWalkMirror", false);                    
                    anim.SetBool("isRifleAimIdleMirror", true);
                    anim.SetBool("isRifleAimWalkFW", false);
                    if (bodyRotated == false)
                    {
                        
                        mainBody.transform.eulerAngles = bodyRotatePlus;
                        bodyRotated = true;
                    }
                
                }

                else if (Input.GetMouseButton(1) && !Input.GetKey("w") && mousePos.x < (Screen.width / 2f))
                {
                    anim.SetBool("isRifleAimWalkMirror", false);
                    anim.SetBool("isRifleAimWalkFW", false);
                    anim.SetBool("isRifleAimIdle", true);
                    anim.SetBool("isRifleAimIdleMirror", false);
                    anim.SetBool("isRifleWalkFW", false);
                    if (bodyRotated == true)
                    {
                        
                        mainBody.transform.eulerAngles = bodyRotateMin;
                        bodyRotated = false;
                    }

                }

                else if (Input.GetMouseButton(1) && Input.GetKey("w") && mousePos.x < (Screen.width / 2f))
                {
                    anim.SetBool("isRifleAimWalkFW", true);
                    anim.SetBool("isRifleAimWalkMirror", false);
                    if (bodyRotated == true)
                    {
                        
                        mainBody.transform.eulerAngles = bodyRotateMin;
                        bodyRotated = false;
                    }

                }

                else if (Input.GetMouseButton(1) && Input.GetKey("w") && mousePos.x > (Screen.width / 2f))
                {
                    anim.SetBool("isRifleAimWalkFW", true);
                    anim.SetBool("isRifleAimWalkMirror", true);
                    if (bodyRotated == false)
                    {
                        
                        mainBody.transform.eulerAngles = bodyRotatePlus;
                        bodyRotated = true;
                    }

                }
                else //when aiming but let go mouse
                {
                    
                    anim.SetBool("isRifleAimWalkFW", false);
                    anim.SetBool("isRifleAimWalkMirror", false);
                    anim.SetBool("isRifleAimIdle", false);
                    anim.SetBool("isRifleAimIdleMirror", false);

                    if (bodyRotated == true)
                    {

                        mainBody.transform.eulerAngles = bodyRotateMin;
                        bodyRotated = false;
                    }

                }

                if (Input.GetMouseButton(1) && Input.GetKey("s") && mousePos.x < (Screen.width / 2f)) //rifle aim walk bw
                {                    
                    anim.SetBool("isRifleAimWalkBWMirror", false);
                    anim.SetBool("isRifleAimWalkBW", true);
                    if (bodyRotated == true)
                    {
                        
                        mainBody.transform.eulerAngles = bodyRotateMin;
                        bodyRotated = false;
                    }
                }
                else if (Input.GetMouseButton(1) && Input.GetKey("s") && mousePos.x > (Screen.width / 2f))  //rifle aim walk bw mirror
                {
                    anim.SetBool("isRifleAimWalkBW", true);
                    anim.SetBool("isRifleAimWalkBWMirror", true);
                    if (bodyRotated == false)
                    {
                        
                        mainBody.transform.eulerAngles = bodyRotatePlus;
                        bodyRotated = true;
                    }
                }
                else
                {
                    anim.SetBool("isRifleAimWalkBWMirror", false);
                    anim.SetBool("isRifleAimWalkBW", false);
                    

                }

                if (Input.GetKey("a") && !anim.GetBool("isRifleAimWalkBW"))
                {
                    var speed = 20.0f;  // Degrees per second;
                    var y = speed * Time.deltaTime;
                    transform.Rotate(0, -y, 0); // World rotation;
                }

                else if (Input.GetKey("a"))
                {
                    var speed = 20.0f;
                    var y = speed * Time.deltaTime;
                    transform.Rotate(0, y, 0);
                }

                if (Input.GetKey("d") && !anim.GetBool("isRifleAimWalkBW"))
                {
                    var speed = 20.0f;
                    var y = speed * Time.deltaTime;
                    transform.Rotate(0, y, 0);
                }

                else if (Input.GetKey("d"))
                {
                    var speed = 20.0f;
                    var y = speed * Time.deltaTime;
                    transform.Rotate(0, -y, 0);
                }
            }

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPanAim : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] public float maxLeft = 0.20f;
    [SerializeField] public float maxRight = 0.80f;
    [SerializeField] public float panSpeed = 0.005f;
    public PlayerController pC;

    void Update()
    {
        var thirdPersonFollow = aimVirtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        var POV = aimVirtualCamera.GetCinemachineComponent<CinemachinePOV>();
        Vector3 mousePos = Input.mousePosition;
        //Vector screenCenterPoint = new Vector(Screen.width / 2f);
        //POV.m_HorizontalAxis = 90; 

        if (Input.GetMouseButton(1) && mousePos.x > (Screen.width / 2f))
        {
            StopCoroutine(DecreaseCoroutine());
            StartCoroutine(IncreaseCoroutine());
            pC.anim.SetBool("isRAimWalkMirror", true);
            //pC.anim.SetBool("isRAimIdleMirror", true);
        }

        else if (Input.GetMouseButton(1) && mousePos.x < (Screen.width / 2f))
        {
            StopCoroutine(IncreaseCoroutine());
            StartCoroutine(DecreaseCoroutine());
            pC.anim.SetBool("isRAimWalkMirror", false);
            //pC.anim.SetBool("isRAimIdleMirror", false);
        }

        IEnumerator IncreaseCoroutine()
        {
            while (thirdPersonFollow.CameraSide < maxRight)
            {
                thirdPersonFollow.CameraSide += panSpeed * Time.deltaTime;

                //yield on a new YieldInstruction that waits for 5 seconds.
                yield return new WaitForSeconds(0.01f);

            }
            
        }

        IEnumerator DecreaseCoroutine()
        {
            while (thirdPersonFollow.CameraSide > maxLeft)
            {
                thirdPersonFollow.CameraSide -= panSpeed * Time.deltaTime;

                //yield on a new YieldInstruction that waits for 5 seconds.
                yield return new WaitForSeconds(0.01f);

            }
            
        }


    }
    }
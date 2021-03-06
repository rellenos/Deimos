using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private int priorityBoostAmount = 10;
    [SerializeField] private Canvas thirdPersonCanvas;
    [SerializeField] private Canvas aimCanvas;
    [SerializeField] private GameObject grappling;
    [SerializeField] private GameObject Reload;
    [SerializeField] public Animator animAlythea;

    private CinemachineVirtualCamera virutalCamera;
    private InputAction aimAction;

    private void Awake()
    {
        virutalCamera = GetComponent<CinemachineVirtualCamera>();
        animAlythea = GameObject.Find("Alythea").GetComponent<Animator>();
        aimAction = playerInput.actions["Aim"];
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    public void StartAim()
    {
        Global.ISaim = true;
        virutalCamera.Priority += priorityBoostAmount;
        aimCanvas.enabled = true;
        thirdPersonCanvas.enabled = false;

        //animAlythea.SetBool("aim", true);

        if (Global.reloading != false)
        {
            Reload.gameObject.SetActive(true);
        }
        else
        {
            Reload.gameObject.SetActive(false);
        }

        if(Global.witchAvatarIsOn == 2 && Global.ISaim == true)
        {
            grappling.gameObject.SetActive(true);
        }

    }

    private void CancelAim()
    {
        Global.ISaim = false;
        virutalCamera.Priority -= priorityBoostAmount;
        aimCanvas.enabled = false;
        thirdPersonCanvas.enabled = true;

        //animAlythea.SetBool("aim", false);

        if (Global.witchAvatarIsOn == 2 && Global.ISaim == false && Global.ISgrappling == false)
        {
            grappling.gameObject.SetActive(false);
        }
    }
}

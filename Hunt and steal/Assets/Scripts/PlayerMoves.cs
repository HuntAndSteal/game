using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class PlayerMoves : MonoBehaviour
{
    PhotonView view;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField]private float speed = 6.0f;
    public CharacterController controller;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            cam = FindObjectOfType<CinemachineVirtualCamera>();
            cam.Follow = gameObject.transform.Find("Follow target");
            controller = gameObject.AddComponent<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
            
        if (view.IsMine)
        {
            if (direction.magnitude >=0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg;
                transform.rotation=Quaternion.Euler(0f,targetAngle,0f);
                controller.Move(direction * speed * Time.deltaTime);
            }
        }
    }
}

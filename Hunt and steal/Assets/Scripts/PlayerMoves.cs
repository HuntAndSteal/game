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
    private float speed = 2.0f;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            cam = FindObjectOfType<CinemachineVirtualCamera>();
            cam.Follow = gameObject.transform.Find("Follow target");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey((KeyCode.RightArrow)))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}

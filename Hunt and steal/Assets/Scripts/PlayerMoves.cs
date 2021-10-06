using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerMoves : MonoBehaviour
{
    PhotonView view;
    private float speed = 2.0f;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
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

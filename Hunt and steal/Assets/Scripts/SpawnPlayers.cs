using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Random = System.Random;

public class SpawnPlayers : MonoBehaviour
{
   public GameObject playerPrefabs;
   public float minX;
   public float maxX;
   public float minZ;
   public float maxZ;
   Random rdn = new Random();

   private void Start()
   {
      Vector3 randomPosition = new Vector3(rdn.Next(Convert.ToInt32(minX), Convert.ToInt32(maxX + 1)),2,rdn.Next(Convert.ToInt32(minZ),Convert.ToInt32(maxZ+1)));
      PhotonNetwork.Instantiate(playerPrefabs.name, randomPosition, Quaternion.identity);
      
   }
}

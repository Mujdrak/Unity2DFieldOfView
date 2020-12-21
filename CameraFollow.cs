using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	private Transform playerPos;

    void Start (){
        
    }

    void Update (){
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
    }
}

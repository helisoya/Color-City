using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float camPlacement;
    void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y+camPlacement,player.position.z);
    }
}

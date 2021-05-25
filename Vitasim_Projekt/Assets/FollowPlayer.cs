using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] public GameObject player;

    private void Update()
    {
        gameObject.transform.position = player.transform.position;
    }
}

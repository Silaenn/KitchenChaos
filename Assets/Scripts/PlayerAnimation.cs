using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerAnimation : NetworkBehaviour
{
    const string IS_WALKING = "IsWalking";
    [SerializeField] Player player;
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!IsOwner)
        {
            return;    
        }
        

        animator.SetBool(IS_WALKING, player.IsWalking());
    }


}

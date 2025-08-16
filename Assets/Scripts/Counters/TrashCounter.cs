using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnTrashSomething;
    new public static void ResetStaticData()
    {
        OnTrashSomething = null;
    }
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            KitchenObject.DestroyKitchenObject(
            player.GetKitchenObject()
            );

            InteractLogicServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    void InteractLogicServerRpc()
    {
        InteractLogicClientRpc();
    }

    [ClientRpc]
    void InteractLogicClientRpc()
    {
        OnTrashSomething?.Invoke(this, EventArgs.Empty);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
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
            player.GetKitchenObject().DestroySelf();

            OnTrashSomething?.Invoke(this, EventArgs.Empty);
        }
    }
}

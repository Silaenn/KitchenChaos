using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    bool isfirstUpdate = true;

    void Update()
    {
        if (isfirstUpdate)
        {
            isfirstUpdate = false;

            Loader.LoaderCallback();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    const string CUT = "Cut";
    [SerializeField] CuttingCounter cuttingCounter;
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        cuttingCounter.OnCut += ContainerCounter_OnPlayerCutObject;
    }

    void ContainerCounter_OnPlayerCutObject(object sender, System.EventArgs e)
    {
        animator.SetTrigger(CUT);
    }
}

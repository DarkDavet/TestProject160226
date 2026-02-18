using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

public class ButtonsManager: MonoBehaviourExtBind
{
    [Bind("OnStartClick")]
    private void OnStartClick()
    {
        Settings.Fsm.Invoke("OnStartAction");
    }

    [Bind("OnStopClick")]
    private void OnStopClick()
    {
        Settings.Fsm.Invoke("OnStopAction");
    }
}

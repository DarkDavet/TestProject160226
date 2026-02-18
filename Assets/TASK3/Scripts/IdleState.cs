using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using System.ComponentModel;
using UnityEngine;

[State("Idle")]
public class IdleState: FSMState
{
    [Enter]
    private void Enter()
    {
        Debug.Log("FSM: Idle enter");
        Model.Set("FsmState", "Idle");
        Model.Set("Speed", 0f);

        Model.Set("BtnStopEnable", false); 
        Model.Set("BtnStartEnable", true);
    }

    

    [Exit]
    private void Exit()
    {
        Log.Debug("FSM: Idle exit");
        
    }
}

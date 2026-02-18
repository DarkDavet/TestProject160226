using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Path;
using System.IO;
using UnityEngine;

[State("Stop")]
public class StopState: FSMState
{
    [Enter]
    private void Enter()
    {
        Debug.Log("FSM: Stop enter");
        Model.Set("FsmState", "Stop");
        float speed = Model.Get<float>("Speed");


        var path = new CPath();
        path.EasingQuadEaseOut(0.6f, speed, 200f, (v) => Model.Set("Speed", v))
         .Action(() => Settings.Invoke("AlignSlots"))
         .Action(() => Model.Set("Speed", 0f));
        Model.Set("SlotsPath", path);
    }

    [One(0.6f)]
    private void SetIdleState()
    {
        Parent.Change("Idle");
    }

    [Exit]
    private void Exit()
    {
        Settings.Invoke("ShowWinEffect");
    }
}

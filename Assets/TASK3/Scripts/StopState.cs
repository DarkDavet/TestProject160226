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
         .Action(() => Model.Set("Speed", 0f))
         .Wait(0.6f)
         .Action(() => Parent.Change("Idle"));
        Model.Set("SlotsPath", path);
    }
}

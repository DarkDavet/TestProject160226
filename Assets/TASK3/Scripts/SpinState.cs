using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;

[State("Spin")]
public class SpinState: FSMState
{

    [Enter]
    private void Enter()
    {
        Model.Set("BtnStartEnable", false);
        Model.Set("BtnStopEnable", false);

        Debug.Log("FSM: Spin enter");
        Model.Set("FsmState", "Spin");

        var path = new CPath();
        path.EasingQuadEaseIn(1.5f, 0f, 1000f, (v) => Model.Set("Speed", v))
         .Wait(1.5f)
         .Action(() => Model.Set("BtnStopEnable", true));
        Model.Set("SlotsPath", path);
    }
}

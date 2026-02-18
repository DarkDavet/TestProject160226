using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Path;
using ExampleFSM;
using System.IO;
using UnityEngine;

public class SetupFSM: MonoBehaviourExtBind
{
    private FSM fsm;
    [OnAwake]
    private void CreateFsm()
    {
        fsm = new FSM();
        Settings.Fsm = fsm;
        fsm.Add(new IdleState());
        fsm.Add(new SpinState());
        fsm.Add(new StopState());
    }

    [OnStart]
    private void StartFsm()
    {
        fsm.Start("Idle");
        Log.Debug("Fsm launched");
    }

    [OnUpdate]
    private void UpdateFsm()
    {
        if (fsm != null) fsm.Update(Time.deltaTime);

        var slotsPath = Model.Get<CPath>("SlotsPath");
        if (slotsPath != null)
        {
            slotsPath.Update(Time.deltaTime);
        }
    }


    [Bind("OnStartClick")]
    private void OnStartClick()
    {
        if (fsm.CurrentStateName == "Idle")
        {
            fsm.Change("Spin");
        }
    }

    [Bind("OnStopClick")]
    private void OnStopClick()
    {
        if (fsm.CurrentStateName == "Spin")
        {
            fsm.Change("Stop");
        }    
            
    }
}

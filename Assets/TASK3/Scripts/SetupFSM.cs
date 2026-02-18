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
    [OnAwake]
    private void CreateFsm()
    {
        Settings.Fsm = new FSM();
        Settings.Fsm.Add(new IdleState());
        Settings.Fsm.Add(new SpinState());
        Settings.Fsm.Add(new StopState());
    }

    [OnStart]
    private void StartFsm()
    {
        Settings.Fsm.Start("Idle");
        Log.Debug("Fsm launched");
    }

    [OnUpdate]
    private void UpdateFsm()
    {
        Settings.Fsm.Update(Time.deltaTime);

        var slotsPath = Model.Get<CPath>("SlotsPath");
        if (slotsPath != null)
        {
            slotsPath.Update(Time.deltaTime);
        }
    }
    
}

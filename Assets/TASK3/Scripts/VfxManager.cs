using AxGrid.Base;
using AxGrid.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class VfxManager: MonoBehaviourExtBind
{
    public List<ParticleSystem> _effectsList;

    [Bind("ShowWinEffect")]
    private void ShowWinEffect()
    {
        _effectsList.ForEach(x => x.Play());
    }
}

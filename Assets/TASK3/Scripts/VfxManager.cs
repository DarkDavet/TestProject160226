using AxGrid.Base;
using AxGrid.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class VfxManager: MonoBehaviourExtBind
{
    public List<ParticleSystem> _effectsList;

    [Bind("ShowWinEffect")]
    private void ShowWinEffect()
    {
        foreach (ParticleSystem effect in _effectsList)
        { 
            effect.Play(); 
        }
    }
}

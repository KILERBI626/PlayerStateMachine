using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBasePlayerState 
{
    public void EnterState();
    public IBasePlayerState ExitState();

}

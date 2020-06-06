using System;
using ModestTree;
using UnityEngine;
using Zenject;
public class TestController : IInitializable, ITickable, IDisposable
{
    public void Initialize()
    {
        Debug.Log("Goingthrough");
    }

    public void Dispose()
    {
        
    }

    public void Tick()
    {
    }

}

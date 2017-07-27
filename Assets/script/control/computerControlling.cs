using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using AssemblyCSharp;

public class computerControlling : controlling
{
    public float speedUpdateFrequency = 1f;

    private float speedUpdateCountDown = 0;



    protected override void Awake()
    {
        base.Awake();
    }

    void ResetSpeedUpdateCountDown()
    {
        this.speedUpdateCountDown = 1 / this.speedUpdateFrequency / Time.deltaTime; 
    }

    public override void UpdateControllingData()
    {
        if (this.speedUpdateCountDown - 0 < 0.1)
        {
            Vector3 randomSpeedVector = UnityEngine.Random.insideUnitSphere;
            randomSpeedVector.z = 0;
            this.physicModel.UpdateCurrentSpeedVector(randomSpeedVector);

            this.ResetSpeedUpdateCountDown();
        }
        else
        {
            this.speedUpdateCountDown -= 1f;
        }
    }
}

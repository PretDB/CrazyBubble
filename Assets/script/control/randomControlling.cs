using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using UnityEngine.Networking;

public class randomControlling : controller
{

    public float speedUpdateFrequency = 1f;

    private float speedUpdateCountDown;

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

    public override void Init(GameObject target)
    {
        base.Init(target);
        if (this.speedUpdateFrequency - 0f < 0.1f)
        {
            this.speedUpdateFrequency = 1f;
        }
    }
}

using System;
using UnityEngine;
using System.Security.Cryptography;

//using UnityEditor;

namespace AssemblyCSharp
{
    public abstract class controller : MonoBehaviour
    {
        public bool isComputer;

        protected physic physicModel;

        protected abstract void Init();

        protected abstract void UpdateCurrentSpeedVector();
    }
}


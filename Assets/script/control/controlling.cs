using System;
using UnityEngine;
using System.Security.Cryptography;

//using UnityEditor;
using System.Threading;
using UnityEngine.Networking;

namespace AssemblyCSharp
{
    public class controlling : NetworkBehaviour
    {
        protected physic physicModel;

        protected virtual void Init()
        {
            this.physicModel = this.gameObject.GetComponent<physic>();
        }

        protected virtual void Awake()
        {
            this.Init();
        }

        public virtual void UpdateControllingData()
        {
        }
    }
}


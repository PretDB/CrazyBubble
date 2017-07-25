using System;
using UnityEngine;
using System.Security.Cryptography;

//using UnityEditor;
using System.Threading;
using UnityEngine.Networking;

namespace AssemblyCSharp
{
    public class controller : NetworkBehaviour
    {
        protected physic physicModel;
        protected GameObject me;

        public virtual void Init(GameObject target)
        {
            this.me = target;
            this.physicModel = target.GetComponent<physic>();
        }

        public virtual void UpdateControllingData()
        {
        }
    }
}


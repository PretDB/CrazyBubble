using System;
using UnityEngine;
using System.Security.Cryptography;

//using UnityEditor;
using System.Threading;

namespace AssemblyCSharp
{
    public class controller : MonoBehaviour
    {

        protected physic physicModel;
        protected GameObject me;

        public virtual void Init(GameObject target)
        {
            this.me = target;
            this.physicModel = this.me.GetComponent<physic>();
        }

        public virtual void UpdateControllingData()
        {
        }
    }
}


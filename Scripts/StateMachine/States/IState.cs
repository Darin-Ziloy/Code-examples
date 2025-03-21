using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SM
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public void UpdateControlInput();
        public void UpdateState();
        public void PhysicsUpdateState();
    }
}


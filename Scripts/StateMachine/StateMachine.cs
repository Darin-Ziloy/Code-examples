using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SM
{
    public abstract class StateMachine
    {
        protected Dictionary<Type, IState> states = new();
        protected IState currentState;

        public void ChangeState(Type type)
        {
            if (states == null) { return; }
            if (!states.ContainsKey(type)) { return; }

            currentState?.Exit();

            currentState = states[type];
            
            currentState.Enter();
        }


        public void ControlInput()
        {
            currentState?.UpdateControlInput();
        }

        public void UpdateState()
        {
            currentState.UpdateState();
        }

        public void PhysicsUpdateState()
        {
            currentState.PhysicsUpdateState();
        }
    }
}

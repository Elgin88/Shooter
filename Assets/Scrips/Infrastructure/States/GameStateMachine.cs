﻿using System;
using System.Collections.Generic;

namespace Scripts.CodeBase.Infractructure
{
    public class GameStateMachine
    {
        private IState _currentState;
        private Dictionary<Type, IState> _states;

        public GameStateMachine(SceneLoader sceneLoader, AllServices allService)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootStraptState)] = new BootStraptState(this, allService),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, allService),
                [typeof(GameLoopState)] = new GameLoopState()
            };
        }

        public void Enter<TState>() where TState : class, IEnterableState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, Payload>(Payload payload) where TState : class, IEnterablePayloadedState<Payload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState GetState<TState>() where TState : class, IState
        {
            return _states[typeof(TState)] as TState;
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            _currentState = state;
            return state;
        }
    }
}
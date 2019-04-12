using System;
using System.Collections.Generic;
using WindowsInput;
using AutoRegger.Core.Data;
using AutoRegger.Core.States;

namespace AutoRegger.Core
{
    public class Regger
    {
        public Window _window;
        private static InputSimulator _inputSimulator = new InputSimulator();

        public IReggerState State { get; private set; }
        private ReggerAccountData CurrentAccountData;

        public Regger(Window window)
        {
            _window = window;
        }

        public void NextState()
        {
            if (State == null)
            {
                State = new RegisterState();
            }

            var @switchBefore = new Dictionary<Type, Action>()
            {
                [typeof(RegisterState)] = () =>
                {
                    CurrentAccountData = new ReggerAccountData()
                    {
                        EmailAccount = EmailPool.Get(),
                        Keyboard = _inputSimulator.Keyboard,
                        Window = _window
                    };
                },
            };

            if (@switchBefore.ContainsKey(State.GetType()))
                @switchBefore[State.GetType()]();
            State.Setup(CurrentAccountData);
            State.Execute();
            
            var @switchAfter = new Dictionary<Type, Action>()
            {
                [typeof(RegisterState)] = () => State = new VerifyEmailState(),
                [typeof(VerifyEmailState)] = () => State = new EndRegisterState(),
                [typeof(EndRegisterState)] = () => State = new SetupAccountState(),
                [typeof(SetupAccountState)] = () => State = new AcceptGiftState(),
                [typeof(AcceptGiftState)] = () => State = new RegisterState()
            };
            
            if (@switchAfter.ContainsKey(State.GetType()))
                @switchAfter[State.GetType()]();

            NextState();
        }
    }
}
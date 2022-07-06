using System;
using System.Collections.Generic;

namespace OOADandPatterns.Patterns.CommandDP
{
    internal class Light
    {
        public void On() => Console.WriteLine("Light on");

        public void Off() => Console.WriteLine("Light off");
    }

    internal class Fan
    {
        public void FanOn() => Console.WriteLine("Fan on");

        public void FanOff() => Console.WriteLine("Fan off");
    }

    internal interface ICommand
    {
        void Execute();
        void Undo();
    }

    internal class FanOn : ICommand
    {
        private readonly Fan _f;

        public FanOn(Fan f) 
        {
            this._f = f;
        }

        public void Execute() => _f.FanOn();

        public void Undo() => _f.FanOff();
    }

    internal class FanOff : ICommand
    {
        private readonly Fan _f;

        public FanOff(Fan f)
        {
            this._f = f;
        }

        public void Execute() => _f.FanOff();

        public void Undo() => _f.FanOn();
    }

    internal class LightOff : ICommand
    {
        private readonly Light _l;

        public LightOff(Light l)
        {
            this._l = l;
        }

        public void Execute() => _l.Off();

        public void Undo() => _l.On();
    }

    internal class LightOn : ICommand
    {
        private readonly Light _l;

        public LightOn(Light l)
        {
            this._l = l;
        }

        public void Execute() => _l.On();

        public void Undo() => _l.Off();
    }

    internal class RemoteControl
    {
        private readonly Dictionary<int, ICommand> _buttons = new Dictionary<int, ICommand>();
        private readonly Fan _f = new Fan();
        private readonly Light _l = new Light();
        private ICommand _last;

        public RemoteControl()
        {
            _buttons.Add(1, new LightOn(_l));
            _buttons.Add(2, new LightOff(_l));
            _buttons.Add(3, new FanOn(_f));
            _buttons.Add(4, new FanOff(_f));
        }

        internal void ButtonPressed(int number)
        {
            _last = _buttons[number];
            _last.Execute();
        }

        internal void Undo()
        {
            _last.Undo();
        }
    }

    public class Command1
    {
        public static void Main1()
        {
            var rm = new RemoteControl();
            rm.ButtonPressed(1);
            rm.ButtonPressed(2);
            rm.Undo();
        }
    }
}
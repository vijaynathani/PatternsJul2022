using System;

namespace OOADandPatterns.Patterns.observer
{
    public class Observable
    {
        private event Action<object> CurrentObservers = delegate { };

        public void AddObserver(Action<object> a) => CurrentObservers += a;

        public void NotifyObservers(object args) => CurrentObservers.Invoke(args);
    }

    internal class WeatherMeasurer : Observable
    {
        public void Change() => NotifyObservers(null);

        public int GetTemperature() => 25;
    }

    internal class MaxMinTemp
    {
        private readonly WeatherMeasurer _wm;

        public MaxMinTemp(WeatherMeasurer wm)
        {
            _wm = wm;
            wm.AddObserver(Update);
        }

        public void Update(object args) => Console.WriteLine("Temp changed to {0}", _wm.GetTemperature());
    }

    internal class Forecaster
    {
        private readonly WeatherMeasurer _wm;

        public Forecaster(WeatherMeasurer wm)
        {
            _wm = wm;
            wm.AddObserver(Update);
        }

        public void Update(object arg) => Console.WriteLine("Forecast changed for temp {0}", _wm.GetTemperature());
    }

    public class ObserverDP
    {
        public static void Main1()
        {
            var wm = new WeatherMeasurer();
            var m1 = new MaxMinTemp(wm);
            var m2 = new Forecaster(wm);
            wm.Change();
        }
    }
}
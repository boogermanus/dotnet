using System;
using System.Collections.Generic;
using FlyweightPattern.ConcreteFlyweight;
using FlyweightPattern.Flyweight;

namespace FlyweightPattern.FlyweightFactory
{
    public class SliderFactory
    {
        private const string BACON = "B";
        private const string VEGGIE = "V";
        private const string BBQ = "Q";

        private Dictionary<char, Slider> _sliders = new Dictionary<char, Slider>();

        public Slider GetSlider(char key)
        {
            var slider = _sliders.ContainsKey(key) ? _sliders[key] : null;

            if(slider == null)
                switch(key.ToString().ToUpper())
                {
                    case BACON: slider = new BaconMaster(); break;
                    case VEGGIE: slider = new Veggie(); break;
                    case BBQ: slider = new BBQKing(); break;
                    default: throw new Exception($"key: {key} not found");
                }
            
            return slider;
        }
    }
}
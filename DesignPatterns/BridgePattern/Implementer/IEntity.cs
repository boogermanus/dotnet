namespace BridgePattern.Implementer
{
    public interface IEntity
    {
        void Introduce(string name);

        // breaks Flash and Batman
        // not an easy change to make
        // void WhatDoYouDo();
    }
}
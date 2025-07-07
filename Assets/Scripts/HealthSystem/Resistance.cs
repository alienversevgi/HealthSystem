using System;
using Misc;

namespace Game.HealthSystem
{
    [Serializable]
    public class Resistance 
    {
        public DamageTypeAmountDictionary DamageReductions;
    }
    
    [Serializable]
    public class DamageTypeAmountDictionary : UnitySerializedDictionary<DamageType,float> { }
}
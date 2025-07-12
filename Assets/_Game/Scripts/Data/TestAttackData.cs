using Game.HealthSystem;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Example
{
    [CreateAssetMenu]
    public class TestAttackData : SerializedScriptableObject
    {
        public DamageData DamageData;

        [ShowInInspector] [PolymorphicDrawerSettings(ShowBaseType = false)] [InlineProperty] [CanBeNull]
        public BuffData BuffData;

        [ShowInInspector] [PolymorphicDrawerSettings(ShowBaseType = false)] [InlineProperty] [CanBeNull]
        public DebuffData DebuffData;

        [ShowInInspector] [PolymorphicDrawerSettings(ShowBaseType = false)] [InlineProperty] [CanBeNull]
        public OverTimeEffectData OverTimeEffectData;
    }
}
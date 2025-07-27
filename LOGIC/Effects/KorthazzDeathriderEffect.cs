using Hearthstone_Deck_Tracker.Hearthstone.EffectSystem;
using Hearthstone_Deck_Tracker.Hearthstone.EffectSystem.Enums;

namespace RivendareWarriderTracker.Logic
{
    public class KorthazzDeathriderEffect : EntityBasedEffect
    {
        public override string CardId => HearthDb.CardIds.NonCollectible.Neutral.RivendareWarrider_KorthazzDeathriderToken;
        protected override string CardIdToShowInUI => HearthDb.CardIds.NonCollectible.Neutral.RivendareWarrider_KorthazzDeathriderToken;

        public KorthazzDeathriderEffect(int entityId, bool isControlledByPlayer) : base(entityId, isControlledByPlayer)
        {

        }

        public override EffectDuration EffectDuration => EffectDuration.Permanent;
        public override EffectTag EffectTag => EffectTag.CardActivation;
    }
}

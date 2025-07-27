using Hearthstone_Deck_Tracker.Hearthstone.EffectSystem;
using Hearthstone_Deck_Tracker.Hearthstone.EffectSystem.Enums;

namespace RivendareWarriderTracker.Logic
{
    public class ZeliekConquestriderEffect : EntityBasedEffect
    {
        public override string CardId => HearthDb.CardIds.NonCollectible.Neutral.RivendareWarrider_ZeliekConquestriderToken;
        protected override string CardIdToShowInUI => HearthDb.CardIds.NonCollectible.Neutral.RivendareWarrider_ZeliekConquestriderToken;

        public ZeliekConquestriderEffect(int entityId, bool isControlledByPlayer) : base(entityId, isControlledByPlayer)
        {

        }

        public override EffectDuration EffectDuration => EffectDuration.Permanent;
        public override EffectTag EffectTag => EffectTag.CardActivation;
    }
}

using Hearthstone_Deck_Tracker.Hearthstone.EffectSystem;
using Hearthstone_Deck_Tracker.Hearthstone.EffectSystem.Enums;

namespace RivendareWarriderTracker.Logic
{
    public class RivendareWarriderEffect : EntityBasedEffect
    {
        public override string CardId => HearthDb.CardIds.Collectible.Neutral.RivendareWarrider;
        protected override string CardIdToShowInUI => HearthDb.CardIds.Collectible.Neutral.RivendareWarrider;

        public RivendareWarriderEffect(int entityId, bool isControlledByPlayer) : base(entityId, isControlledByPlayer)
        {

        }

        public override EffectDuration EffectDuration => EffectDuration.Permanent;
        public override EffectTag EffectTag => EffectTag.CardActivation;
    }
}

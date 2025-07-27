using Events = Hearthstone_Deck_Tracker.API.GameEvents;
using Card = Hearthstone_Deck_Tracker.Hearthstone.Card;
using Entity = Hearthstone_Deck_Tracker.Hearthstone.Entities.Entity;

using Hearthstone_Deck_Tracker.Hearthstone.EffectSystem.Factory;
using Hearthstone_Deck_Tracker.Hearthstone.EffectSystem;
using Hearthstone_Deck_Tracker.API;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace RivendareWarriderTracker.Logic
{
    public class HorsemanDeathTracker
    {
        private readonly List<string> cardIds = new List<string>()
        {
            HearthDb.CardIds.Collectible.Neutral.RivendareWarrider,
            HearthDb.CardIds.NonCollectible.Neutral.RivendareWarrider_BlaumeuxFamineriderToken,
            HearthDb.CardIds.NonCollectible.Neutral.RivendareWarrider_KorthazzDeathriderToken,
            HearthDb.CardIds.NonCollectible.Neutral.RivendareWarrider_ZeliekConquestriderToken
        };

        public HorsemanDeathTracker()
        {
            // Subscribe to player play events to track when cards are played
            Events.OnPlayerPlayToGraveyard.Add(HandlePlayerPlayToGraveyard);
            Events.OnOpponentPlayToGraveyard.Add(HandleOpponentPlayToGraveyard);
            registerCustomEffects();
        }

        private void HandlePlayerPlayToGraveyard(Card card)
        {
            handleCardToGraveyard(card, true);
        }

        private void HandleOpponentPlayToGraveyard(Card card)
        {
            handleCardToGraveyard(card, false);
        }

        private void handleCardToGraveyard(Card card, bool player)
        {
            var entity = findEntity(card, player);

            if (
                cardIds.Contains(card.Id) &&
                // Prevent adding duplicate effects
                !Core.Game.ActiveEffects.GetVisibleEffects(player).Any(e => e.CardId == card.Id))
            {
                // Add the effect using the actual entity (this will trigger our custom effect factory
                Core.Game.ActiveEffects.TryAddEffect(entity, player);
            }
        }

        private Entity findEntity(Card card, bool player)
        {
            return Core.Game.Entities.Values.FirstOrDefault(e =>
                e.CardId == card.Id &&
                e.IsControlledBy(player ? Core.Game.Player.Id : Core.Game.Opponent.Id)
            );
        }

        private void registerCustomEffects()
        {
            // Access the private Constructors dictionary using reflection
            var effectFactoryType = typeof(EffectFactory);
            var baseFactoryType = effectFactoryType.BaseType;
            var constructorsField = baseFactoryType.GetField("Constructors",
                BindingFlags.NonPublic | BindingFlags.Static);

            if (!(constructorsField?.GetValue(null) is System.Collections.IDictionary constructors))
                return;

            // Register the custom effects

            var rivendareConstructor = DynamicFactory<EntityBasedEffect>
                .GetConstructor(typeof(RivendareWarriderEffect).GetConstructors()[0]);
            constructors[HearthDb.CardIds.Collectible.Neutral.RivendareWarrider] = rivendareConstructor;

            var blaumeuxConstructor = DynamicFactory<EntityBasedEffect>
               .GetConstructor(typeof(BlaumeuxFamineriderEffect).GetConstructors()[0]);
            constructors[HearthDb.CardIds.NonCollectible.Neutral.RivendareWarrider_BlaumeuxFamineriderToken] = blaumeuxConstructor;

            var korthazzConstructor = DynamicFactory<EntityBasedEffect>
                .GetConstructor(typeof(KorthazzDeathriderEffect).GetConstructors()[0]);
            constructors[HearthDb.CardIds.NonCollectible.Neutral.RivendareWarrider_KorthazzDeathriderToken] = korthazzConstructor;

            var zeliekConstructor = DynamicFactory<EntityBasedEffect>
                .GetConstructor(typeof(ZeliekConquestriderEffect).GetConstructors()[0]);
            constructors[HearthDb.CardIds.NonCollectible.Neutral.RivendareWarrider_ZeliekConquestriderToken] = zeliekConstructor;
        }
    }
}

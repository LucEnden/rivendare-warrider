using System;
using System.Reflection;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.Plugins;
using RivendareWarriderTracker.Logic;

namespace RivendareWarriderTracker
{
    public class HDTBootstrap : IPlugin
    {
        private HorsemanDeathTracker _trackerInstance;

        public string Name => LocalizeTools.GetLocalized("TextName");

        public string Description => LocalizeTools.GetLocalized("TextDescription");

        public string Author => "Luc van den Enden";

        public string ButtonText => LocalizeTools.GetLocalized("LabelSettings");

        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public MenuItem MenuItem { get; set; } = null;

        public void OnButtonPress() { }

        public void OnLoad() 
        {
            _trackerInstance = new HorsemanDeathTracker();
        }

        public void OnUnload() 
        {
            _trackerInstance = null;
        }

        public void OnUpdate() { }
    }
}
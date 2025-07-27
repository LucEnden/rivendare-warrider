using Hearthstone_Deck_Tracker.API;
//using RivendareWarriderTracker.Controls;
using RivendareWarriderTracker.Logic;
using RivendareWarriderTracker.Properties;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using Core = Hearthstone_Deck_Tracker.API.Core;

namespace RivendareWarriderTracker
{
    public class RivendareWarriderTracker : IDisposable
    {
        private static string PlayerPanelName = "\"Rivendare, Warrider\" - Player Progress";
        private static string OpponentPanelName = "\"Rivendare, Warrider\" - Opponent Progress";

        public static InputMoveManager inputMoveManager;
        //public RivendareTrackerPannel playerPanel;
        //public RivendareTrackerPannel opponentPanel;

        public RivendareWarriderTracker()
        {
            // We are adding the Panel here for simplicity.  It would be better to add it under InitLogic()
            InitViewPanel();

            GameEvents.OnGameStart.Add(GameTypeCheck);
            GameEvents.OnGameEnd.Add(CleanUp);
        }

        /// <summary>
        /// Check the game type to see if our Plug-in is used.
        /// </summary>
        private void GameTypeCheck()
        {
            // ToDo : Enable toggle Props
            if (Core.Game.CurrentGameType == HearthDb.Enums.GameType.GT_RANKED ||
                Core.Game.CurrentGameType == HearthDb.Enums.GameType.GT_CASUAL ||
                Core.Game.CurrentGameType == HearthDb.Enums.GameType.GT_FSG_BRAWL ||
                Core.Game.CurrentGameType == HearthDb.Enums.GameType.GT_ARENA)
            {
                InitLogic();
            }
        }

        //private void InitLogic()
        //{
        //    // Here you can begin to work your Plug-in magic
        //}

        //private void InitViewPanel()
        //{
        //    playerPanel = new RivendareTrackerPannel()
        //    {
        //        Name = PlayerPanelName,
        //        Visibility = System.Windows.Visibility.Collapsed
        //    };
        //    Core.OverlayCanvas.Children.Add(playerPanel);

        //    Canvas.SetTop(playerPanel, Settings.Default.Top);
        //    Canvas.SetLeft(playerPanel, Settings.Default.Left);

        //    inputMoveManager = new InputMoveManager(playerPanel);

        //    Settings.Default.PropertyChanged += SettingsChanged;
        //    SettingsChanged(null, null);
        //}

        //private void SettingsChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    playerPanel.RenderTransform = new ScaleTransform(Settings.Default.Scale / 100, Settings.Default.Scale / 100);
        //    playerPanel.Opacity = Settings.Default.Opacity / 100;
        //}

        //public void CleanUp()
        //{
        //    if (playerPanel != null)
        //    {
        //        Core.OverlayCanvas.Children.Remove(playerPanel);
        //        Dispose();
        //    }
        //}

        //public void Dispose()
        //{
        //    inputMoveManager.Dispose();
        //}
    }
}
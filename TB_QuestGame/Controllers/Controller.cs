using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Controller
    {
        #region FIELDS

        private bool _usingGame;

        //
        // declare all objects required for the game
        // Note - these field objects do not require properties since they
        //        are not accessed outside of the controller
        //
        private ConsoleView _gameConsoleView;
        private TimeTraveler _gameTraveler;
        private TheFuture _gameYLocation;

        #endregion

        #region PROPERTIES


        #endregion
        
        #region CONSTRUCTORS

        public Controller()
        {
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion
        
        #region METHODS

        /// <summary>
        /// initialize the game 
        /// </summary>
        private void InitializeGame()
        {
            _usingGame = true;
            _gameYLocation = new TheFuture();
            _gameTraveler = new TimeTraveler();
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameYLocation);

        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageGameLoop()
        {
            TimeTravelerAction travelerActionChoice;

            _gameConsoleView.DisplayWelcomeScreen();

            InitializeMission();

            //
            // game loop
            //
            while (_usingGame)
            {

                //
                // get a menu choice from the ConsoleView object
                //
                travelerActionChoice = _gameConsoleView.DisplayGetTravelerActionChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case TimeTravelerAction.None:
                        break;
                    case TimeTravelerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case TimeTravelerAction.Travel:
                        _gameTraveler.YearTimeLocationID = _gameConsoleView.DisplayGetTravelersNewDestination().YearLocationID;
                        break;
                    case TimeTravelerAction.TravelerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;
                    case TimeTravelerAction.TravelerInventory:
                        _gameConsoleView.DisplayTravelerItems();
                        break;
                    case TimeTravelerAction.TravelerTreasure:
                        _gameConsoleView.DisplayTravelerTreasure();
                        break;
                    case TimeTravelerAction.ListYearDestinations:
                        _gameConsoleView.DisplayListAllTARDISDestinations();
                        break;
                    case TimeTravelerAction.ListItems:
                        _gameConsoleView.DisplayListAllGameItems();
                        break;
                    case TimeTravelerAction.ListTreasures:
                        _gameConsoleView.DisplayListAllGameTreasures();
                        break;
                    case TimeTravelerAction.Exit:
                        _usingGame = false;
                        break;
                    default:
                        break;
                }
            }

            _gameConsoleView.DisplayExitPrompt();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the traveler's starting game  parameters
        /// </summary>
        private void InitializeMission()
        {
            _gameConsoleView.DisplayGameSetupIntro();
            _gameTraveler.Name = _gameConsoleView.DisplayGetTravelersName();
            _gameTraveler.Race = _gameConsoleView.DisplayGetTravelersRace();
            _gameTraveler.YearTimeLocationID = _gameConsoleView.DisplayGetTravelersNewDestination().YearLocationID;

            // 
            // add initial items to the traveler's inventory
            //
            AddItemToTravelersInventory(3);
            AddItemToTravelersTreasure(1);
        }

        /// <summary>
        /// add a game item to the traveler's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void AddItemToTravelersInventory(int itemID)
        {
            Item item;

            item = _gameYLocation.GetItemtByID(itemID);
            item.YearTimeLocationID = 0;

            _gameTraveler.TimeTravelersItems.Add(item);
        }

        /// <summary>
        /// add a game treasure to the traveler's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void AddItemToTravelersTreasure(int itemID)
        {
            Treasure item;

            item = _gameYLocation.GetTreasuretByID(itemID);
            item.YearTimeLocationID = 0;

            _gameTraveler.TimeTravelersTreasures.Add(item);
        }

        #endregion
    }
}

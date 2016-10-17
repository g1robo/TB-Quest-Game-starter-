using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the TheFuture class manages all of the game elements
    /// </summary>
    public class TheFuture
    {
        #region ***** define all lists to be maintained by the YLocation object *****

        //
        // list of all year-time locations
        //
        public List<YearLocation> YearTimeLocations { get; set; }

        //
        // list of all items
        //
        public List<Item> Items { get; set; }


        //
        // list of all treasure
        //
        public List<Treasure> Treasures { get; set; }

        #endregion

        #region ***** constructor *****

        //
        // default TheFuture constructor
        //
        public TheFuture()
        {
            //
            // instantiate the lists of year-time locations and game objects
            //
            this.YearTimeLocations = new List<YearLocation>();
            this.Items = new List<Item>();
            this.Treasures = new List<Treasure>();

            //
            // add all of the year-time locations and game objects to their lists
            // 
            IntializeYLocationYearTimeLocations();
            IntializeYLocationItems();
            IntializeYLocationTreasures();
        }

        #endregion

        #region ***** define methods to get the next available ID for game elements *****

        /// <summary>
        /// return the next available ID for a YearLocation object
        /// </summary>
        /// <returns>next YearTimeLocationObjectID </returns>
        private int GetNextYearTimeLocationID()
        {
            int MaxID = 0;

            foreach (YearLocation YTLocation in YearTimeLocations)
            {
                if (YTLocation.YearLocationID > MaxID)
                {
                    MaxID = YTLocation.YearLocationID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for an item
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextItemID()
        {
            int MaxID = 0;

            foreach (Item item in Items)
            {
                if (item.GameObjectID > MaxID)
                {
                    MaxID = item.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for a treasure
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextTreasureID()
        {
            int MaxID = 0;

            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID > MaxID)
                {
                    MaxID = treasure.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        #endregion

        #region ***** define methods to return game element objects *****

        /// <summary>
        /// get a YearLocation object using an ID
        /// </summary>
        /// <param name="ID">year-time location ID</param>
        /// <returns>requested year-time location</returns>
        public YearLocation GetYearTimeLocationByID(int ID)
        {
            YearLocation spt = null;

            //
            // run through the year-time location list and grab the correct one
            //
            foreach (YearLocation location in YearTimeLocations)
            {
                if (location.YearLocationID == ID)
                {
                    spt = location;
                }
            }

            //
            // the specified ID was not found in the YLocation
            // throw and exception
            //
            if (spt == null)
            {
                string feedbackMessage = $"The Space-Time Location ID {ID} does not exist in the current TheFuture.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return spt;
        }

        /// <summary>
        /// get an item using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested item object</returns>
        public Item GetItemtByID(int ID)
        {
            Item requestedItem = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Item item in Items)
            {
                if (item.GameObjectID == ID)
                {
                    requestedItem = item;
                }
            }

            //
            // the specified ID was not found in the YLocation
            // throw and exception
            //
            if (requestedItem == null)
            {
                string feedbackMessage = $"The item ID {ID} does not exist in the current TheFuture.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedItem;
        }

        /// <summary>
        /// get a treasure using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested treasure object</returns>
        public Treasure GetTreasuretByID(int ID)
        {
            Treasure requestedTreasure = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID == ID)
                {
                    requestedTreasure = treasure;
                };
            }

            //
            // the specified ID was not found in the YLocation
            // throw and exception
            //
            if (requestedTreasure == null)
            {
                string feedbackMessage = $"The treasure ID {ID} does not exist in the current TheFuture.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedTreasure;
        }

        #endregion

        #region ***** define methods to get lists of game elements by location *****


        /// get a list of items using a year-time location ID
        /// </summary>
        /// <param name="ID">year-time location ID</param>
        /// <returns>list of items in the specified location</returns>
        public List<Item> GetItemtsByYearTimeLocationID(int ID)
        {
            // TODO validate YearLocationID

            List<Item> itemsInYearTimeLocation = new List<Item>();

            //
            // run through the item list and put all items in the current location
            // into a list
            //
            foreach (Item item in Items)
            {
                if (item.YearTimeLocationID == ID)
                {
                    itemsInYearTimeLocation.Add(item);
                }
            }

            return itemsInYearTimeLocation;
        }

        /// get a list of treasures using a year-time location ID
        /// </summary>
        /// <param name="ID">year-time location ID</param>
        /// <returns>list of treasures in the specified location</returns>
        public List<Treasure> GetTreasuressByYearTimeLocationID(int ID)
        {
            // TODO validate YearLocationID

            List<Treasure> treasuresInYearTimeLocation = new List<Treasure>();

            //
            // run through the treasure list and put all items in the current location
            // into a list
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.YearTimeLocationID == ID)
                {
                    treasuresInYearTimeLocation.Add(treasure);
                }
            }

            return treasuresInYearTimeLocation;
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the YLocation with all of the year-time locations
        /// </summary>
        private void IntializeYLocationYearTimeLocations()
        {
            YearTimeLocations.Add(new YearLocation
            {
                Name = "TARDIS Base",
                YearLocationID = 1,
                Description = "The Norlon Corporation's secret laboratory located deep underground, " +
                              " beneath a nondescript 7-11 on the south-side of Toledo, OH.",
                Accessable = true
            });

            YearTimeLocations.Add(new YearLocation
            {
                Name = "Xantoria Market",
                YearLocationID = 2,
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an " +
                              "open market managed by the Xantorian Commerce Coop. It is a place " +
                              "where many races from various systems trade goods.",
                Accessable = true
            });

            YearTimeLocations.Add(new YearLocation
            {
                Name = "Felandrian Plains",
                YearLocationID = 3,
                Description = "The Felandrian Plains are a common destination for tourist. " +
                  "Located just north of the equatorial line on the planet of Corlon, they" +
                  "provide excellent habitat for a rich ecosystem of flora and fauna.",
                Accessable = true
            });
        }

        /// <summary>
        /// initialize the YLocation with all of the items
        /// </summary>
        private void IntializeYLocationItems()
        {
            Items.Add(new Item
            {
                Name = "Key",
                GameObjectID = 1,
                Description = "A gold encrusted chest with strange markings lay next to a strange blue rock.",
                YearTimeLocationID = 3,
                HasValue = false,
                Value = 0,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Mirror",
                GameObjectID = 2,
                Description = "A full sized mirror with jewels decorating the border.",
                YearTimeLocationID = 2,
                HasValue = false,
                Value = 0,
                CanAddToInventory = false
            });

            Items.Add(new Item
            {
                Name = "Encabulator",
                GameObjectID = 3,
                Description = "A multi-function device carried by all Time Lords.",
                YearTimeLocationID = 0,
                HasValue = true,
                Value = 500,
                CanAddToInventory = true
            });
        }

        /// <summary>
        /// initialize the YLocation with all of the treasures
        /// </summary>
        private void IntializeYLocationTreasures()
        {
            Treasures.Add(new Treasure
            {
                Name = "Trantorian Ruby",
                TreasureType = Treasure.Type.Ruby,
                GameObjectID = 1,
                Description = "A deep red ruby the size of an egg.",
                YearTimeLocationID = 2,
                HasValue = true,
                Value = 25,
                CanAddToInventory = true
            });

            Treasures.Add(new Treasure
            {
                Name = "Lodestone",
                TreasureType = Treasure.Type.Lodestone,
                GameObjectID = 2,
                Description = "A deep red ruby the size of an egg.",
                YearTimeLocationID = 3,
                HasValue = true,
                Value = 15,
                CanAddToInventory = true
            });
        }

        #endregion

    }
}


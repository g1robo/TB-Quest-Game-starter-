using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class TimeTraveler : Character
    {
        #region FIELDS

        private List<Item> _timeTravelersItems;
        private List<Treasure> _timeTravelersTreasures;

        #endregion

        public List<Item> TimeTravelersItems
        {
            get { return _timeTravelersItems; }
            set { _timeTravelersItems = value; }
        }

        public List<Treasure> TimeTravelersTreasures
        {
            get { return _timeTravelersTreasures; }
            set { _timeTravelersTreasures = value; }
        }

        #region PROPERTIES



        #endregion


        #region CONSTRUCTORS

        public TimeTraveler()
        {
            _timeTravelersItems = new List<Item>();
            _timeTravelersTreasures = new List<Treasure>();
        }

        public TimeTraveler(string name, RaceType race, int YearTimeLocationID) : base(name, race, YearTimeLocationID)
        {

        }

        #endregion


        #region METHODS



        #endregion
    }
}

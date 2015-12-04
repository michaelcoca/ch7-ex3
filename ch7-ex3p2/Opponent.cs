using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch7_ex3p2
{
    public class Opponent
    {
        private Location myLocation;

        //public Location MyLocation
        //{
        //    get { return myLocation; }
        //    set { myLocation = value; }
        //}

        private Random random;

        //public Random MyRandom
        //{
        //    get { return random; }
        //    set { random = value; }
        //}

        public Opponent(Location myLocation)
        {
            this.myLocation = myLocation;
            this.random = new Random();
        }

        private void Move()
        {
            if (myLocation is IHasExteriorDoor && random.Next(2) == 1)
            {
                IHasExteriorDoor locationWithExteriorDoor = myLocation as IHasExteriorDoor;
                myLocation = locationWithExteriorDoor.DoorLocation;
            }
            else
            {
                //bool hidingPlaceFound = false;
                do
                {
                    myLocation = myLocation.Exits[random.Next(myLocation.Exits.Count())];
                } while (!(myLocation is IHidingPlace));
            }
        }

        public bool Check(Location location)
        {
            return location == myLocation;
        }
    }
}

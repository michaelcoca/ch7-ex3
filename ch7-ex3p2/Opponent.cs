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
        private Random random;

        public Opponent(Location myLocation)
        {
            this.myLocation = myLocation;
            this.random = new Random();
        }

        public void Move()
        {
            if (myLocation is IHasExteriorDoor && random.Next(2) == 1)
            {
                IHasExteriorDoor locationWithExteriorDoor = myLocation as IHasExteriorDoor;
                myLocation = locationWithExteriorDoor.DoorLocation;
            }

            do
            {
                myLocation = myLocation.Exits[random.Next(myLocation.Exits.Length)];
            } while (!(myLocation is IHidingPlace));
        }

        public bool Check(Location location)
        {
            return location == myLocation;
        }
    }
}

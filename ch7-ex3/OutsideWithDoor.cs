using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch7_ex3
{
    public class OutsideWithDoor:Outside, IHasExteriorDoor
    {
        public OutsideWithDoor(string name, bool hot):base(name, hot)
        {

        }

        private Location doorLocation;

        public Location DoorLocation
        {
            get
            {
                return doorLocation;
            }
            set
            {
                doorLocation = value;
            }
        }

        private string doorDescription;

        public string DoorDescription
        {
            get { return doorDescription; }
        }

    }
}

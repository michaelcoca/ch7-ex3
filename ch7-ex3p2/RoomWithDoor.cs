﻿namespace ch7_ex3p2
{
    class RoomWithDoor:Room,IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string doorDescription):base(name, decoration)
        {
            this.doorDescription = doorDescription;
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
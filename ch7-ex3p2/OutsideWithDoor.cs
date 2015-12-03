namespace ch7_ex3p2
{
    public class OutsideWithDoor:OutsideWithHidingPlace, IHasExteriorDoor
    {
        public OutsideWithDoor(string name, bool hot, string doorDescription):base(name, hot)
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

        public override string Description
        {
            get
            {
                return base.Description + " You see " + doorDescription + ".";
            }
        }

    }
}

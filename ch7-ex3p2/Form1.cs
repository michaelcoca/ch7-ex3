using System;
using System.Windows.Forms;

namespace ch7_ex3p2
{
    public partial class Form1 : Form
    {
        private Location currentLocation;
        OutsideWithDoor backYard = new OutsideWithDoor("Back Yard", true, "a screen door");
        OutsideWithHidingPlace garden = new OutsideWithHidingPlace("Garden", false);
        OutsideWithDoor frontYard = new OutsideWithDoor("Front Yard", false, "an oak door with a brass knob");
        RoomWithDoor livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "an oak door with a brass knob");
        Room diningRoom = new Room("Dining Room", "a crystal chandelier");
        RoomWithDoor kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "a screen door");
        Room stairs = new Room("Stairs", "a wooden banister");
        RoomWithHidingPlace upstairsHallway = new RoomWithHidingPlace("Upstairs Hallway", "a picture of a dog");
        RoomWithHidingPlace masterBedroom = new RoomWithHidingPlace("Master Bedroom", "a large bed");
        RoomWithHidingPlace secondBedroom = new RoomWithHidingPlace("Second Bedroom", "a small bed");
        RoomWithHidingPlace bathroom = new RoomWithHidingPlace("Bathroom", "a sink and a toilet");
        OutsideWithHidingPlace driveway = new OutsideWithHidingPlace("Driveway", false);
        Opponent opponent;


        public Form1()
        {
            InitializeComponent();
            CreateObjects();
        }
        
        public void CreateObjects()
        {

            backYard.Exits = new Location[] { kitchen, garden };
            garden.Exits = new Location[] { backYard, frontYard };
            frontYard.Exits = new Location[] { garden, livingRoom };
            livingRoom.Exits = new Location[] { frontYard, diningRoom };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { diningRoom, backYard };
            stairs.Exits = new Location[] { livingRoom, upstairsHallway };
            upstairsHallway.Exits = new Location[] { masterBedroom, secondBedroom, bathroom };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;

            upstairsHallway.HidingPlaceName = "the closet";
            masterBedroom.HidingPlaceName = "under the bed";
            secondBedroom.HidingPlaceName = "under the bed";
            bathroom.HidingPlaceName = "the shower";
            driveway.HidingPlaceName = "the garage";
            garden.HidingPlaceName = "the shed";

            //MoveToANewLocation(backYard);
            goHere.Visible = false;
            exits.Visible = false;
            goThroughTheDoor.Visible = false;
        }

        private void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;

            exits.Items.Clear();
            foreach (var item in currentLocation.Exits)
            {
                exits.Items.Add(item.Description);
            }
            exits.SelectedIndex = 0;

            description.Text = currentLocation.Description;

            goThroughTheDoor.Visible = (currentLocation is IHasExteriorDoor);
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            if (currentLocation is IHasExteriorDoor)
            {
                IHasExteriorDoor withDoor = currentLocation as IHasExteriorDoor;
                MoveToANewLocation(withDoor.DoorLocation);
            }
        }

        private void check_Click(object sender, EventArgs e)
        {

        }

        private void hide_Click(object sender, EventArgs e)
        {
            opponent = new Opponent(frontYard);
        }
    }
}

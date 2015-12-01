using System;
using System.Windows.Forms;

namespace ch7_ex3p2
{
    public partial class Form1 : Form
    {
        private Location currentLocation;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
        }
        
        public void CreateObjects()
        {
            OutsideWithDoor backYard = new OutsideWithDoor("Back Yard", true, "a screen door");
            Outside garden = new Outside("Garden", false);
            OutsideWithDoor frontYard = new OutsideWithDoor("Front Yard", false , "an oak door with a brass knob");
            RoomWithDoor livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "an oak door with a brass knob");
            Room diningRoom = new Room("Dining Room", "a crystal chandelier");
            RoomWithDoor kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "a screen door");

            backYard.Exits = new Location[] { kitchen, garden };
            garden.Exits = new Location[] { backYard, frontYard };
            frontYard.Exits = new Location[] { garden, livingRoom };
            livingRoom.Exits = new Location[] { frontYard, diningRoom };
            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { diningRoom, backYard };
            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;

            MoveToANewLocation(backYard);
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

        private void description_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
    }
}

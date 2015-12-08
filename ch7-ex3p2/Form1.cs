using System;
using System.Windows.Forms;

namespace ch7_ex3p2
{
    public partial class Form1 : Form
    {
        private Location currentLocation;
        OutsideWithDoor backYard = new OutsideWithDoor("Back Yard", true, "a screen door");
        OutsideWithHidingPlace garden = new OutsideWithHidingPlace("Garden", false, "in the shed");
        OutsideWithDoor frontYard = new OutsideWithDoor("Front Yard", false, "an oak door with a brass knob");
        RoomWithDoor livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "in the closet", "an oak door with a brass knob");
        Room diningRoom = new Room("Dining Room", "a crystal chandelier");
        RoomWithDoor kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "in the cabinet", "a screen door");
        Room stairs = new Room("Stairs", "a wooden banister");
        RoomWithHidingPlace upstairsHallway = new RoomWithHidingPlace("Upstairs Hallway", "a picture of a dog", "in the closet");
        RoomWithHidingPlace masterBedroom = new RoomWithHidingPlace("Master Bedroom", "a large bed", "under the bed");
        RoomWithHidingPlace secondBedroom = new RoomWithHidingPlace("Second Bedroom", "a small bed", "under the bed");
        RoomWithHidingPlace bathroom = new RoomWithHidingPlace("Bathroom", "a sink and a toilet", "in the shower");
        OutsideWithHidingPlace driveway = new OutsideWithHidingPlace("Driveway", false, "in the garage");
        Opponent opponent;
        int totalMoves = -1;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
        }
        
        public void CreateObjects()
        {

            backYard.Exits = new Location[] { kitchen, garden, driveway };
            garden.Exits = new Location[] { backYard, frontYard };
            frontYard.Exits = new Location[] { garden, livingRoom, driveway };
            livingRoom.Exits = new Location[] { frontYard, diningRoom, stairs };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { diningRoom, backYard };
            stairs.Exits = new Location[] { livingRoom, upstairsHallway };
            upstairsHallway.Exits = new Location[] { masterBedroom, secondBedroom, bathroom, stairs };
            masterBedroom.Exits = new Location[] { upstairsHallway };
            secondBedroom.Exits = new Location[] { upstairsHallway };
            bathroom.Exits = new Location[] { upstairsHallway };
            driveway.Exits = new Location[] { backYard, frontYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;

            MoveToANewLocation(backYard);
            goHere.Visible = false;
            check.Visible = false;
            exits.Visible = false;
            goThroughTheDoor.Visible = false;
        }

        private void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;

            exits.Items.Clear();
            foreach (var item in currentLocation.Exits)
            {
                exits.Items.Add(item.Name);
            }
            exits.SelectedIndex = 0;

            description.Text = currentLocation.Description;

            goThroughTheDoor.Visible = (currentLocation is IHasExteriorDoor);
            if (currentLocation is IHidingPlace)
            {
                check.Visible = true;
                IHidingPlace hidingLocation = currentLocation as IHidingPlace;
                check.Text = "Check " + hidingLocation.HidingPlaceName;
            }
            else
                check.Visible = false;
            totalMoves++;
            description.Text += "The player has moved " + totalMoves.ToString() + " times. ";
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
            totalMoves++;
            description.Text += "The player has moved " + totalMoves.ToString() + " times. ";
            bool isFound = opponent.Check(currentLocation);
            if (isFound)
                ResetGame();
            //else
                
        }

        private void ResetGame()
        {
            MessageBox.Show("You found me in " + totalMoves + " moves!");
            IHidingPlace foundLocation = currentLocation as IHidingPlace;
            description.Text = "The opponent was hiding " + currentLocation.Name + " in " + totalMoves.ToString() + " moves. ";
            opponent = new Opponent(frontYard);
            hide.Visible = true;
            check.Visible = false;
            goHere.Visible = false;
            exits.Visible = false;
            goThroughTheDoor.Visible = false;
            totalMoves = 0;
        }

        private void RedrawForm()
        {
            hide.Visible = false;
            if (currentLocation is IHidingPlace)
            {
                check.Visible = true;
                IHidingPlace hidingLocation = currentLocation as IHidingPlace;
                check.Text = "Check " + hidingLocation.HidingPlaceName;
            }
            else
                check.Visible = false;
            goHere.Visible = true;
            goThroughTheDoor.Visible = true;
            exits.Visible = true;
        }

        private void hide_Click(object sender, EventArgs e)
        {
            opponent = new Opponent(frontYard);
            for (int i = 0; i < 10; i++)
            {
                int theCount = i + 1;
                description.Text += theCount.ToString() + "... ";
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
                opponent.Move();
            }
            description.Text += "Ready or not, here I come! ";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            RedrawForm();
        }
    }
}

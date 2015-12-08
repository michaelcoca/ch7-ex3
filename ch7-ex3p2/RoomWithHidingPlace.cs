using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch7_ex3p2
{
    public class RoomWithHidingPlace : Room, IHidingPlace
    {
        private string hidingPlaceName;

        public string HidingPlaceName
        {
            get { return hidingPlaceName; }
            set { hidingPlaceName = value; }
        }

        public RoomWithHidingPlace(string name, string decoration, string hidingPlaceName) : base(name, decoration)
        {
            this.hidingPlaceName = hidingPlaceName;
        }

        public override string Description
        {
            get
            {
                return base.Description + " Someone could hide in " + hidingPlaceName + ". ";
            }
        }
    }
}

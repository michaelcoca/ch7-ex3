using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch7_ex3p2
{
    public class OutsideWithHidingPlace:Outside, IHidingPlace
    {
        private string hidingPlaceName;

        public string HidingPlaceName
        {
            get { return hidingPlaceName; }
            set { hidingPlaceName = value; }
        }

        public OutsideWithHidingPlace(string name, bool hot, string hidingPlaceName) :base(name, hot)
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

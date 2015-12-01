using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch7_ex3
{
    interface IHasExteriorDoor
    {
        string DoorDescription {get;}

        Location DoorLocation {get;set;}
        
    }
}

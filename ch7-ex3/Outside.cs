using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch7_ex3
{
    public class Outside:Location
    {
        public Outside(string name, bool hot):base(name)
        {
            this.hot = hot;
        }

        private bool hot;

        public bool Hot
        {
            get { return hot; }
        }

        public override string Description
        {
            get
            {
                if (hot)
                    return base.Description + " It's very hot here.";
                else
                    return base.Description;
            }
        }
    }
}

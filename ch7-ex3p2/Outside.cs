namespace ch7_ex3p2
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

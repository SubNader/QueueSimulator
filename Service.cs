using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    class Service
    {

        int number;
        int workhours;
        int mincustomers;
        int maxcustomers;
        int minserve;
        int maxserve;
        int servingtime;
        int totalserve;

        public int Number
        {
            set { this.number = value; }
            get { return this.number; }
        }

        public int WorkingHours
        {
            set { this.workhours = value; }
            get { return this.workhours; }
        }

        public int MinimumCustomers
        {
            set { this.mincustomers = value; }
            get { return this.mincustomers; }
        }

        public int MaximumCustomers
        {
            set { this.maxcustomers = value; }
            get { return this.maxcustomers; }
        }

        public int MinimumServingTime
        {
            set { this.minserve = value; }
            get { return this.minserve; }
        }

        public int MaximumServingTime
        {
            set { this.maxserve = value; }
            get { return this.maxserve; }
        }

        public int ServingTime
        {
            set { this.servingtime = value; }
            get { return this.servingtime; }
        }

        public int TotalServingTime
        {
            set { this.totalserve = value; }
            get { return this.totalserve; }
        }

    }
}

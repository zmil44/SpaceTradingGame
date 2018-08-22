using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class WarpSpeed
    {
        private double velocity;
        private int days;

        private double distance;

        public int GetTimeTravelled(double distance, int warpSpeedFactor)
        {
            CalculateVelocity(warpSpeedFactor);
            days = Convert.ToInt32((distance/velocity)*(365));
            return days;
        }

        private void CalculateVelocity(int warpSpeedFactor)
        {
            velocity = (Math.Pow(warpSpeedFactor, (10.0 / 3))) + Math.Pow((10-warpSpeedFactor),((-11.0/3)));
        }
    }
}

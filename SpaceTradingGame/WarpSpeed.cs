using System;

namespace SpaceTradingGame
{
    class WarpSpeed
    {
        double velocity;
        int days;


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

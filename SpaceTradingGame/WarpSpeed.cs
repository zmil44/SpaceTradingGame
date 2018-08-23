using System;

namespace SpaceTradingGame
{
    class WarpSpeed
    {
        private double _velocity;
        private int _days;


        public int GetTimeTravelled(double distance, int warpSpeedFactor)
        {
            CalculateVelocity(warpSpeedFactor);
            _days = Convert.ToInt32((distance/_velocity)*(365));
            return _days;
        }

        private void CalculateVelocity(int warpSpeedFactor)
        {
            _velocity = (Math.Pow(warpSpeedFactor, (10.0 / 3))) + Math.Pow((10-warpSpeedFactor),((-11.0/3)));
        }
    }
}

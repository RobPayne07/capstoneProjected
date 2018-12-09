using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capstoneProjected
{
    class RoomStats
    {

        #region Props
        private double _dimensionOne;

        private double _dimensionTwo;

        private string _roomName;

        private double _squareFootage;

        

        #endregion

        #region Fields
        public double DimensionOne
        {
            get { return _dimensionOne; }
            set { _dimensionOne = value; }
        }

        public double DimensionTwo
        {
            get { return _dimensionTwo; }
            set { _dimensionTwo = value; }
        }

        public string RoomName
        {
            get { return _roomName; }
            set { _roomName = value; }
        }

        public double SquareFootage
        {
            get { return _squareFootage; }
            set { _squareFootage = value; }
        }
        #endregion

        #region Methods

        #endregion

    }
}

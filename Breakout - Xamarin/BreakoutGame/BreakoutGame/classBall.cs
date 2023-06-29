using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BreakoutGame
{
    public class classBall
    {
        public double valueX = 0.025;
        public double valueY = -0.025;

        private double _positionX;
        private double _positionY;
        private double _sizeWidth;
        private double _sizeHeight;
        public BoxView boxBall;
        public classBall()
        {
        }
        public void createBall(double x, double y, double width, double height)
        {
            _positionX = x;
            _positionY = y;
            _sizeWidth = width;
            _sizeHeight = height;
            boxBall = new BoxView { BackgroundColor = Color.White, CornerRadius = 50 };
            Rectangle paddingRect = new Rectangle(_positionX, _positionY, _sizeWidth, _sizeHeight);
            boxBall.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            boxBall.SetValue(AbsoluteLayout.LayoutFlagsProperty, AbsoluteLayoutFlags.PositionProportional);
        }
        public void setBallPosition(double x, double y)
        {
            Rectangle paddingRect = new Rectangle(x, y, _sizeWidth, _sizeHeight);
            boxBall.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            _positionX = x;
            _positionY = y;
        }
        public void moveBall()
        {
           Rectangle paddingRect = new Rectangle(_positionX + valueX, _positionY + valueY, _sizeWidth, _sizeHeight);
           boxBall.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            _positionX = _positionX + valueX;
            _positionY = _positionY + valueY;
        } 
        public void collisionBall(BoxView padde)
        {
            if (_positionX >= 1 || _positionX <= 0)
                valueX = -valueX;
            else if (boxBall.Bounds.IntersectsWith(padde.Bounds))
                if (valueY > 0)
                    valueY = -valueY;
            if(_positionY <= 0)
                valueY = -valueY;
        }
    }
}

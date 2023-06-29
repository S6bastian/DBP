using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BreakoutGame
{
    public class classPadde
    {
        public BoxView boxPadde;
        private double _positionX;
        private double _positionY;
        private double _sizeWidth;
        private double _sizeHeight;
        public classPadde()
        {
        }
        public void createPadde(double x, double y, double width, double height)
        {
            _positionX = x;
            _positionY = y;
            _sizeWidth = width;
            _sizeHeight = height;
            boxPadde = new BoxView { BackgroundColor = Color.White};
            Rectangle paddingRect = new Rectangle(_positionX, _positionY, _sizeWidth, _sizeHeight);
            boxPadde.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            boxPadde.SetValue(AbsoluteLayout.LayoutFlagsProperty, AbsoluteLayoutFlags.All);
        }
        public void setPaddePosition(double x)
        {
            Rectangle paddingRect = new Rectangle(x, _positionY, _sizeWidth, _sizeHeight);
            boxPadde.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            _positionX = x;
        }
        public void setPaddeSize(double width, double height)
        {
            Rectangle paddingRect = new Rectangle(_positionX, _positionY, width, height);
            boxPadde.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            _sizeWidth = width;
            _sizeHeight = height;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BreakoutGame
{
    public class classEnemy
    {
        public List<Button> listEnemy;
        public int countVisible;
        private classBall _ball;
        private AbsoluteLayout _gameArea;
        public classEnemy(classBall ball, AbsoluteLayout gameArea)
        {
            listEnemy = new List<Button>();
            _ball = ball;
            _gameArea = gameArea;
        }
        private Button createEnemy(double x, double y, double width, double height)
        {
            Button boxEnemy = new Button { BackgroundColor = Color.Red, CornerRadius = 5,
            BorderColor = Color.Khaki, BorderWidth = 3};
            Rectangle paddingRect = new Rectangle(x,y, width, height);
            boxEnemy.SetValue(AbsoluteLayout.LayoutBoundsProperty, paddingRect);
            boxEnemy.SetValue(AbsoluteLayout.LayoutFlagsProperty, AbsoluteLayoutFlags.All);

            return boxEnemy;
        }

        public void collisionEnemy()
        {
            for (int i = 0; i < listEnemy.Count; i++)
            {
                if (_ball.boxBall.Bounds.IntersectsWith(listEnemy[i].Bounds) && listEnemy[i].IsVisible)
                {
                    if(_ball.valueY < 0)
                        _ball.valueY = -_ball.valueY;
                    listEnemy[i].IsVisible = false;
                    countVisible--;
                }
            }
        }

        public void AddEnemy()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    Button enemy = createEnemy(i * 0.2, j * 0.09, 0.15, 0.08);
                    listEnemy.Add(enemy);
                    _gameArea.Children.Add(enemy);
                }
            }
            countVisible = listEnemy.Count;
        }

        public void EnemyVisible()
        {
            for (int i = 0; i < listEnemy.Count; i++)
            {
                listEnemy[i].IsVisible = true;
            }
            countVisible = listEnemy.Count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BreakoutGame
{
    public class classTimerBall
    {
        private bool _valueTimer;
        private classBall _ball;
        private classPadde _padde;
        private classEnemy _enemy;
        private classVictoryLose _victoryLose;
        int count = 4;
        private bool win;
        Label _lbl;

        public classTimerBall(classBall ball, classPadde padde, classEnemy enemy, Label lbl, Button btnLevel, List<Image> imageHeart)
        {
            _ball = ball;
            _padde = padde;
            _enemy = enemy;
            _victoryLose = new classVictoryLose(btnLevel, imageHeart);
            _lbl = lbl;
        }

        public void TimerBall()
        {
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 20), () =>
            {
                if (_valueTimer)
                {
                    _ball.moveBall();
                    _enemy.collisionEnemy();
                    _ball.collisionBall(_padde.boxPadde);
                    if (_ball.boxBall.Y >= _padde.boxPadde.Y + _padde.boxPadde.Height)
                    {
                        Stop();
                        win = false;
                    }
                    else if (_enemy.countVisible==0)
                    {
                        Stop();
                        win = true;
                    }
                    return true;
                }
                else
                {
                    ye();
                    return false;
                }
            });
        }

        public async Task Start()
        {
            _valueTimer = true;
            await Task.Factory.StartNew(() =>
            {
                TimerBall();
            });
        }

        public void Stop()
        {
            _valueTimer = false;
        }

        public async void ye()
        {
            if (await _victoryLose.WinOrLose(win, _ball, _enemy, _padde))
            {
                _lbl.IsVisible = true;
                _lbl.Text = count.ToString();
                countDown();
            }
        }

        public void countDown()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (count > 0)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        _lbl.Text = count.ToString();
                    });
                    count--;
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        _lbl.IsVisible = false;
                        count = 4;
                    });
                    timerCountDown();
                    return false;
                }

                return true;
            });
            
        }
        public async void timerCountDown()
        {
            await Start();
        }

    }
}

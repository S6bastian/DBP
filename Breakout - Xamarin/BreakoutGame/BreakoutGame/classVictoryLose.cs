using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.Threading.Tasks;
//using Android.App;

namespace BreakoutGame
{
    public class classVictoryLose
    {
        private int level { get; set; } = 1;
        private int vitessePourcentage { get; set; } = 0;
        private int largeurPourcentage { get; set; } = 0;
        private string _title { get; set; }
        private string _description { get; set; }
        private string btnYes { get; set; }
        private string btnNo { get; set; }
        private Button _btnLevel { get; set; }
        private int nbHeart { get; set; } = -1;
        private List<Image> _imageHeart { get; set; }

        public classVictoryLose(Button btnLevel, List<Image> imageHeart)
        {
            _btnLevel = btnLevel;
            _imageHeart = imageHeart;
        }

        public async Task<bool> WinOrLose(bool win, classBall ball, classEnemy enemy, classPadde padde)
        {
            if (win)
                Victory();
            else
            {
                Lose();
            }
            return await restart(win,ball, enemy, padde);
        }

        private void Victory()
        {
            vitessePourcentage += 10;
            largeurPourcentage += 10;
            level++;
            _title = "Ganaste";
            _description = $"↗Level : +1\n↗Speed : +{vitessePourcentage}%\n↘Ancho : -{largeurPourcentage}%";
            btnNo = "Salir";
            btnYes = "Continuar";
        }

        private void Lose()
        {
            _title = "Casi";
            _description = $"Menos una vida";
            btnNo = "Salir";
            btnYes = "Continuar";
            nbHeart++;
            if (nbHeart >= 4)
                NoneHeart();
        }

        private void NoneHeart()
        {
            _title = "Perdiste";
            _description = $"El juego se acabó\nPuntuacion :\nNivel : {level}\nVelocidad : +{vitessePourcentage}%\nAncho : -{largeurPourcentage}%";
            btnYes = "Reiniciar";
            btnNo = "Salir";
            level = 1;
            vitessePourcentage = 0;
            largeurPourcentage = 0;
        }

        private async Task<bool> restart(bool win,classBall ball, classEnemy enemy, classPadde padde)
        {
            string text = "\n¿Quieres empezar de nuevo?";
            bool e = await App.Current.MainPage.DisplayAlert(_title, _description + text , btnYes, btnNo);
            if (e)
            {
                padde.setPaddlePosition(0.5);
                ball.setBallPosition(0.5, 0.87);

                if (win)
                {
                    padde.setPaddleSize(0.2 - ((0.2 * largeurPourcentage) / 100), 0.03);
                    if (ball.valueY < 0)
                        ball.valueY -= ((ball.valueY * vitessePourcentage) / 100);
                    else
                        ball.valueY = -ball.valueY - ((ball.valueY * vitessePourcentage)/100);
                    if (ball.valueX < 0)
                        ball.valueX = -(ball.valueX - ((ball.valueX * vitessePourcentage) / 100));
                    else
                        ball.valueX = -(ball.valueX + ((ball.valueX * vitessePourcentage) / 100));

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        _btnLevel.Text = $"Nivel : {level}";
                    });
                    enemy.EnemyVisible();
                }
                else
                {
                    if(nbHeart >= 4)
                    {
                        ball.valueY = -0.025;
                        ball.valueX = -0.025;
                        padde.setPaddleSize(0.2, 0.03);
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            _btnLevel.Text = $"Nivel : {level}";
                            for (int i = 0; i < 4; i++)
                            {
                                _imageHeart[i].IsVisible = true;
                            }
                        });

                        nbHeart = -1;
                        enemy.EnemyVisible();
                    }
                    else
                    {
                        ball.valueX = -ball.valueX;
                        if (ball.valueY > 0)
                            ball.valueY = -ball.valueY;
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            _imageHeart[nbHeart].IsVisible = false;

                        });
                    }
                }
                
                return e;
            }
            else
            {
                System.Environment.Exit(0);
                return e;
            }
        }
    }
}

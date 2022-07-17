using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkOutGame.AdditionalClasses;
using WorkOutGame.GameObjects;

namespace WorkOutGame.Button
{
    internal class Button : GameObjectView, IButton
    {
        public Button(Context context, Dimention pos, int resource)
        {
            Image = BitmapFactory.DecodeResource(context.Resources, resource);

            Position = pos;

            Image = Bitmap.CreateScaledBitmap(Image, Position.Width, Position.Height, true);
        }

        public void OnClick(float x, float y)
        {
            if (IsInCollider(x, y))
            {
                Console.WriteLine($"Click in Button x: {Position.X} y: {Position.Y}");
            }
        }

        private bool IsInCollider(float x, float y)
        {
            return x >= Position.X && x <= Position.Width + Position.X && y >= Position.Y && y <= Position.Height + Position.Y;
        }
    }
}
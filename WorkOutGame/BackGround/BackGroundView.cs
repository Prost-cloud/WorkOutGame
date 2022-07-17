using Android.Content;
using Android.Graphics;

namespace WorkOutGame.GameObjects
{
    public class BackGroundView : GameObjectView
    {
        public BackGroundView(Context context)
        {
            Image = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.BackGround);

            var metrics = context.Resources.DisplayMetrics;

            Position = new AdditionalClasses.Dimention(0, 0, metrics.WidthPixels, metrics.HeightPixels);

            Image = Bitmap.CreateScaledBitmap(Image, Position.Width, Position.Height, true);
        }

        //public void FlipBackGround()
        //{
        //    var saveX = X;
        //    var saveY = Y;
        //    X++;
        //    Y++;
        //    Width--;
        //    Height--;

        //    Bitmap = Bitmap.CreateScaledBitmap(Bitmap, Height, Width, true);

        //    //Bitmap = Bitmap.CreateScaledBitmap(Bitmap, Width, Height, true);
        //}
    }
}
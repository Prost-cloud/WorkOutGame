using Android.Graphics;
using WorkOutGame.AdditionalClasses;

namespace WorkOutGame.GameObjects
{
    public abstract class GameObjectView
    {
        private Bitmap _bitmap;
        private Dimention _position;


        public Dimention Position { get; protected set ; }
        public Bitmap Image { get; protected set; }
    }
}
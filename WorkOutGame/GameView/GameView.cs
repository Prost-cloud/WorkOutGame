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
using System.Threading;
using WorkOutGame.GameObjects;
using WorkOutGame.AdditionalClasses;

namespace WorkOutGame.GameView
{
    internal class GameView : SurfaceView, ISurfaceHolderCallback
    {
        Thread gameThread;
        Thread renderThread;

        ISurfaceHolder surfaceHolder;

        bool isRunning;
        int displayX;
        int displayY;

        float ratioX;
        float ratioY;

        BackGroundView backGroundView;
        WorkOutGame.Button.Button[] button;

        public delegate void CheckPressButton(float x, float y);
        public event CheckPressButton CheckPressButtonEvent;


        public GameView(Context context) : base(context)
        {
            var metrics = Resources.DisplayMetrics;

            displayX = metrics.WidthPixels;
            displayY = metrics.HeightPixels;

            ratioX = displayX / 1920f;
            ratioY = displayY / 1080f;

            surfaceHolder = Holder;
            surfaceHolder.AddCallback(this);

            backGroundView = new BackGroundView(context);
            button = new Button.Button[2];
            button[0] = new Button.Button(context, new Dimention(25, 25, 250, 300), Resource.Drawable.Button);
            button[1] = new Button.Button(context, new Dimention(25, 290, 250, 300), Resource.Drawable.Button);

            foreach (var b in button)
            {
                CheckPressButtonEvent += b.OnClick;
            }
        }

        override public void Draw(Canvas canvas)
        {
            canvas.DrawBitmap(backGroundView.Image, backGroundView.Position.X, backGroundView.Position.Y, null);
            foreach (var b in button)
            {
                canvas.DrawBitmap(b.Image, b.Position.X, b.Position.Y, null);
            }
        }

        public void Update()
        {
            Canvas canvas = null;
            while (isRunning)
            {
                if (surfaceHolder.Surface.IsValid)
                {
                    canvas = surfaceHolder.LockCanvas();
                    Draw(canvas);
                    surfaceHolder.UnlockCanvasAndPost(canvas);
                }
                Thread.Sleep(16);
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                CheckPressButtonEvent.Invoke(e.RawX, e.RawY);
            }

            return base.OnTouchEvent(e);
            //return true;
        }



        public void Run()
        {
            Canvas canvas = null;
            while (isRunning)
            {
                if (surfaceHolder.Surface.IsValid)
                {
                    canvas = surfaceHolder.LockCanvas();
                    Draw(canvas);
                    surfaceHolder.UnlockCanvasAndPost(canvas);
                }
                Thread.Sleep(16);
            }
        }

        public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        {
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            Resume();
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            Pause();
        }
        public void Resume()
        {
            isRunning = true;

            gameThread = new Thread(new ThreadStart(Update));
            renderThread = new Thread(new ThreadStart(Run));

            gameThread.Start();
            renderThread.Start();
        }

        public void Pause()
        {
            bool retry = true;
            while (retry)
            {
                try
                {
                    isRunning = false;
                    gameThread.Join();
                    renderThread.Join();
                    retry = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
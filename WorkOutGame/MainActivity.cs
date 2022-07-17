﻿using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;

namespace WorkOutGame
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        GameView.GameView gameView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            //Set our view from the "main" layout resource

            Window.AddFlags(Android.Views.WindowManagerFlags.Fullscreen);

            gameView = new GameView.GameView(this);

            SetContentView(gameView);
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (gameView != null)
            {
                gameView.Resume();
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            if (gameView != null)
            {
                gameView.Pause();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
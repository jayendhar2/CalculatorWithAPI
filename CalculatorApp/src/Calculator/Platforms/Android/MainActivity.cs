﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Javax.Net.Ssl;
using Org.Apache.Http.Conn.Ssl;

namespace Calculator;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    //To ignore https certificate
    protected override void OnCreate(Bundle savedInstanceState)
    {
#if DEBUG
        HttpsURLConnection.DefaultHostnameVerifier = new AllowAllHostnameVerifier();
#endif
        base.OnCreate(savedInstanceState);
    }
}

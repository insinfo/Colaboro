using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Airbnb.Lottie;

namespace Colaboro.Droid
{                                           //"@drawable/icon" NoHistory = true
    // //[Activity(Label = "Colaboro", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [Activity(Label = "Colaboro", Icon = "@mipmap/icon", Theme = "@style/SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : AppCompatActivity , Animator.IAnimatorListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Creating a new RelativeLayout
            RelativeLayout relativeLayout = new RelativeLayout(this);            
            // Defining the RelativeLayout layout parameters with Fill_Parent
            RelativeLayout.LayoutParams relativeLayoutParams = 
            new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.MatchParent);
            /*LottieAnimationView animationView = new LottieAnimationView(this);
            animationView.LayoutParameters = relativeLayoutParams;
            animationView.SetAnimation("spinner_into_confirmation.json");
            animationView.PlayAnimation();           
            animationView.AddAnimatorListener(this);
            relativeLayout.AddView(animationView);*/
            SetContentView(relativeLayout);

            StartActivity(typeof(MainActivity));
           // OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
            Finish();


            // Disable activity slide-in animation
            OverridePendingTransition(0, 0);
        }

        void Animator.IAnimatorListener.OnAnimationCancel(Animator animation)
        {           
        }

        void Animator.IAnimatorListener.OnAnimationEnd(Animator animation)
        {               
            // start the new activity
            StartActivity(typeof(MainActivity));
            OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
            Finish();
        }

        void Animator.IAnimatorListener.OnAnimationRepeat(Animator animation)
        {           
        }

        void Animator.IAnimatorListener.OnAnimationStart(Animator animation)
        {           
        }
    }
	

	
}




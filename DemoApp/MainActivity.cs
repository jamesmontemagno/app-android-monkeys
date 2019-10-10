using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace DemoApp
{
    [Activity(Label = "@string/app_name", 
        Theme = "@style/AppTheme.NoActionBar",
        MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Android.Support.V4.App.FragmentManager fragmentManager;
        private Android.Support.V4.App.Fragment monkeysFragment;
        public Android.Support.V7.Widget.Toolbar toolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            this.toolbar = toolbar;
            SetSupportActionBar(toolbar);

            fragmentManager = SupportFragmentManager;

            monkeysFragment = new MonkeyListFragment();

            fragmentManager.BeginTransaction().Replace(Resource.Id.main_container, monkeysFragment).Commit();
        }

    

    }
}
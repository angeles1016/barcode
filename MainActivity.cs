using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace BarcodeGenerator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main); // <----- MAIN UI

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            Android.Content.Intent i = new Android.Content.Intent(this, typeof(BarcodeEntryForm));
            RadioButton divITRadioButton = FindViewById<RadioButton>(Resource.Id.divIT);         
            divITRadioButton.Click += delegate {
                i.PutExtra("SOURCE", GenerateBarcodeTo.DIV_OF_IT);
                StartActivity(i); 
            };

            RadioButton hscITRadioButton = FindViewById<RadioButton>(Resource.Id.hscIT);
            hscITRadioButton.Click += delegate {
                i.PutExtra("SOURCE", GenerateBarcodeTo.HSC_IT);
                StartActivity(i); 
            };
        }

        public void barcodeEntryActivity(Object obj, EventArgs args) {
            StartActivity(typeof(BarcodeEntryForm));     
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

  

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeGenerator
{
    [Activity(Label = "@string/app_name")]
    public class BarcodeEntryForm : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.barcodeEntryFormLayout);

            // from 'Div Of IT' or 'HSC IT' ?
            string generateBarcodeTo = Intent.GetCharSequenceExtra("SOURCE");

            Button generateBarcodeButton = FindViewById<Button>(Resource.Id.generateBarcodeBtn);
            generateBarcodeButton.Click += delegate {
                if (generateBarcodeTo.Equals(GenerateBarcodeTo.DIV_OF_IT))
                    StartActivity(typeof(ShowITBarcodeActivity));
                else if (generateBarcodeTo.Equals(GenerateBarcodeTo.HSC_IT)) {
                    StartActivity(typeof(ShowHscBarcodeActivity));
                }
            };
        }
    }
}
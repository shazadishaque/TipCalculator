using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace TipCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button calculateButton;
        EditText inputBill;
        TextView outputTip;
        TextView outputTotal;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);

            calculateButton.Click += OnCalculateClick;
            inputBill.TextChanged += OnBillKeyPress;

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
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

        private void OnBillKeyPress(object sender, EventArgs e)
        {
            CalculateBill();
        }

        private void OnCalculateClick(object sender, EventArgs e)
        {
            CalculateBill();
        }

        private void CalculateBill()
        {
            outputTip.Text = "";
            outputTotal.Text = "";

            string text = inputBill.Text;
            double bill = 0;

            if (double.TryParse(text, out bill))
            {
                double tip = bill * 0.15;
                double total = bill + tip;

                outputTip.Text = tip.ToString("#,0.00");
                outputTotal.Text = total.ToString("#,0.00");
            }
        }

    }
}



using Foundation;
using NativeIOS.Services;
using Plugin.Connectivity;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UIKit;
using static NativeIOS.Model.DropBoxData;

namespace NativeIOS
{
    public partial class TestViewController : UIViewController
    {
        #region Properties
        private List<DropBoxRow> Data;
        bool useRefreshControl = false;
        UIRefreshControl RefreshControl;
        #endregion

        public TestViewController (IntPtr handle) : base (handle)
        {
        }


        #region ViewDidLoad
        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            LoadDropBoxContent();
            await RefreshAsync();
            AddRefreshControl();
            CView.Add(RefreshControl);
        }
        #endregion

        #region ServiceCalling
        private async void LoadDropBoxContent()
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    //loader.StartAnimating();
                    HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri("https://dl.dropboxusercontent.com");
                    var dropBoxContentService = RestService.For<IDropBoxContent>(httpClient);
                    var apiData = await dropBoxContentService.GetDropBoxContent();
                    Data = new List<DropBoxRow>();
                    Data = apiData.DropBoxRows;
                    if (Data == null && Data.Count == 0) return;
                    CView.Source = new DropBoxCVS(Data);
                    CView.ReloadData();
                    //Collectionview
                    //loader.StopAnimating();
                   // loader.Hidden = true;
                }
                else
                {
                    var okAlertController = UIAlertController.Create("Alert Message", "Opps..Internet is Connected!!", UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region PullToRefresh
        private async Task RefreshAsync()
        {
            if (useRefreshControl)
                RefreshControl.BeginRefreshing();

            if (useRefreshControl)
                RefreshControl.EndRefreshing();

            CView.ReloadData();
        }

        private void AddRefreshControl()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(6, 0))
            {
                RefreshControl = new UIRefreshControl();
                RefreshControl.ValueChanged += async (sender, e) =>
                {
                    await RefreshAsync();
                };
                useRefreshControl = true;
            }
        }
        #endregion

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
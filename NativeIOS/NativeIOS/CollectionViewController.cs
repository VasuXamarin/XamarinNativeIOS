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
    public partial class CollectionViewController : UIViewController
    {
        #region Properties
        private List<DropBoxRow> Data;
        bool useRefreshControl = false;
        UIRefreshControl RefreshControl;
        #endregion

        public CollectionViewController (IntPtr handle) : base (handle)
        {
        }


        #region ViewDidLoad
        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            LoadDropBoxContent();
            await RefreshAsync();
            AddRefreshControl();
            DropBoxCollectionView.Add(RefreshControl);
            DropBoxCollectionView.Layer.CornerRadius = 10;
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
                    DropBoxCollectionView.Source = new DropBoxCVS(Data);
                    DropBoxCollectionView.ReloadData();
                   // loader.StopAnimating();
                    //loader.Hidden = true;
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

            DropBoxCollectionView.ReloadData();
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
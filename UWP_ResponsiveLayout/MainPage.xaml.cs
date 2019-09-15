using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;
using FFmpegInterop;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.Media.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_ResponsiveLayout
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private FFmpegInteropMSS FFmpegMSS;

        private async void LoadMediaFile(object sender, TappedRoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.VideosLibrary;

            picker.FileTypeFilter.Add(".mp4");
            picker.FileTypeFilter.Add(".avi");
            picker.FileTypeFilter.Add(".fla");
            picker.FileTypeFilter.Add(".fvl");
            picker.FileTypeFilter.Add(".mpeg");
            picker.FileTypeFilter.Add(".mpeg2");
            picker.FileTypeFilter.Add(".3gp");
            picker.FileTypeFilter.Add(".mpg");
            picker.FileTypeFilter.Add(".mov");
            picker.FileTypeFilter.Add(".rmvb");
            picker.FileTypeFilter.Add(".vob");
            picker.FileTypeFilter.Add(".vmw");
            picker.FileTypeFilter.Add(".webm");

            StorageFile file = await picker.PickSingleFileAsync();

            if (file != null)
            {
                if (mediaPlayer.CanPause == true)
                    try
                    {
                        mediaPlayer.Pause();
                    }
                    catch (Exception)
                    {

                    }
            }
            else
            {
                try
                {
                    mediaPlayer.Stop();
                }
                catch (Exception)
                {

                }
            }

            IRandomAccessStream readStream = await file.OpenAsync(FileAccessMode.Read);

            try
            {
                FFmpegMSS = FFmpegInteropMSS.CreateFFmpegInteropMSSFromStream(readStream, true, true);
                MediaStreamSource mss = FFmpegMSS.GetMediaStreamSource();

                if (mss != null)
                {
                    mediaPlayer.AreTransportControlsEnabled = true;

                    mediaPlayer.TransportControls.IsFastForwardButtonVisible = true;
                    mediaPlayer.TransportControls.IsFastForwardEnabled = true;
                    mediaPlayer.TransportControls.IsFastRewindButtonVisible = true;
                    mediaPlayer.TransportControls.IsFastRewindEnabled = true;
                    mediaPlayer.TransportControls.IsNextTrackButtonVisible = true;
                    mediaPlayer.TransportControls.IsPreviousTrackButtonVisible = true;
                    mediaPlayer.TransportControls.IsPlaybackRateButtonVisible = true;
                    mediaPlayer.TransportControls.IsPlaybackRateEnabled = true;
                    mediaPlayer.TransportControls.IsSkipBackwardButtonVisible = true;
                    mediaPlayer.TransportControls.IsSkipBackwardEnabled = true;
                    mediaPlayer.TransportControls.IsSkipForwardButtonVisible = true;
                    mediaPlayer.TransportControls.IsSkipForwardEnabled = true;
                    mediaPlayer.TransportControls.IsStopButtonVisible = true;
                    mediaPlayer.TransportControls.IsStopEnabled = true;
                    mediaPlayer.TransportControls.IsRightTapEnabled = true;

                    mediaPlayer.SetMediaStreamSource(mss);
                    mediaPlayer.Play();
                }
                else
                {
                    var msg = new MessageDialog("Error");
                    await msg.ShowAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

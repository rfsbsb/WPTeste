﻿using App1.Model;
using App1.ViewModel;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.
            ObterDados();
            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void ObterDados() {
          BaseVM basevm = new BaseVM();
          await basevm.GetListaLivros();
          this.listaLivros.Source = basevm.listaLivros;
        }

        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
          Frame.Navigate(typeof(Pesquisar));

        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
          Livro livro = ((Livro)e.ClickedItem);
          Frame.Navigate(typeof(ExibeLivro), livro.Codigo);
        }
    }
}

using App1.Model;
using App1.ViewModel;
using System;
using System.Diagnostics;
using System.Text;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;
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

        private async void CriarTile() {
            var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150ImageCollection);

            XmlNodeList tileImageAttributes = tileXml.GetElementsByTagName("image");

            BaseVM basevm = new BaseVM();
            int numItens = Convert.ToInt32(ApplicationData.Current.LocalSettings.Values["numItems"]);
            await basevm.GetListaLivrosAleatorios();

            int index = 0;
            foreach (var item in basevm.listaLivros)
            {
                if (index <= numItens-1)
                {
                    ((XmlElement)tileImageAttributes[index]).SetAttribute("src", item.Capas[0]);
                }

                index++;
            }

            var tileNotification = new TileNotification(tileXml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
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
            //toda vez que carregar os livros, atualiza o Live Tile
            this.CriarTile();
            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void ObterDados() {
          if (this.listaLivros.Source == null) {
            BaseVM basevm = new BaseVM();
            await basevm.GetListaLivros();
            this.listaLivros.Source = basevm.listaLivros;
          }
        }

        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
          Frame.Navigate(typeof(Pesquisar));
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
          Livro livro = ((Livro)e.ClickedItem);
          Frame.Navigate(typeof(ExibeLivro), livro.Codigo);
        }

        private void AppBarButton_Config_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Configuracoes));
        }
    }
}

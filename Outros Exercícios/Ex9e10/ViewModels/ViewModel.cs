using Ex9e10.Models;

namespace Ex9e10.ViewModels
{
    public class ViewModel : BaseViewModel
    {
        public delegate void MethodWithString(string str);
        public event MethodWithString OpenInBrowser;

        public Model Model { get; init; }

        private Canal selectedCanal;
        public Canal SelectedCanal
        {
            get => selectedCanal;
            set
            {
                selectedCanal = value;
                OnPropertyChanged(nameof(SelectedCanal));
            }
        }

        private Noticia selectedNoticia;
        public Noticia SelectedNoticia
        {
            get => selectedNoticia;
            set
            {
                selectedNoticia = value;
                OnPropertyChanged(nameof(SelectedNoticia));
            }
        }

        public ViewModel()
        {
            Model = new Model();
            /*Model.AdicionarCanal("http://side.utad.pt/rss.pl?INF");
            Model.AdicionarCanal("http://side.utad.pt/rss.pl?TIC");
            Model.AdicionarCanal("http://side.utad.pt/rss.pl?CMU");*/
            Model.AdicionarCanal("http://feeds.jn.pt/JN-ULTIMAS");
        }

        public void ShowNoticia()
        {
            if (SelectedNoticia != null)
            {
                OpenInBrowser?.Invoke(SelectedNoticia.Link);
            }
        }
    }
}

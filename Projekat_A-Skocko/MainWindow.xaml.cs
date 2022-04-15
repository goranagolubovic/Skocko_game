using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
namespace Projekat_A_Skocko
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private string nextMusicPicture = "mute.png";
    private string previousMusicPicture = "";
    private string currentMusicPicture = "volume.png";
    static System.Media.SoundPlayer player;
    public MainWindow()
    {
      InitializeComponent();
      player = new System.Media.SoundPlayer(ConfigurationManager.AppSettings.Get("SONG_PATH"));
      player.Load();
      player.Play();
    }

    private void startGame(object sender, RoutedEventArgs e)
    {
      GameWindow window = new GameWindow();
      this.Hide();
      window.Show();
    }
    private void control_Music(object sender, MouseButtonEventArgs e)
    {
      ImageBrush brush = new ImageBrush();
      brush.ImageSource = new BitmapImage(new Uri(ConfigurationManager.AppSettings.Get("IMG_FOLDER") + nextMusicPicture, UriKind.Relative));
      previousMusicPicture = currentMusicPicture;
      currentMusicPicture = nextMusicPicture;
      nextMusicPicture = previousMusicPicture;
      musicCanvas.Background = brush;
      if (currentMusicPicture.Equals("volume.png"))
      {
        player.Play();
      }
      else
      {
        player.Stop();
      }
    }
  }
}

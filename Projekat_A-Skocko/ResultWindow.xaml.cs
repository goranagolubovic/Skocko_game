using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;

namespace Projekat_A_Skocko
{
  /// <summary>
  /// Interaction logic for ResultWindow.xaml
  /// </summary>
  public partial class ResultWindow : Window
  {
    private int score;
    public ResultWindow(int score)
    {
      this.score = score;;
      InitializeComponent();
      if (score > 0)
      {
        ImageBrush brush = new ImageBrush();
        brush.ImageSource = new BitmapImage(new Uri(ConfigurationManager.AppSettings.Get("HAPPY_MONKEY_IMG"), UriKind.Relative));
        monkeyCanvas.Background = brush;
        resultBlock.Text = score.ToString();
        resultTextBlock.Text = ConfigurationManager.AppSettings.Get("WIN_TEXT");
      }
      else
      {
        ImageBrush brush = new ImageBrush();
        brush.ImageSource = new BitmapImage(new Uri(ConfigurationManager.AppSettings.Get("CRY_MONKEY_IMG"), UriKind.Relative));
        monkeyCanvas.Background = brush;
        resultTextBlock.Text = ConfigurationManager.AppSettings.Get("LOSE_TEXT");
      }
    }


    private void quitTheGame(object sender, RoutedEventArgs e)
    {
      System.Windows.Application.Current.Shutdown();
    }

    private void playAgain(object sender, RoutedEventArgs e)
    {
      Window window = new GameWindow();
      this.Close();
      window.Show();
    }
  }
}

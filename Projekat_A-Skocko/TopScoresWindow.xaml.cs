using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
  /// Interaction logic for TopScoresWindow.xaml
  /// </summary>
  public partial class TopScoresWindow : Window
  {
    private Window previousWindow;
    public TopScoresWindow(Window previousWindow)
    {
      this.previousWindow = previousWindow;
      InitializeComponent();
      List<int> scores =
        File.ReadAllLines(ConfigurationManager.AppSettings.Get("SCORE_FILE")).ToList().ConvertAll(elem=>Convert.ToInt32(elem)).OrderByDescending(elem => elem).Distinct().ToList();
      TextBlock[] texts =
      {
        score1,score2,score3,score4,score5
      };
      for(int i = 0; i < 5; i++)
      {
        texts[i].Text = scores.ElementAt(i).ToString();
      }
    }

    private void back(object sender, RoutedEventArgs e)
    {
      this.Hide();
      previousWindow.Show();
    }

    private void quitTheGame(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}

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
      this.score = score;
      InitializeComponent();
      if(score>0)
      resultTextBlock.Text = "Congratulations! You found the winning combination.Your score is " + score;
      else
        resultTextBlock.Text = "You lost all your chance.Your score is " + score;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }
  }
}

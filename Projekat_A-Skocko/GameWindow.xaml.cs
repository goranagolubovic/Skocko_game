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
using System.Windows.Threading;

namespace Projekat_A_Skocko
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class GameWindow : Window
  {
    private bool isRowFilled = false;
    private string[] arraysOfSymbols = { "monkey", "banana", "giraffe", "lion", "jungle" };
    private int currentRow = 0;
    private int correctItems = 0;
    private int wrongPlaceItems = 0;
    private int score = 120;
    private int resultWindowScore = 120;
    private int numberOfGrid1rectanglesFilled = 0;
    public List<Tuple<string, int>> repeativeItems
    {
      get;
      set;
    }
    private IDictionary<int, string> rowFilled;
    private IDictionary<int, string> itemsNotPositionedWell;
    public List<Tuple<string, int>> result
    {
      get;
      set;
    }
    private DateTime startTime;
    private DispatcherTimer dtimer;
    public GameWindow()
    {
      repeativeItems = new List<Tuple<string, int>>();
      rowFilled = new Dictionary<int, string>();
      itemsNotPositionedWell = new Dictionary<int, string>();
      result = new List<Tuple<string, int>>();
      /*result.Add(new Tuple<string,int>("monkey", 0));
      result.Add(new Tuple<string, int>("jungle", 1));
      result.Add(new Tuple<string, int>("banana", 2));
      result.Add(new Tuple<string, int>("giraffe", 3));*/
      dtimer = new DispatcherTimer();
      dtimer.Interval = TimeSpan.FromSeconds(1);
      dtimer.Tick += Timer_Tick;
      dtimer.Start();
      startTime = DateTime.Now;
      InitializeComponent();
      generateResult();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
      string time = (DateTime.Now - startTime).ToString().Substring(0, 8);
      timerTextBlock.Text =time;
    }
    private void generateResult()
    {
      Random random = new Random();
      for (int i = 0; i < grid1.ColumnDefinitions.Count; i++)
      {
        result.Add(new Tuple<string, int>(arraysOfSymbols[random.Next(arraysOfSymbols.Length)], i));
      }
      MessageBox.Show(string.Join(", ", result));
    }
    private Tuple<Rectangle, int> findNotFilledRectangle()
    {
      Tuple<Rectangle, int> tuple;
      for (int i = 0; i < grid1.RowDefinitions.Count; i++)
      {
        for (int j = 0; j < grid1.ColumnDefinitions.Count; j++)
        {
          Rectangle element = this.GetElementInGridPosition(j, i);
          if (!(element.Fill is ImageBrush))
          {
            tuple = new Tuple<Rectangle, int>(element, j);
            if (j == grid1.ColumnDefinitions.Count - 1)
            {
              isRowFilled = true;
            }
            numberOfGrid1rectanglesFilled++;
            return tuple;
          }
        }
      }
      return null;
    }
    private void monkey_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (numberOfGrid1rectanglesFilled == grid1.ColumnDefinitions.Count*grid1.RowDefinitions.Count)
      {
        return;
      }
      Tuple<Rectangle, int> tuple = findNotFilledRectangle();
      Rectangle element = tuple.Item1;
      int position = tuple.Item2;
      ImageBrush imgBrush = new ImageBrush();
      imgBrush.ImageSource = new BitmapImage(new Uri(ConfigurationManager.AppSettings.Get("MONKEY_IMG"), UriKind.Relative));
      element.Fill = imgBrush;
      rowFilled.Add(new KeyValuePair<int, string>(position, "monkey"));
      if (isRowFilled)
      {
        isRowFilled = false;
        fillGrid2(currentRow);
      }
    }

    private Rectangle GetElementInGridPosition(int column, int row)
    {
      foreach (Rectangle element in this.grid1.Children)
      {
        if (Grid.GetColumn(element) == column && Grid.GetRow(element) == row)
          return element;
      }

      return null;
    }

    private void banana_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (numberOfGrid1rectanglesFilled == grid1.ColumnDefinitions.Count * grid1.RowDefinitions.Count)
      {
        return;
      }
      Tuple<Rectangle, int> tuple = findNotFilledRectangle();
      Rectangle element = tuple.Item1;
      int position = tuple.Item2;
      ImageBrush imgBrush = new ImageBrush();
      imgBrush.ImageSource = new BitmapImage(new Uri(ConfigurationManager.AppSettings.Get("BANANA_IMG"), UriKind.Relative));
      element.Fill = imgBrush;
      rowFilled.Add(new KeyValuePair<int, string>(position, "banana"));
      if (isRowFilled)
      {
        isRowFilled = false;
        fillGrid2(currentRow);
      }
    }

    private void giraffe_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (numberOfGrid1rectanglesFilled == grid1.ColumnDefinitions.Count * grid1.RowDefinitions.Count)
      {
        return;
      }
      Tuple<Rectangle, int> tuple = findNotFilledRectangle();
      Rectangle element = tuple.Item1;
      int position = tuple.Item2;
      ImageBrush imgBrush = new ImageBrush();
      imgBrush.ImageSource = new BitmapImage(new Uri(ConfigurationManager.AppSettings.Get("GIRAFFE_IMG"), UriKind.Relative));
      element.Fill = imgBrush;
      rowFilled.Add(new KeyValuePair<int, string>(position, "giraffe"));
      if (isRowFilled)
      {
        isRowFilled = false;
        fillGrid2(currentRow);
      }
    }

    private void lion_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (numberOfGrid1rectanglesFilled == grid1.ColumnDefinitions.Count * grid1.RowDefinitions.Count)
      {
        return;
      }
      Tuple<Rectangle, int> tuple = findNotFilledRectangle();
      Rectangle element = tuple.Item1;
      int position = tuple.Item2;
      ImageBrush imgBrush = new ImageBrush();
      imgBrush.ImageSource = new BitmapImage(new Uri(ConfigurationManager.AppSettings.Get("LION_IMG"), UriKind.Relative));
      element.Fill = imgBrush;
      rowFilled.Add(new KeyValuePair<int, string>(position, "lion"));
      if (isRowFilled)
      {
        isRowFilled = false;
        fillGrid2(currentRow);
      }
    }

    private void jungle_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (numberOfGrid1rectanglesFilled == grid1.ColumnDefinitions.Count * grid1.RowDefinitions.Count)
      {
        return;
      }
      Tuple<Rectangle, int> tuple = findNotFilledRectangle();
      Rectangle element = tuple.Item1;
      int position = tuple.Item2;
      ImageBrush imgBrush = new ImageBrush();
      imgBrush.ImageSource = new BitmapImage(new Uri(ConfigurationManager.AppSettings.Get("JUNGLE_IMG"), UriKind.Relative));
      element.Fill = imgBrush;
      rowFilled.Add(new KeyValuePair<int, string>(position, "jungle"));
      if (isRowFilled)
      {
        isRowFilled = false;
        fillGrid2(currentRow);
      }
    }
    private void fillGrid2(int row)
    {
      Canvas[] arrows = { arrowRow1, arrowRow2, arrowRow3, arrowRow4, arrowRow5, arrowRow6 };
      arrows[currentRow].Visibility = Visibility.Hidden;
      foreach (KeyValuePair<int, string> elem in rowFilled)
      {
        itemsNotPositionedWell.Add(elem);
      }
      Rectangle rectangleForColoring = null;
      foreach (KeyValuePair<int, string> elem in rowFilled)
      {
        int i = elem.Key;
        if (elem.Value.Equals(result[i].Item1) && elem.Key == result[i].Item2)
        {
          Tuple<string, int> tuple = new Tuple<string, int>(elem.Value, i);
          repeativeItems.Add(tuple);
          itemsNotPositionedWell.Remove(new KeyValuePair<int, string>(i, elem.Value));
          correctItems++;
        }
      }
      foreach (KeyValuePair<int, string> elem in itemsNotPositionedWell)
      {
        for (int i = 0; i < grid2.ColumnDefinitions.Count; i++) { 
        Tuple<string, int> tuple = new Tuple<string, int>(elem.Value, i);
        bool isItemAlreadyCounted = repeativeItems.Contains(tuple);
        if (!isItemAlreadyCounted && result.Contains(tuple))
        {

          repeativeItems.Add(tuple);
          wrongPlaceItems++;
            break;
        }
      }
      }
      foreach (Rectangle element in this.grid2.Children)
      {
        for (int c1 = 0; c1 < correctItems; c1++)
        {
          if (Grid.GetRow(element) == row && Grid.GetColumn(element) == c1)
          {
            rectangleForColoring = element;
            ImageBrush imgBrush = new ImageBrush();

            imgBrush.ImageSource = new BitmapImage(new Uri(ConfigurationManager.AppSettings.Get("OK_IMG"), UriKind.Relative));
            rectangleForColoring.Fill = imgBrush;
          }
        }
        for (int c2 = correctItems; c2 < (wrongPlaceItems + correctItems); c2++)
        {
          if (Grid.GetRow(element) == row && Grid.GetColumn(element) == c2)
          {
            rectangleForColoring = element;
            ImageBrush imgBrush = new ImageBrush();

            imgBrush.ImageSource = new BitmapImage(new Uri(ConfigurationManager.AppSettings.Get("NOT_IMG"), UriKind.Relative));
            rectangleForColoring.Fill = imgBrush;
          }
        }
      }
      rowFilled.Clear();
      repeativeItems.Clear();
      currentRow++;
      resultWindowScore = score;

      if (currentRow < grid1.RowDefinitions.Count - 1)
        arrows[currentRow].Visibility = Visibility.Visible;

      itemsNotPositionedWell.Clear();
      if (correctItems == grid1.ColumnDefinitions.Count)
      {
        dtimer.Stop();
        int hoursOfPlaying = Convert.ToInt32(timerTextBlock.Text.Substring(0, 2));
        int minutesOfPlaying = Convert.ToInt32(timerTextBlock.Text.Substring(3, 2));
        int secondsOfPlaying = Convert.ToInt32(timerTextBlock.Text.Substring(6, 2));
        int timeOfPlaying = hoursOfPlaying * 3600 + minutesOfPlaying * 60 + secondsOfPlaying;
        double totallyScore = (double)score / (double)timeOfPlaying * 100;
        resultWindowScore = Convert.ToInt32(totallyScore);
        var timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        timer.Start();
        timer.Tick += (sender, args) =>
        {
          timer.Stop();
          Window window = new ResultWindow(resultWindowScore);
          this.Hide();
          window.Show();
        };
      }
      else if (currentRow == grid1.RowDefinitions.Count)
      {
        score -= 20;
        dtimer.Stop();
        int hoursOfPlaying = Convert.ToInt32(timerTextBlock.Text.Substring(0, 2));
        int minutesOfPlaying = Convert.ToInt32(timerTextBlock.Text.Substring(3, 2));
        int secondsOfPlaying = Convert.ToInt32(timerTextBlock.Text.Substring(6, 2));
        int timeOfPlaying = hoursOfPlaying * 3600 + minutesOfPlaying * 60 + secondsOfPlaying;
        double totallyScore = (double)score / (double)timeOfPlaying * 100;
        resultWindowScore = Convert.ToInt32(totallyScore);
        var timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        timer.Start();
        timer.Tick += (sender, args) =>
        {
          timer.Stop();
          Window window = new ResultWindow(resultWindowScore);
          this.Close();
          window.Show();
        };
      }
      if (correctItems == 4)
      {
        return;
      }
      score -= 20;
      wrongPlaceItems = 0;
      correctItems = 0;
    }

    private void deleteImage(object sender, MouseButtonEventArgs e)
    {
      Rectangle rectangle =(Rectangle) e.Source;
      if (currentRow != (int)rectangle.GetValue(Grid.RowProperty))
      {
        return;
      }
        string item = "";
      foreach(KeyValuePair<int,string> elem in rowFilled)
      {
        if(elem.Key== (int)rectangle.GetValue(Grid.ColumnProperty))
        {
          item = elem.Value;
          break;
        }
      }
      rowFilled.Remove(new KeyValuePair<int, string>((int)rectangle.GetValue(Grid.ColumnProperty), item));
      rectangle.Fill= new SolidColorBrush(Color.FromRgb(212, 150, 91));
      numberOfGrid1rectanglesFilled--;
    }
  }
}

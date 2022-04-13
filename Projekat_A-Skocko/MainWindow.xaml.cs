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

namespace Projekat_A_Skocko
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private bool isRowFilled = false;
    private string[] arraysOfSymbols = { "monkey", "banana", "giraffe", "lion", "jungle" };
    private int currentRow = 0;
    private int correctItems = 0;
    private int wrongPlaceItems = 0;
    private int score = 120;
    private string nextMusicPicture = "mute.png";
    private string previousMusicPicture = "";
    private string currentMusicPicture = "volume.png";
    private String path = "C:\\Users\\goran\\Desktop\\Projekat_A-Skocko\\Projekat_A-Skocko\\song.wav";
    public List<Tuple<string, int>> repeativeItems
    {
      get;
      set;
    }
    public List<Tuple<string, int>> rowFilled
    {
      get;
      set;
    }
    public List<Tuple<string, int>> result
    {
      get;
      set;
    }
    System.Media.SoundPlayer player;
    public MainWindow()
    {
      repeativeItems = new List<Tuple<string, int>>();
      rowFilled = new List<Tuple<string, int>>();
      result = new List<Tuple<string, int>>();
      generateResult();
      InitializeComponent();
      player =  new System.Media.SoundPlayer(path);
      player.Load();
      player.Play();

    }
    private void generateResult()
    {
      Random random = new Random();
      for (int i = 0; i < 4; i++)
      {
        result.Add(new Tuple<string, int>(arraysOfSymbols[random.Next(arraysOfSymbols.Length)], i));
      }
      MessageBox.Show(string.Join(", ", result));
    }
    private Tuple<Rectangle, int> findNotFilledRectangle()
    {
      Tuple<Rectangle, int> tuple;
      for (int i = 0; i < 6; i++)
      {
        for (int j = 0; j < 4; j++)
        {
          Rectangle element = this.GetElementInGridPosition(j, i);
          if (!(element.Fill is ImageBrush))
          {
            tuple = new Tuple<Rectangle, int>(element, j);
            if (j == 3)
            {
              isRowFilled = true;
            }
            return tuple;
          }
        }
      }
      return null;
    }
    private void monkey_MouseDown(object sender, MouseButtonEventArgs e)
    {
      Tuple<Rectangle, int> tuple = findNotFilledRectangle();
      Rectangle element = tuple.Item1;
      int position = tuple.Item2;
      ImageBrush imgBrush = new ImageBrush();
      imgBrush.ImageSource = new BitmapImage(new Uri("C:\\Users\\goran\\Desktop\\Projekat_A-Skocko\\Projekat_A-Skocko\\images\\monkey.png", UriKind.Relative));
      element.Fill = imgBrush;
      rowFilled.Add(new Tuple<string, int>("monkey", position));
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
      Tuple<Rectangle, int> tuple = findNotFilledRectangle();
      Rectangle element = tuple.Item1;
      int position = tuple.Item2;
      ImageBrush imgBrush = new ImageBrush();
      imgBrush.ImageSource = new BitmapImage(new Uri("C:\\Users\\goran\\Desktop\\Projekat_A-Skocko\\Projekat_A-Skocko\\images\\banana.png", UriKind.Relative));
      element.Fill = imgBrush;
      rowFilled.Add(new Tuple<string, int>("banana", position));
      if (isRowFilled)
      {
        isRowFilled = false;
        fillGrid2(currentRow);
      }
    }

    private void giraffe_MouseDown(object sender, MouseButtonEventArgs e)
    {
      Tuple<Rectangle, int> tuple = findNotFilledRectangle();
      Rectangle element = tuple.Item1;
      int position = tuple.Item2;
      ImageBrush imgBrush = new ImageBrush();
      imgBrush.ImageSource = new BitmapImage(new Uri("C:\\Users\\goran\\Desktop\\Projekat_A-Skocko\\Projekat_A-Skocko\\images\\giraffe.png", UriKind.Relative));
      element.Fill = imgBrush;
      rowFilled.Add(new Tuple<string, int>("giraffe", position));
      if (isRowFilled)
      {
        isRowFilled = false;
        fillGrid2(currentRow);
      }
    }

    private void lion_MouseDown(object sender, MouseButtonEventArgs e)
    {
      Tuple<Rectangle, int> tuple = findNotFilledRectangle();
      Rectangle element = tuple.Item1;
      int position = tuple.Item2;
      ImageBrush imgBrush = new ImageBrush();
      imgBrush.ImageSource = new BitmapImage(new Uri("C:\\Users\\goran\\Desktop\\Projekat_A-Skocko\\Projekat_A-Skocko\\images\\lion.png", UriKind.Relative));
      element.Fill = imgBrush;
      rowFilled.Add(new Tuple<string, int>("lion", position));
      if (isRowFilled)
      {
        isRowFilled = false;
        fillGrid2(currentRow);
      }
    }

    private void jungle_MouseDown(object sender, MouseButtonEventArgs e)
    {
      Tuple<Rectangle, int> tuple = findNotFilledRectangle();
      Rectangle element = tuple.Item1;
      int position = tuple.Item2;
      ImageBrush imgBrush = new ImageBrush();
      imgBrush.ImageSource = new BitmapImage(new Uri("C:\\Users\\goran\\Desktop\\Projekat_A-Skocko\\Projekat_A-Skocko\\images\\jungle.png", UriKind.Relative));
      element.Fill = imgBrush;
      rowFilled.Add(new Tuple<string, int>("jungle", position));
      if (isRowFilled)
      {
        isRowFilled = false;
        fillGrid2(currentRow);
      }
    }
    private void fillGrid2(int row)
    {
      Rectangle rectangleForColoring = null;
      for (int i = 0; i < 4; i++)
      {
        if (rowFilled[i].Item1.Equals(result[i].Item1) && rowFilled[i].Item2 == result[i].Item2)
        {
          correctItems++;
        }
      }
      for (int j = 0; j < 4; j++)
      {
        for (int k = 0; k < 4; k++)
        {
          Tuple<string, int> tuple = new Tuple<string, int>(rowFilled[j].Item1, k);
          bool isItemAlreadyCounted = repeativeItems.Contains(tuple);
          if (!isItemAlreadyCounted && result.Contains(tuple) && !(rowFilled[k].Item1.Equals(result[k].Item1) && rowFilled[k].Item2 == result[k].Item2))
          { 
            repeativeItems.Add(tuple);
            wrongPlaceItems++;
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

            imgBrush.ImageSource = new BitmapImage(new Uri("C:\\Users\\goran\\Desktop\\Projekat_A-Skocko\\Projekat_A-Skocko\\images\\OK.png", UriKind.Relative));
            rectangleForColoring.Fill = imgBrush;
          }
        }
        for (int c2 = correctItems; c2 < (wrongPlaceItems+correctItems); c2++)
        {
          if (Grid.GetRow(element) == row && Grid.GetColumn(element) == c2)
          {
            rectangleForColoring = element;
            ImageBrush imgBrush = new ImageBrush();

            imgBrush.ImageSource = new BitmapImage(new Uri("C:\\Users\\goran\\Desktop\\Projekat_A-Skocko\\Projekat_A-Skocko\\images\\NOT.png", UriKind.Relative));
            rectangleForColoring.Fill = imgBrush;
          }
        }
      }
      if (correctItems == 4)
      {
        var timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
        timer.Start();
        timer.Tick += (sender, args) =>
        {
          timer.Stop();
          Window window = new ResultWindow(score);
          this.Hide();
          window.Show();
        };
      }
      rowFilled.Clear();
      repeativeItems.Clear();
      currentRow++;
      if (currentRow == 6)
      {
        var timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
        timer.Start();
        timer.Tick += (sender, args) =>
        {
          timer.Stop();
          Window window = new ResultWindow(score);
          this.Hide();
          window.Show();
        };
      }
      score -= 20;
      wrongPlaceItems = 0;
      correctItems = 0;
    }

    private void control_Music(object sender, MouseButtonEventArgs e)
    {
      ImageBrush brush = new ImageBrush();
      brush.ImageSource= new BitmapImage(new Uri("C:\\Users\\goran\\Desktop\\Projekat_A-Skocko\\Projekat_A-Skocko\\images\\"+nextMusicPicture, UriKind.Relative));
      previousMusicPicture = currentMusicPicture;
      currentMusicPicture = nextMusicPicture;
      nextMusicPicture = previousMusicPicture;
      musicCanvas.Background = brush;
      if (currentMusicPicture.Equals("volume.png"))
      {
        player.Load();
        player.Play();
      }
      else
      {
        player.Stop();
      }
    }
  }
}

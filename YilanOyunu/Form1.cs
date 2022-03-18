using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YilanOyunu
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Çok kolay");
            comboBox1.Items.Add("Kolay");
            comboBox1.Items.Add("Orta");
            comboBox1.Items.Add("Zor");
            comboBox1.Items.Add("Çok zor");
            comboBox1.Items.Add("İmkansız");
            comboBox1.SelectedIndex = 2;//başlangıçta kolay seçilmiş olsun.
        }
        private const Keys up = Keys.Up;//basılan tuşun ne olduğunu algılamamız için tanımladık.
        private const Keys right = Keys.Right;
        private const Keys down = Keys.Down;
        private const Keys left = Keys.Left;

        private int posX;//yılanın pozisyonunu sakla
        private int posY;
        private const int xMax = 69;//panelin sınırlarını belirliyor.
        private const int xMin = 0;
        private const int yMax = 46;
        private const int yMin = 0;

        private bool lastKeyProcessed = true;// herhangi bir tuşa basıldıktan sonra o yöne en az bir defa gidilip gidilmediğini tutuyor.
        private int multiplier = 11;//ikinci bölümdeki posX, xMax gibi değişkenleri piksel cinsinden ifade edebilmek için kullandığımız çarpan.
        private int gamePoint = 0;//oyun puanının tutulduğu değişken.
        private DirectionEnum direction;// yılanın o anda hangi yöne gittiğinin tutulduğu değişken.
        private Point bait;//yemin bulunduğu pozisyon.
        private List<Point> snakePosition = new List<Point>();//yılanın hangi karelerde olduğunu tutan liste.


        public enum DirectionEnum// DirectionEnum isminde yönleri belirten bir enum yazmış olduk.
        {
            Undefined,
            Up,
            Right,
            Down,
            Left
        }
        private void drawSnake()//ekrana yılanı çizdirdi
        {
            GameArea.Refresh();//paneli temizledi
            drawBait();// metodu çağırıyor ve metod yemi çiziyor.
            foreach (Point item in snakePosition)//snakePosition değişkeninde yılanın bulunduğu her bir karenin değeri mevcut.
            {//bu her değeri tek tek foreachle donduruyoruz.
                int xVal = item.X * multiplier;//multiplier ile çarparak gerçek piksel değerlerini elde ediyoruz
                int yVal = item.Y * multiplier;  
                drawPoint(xVal, yVal); //drawPoint ile bu pikseller üzerinde bir kutu çizdiriyoruz. 
                //snakePosition içerisindeki tüm değerler için bu işi yaptığımızda ekranda yılan görünür oluyor.
              
            }
        }

        private void drawPoint(int x, int y, bool isBlack = true)//ekrana sadece bir kutu çiziyor.
        {
            using (Graphics g = this.GameArea.CreateGraphics())//panelin kullanılması gerektiği belirtiliyor.
            {
                Color penColor = isBlack ? Color.Black : Color.Red;//kutunun hangi renk olacağına karar veriyor
                Pen pen = new Pen(penColor, 5);
                g.DrawRectangle(pen, x, y, 5, 5);// gameArea üzerine x-y koordinatlarında eni ve boyu 5px olan bir kutu çiziyor.
                pen.Dispose();
            }
        }

        private void drawBait()//yem çiz
        {
            drawPoint(bait.X, bait.Y, false);
        }
        private void setGameSpeed()//yılanın ne kadar hızlı hareket edeceğini belirliyor.
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    GameTimer.Interval = 100;
                    break;
                case 1:
                    GameTimer.Interval = 75;
                    break;
                case 2:
                default:
                    GameTimer.Interval = 50;
                    break;
                case 3:
                    GameTimer.Interval = 40;
                    break;
                case 4:
                    GameTimer.Interval = 25;
                    break;
                case 5:
                    GameTimer.Interval = 10;
                    break;
            }

        }
        private void resetVariables()//değerler sıfırlanıyor.
        {
            posX = 12;
            posY = 20;
            gamePoint = 0;
            direction = DirectionEnum.Right;
            printStat();
        }
        private void printStat()//skor ve ne kadar yediğini gösteriyor.
        {
            scoreLabel.Text = gamePoint.ToString();
            baitLabel.Text = (snakePosition.Count - 3).ToString();
        }
      
        private void createNewSnake()
        {
            snakePosition.Clear();
            snakePosition.Add(new Point(12, 20));
            snakePosition.Add(new Point(11, 20));
            snakePosition.Add(new Point(10, 20));
        }
        private void setPositionValues()//yılanın gideceği yöndeki pozisyon değerini setliyor.
        {
            switch (direction)
            {
                case DirectionEnum.Down:
                    posY++;
                    break;
                case DirectionEnum.Up:
                    posY--;
                    break;
                case DirectionEnum.Left:
                    posX--;
                    break;
                case DirectionEnum.Right:
                default:
                    posX++;
                    break;
            }
        }
        private bool isGameOver()//oyunun bitip bitmediğini kontrol eden
        {
           
            if (snakePosition.Any(t => t.X == posX && t.Y == posY))
            {
                return true;
            }

            return false;
        }
        private void createBait()// yeni yem oluşturan metot
        {
            Random random = new Random(DateTime.Now.TimeOfDay.Milliseconds);
            int x = 0;
            int y = 0;
            bool contains = true;

            while (contains)
            {
                x = random.Next(xMin, xMax + 1) * multiplier;
                y = random.Next(yMin, yMax + 1) * multiplier;

                contains = snakePosition.Any(t => t.X == x && t.Y == y);
            }

            bait = new Point(x, y);
        }
        private void eatBait()//yılanın en son noktsından yılana bir tane daha ekleniyor.
        {
            Point lastPoint = snakePosition[snakePosition.Count - 1];
            snakePosition.Add(new Point(lastPoint.X, lastPoint.Y));
            gamePoint += (comboBox1.SelectedIndex + 1) * 10;
            printStat();
            createBait();
        }
        private void determineDirection(Keys keyData)
            /*yılanın yönüne karar veriliyor. case’ler içerisindeki if blokları ise tersine gidiş olmasın diye konuldu.
           Yani eğer yılan aşağı doğru giderken yukarı butonuna basarsanız bu tuş yoksayılacaktır. */
        {
            switch (keyData)
            {
                case up:
                    if (direction != DirectionEnum.Down)
                        direction = DirectionEnum.Up;
                    break;
                case down:
                    if (direction != DirectionEnum.Up)
                        direction = DirectionEnum.Down;
                    break;
                case left:
                    if (direction != DirectionEnum.Right)
                        direction = DirectionEnum.Left;
                    break;
                case right:
                default:
                    if (direction != DirectionEnum.Left)
                        direction = DirectionEnum.Right;
                    break;
            }
        }
        private void startGame()
        {
            comboBox1.Enabled = false;
            button1.Enabled = false;
            setGameSpeed();
            GameTimer.Enabled = true;
        }

        private void playGame()
        {
            setPositionValues();
            bool isGameEnded = isGameOver();

            if (isGameEnded)
            {
                GameTimer.Enabled = false;
                MessageBox.Show(String.Format("Oyun Bitti! Puanınız: {0}", gamePoint),
        "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (posY > yMax)
                posY = yMin;
            else if (posY < yMin)
                posY = yMax;

            if (posX > xMax)
                posX = xMin;
            else if (posX < xMin)
                posX = xMax;

            snakePosition.Insert(0, new Point(posX, posY));
            snakePosition.RemoveAt(snakePosition.Count - 1);

            if (bait.X == posX * multiplier && bait.Y == posY * multiplier)
            {
                eatBait();
            }

            drawSnake();
            lastKeyProcessed = true;
        }

        private void resetGame()
        {
            GameTimer.Enabled = false;
            button1.Enabled = true;
            comboBox1.Enabled = true;

            createNewSnake();
            resetVariables();
            createBait();
            drawSnake();
        }

        private void pauseGame(Keys keyData)//basılan tuş P ise Timer durdurulur veya devam ettirilir.
        {
            if (keyData == Keys.P)
            {
                GameTimer.Enabled = !GameTimer.Enabled;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetGame();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            playGame();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
           /* if kontrolünde yılanın şu anda hareket edip etmediği, son basılan tuş için en az bir hareket gerçekleştiğinin ve basılan
                tuşun P olmadığının kontrolü yapılıyor.Eğer yılan hareket ediyorsa, son basılan tuş için en az bir hareket yapılmışsa
                ve basılan tuş P değilse, yeni hareket için öncelikle lastKeyProcessed değişkeni false yapılıyor(yeni bir tuşa 
                basıldı anlamında), ardından da determineDirection metodu çağrılarak yılanın yeni pozisyonu belirleniyor.
                pauseGame metodu ise P tuşuna basılmışsa oyunu durdurmaya/ devam ettirmeye yarıyor. Son satırdaki kod ise, 
                metodu override ettiğimiz için, asıl kod bloğunun çalışmasını sağlıyor.*/
            if (GameTimer.Enabled && lastKeyProcessed && keyData != Keys.P)
            {
                lastKeyProcessed = false;
                determineDirection(keyData);
            }

            pauseGame(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

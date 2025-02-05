using Iot.Device.Ws28xx.Esp32;
using System.Drawing;
using System.Threading;

namespace ESP32S3_RGBLED
{
    public class Program
    {
        public static void Main()
        {
            const int count = 1;    //LEDの数　オンボードLEDが対象なので１
            const int ledPin = 48;  //LEDを接続しているGPIO番号

            Color[] rainbow = { Color.Red,          //配列に点灯パターンを登録 
                                Color.Orange, 
                                Color.Yellow, 
                                Color.Green, 
                                Color.DarkCyan, 
                                Color.DarkBlue, 
                                Color.Purple, 
                              };

            //接続しているLEDの型番によって変わります。Ws2812b,Ws2815b,sk6812など
            Ws28xx led = new Ws2812c(ledPin, count);

            BitmapImage img = led.Image;

            while (true)
            {     
                foreach (Color color in rainbow)
                {
                    img.SetPixel(0, 0, color);      //順番に色を設定
                    led.Update();                   //設定した色を反映　アップデートしないと色が変わらない
                    Thread.Sleep(1000);             //1秒待機
                }
            }
        }
    }
}

using Iot.Device.Ws28xx.Esp32;
using System.Drawing;
using System.Threading;

namespace ESP32S3_RGBLED
{
    public class Program
    {
        public static void Main()
        {
            const int count = 1;    //LED�̐��@�I���{�[�hLED���ΏۂȂ̂łP
            const int ledPin = 48;  //LED��ڑ����Ă���GPIO�ԍ�

            Color[] rainbow = { Color.Red,          //�z��ɓ_���p�^�[����o�^ 
                                Color.Orange, 
                                Color.Yellow, 
                                Color.Green, 
                                Color.DarkCyan, 
                                Color.DarkBlue, 
                                Color.Purple, 
                              };

            //�ڑ����Ă���LED�̌^�Ԃɂ���ĕς��܂��BWs2812b,Ws2815b,sk6812�Ȃ�
            Ws28xx led = new Ws2812c(ledPin, count);

            BitmapImage img = led.Image;

            while (true)
            {     
                foreach (Color color in rainbow)
                {
                    img.SetPixel(0, 0, color);      //���ԂɐF��ݒ�
                    led.Update();                   //�ݒ肵���F�𔽉f�@�A�b�v�f�[�g���Ȃ��ƐF���ς��Ȃ�
                    Thread.Sleep(1000);             //1�b�ҋ@
                }
            }
        }
    }
}

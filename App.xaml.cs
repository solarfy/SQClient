using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SQClient
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //代码测试区
            //string str = "imepvJVeJD1oBR49UNOvvaM1c7tKnJW8RycWOyAVDj61+bs89yl2vd6h8DycWcm9srDrPDhM6j3u0SS9JTOxPdmH0r11/2w8/X5nvfXI2jzgnLI8E5dKvRvHjr6DW1c9LfOcPQJ5U72GkNS9pM1WPbAFqL27LsQ85bi4vXhyfj0fA8a7kNkcPuxpmztt8LK8QA9avK+XgDwU4z29hlzRvc5k7D2U3sw9MltWPIyjfzxCl888wPBwvBwMeD2/Nao9fiQPvo8opz1ifpQ9nPJ6Pfh4rj2wkq68y8d3Pf+j5z3y8+M8D5eivISIGDynwpu92ZuCvZdDyD36PPE4/vVAu8iXgjwhaiQ+PZgPPHvKkzyWzSy9m8SePIZLi7zsONS9RhyEPHa1u7pcz5q9jFy5PU1Rgb2pWjG9M3gOPjO5jLyX6oC9D5afvOmusb3kaVi9K8SgPY2/mz32PpK82wLjvMbt3DyR9rk7anAZvnWVqb2y7UA8//Y8PCCyurx2UYe81GcdvXu+Ab5UwdM9TE62vYNMRz04ZeI9FYiuvQguuDw/VjG9+OQGvdBpGbxdWSu8mN5lvWgVPbxZESa9wTWbPS51sr3zYcu85DUgPE9oWz0Hp9o7o0uHvWjqFrtgIeU9kVCvvTtHeT142Re+L9hcPAgZJL3glWY81/VZPfflBL0ExgY8uIy2Pc6kQr72PI68Ys43PP1anr0DaoC88v2kPEQsyL1bKMW9FwmMPYmky7w6jAe+0dKKvR5ulLzDa4w91cC2vQeUsDz6db+9VT/ZPOlKQjtI/VA9j4snPu8GED1S3Xu9DD9hPb4Tsj2WBzQ8GheuPTIlDT4QLcm98QAsuyBS3DzBz6u9i7dlOwv03bz780Y9M0t1vYFNHb1jz2673kuBPVvRbTz+wxo9cIT1vfd7Gr1/Dqa9wKEJvurbKr2Geca9KImKvQIp0j2usZ69w41QPSAhjj0sHRo9y0Mvvb+IMLyPpp87pqAsPdiNAD4wlZ67PRzaPUQoiLzxfyi+";

            //byte[] byteFeatures = Convert.FromBase64String(str);
            //float[] floatFeatures = new float[byteFeatures.Length / 4];

            //for (int i = 0, j = 0; i < byteFeatures.Length; i += 4, j++)
            //{
            //    floatFeatures[j] = BitConverter.ToSingle(byteFeatures, i);
            //}


            //SQClient.Model.AI ai = new Model.AI();
            //ai.Extract(@"C:\Users\Yang\Desktop\REC\test.jpeg");
            //ai.ExtractLocal(@"C:\Users\Yang\Desktop\REC\test.jpeg");
        }
    }
}

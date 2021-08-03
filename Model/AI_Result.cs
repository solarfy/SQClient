using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQClient.Model
{
    class AI_Result
    {
        public string Path;
        public string Type;
        public string Code;
        public string Feature;  //base64

        //Byte数组特征点
        public byte[] ByteFeature 
        {
            get => Convert.FromBase64String(Feature);                       
        }

        //Float数组特征点
        public float[] FloatFeature
        {
            get
            {
                float[] features = new float[ByteFeature.Length / 4];

                for (int i = 0, j = 0; i < ByteFeature.Length; i += 4, j++)
                {
                    features[j] = BitConverter.ToSingle(ByteFeature, i);
                }

                return features;
            }
        }
    }
}

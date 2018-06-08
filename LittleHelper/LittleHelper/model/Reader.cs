using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImgReader;
using Nnet;

namespace LittleHelper.model
{
    class Reader
    {
        private static ImgReader.ImgReader reader = new ImgReader.ImgReader();
        private static NeuroNet net = NeuroNet.LoadFromFile("nnet.nnw");

        public static int GetData(ReadData data)
        {
            List<byte[]> array = reader.TranslateFromScreen(data.Area, data.Sensitivity, data.FSize);
            int result = 0;
            foreach (var item in array)
            {
                result *= 10;
                result += net.TranslateDigit(item);
            }
            return result;
        }
    }
}

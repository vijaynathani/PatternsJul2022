using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace OOADandPatterns.Patterns.Benchmark
{
    public class DeepCopy
    {
        List<C1> obs;

        public void Initialize() => obs = C1.GetLongList();

        public List<C1> SerializeDeserializeAllObjects()
        {
            var ms = new MemoryStream();
            SerializeList(ms);
            return DeserializeFromMemory(ms);
        }

        private List<C1> DeserializeFromMemory(MemoryStream ms)
        {
            ms.Seek(0, SeekOrigin.Begin);
            return (List<C1>) new BinaryFormatter().Deserialize(ms);
        }

        private void SerializeList(MemoryStream ms) => new BinaryFormatter().Serialize(ms, obs);


        public void DeepCopyWarmup()
        {
            Console.WriteLine("Serialization/Deserialization warmup");
            for (var i = 0; i < BenchmarkMain.WarmUp; ++i)
                Initialize();
            SerializeDeserializeAllObjects();
            Console.WriteLine("Serialization/Deserialization warmup completed");

        }
        public void DeepCopyTask()
        {
            var t = BenchmarkMain.AverageMillisecondsTakenForMultipleRuns(() => SerializeDeserializeAllObjects(), "Serialization");
            Console.WriteLine("Average time per run by Serialization/Deserialization copy is {0} milliseconds", t);
        }

    }
}

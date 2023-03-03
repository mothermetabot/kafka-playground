using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.kafka.client
{
    internal interface IProcessor
    {
        void Start();
    }
}

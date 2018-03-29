// 2018032923:10Class1.csРоман Евсеев2018032923:10

using System;
using System.IO;

namespace ExpressionTree2.TestCalsses
{
    public class ClassA
    {
        public string Name { get; set; } = "classA_name";
        public int DataSize { get; set; } = 12;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public Stream Stream { get; set; } = new FileStream("somefile.txt", FileMode.Create);
    }
}
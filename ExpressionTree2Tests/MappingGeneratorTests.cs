using ExpressionTree2;
using ExpressionTree2.TestCalsses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionTree2Tests
{
    [TestClass]
    public class MappingGeneratorTests
    {
        [TestMethod]
        public void GenerateTest()
        {
            var dest = new MappingGenerator().Generate<ClassA, ClassB>();
            var classA = new ClassA();
            var mappedClassB = dest(classA);

            Assert.AreEqual(mappedClassB.Name, classA.Name);
            Assert.AreEqual(mappedClassB.DateTime, classA.DateTime);
            Assert.AreEqual(mappedClassB.DataSize, classA.DataSize);
        }
    }
}
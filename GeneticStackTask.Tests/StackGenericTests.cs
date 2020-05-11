using System;
using GenericStackTask;
using NUnit.Framework;

namespace GeneticStackTask.Tests
{
    [TestFixture(new[] {12, 3, 4, Int32.MaxValue, Int32.MinValue, -12, 45, 12}, 67, 8,
        TypeArgs = new Type[] {typeof(int)})]
    [TestFixture(new[] {0.362, 3.0987, -198.4, -1008245.78, 9012.0001}, 0.8911, 5,
        TypeArgs = new Type[] {typeof(double)})]
    [TestFixture(new[] {"12", "Zero", "Test", "Hello"}, "Hello, world!", 4, TypeArgs = new Type[] {typeof(string)})]
    [TestFixture(new[] {"12", "Zero", null, "Test", "Hello", null}, null, 6, TypeArgs = new Type[] {typeof(string)})]
    [TestFixture(new[] {'a', '\n', '4', '5'}, '\t', 4, TypeArgs = new Type[] {typeof(char)})]
    [TestFixture(new[] {true, false, true, true}, false, 4, TypeArgs = new Type[] {typeof(bool)})]
    public class StackGenericTests<T>
    {
        private readonly Stack<T> _stack;
        private readonly T[] _array;
        private readonly T _value;
        private readonly int _initCount;
        private const int someValue = 3;

        public StackGenericTests(T[] source, T value, int count)
        {
            _stack = new Stack<T>(source);
            _value = value;
            _initCount = count;
            _array = source;
        }

        [Test]
        [Order(0)]
        public void Ctor_BasedOnEnumerableSource()
        {
            Assert.That(_stack.Count == _initCount);
        }

        [Test]
        [Order(1)]
        public void Iterator_Test()
        {
            int i = _initCount;
            foreach (var item in _stack)
            {
                Assert.AreEqual(item, _array[--i]);
            }
        }

        [Test]
        [Order(2)]
        public void ToArray_Test()
        {
            T[] copy = _stack.ToArray();
            Assert.Multiple((() =>
            {
                CollectionAssert.AreEqual(_array, copy);
                Assert.AreNotSame(_array, copy);
            }));
        }

        [Test]
        [Order(3)]
        public void Push_OneElement()
        {
            int count = _stack.Count;
            _stack.Push(_value);
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(_stack, _value);
                Assert.That(_stack.Count == count + 1);
            });
        }

        [Test]
        [Order(4)]
        public void Contains_Test()
        {
            Assert.IsTrue(_stack.Contains(_value));
        }

        [Test]
        [Order(4)]
        public void Peek_Test()
        {
            int count = _stack.Count;
            T actual = _stack.Peek();
            Assert.Multiple(() =>
            {
                Assert.That(_stack.Count == count);
                Assert.AreEqual(_value, actual);
            });
        }

        [Test]
        [Order(5)]
        public void Push_SomeElement()
        {
            int count = _stack.Count;
            for (int i = 1; i <= someValue; i++)
            {
                _stack.Push(_value);
            }

            Assert.That(_stack.Count == count + someValue);
        }

        [Test]
        [Order(6)]
        public void Pop_SomeElement()
        {
            int count = _stack.Count;
            for (int i = 1; i <= someValue; i++)
            {
                T item = _stack.Pop();
            }

            Assert.That(_stack.Count == count - someValue);
        }

        [Test]
        [Order(7)]
        public void Iterator_PopFromStack_Throw_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var item in _stack)
                {
                    T t = _stack.Pop();
                }
            }, "Stack cannot be changed during iteration.");
        }

        [Test]
        [Order(8)]
        public void Iterator_PushIntoStack_Throw_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var item in _stack)
                {
                    _stack.Push(_value);
                }
            }, "Stack cannot be changed during iteration.");
        }

        [Test]
        [Order(9)]
        public void Clear_Test()
        {
            _stack.Clear();
            Assert.That(_stack.Count == 0);
        }

        [Test]
        [Order(10)]
        public void Pop_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Pop(), "Invalid operation pop, stack is empty.");
        }
    }
}
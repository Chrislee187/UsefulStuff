using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Combinatorics.Collections;
using NUnit.Framework;
using Shouldly;

namespace UsefullStuff.UnitTests
{
    [TestFixture]
    public class PermutationsTests
    {
        [Test]
        public void ShouldHaveTwoPermutations()
        {
            var o1 = new TestObject("A");
            var o2 = new TestObject("B");
            var o3 = new TestObject("C");
            var list = new List<TestObject>() {o1, o2, o3};

            var perms = new Permutations<TestObject>(list);

            ShowPerm(perms);
        }

        void ShowPerm(IEnumerable<IList<TestObject>> perm)
        {
            foreach (var p in perm)
            {
                foreach (var to in p)
                {
                    Console.Write($"{to.Id}");
                }
                Console.WriteLine();
            }
        }
    }

    class TestObject : IComparable<TestObject>
    {
        public string Id;

        public TestObject(string id)
        {
            Id =id;
        }

        public override string ToString()
        {
            return Id;
        }

        protected bool Equals(TestObject other)
        {
            return Id == other.Id;
        }

        public int CompareTo(TestObject other) => Id.CompareTo(other.Id);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TestObject) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}
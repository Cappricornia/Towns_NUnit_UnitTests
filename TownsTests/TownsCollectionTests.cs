using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TownsTests
{
    public class TownsCollectionTests
    {
        private TownsCollection townCollectionSingle;
        private TownsCollection townCollectionMultiple;



        [SetUp] 
        public void SetUp() 
        {
            this.townCollectionSingle = new TownsCollection("London");   
            this.townCollectionMultiple = new TownsCollection("London, Paris"); 
        }


        [Test]
        public void Test_constructor_create_empty_town_collection()
        {
            var emptyTownCollection = new TownsCollection();
            Assert.That(emptyTownCollection.ToString, Is.Empty);
            Assert.That(emptyTownCollection.Towns.Count, Is.EqualTo(0));

        }


        [Test]
        public void Test_constructor_create_single_town_collection()
        {
            Assert.That(this.townCollectionSingle.ToString, Is.EqualTo("London"));
            Assert.That(this.townCollectionSingle.Towns.Count, Is.EqualTo(1));

        }
        [Test]
        public void Test_constructor_create_two_towns_collection()
        {
            Assert.That(this.townCollectionMultiple.ToString, Is.EqualTo("London, Paris"));
            Assert.That(this.townCollectionMultiple.Towns.Count, Is.EqualTo(2));

        }

        [Test]
        public void Test_add_empty_string_to_the_collection()
        {
            bool result = this.townCollectionMultiple.Add("");  

            Assert.IsFalse(result);
            Assert.That(this.townCollectionMultiple.Towns.Count, Is.EqualTo(2));
            Assert.That(this.townCollectionMultiple.ToString, Is.EqualTo("London, Paris"));

        }

        [Test]
        public void Test_add_one_town_to_the_collection()
        {
           
            bool result = this.townCollectionMultiple.Add("New York");

            Assert.IsTrue(result);
            Assert.That(this.townCollectionMultiple.Towns.Count, Is.EqualTo(3));
            Assert.That(this.townCollectionMultiple.ToString, Is.EqualTo("London, Paris, New York"));

        }

        [Test]
        public void Test_add_duplicate_town_to_the_collection()
        {

            this.townCollectionMultiple.Add("London");

            Assert.That(this.townCollectionMultiple.Towns.Count, Is.EqualTo(2));
            Assert.That(this.townCollectionMultiple.ToString, Is.EqualTo("London, Paris"));

        }

        [Test]
        public void Test_remove_town_at_validIndex()
        {
            this.townCollectionMultiple.Towns.RemoveAt(1);

            Assert.That(this.townCollectionMultiple.Towns.Count, Is.EqualTo(1));
            Assert.That(this.townCollectionMultiple.ToString, Is.EqualTo("London"));

        }

        [Test]
        public void Test_remove_town_at_invalidIndex()
        {
            Assert.That(() => this.townCollectionMultiple.RemoveAt(5), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_reverse_collection_with_two_towns()
        {
            this.townCollectionMultiple.Reverse();
            
            Assert.That(this.townCollectionMultiple.Towns.Count, Is.EqualTo(2));
            Assert.That(this.townCollectionMultiple.ToString, Is.EqualTo("Paris, London"));
        }

        [Test]
        public void Test_reverse_one_town_in_the_collection_throws_exception()
        {
            var towns = new TownsCollection("London");
            Assert.That(() => towns.Reverse(), Throws.InstanceOf<InvalidOperationException>());
        }


        [Test]  
        public void Test_reverse_null_collection()
        {
            var townsCollection = new TownsCollection();
            townsCollection.Towns = null;

            Assert.That(() => townsCollection.Reverse(), Throws.InstanceOf<ArgumentNullException>());
        }

    }
}

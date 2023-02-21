using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towns;

namespace TownsTests
{
    public class TownsProcessorTests
    {

        [Test]
        public void Test_execute_invalid_command()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var actual = townProcessor.ExecuteCommand("InvalidCommand");

            //Assert
            Assert.That(actual, Is.EqualTo("Invalid command: InvalidCommand"));
        }

        [Test]
        public void Test_execute_CREATE_command()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var command = "CREATE London, Paris, New York";
            var actual = townProcessor.ExecuteCommand(command);
            

            //Assert
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(3)); 
            Assert.That(actual, Is.EqualTo("Successfully created collection of towns."));
        }

        [Test]
        public void Test_execute_PRINT_command()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var command = "CREATE London, Paris, New York";
            townProcessor.ExecuteCommand(command);
            var printCommand = "PRINT";
            var actual = townProcessor.ExecuteCommand(printCommand);

            //Assert
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(3));
            Assert.That(actual, Is.EqualTo("Towns: London, Paris, New York"));
        }


        [Test]
        public void Test_execute_ADD_command_validData()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var command = "CREATE London, Paris";
            townProcessor.ExecuteCommand(command);
            var addCommand = "ADD New York";
           
            var actual = townProcessor.ExecuteCommand(addCommand);

            //Assert
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(3));
            Assert.That(actual, Is.EqualTo("Successfully added: New York"));
        }


        [Test]
        public void Test_execute_ADD_command_invalidData()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var command = "CREATE London, Paris";
            townProcessor.ExecuteCommand(command);
            var addCommand = "ADD";

            var actual = townProcessor.ExecuteCommand(addCommand);

            //Assert
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
            Assert.That(actual, Is.EqualTo("Cannot add: "));
        }


        [Test]
        public void Test_execute_ADD_command_existingTown()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var command = "CREATE London, Paris";
            townProcessor.ExecuteCommand(command);
            var addCommand = "ADD London";

            var actual = townProcessor.ExecuteCommand(addCommand);

            //Assert
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
            Assert.That(actual, Is.EqualTo("Cannot add: London"));
        }

        [Test]
        public void Test_execute_REMOVE_command_invalidData()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var command = "CREATE London, Paris";
            townProcessor.ExecuteCommand(command);
            var removeCommand = "REMOVE 5";

            var actual = townProcessor.ExecuteCommand(removeCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Invalid operation.")); 
        }

        [Test]
        public void Test_execute_REMOVE_command_validData()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var command = "CREATE London, Paris";
            townProcessor.ExecuteCommand(command);
            var removeCommand = "REMOVE 0";
            var actual = townProcessor.ExecuteCommand(removeCommand);
            
            //Assert
            Assert.That(actual, Is.EqualTo("Successfully removed from index: 0"));
        }

        [Test]
        public void Test_execute_REVERSE_command_validData()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var command = "CREATE London, Paris";
            townProcessor.ExecuteCommand(command);
            var reverseCommand = "REVERSE";
            var actual = townProcessor.ExecuteCommand(reverseCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Collection of towns reversed."));
        }

        [Test]
        public void Test_execute_REVERSE_command_invalidData()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var command = "CREATE London";
            townProcessor.ExecuteCommand(command);
            var reverseCommand = "REVERSE";
            var actual = townProcessor.ExecuteCommand(reverseCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Cannot reverse a collection of towns with less than 2 items."));
        }

    }
}

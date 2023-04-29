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
        public void Test_CreateTowns_verifyCorrectResult()
        {
            var townProcessor = new TownsProcessor();
            var createCommand = "CREATE Dolno Uino, Buichinovchi, Trun";

            townProcessor.ExecuteCommand(createCommand);
            var printInput = "PRINT";

            var actualResult = townProcessor.ExecuteCommand(printInput);

            Assert.That(actualResult, Is.EqualTo("Towns: Dolno Uino, Buichinovchi, Trun"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test_AddTown_verifyAddedCorrect()
        {
            var townProcessor = new TownsProcessor();
            var createCommand = "CREATE Dolno Uino, Buichinovchi, Trun";

            townProcessor.ExecuteCommand(createCommand);
            var addTown = "ADD Bagdad";
            //var printInput = "PRINT";

            var actualResult = townProcessor.ExecuteCommand(addTown);


            Assert.That(actualResult, Is.EqualTo("Successfully added: Bagdad"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(4));
        }

        [Test]
        public void Test_RemoveAtTown_verifyRemovedCorrect()
        {
            var townProcessor = new TownsProcessor();
            var createCommand = "CREATE Dolno Uino, Buichinovchi, Trun";

            townProcessor.ExecuteCommand(createCommand);
            var removeTown = "REMOVE 1";

            var actualResult = townProcessor.ExecuteCommand(removeTown);
            //var printInput = "PRINT";


            Assert.That(actualResult, Is.EqualTo("Successfully removed from index: 1"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        
        [Test]
        public void Test_ReverseCollection_verifySuccessfulReversed()
        {
            var townProcessor = new TownsProcessor();
            var createCommand = "CREATE Dolno Uino, Buichinovchi, Trun";

            townProcessor.ExecuteCommand(createCommand);
            var reverseTowns = "REVERSE";

            var actualResult = townProcessor.ExecuteCommand(reverseTowns);

            Assert.That(actualResult, Is.EqualTo("Collection of towns reversed."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test_ReverseCollectionIncorrectData_returnsInformationMessage()
        {
            var townProcessor = new TownsProcessor();
            var createCommand = "CREATE Sofia";

            townProcessor.ExecuteCommand(createCommand);
            var reverseTowns = "REVERSE";

           var actualResult = townProcessor.ExecuteCommand(reverseTowns);
                        
           //Assert.That(() => townProcessor.ExecuteCommand("REVERSE"), Throws.InstanceOf<InvalidOperationException>());
           Assert.That(actualResult, Is.EqualTo("Cannot reverse a collection of towns with less than 2 items."));
        }
    }
}

using ConsoleApplication;
using Moq;
using NUnit.Framework;
using System;

namespace StringCalculator.ConsoleApplication.Tests
{
    public class ConsoleApplicationTests
    {
        class ConsoleWorkerTests
        {
            private readonly ConsoleWorker worker;
            private readonly Mock<ConsoleWrapper> mockWrapper;
            private readonly Mock<StringCalculator> mockCalculator;

            public ConsoleWorkerTests()
            {
                mockWrapper = new Mock<ConsoleWrapper>();
                mockCalculator = new Mock<StringCalculator>();
                worker = new ConsoleWorker(mockWrapper.Object, mockCalculator.Object);
            }

            [Test, Timeout(1000)]
            public void Run_InputEmptyString_ShouldDisplayInitialMessageOnceAndNewerDisplayContinueMessage()
            {
                mockWrapper.Setup(x => x.ReadLine())
                    .Returns(string.Empty);

                worker.Run();

                mockWrapper.Verify(mock => mock.ReadLine(), Times.Once);
                mockWrapper.Verify(mock => mock.ShowMessage("Enter comma separated numbers (enter to exit):"), Times.Once);
                mockWrapper.Verify(mock => mock.ShowMessage("you can enter other numbers (enter to exit)?"), Times.Never);
            }

            [Test, Timeout(1000)]
            public void Run_InputMultipleStrings_ReturnMoreThanOneResult()
            {
                mockWrapper.SetupSequence(x => x.ReadLine())
                    .Returns("1")
                    .Returns("2")
                    .Returns(string.Empty);

                mockCalculator.Setup(x => x.Add(It.IsAny<string>()))
                    .Returns(1);

                worker.Run();

                mockWrapper.Verify(mock => mock.ShowMessage("Result: 1\n"), Times.AtLeast(2));
            }

            [Test, Timeout(1000)]
            public void Run_InputStringsWithNegativeNumbers_ReturnException()
            {
                mockWrapper.SetupSequence(x => x.ReadLine())
                    .Returns("1,-2")
                    .Returns(string.Empty);

                mockCalculator.Setup(x => x.Add("1,-2"))
                    .Throws(new ArgumentException("Negatives are not allowed: -2"));

                worker.Run();

                mockWrapper.Verify(x => x.ShowMessage("Negatives are not allowed: -2"), Times.Once);
            }

            [Test, Timeout(1000)]
            public void Run_InputMultipleStrings_ShouldReturnMessageMoreThanOnceTime()
            {
                mockWrapper.SetupSequence(x => x.ReadLine())
                    .Returns("1")
                    .Returns("3,4")
                    .Returns(string.Empty);

                worker.Run();

                mockWrapper.Verify(mock => mock.ShowMessage("you can enter other numbers (enter to exit)?"), Times.AtLeast(2));
            }

        }
    }
}

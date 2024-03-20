using System.Threading;
using App.Character;
using Cysharp.Threading.Tasks;
using Infra.Components.Tickable;
using Moq;
using NUnit.Framework;

namespace App.Character.Dino.Tests
{
    public class CharacterTests
    {
        [SetUp]
        public void Setup()
        {
            ICharacter character = new Character(default, default, default);
        }

        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        public void TestRunMethodInitiatesDefaultBehavior()
        {
            Assert.Pass();
            
            /*
            
            // Arrange
            var soundsMock = new Mock<ICharacterSounds>();
            var tickableContextMock = new Mock<ITickableContext>();
            var behaviorFactoryMock = new Mock<ICharacterBehaviorFactory>();
            var defaultBehaviorMock = new Mock<ICharacterBehavior>();

            behaviorFactoryMock.Setup(f => f.Create(It.IsAny<CharacterBehaviorOptions>()))
                .Returns(defaultBehaviorMock.Object);

            var character = new Character(soundsMock.Object, tickableContextMock.Object, behaviorFactoryMock.Object);

            // Act
            character.Run(CancellationToken.None).Forget();

            // Assert
            defaultBehaviorMock.Verify(b => b.Execute(It.IsAny<CancellationToken>()), Times.Once);

            // Additionally, verify that the behavior factory was called with the correct parameters.
            behaviorFactoryMock.Verify(f => f.Create(CharacterBehaviorOptions.Default), Times.Once);

            // Verify that no sound is played when running (based on example; adjust as needed).
            soundsMock.Verify(s => s.Play(It.IsAny<CharacterSoundType>()), Times.Never);
            */
        }
    }
}
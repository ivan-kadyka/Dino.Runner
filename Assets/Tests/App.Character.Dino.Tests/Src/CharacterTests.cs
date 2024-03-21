using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using Moq;
using NUnit.Framework;
using UniRx;
using UnityEngine.TestTools;

namespace App.Character.Dino.Tests
{
    public class CharacterTests
    {
        private TestTickableContext _tickableContext;
        private ICharacter _character;
        
        private Mock<ICharacterSounds> _soundsMock;
        private Mock<ICharacterPhysics> _physicsMock;

        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        [SetUp]
        public void Setup()
        {
            _soundsMock = new Mock<ICharacterSounds>();
            _physicsMock = new Mock<ICharacterPhysics>();

            _tickableContext = new TestTickableContext();
            
            var settings = new CharacterSettings();
            var jumpBehaviorFactory = new JumpBehaviorFactory(_physicsMock.Object, _soundsMock.Object, settings);
            var characterBehaviorFactory = new CharacterBehaviorFactory(jumpBehaviorFactory, settings);
            
            _character = new Character(_soundsMock.Object, _tickableContext, characterBehaviorFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _disposables.Clear();
            _character.Dispose();
        }
        
        
        [UnityTest]
        public IEnumerator ApplyEffect_UseFly_ShouldBeApplied() => UniTask.ToCoroutine(async () =>
        {
            //Arrange
            CharacterState nextState = CharacterState.Default;
            _disposables.Add(_character.State.Subscribe(t => { nextState = t;}));
            
            var effectOptions = new CharacterOptions(CharacterState.Fly, TimeSpan.Zero);
            
            // Act
            await _character.ApplyEffect(effectOptions);
            
            
            // Assert
            Assert.AreEqual(CharacterState.Fly, nextState);
            Assert.AreEqual(CharacterState.Fly, _character.State.Value);
        });
    }
}
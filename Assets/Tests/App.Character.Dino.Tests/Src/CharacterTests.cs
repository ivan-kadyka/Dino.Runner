using System;
using System.Collections;
using App.Character.Dino.GameContext;
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
        private ICharacterBehaviorFactory _characterBehaviorFactory;

        [SetUp]
        public void Setup()
        {
            _soundsMock = new Mock<ICharacterSounds>();
            _physicsMock = new Mock<ICharacterPhysics>();

            _tickableContext = new TestTickableContext();
            
            var settings = new CharacterSettings();
            var gameContext = new StubGameContext();
            
            var jumpBehaviorFactory = new JumpBehaviorFactory(_physicsMock.Object, _soundsMock.Object, settings);
             _characterBehaviorFactory = new CharacterBehaviorFactory(jumpBehaviorFactory, settings, gameContext);
            
            _character = new Character(_soundsMock.Object, _tickableContext, _characterBehaviorFactory);
            _disposables.Add(_character);
        }

        [TearDown]
        public void TearDown()
        {
            _disposables.Clear();
        }
        
        
        [UnityTest]
        public IEnumerator ApplyEffect_UseFly_ShouldBeApplied() => UniTask.ToCoroutine(async () =>
        {
            //Arrange
            CharacterState nextState = CharacterState.Default;
            _disposables.Add(_character.State.Subscribe(t => { nextState = t;}));
            
            var options = new EffectStartOptions(CharacterState.Fly, TimeSpan.Zero);
            var newBehavior = _characterBehaviorFactory.Create(options.Type);
            
            // Act
            await _character.ApplyEffectBehavior(newBehavior, options);
            
            
            // Assert
            Assert.AreEqual(CharacterState.Fly, nextState);
            Assert.AreEqual(CharacterState.Fly, _character.State.Value);
        });
    }
}
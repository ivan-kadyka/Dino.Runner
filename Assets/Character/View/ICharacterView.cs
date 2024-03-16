using Character.Model;
using Controllers;

namespace Character.View
{
    public interface ICharacterView : IView
    {
        void Initialize(ICharacter character);
    }
}